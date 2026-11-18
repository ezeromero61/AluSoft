using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AluSoft.UI
{
    internal static class Navegacion
    {
        internal static bool Preguntar(string pregunta)
        {
            return MessageBox.Show(pregunta, "AluSoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        internal static void Abrir(Form actual, Form siguiente)
        {
            Panel panel = actual.Parent as Panel;
            if (panel == null)
            {
                siguiente.Show();
                return;
            }

            AjusteFormularios.PrepararParaPanel(siguiente);
            siguiente.TopLevel = false;
            siguiente.Dock = DockStyle.Fill;
            siguiente.FormBorderStyle = FormBorderStyle.None;

            panel.Controls.Remove(actual);
            panel.Controls.Add(siguiente);
            panel.Tag = siguiente;
            siguiente.Show();
            panel.BeginInvoke(new Action(actual.Dispose));
        }

        internal static void Seleccionar(ComboBox combo, int id)
        {
            if (id <= 0) return;
            combo.SelectedValue = id;
            if (Equals(combo.SelectedValue, id)) return;
            // Si el combo todavía no terminó de enlazarse, se reintenta cuando ya está en pantalla.
            Action reintentar = delegate { if (!Equals(combo.SelectedValue, id)) combo.SelectedValue = id; };
            if (combo.IsHandleCreated) combo.BeginInvoke(reintentar);
            else
            {
                EventHandler h = null;
                h = delegate { combo.HandleCreated -= h; combo.BeginInvoke(reintentar); };
                combo.HandleCreated += h;
            }
        }
    }

    // Recuerda si el usuario maximizó una ventana y aplica lo mismo a las demás.
    internal static class VentanaGlobal
    {
        private static FormWindowState? estado;
        private static readonly HashSet<Form> registradas = new HashSet<Form>();

        internal static void Iniciar()
        {
            Application.Idle += delegate { RegistrarNuevas(); CerrarSiNoQuedanVentanas(); };
        }

        // [CORREGIDO] El inicio de sesión se oculta al entrar al menú y nunca se cerraba: al cerrar el
        // menú con la X el programa quedaba abierto en segundo plano (y Visual Studio no podía volver
        // a compilar porque el .exe seguía en uso). Si después de cerrar una ventana no queda ninguna
        // visible, se cierra la aplicación.
        private static bool revisarCierre;

        private static void CerrarSiNoQuedanVentanas()
        {
            if (!revisarCierre) return;
            revisarCierre = false;
            if (!Application.OpenForms.Cast<Form>().Any(f => f.Visible))
                Application.Exit();
        }

        private static bool Aplica(Form f)
        {
            return f.TopLevel && f.MaximizeBox &&
                   (f.FormBorderStyle == FormBorderStyle.Sizable || f.FormBorderStyle == FormBorderStyle.SizableToolWindow);
        }

        private static void RegistrarNuevas()
        {
            foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
            {
                if (registradas.Contains(f)) continue;
                registradas.Add(f);
                f.FormClosed += delegate { registradas.Remove(f); revisarCierre = true; };
                AmpliarDesplegables(f);
                if (!Aplica(f)) continue;

                // Solo se toma en cuenta lo que el usuario cambia a mano (maximizar / restaurar).
                Aplicar(f);

                f.Resize += delegate
                {
                    if (f.Visible && Aplica(f) && f.WindowState != FormWindowState.Minimized)
                        estado = f.WindowState;
                };
                f.VisibleChanged += delegate { if (f.Visible) Aplicar(f); };
            }
        }

        // Los desplegables se abren tan anchos como su texto más largo, para que se lean completos.
        private static readonly HashSet<Control> revisados = new HashSet<Control>();

        private static void AmpliarDesplegables(Control c)
        {
            if (!revisados.Add(c)) return;
            c.Disposed += delegate { revisados.Remove(c); };
            ComboBox combo = c as ComboBox;
            if (combo != null) combo.DropDown += AjustarAnchoDesplegable;
            c.ControlAdded += (s, e) => AmpliarDesplegables(e.Control);
            foreach (Control hijo in c.Controls) AmpliarDesplegables(hijo);
        }

        private static void AjustarAnchoDesplegable(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            int ancho = combo.Width;
            foreach (object item in combo.Items)
            {
                int texto = TextRenderer.MeasureText(combo.GetItemText(item), combo.Font).Width;
                ancho = Math.Max(ancho, texto + SystemInformation.VerticalScrollBarWidth + 10);
            }
            int maximo = Screen.FromControl(combo).WorkingArea.Width - 20;
            combo.DropDownWidth = Math.Min(ancho, maximo);
        }

        private static void Aplicar(Form f)
        {
            if (estado == null || !Aplica(f)) return;
            if (f.WindowState != estado.Value) f.WindowState = estado.Value;
        }
    }

    // Estado de producción: solo se cargan fecha de inicio y de fin; la de fin se habilita
    // cuando la producción se da por terminada.
    internal static class FechasEstado
    {
        internal static bool Termino(string estado)
        {
            return estado == "Terminado" || estado == "Entregado";
        }

        internal static void Configurar(TextBox txbEstado, DateTimePicker fechaFin, params Control[] ocultar)
        {
            foreach (Control c in ocultar) c.Visible = false;
            EventHandler actualizar = delegate
            {
                bool termino = Termino(txbEstado.Text);
                if (termino && !fechaFin.Enabled) fechaFin.Value = DateTime.Today;
                fechaFin.Enabled = termino;
            };
            txbEstado.TextChanged += actualizar;
            actualizar(null, EventArgs.Empty);
        }
    }

    // Pedido de cliente: las fechas de entrega (estimada y real) arrancan una semana después de
    // la fecha del pedido y se pueden modificar.
    internal static class FechasPedido
    {
        internal const int DiasEntrega = 7;

        internal static void Vincular(DateTimePicker pedido, DateTimePicker estimada, DateTimePicker real)
        {
            pedido.ValueChanged += delegate { Ajustar(pedido, estimada, real); };
            Ajustar(pedido, estimada, real);
        }

        internal static void Ajustar(DateTimePicker pedido, DateTimePicker estimada, DateTimePicker real)
        {
            DateTime entrega = pedido.Value.Date.AddDays(DiasEntrega);
            estimada.Value = entrega;
            real.Value = entrega;
        }

        // Al mostrar un pedido guardado: si una fecha no es posterior al pedido, se propone pedido + 7.
        internal static void Mostrar(DateTimePicker pedido, DateTimePicker estimada, DateTimePicker real,
                                     DateTime fechaPedido, DateTime fechaEstimada, DateTime fechaReal)
        {
            pedido.Value = fechaPedido.Year > 1900 ? fechaPedido : DateTime.Today;
            DateTime propuesta = pedido.Value.Date.AddDays(DiasEntrega);
            estimada.Value = fechaEstimada.Date > pedido.Value.Date ? fechaEstimada : propuesta;
            real.Value = fechaReal.Date > pedido.Value.Date ? fechaReal : propuesta;
        }
    }

    internal static class EstadosCombo
    {
        internal static ComboBox Reemplazar(TextBox texto, string[] opciones, string inicial = null)
        {
            ComboBox combo = new ComboBox();
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Location = texto.Location;
            combo.Size = new System.Drawing.Size(texto.Width, combo.Height);
            combo.Font = texto.Font;
            combo.Anchor = texto.Anchor;
            combo.TabIndex = texto.TabIndex;
            combo.Items.AddRange(opciones);

            Control padre = texto.Parent;
            TableLayoutPanel tabla = padre as TableLayoutPanel;
            if (tabla != null)
            {
                TableLayoutPanelCellPosition celda = tabla.GetCellPosition(texto);
                combo.Dock = texto.Dock;
                tabla.Controls.Remove(texto);
                tabla.Controls.Add(combo, celda.Column, celda.Row);
            }
            else
            {
                padre.Controls.Add(combo);
            }
            texto.Visible = false;

            bool sincronizando = false;
            combo.SelectedIndexChanged += delegate
            {
                if (sincronizando) return;
                sincronizando = true;
                texto.Text = combo.SelectedItem == null ? "" : combo.SelectedItem.ToString();
                sincronizando = false;
            };
            texto.TextChanged += delegate
            {
                if (sincronizando) return;
                sincronizando = true;
                string valor = texto.Text.Trim();
                if (valor.Length == 0)
                    combo.SelectedIndex = -1;
                else
                {
                    int i = combo.FindStringExact(valor);
                    if (i < 0) i = combo.Items.Add(valor);
                    combo.SelectedIndex = i;
                }
                sincronizando = false;
            };

            if (!string.IsNullOrEmpty(inicial))
                texto.Text = inicial;
            return combo;
        }
    }

    internal class PanelRenglones
    {
        public readonly BindingList<BE.cls36_PresupuestoDetalle> Renglones = new BindingList<BE.cls36_PresupuestoDetalle>();
        public readonly DataGridView Grilla = new DataGridView();
        public readonly Button BtnAgregar = new Button();
        public readonly Button BtnQuitar = new Button();
        public event Action Cambio;
        private bool editable = true;

        // Versión al pie del formulario (alta de presupuesto).
        public PanelRenglones(Form form, Control relleno)
        {
            Panel panel = Construir();
            panel.Dock = DockStyle.Bottom;
            panel.Height = 160;
            panel.Padding = new Padding(8, 2, 8, 4);
            form.Controls.Add(panel);
            panel.BringToFront();
            relleno.BringToFront();
        }

        // Versión compacta debajo de otra grilla (gestión de presupuesto): ocupa la mitad inferior.
        public PanelRenglones(DataGridView arriba)
        {
            Panel panel = Construir();
            Control contenedor = arriba.Parent;
            contenedor.Controls.Add(panel);
            arriba.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            int margenSuperior = arriba.Top;
            EventHandler acomodar = delegate
            {
                int alto = contenedor.ClientSize.Height - margenSuperior - 8;
                if (alto < 120) return;
                arriba.Top = margenSuperior;
                arriba.Height = alto * 45 / 100;
                panel.SetBounds(arriba.Left, arriba.Bottom + 6, arriba.Width, contenedor.ClientSize.Height - arriba.Bottom - 12);
            };
            contenedor.Resize += acomodar;
            acomodar(null, EventArgs.Empty);
        }

        private Panel Construir()
        {
            Panel panel = new Panel();
            System.Drawing.Font chica = new System.Drawing.Font("Microsoft Sans Serif", 9F);

            FlowLayoutPanel barra = new FlowLayoutPanel();
            barra.Dock = DockStyle.Top;
            barra.Height = 32;
            barra.FlowDirection = FlowDirection.LeftToRight;
            barra.WrapContents = false;

            Label titulo = new Label();
            titulo.Text = "Productos del presupuesto";
            titulo.AutoSize = true;
            titulo.Margin = new Padding(0, 8, 12, 0);
            titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);

            BtnAgregar.Text = "+ Agregar";
            BtnAgregar.Font = chica;
            BtnAgregar.Size = new System.Drawing.Size(95, 28);
            BtnQuitar.Text = "− Quitar";
            BtnQuitar.Font = chica;
            BtnQuitar.Size = new System.Drawing.Size(95, 28);
            BtnQuitar.Click += delegate { QuitarSeleccionado(); };
            barra.Controls.Add(titulo);
            barra.Controls.Add(BtnAgregar);
            barra.Controls.Add(BtnQuitar);

            Grilla.Dock = DockStyle.Fill;
            Grilla.Font = chica;
            Grilla.ReadOnly = true;
            Grilla.AllowUserToAddRows = false;
            Grilla.AllowUserToDeleteRows = false;
            Grilla.RowHeadersVisible = false;
            Grilla.BackgroundColor = System.Drawing.SystemColors.Window;
            Grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grilla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grilla.RowTemplate.Height = 22;
            Grilla.DataBindingComplete += delegate { ConfigurarColumnas(); };
            Grilla.DataSourceChanged += delegate
            {
                if (Grilla.DataSource == null)
                    Grilla.BeginInvoke(new Action(delegate { Renglones.Clear(); Grilla.DataSource = Renglones; AvisarCambio(); }));
            };
            Grilla.DataSource = Renglones;

            panel.Controls.Add(Grilla);
            panel.Controls.Add(barra);
            return panel;
        }

        private void ConfigurarColumnas()
        {
            foreach (string oculta in new[] { "IdDetalle", "IdPresupuesto", "IdCatalogo", "IdStock" })
                if (Grilla.Columns.Contains(oculta)) Grilla.Columns[oculta].Visible = false;
            if (Grilla.Columns.Contains("PrecioUnitario")) Grilla.Columns["PrecioUnitario"].HeaderText = "Precio unit.";
            if (Grilla.Columns.Contains("Producto")) Grilla.Columns["Producto"].FillWeight = 220;
            foreach (string col in new[] { "Cantidad", "PrecioUnitario", "Subtotal" })
                if (Grilla.Columns.Contains(col))
                {
                    Grilla.Columns[col].FillWeight = 70;
                    Grilla.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            foreach (string col in new[] { "PrecioUnitario", "Subtotal" })
                if (Grilla.Columns.Contains(col)) Grilla.Columns[col].DefaultCellStyle.Format = "N0";
        }

        public bool Editable
        {
            get { return editable; }
            set { editable = value; BtnAgregar.Enabled = value; BtnQuitar.Enabled = value; }
        }

        public int Subtotal
        {
            get { return Renglones.Sum(r => r.Subtotal); }
        }

        // Texto corto para la columna Descripción del presupuesto (ya no se carga a mano).
        public string Resumen
        {
            get
            {
                if (Renglones.Count == 0) return "";
                BE.cls36_PresupuestoDetalle p = Renglones[0];
                string texto = Renglones.Count == 1 ? p.Cantidad + " x " + p.Producto
                                                    : p.Producto + " y " + (Renglones.Count - 1) + " producto(s) más";
                return texto.Length > 50 ? texto.Substring(0, 50) : texto;
            }
        }

        public void Agregar(int idCatalogo, string producto, int cantidad, int precio)
        {
            if (cantidad <= 0) throw new ArgumentException("La cantidad tiene que ser mayor a 0.");
            BE.cls36_PresupuestoDetalle existente = Renglones.FirstOrDefault(r => r.IdCatalogo == idCatalogo && r.PrecioUnitario == precio);
            if (existente != null)
            {
                existente.Cantidad += cantidad;
                Renglones.ResetBindings();
            }
            else
            {
                BE.cls36_PresupuestoDetalle d = new BE.cls36_PresupuestoDetalle();
                d.IdCatalogo = idCatalogo;
                d.Producto = producto;
                d.Cantidad = cantidad;
                d.PrecioUnitario = precio;
                Renglones.Add(d);
            }
            AvisarCambio();
        }

        public void Cargar(IEnumerable<BE.cls36_PresupuestoDetalle> lista)
        {
            Renglones.Clear();
            foreach (BE.cls36_PresupuestoDetalle d in lista) Renglones.Add(d);
            AvisarCambio();
        }

        private void QuitarSeleccionado()
        {
            BE.cls36_PresupuestoDetalle d = Grilla.CurrentRow == null ? null : Grilla.CurrentRow.DataBoundItem as BE.cls36_PresupuestoDetalle;
            if (d == null) return;
            Renglones.Remove(d);
            AvisarCambio();
        }

        private void AvisarCambio()
        {
            if (Cambio != null) Cambio();
        }
    }

    internal static class CadenaVenta
    {
        internal static bool PuedeFacturarPedido(int idPedido, out string motivo)
        {
            motivo = null;
            if (idPedido <= 0)
            {
                motivo = "Seleccioná un pedido válido.";
                return false;
            }

            BE.cls09_Factura yaFacturado = new BLL.Factura().ListarCatalogo().FirstOrDefault(f => f.IdPedido == idPedido);
            if (yaFacturado != null)
            {
                motivo = "El pedido ya tiene la factura N° " + yaFacturado.Idfactura + ".";
                return false;
            }

            List<BE.cls14_OrdenProduccion> ordenes = new BLL.OrdenProduccion()
                .ListarCatalogo2()
                .Where(o => o.IdPedido == idPedido)
                .ToList();
            if (ordenes.Count == 0)
            {
                motivo = "El pedido todavía no tiene órdenes de producción asociadas.";
                return false;
            }

            // Se factura cuando TODAS las órdenes del pedido están terminadas (o salieron desde stock).
            Dictionary<int, string> estadoActual;
            List<BE.cls14_OrdenProduccion> sinTerminar = OrdenesSinTerminar(idPedido, out estadoActual);
            if (sinTerminar.Count > 0)
            {
                motivo = "Se factura cuando todas las órdenes del pedido están terminadas. " +
                    (sinTerminar.Count == 1 ? "Falta terminar esta orden:\n" : "Faltan terminar estas " + sinTerminar.Count + " órdenes:\n")
                    + Describir(sinTerminar, estadoActual)
                    + "\n\nCargale el estado «Terminado» en Producción → Estados de producción.";
                return false;
            }
            return true;
        }

        internal static bool SinIniciar(string estado)
        {
            return string.IsNullOrWhiteSpace(estado) || estado == "Sin estado" || estado == "Pendiente";
        }

        // Órdenes del pedido cuyo último estado no es Terminado ni Entregado.
        internal static List<BE.cls14_OrdenProduccion> OrdenesSinTerminar(int idPedido, out Dictionary<int, string> estadoActual)
        {
            estadoActual = new Dictionary<int, string>();
            List<BE.cls14_OrdenProduccion> ordenes = new BLL.OrdenProduccion().ListarCatalogo2()
                .Where(o => o.IdPedido == idPedido).OrderBy(o => o.Idordenproduccion).ToList();
            List<BE.cls15_Estado> estados = new BLL.Estado().ListarCatalogo();
            List<BE.cls14_OrdenProduccion> pendientes = new List<BE.cls14_OrdenProduccion>();
            foreach (BE.cls14_OrdenProduccion orden in ordenes)
            {
                BE.cls15_Estado ultimo = estados
                    .Where(e => e.Idordenproduccion == orden.Idordenproduccion)
                    .OrderByDescending(e => e.Idestado)
                    .FirstOrDefault();
                string estado = ultimo == null ? "Sin estado" : (ultimo.Estado ?? "").Trim();
                estadoActual[orden.Idordenproduccion] = estado;
                if (!FechasEstado.Termino(estado)) pendientes.Add(orden);
            }
            return pendientes;
        }

        private static string Describir(List<BE.cls14_OrdenProduccion> ordenes, Dictionary<int, string> estadoActual)
        {
            return string.Join("\n", ordenes.Select(o => "  • Orden N° " + o.Idordenproduccion + " - " +
                (string.IsNullOrWhiteSpace(o.Observaciones) ? "" : o.Observaciones + " - ") + estadoActual[o.Idordenproduccion]));
        }

        // Después de registrar producción o un estado: lleva a la siguiente orden pendiente del
        // pedido, o a la factura si ya están todas terminadas.
        internal static void SiguientePaso(Form actual, int idPedido, int idOrdenActual = 0)
        {
            if (idPedido <= 0) return;
            Dictionary<int, string> estadoActual;
            List<BE.cls14_OrdenProduccion> pendientes = OrdenesSinTerminar(idPedido, out estadoActual);
            bool facturado = new BLL.Factura().ListarCatalogo().Any(f => f.IdPedido == idPedido);
            // La factura se ofrece recién cuando todas las órdenes del pedido están terminadas.
            if (!facturado && pendientes.Count == 0)
            {
                string texto = "Todas las órdenes del pedido están terminadas. ¿Querés emitir la factura?";
                if (Navegacion.Preguntar(texto))
                {
                    Navegacion.Abrir(actual, new global::AluSoftPresentacion16_6.frm09_Factura_1(idPedido));
                    return;
                }
            }
            if (pendientes.Count == 0) return;
            // Primero otra orden del pedido (la que no se acaba de cargar), empezando por las que no arrancaron.
            BE.cls14_OrdenProduccion siguiente = pendientes
                .OrderBy(o => o.Idordenproduccion == idOrdenActual ? 1 : 0)
                .ThenBy(o => SinIniciar(estadoActual[o.Idordenproduccion]) ? 0 : 1)
                .ThenBy(o => o.Idordenproduccion)
                .First();
            bool tieneProduccion = new BLL.Produccion().ListarCatalogo()
                .Any(p => p.Idordenproduccion == siguiente.Idordenproduccion);
            string accion = tieneProduccion ? "cargar el estado (avance o terminación)" : "registrar el inicio de la producción";
            if (Navegacion.Preguntar("Faltan terminar estas órdenes del pedido:\n" + Describir(pendientes, estadoActual) +
                                     "\n\n¿Querés " + accion +
                                     " de la orden N° " + siguiente.Idordenproduccion + "?"))
            {
                if (tieneProduccion)
                    Navegacion.Abrir(actual, new global::AluSoftPresentacion16_6.frm15_Estado_1(siguiente.Idordenproduccion));
                else
                    Navegacion.Abrir(actual, new global::AluSoftPresentacion16_6.frm21_Produccion_1(siguiente.Idordenproduccion));
            }
        }

        internal static void RegistrarEstadoInicial(BE.cls14_OrdenProduccion orden)
        {
            BLL.Estado gestado = new BLL.Estado();
            BE.cls15_Estado estado = new BE.cls15_Estado();
            estado.Idestado = gestado.Max(estado) + 1;
            estado.Idordenproduccion = orden.Idordenproduccion;
            estado.Fechaorden = orden.Fechaorden;
            estado.Fechainicioproduccion = orden.Fechaorden;
            estado.Fechafinproduccion = DateTime.MinValue;   // se completa al terminar
            estado.Fechaentrega = DateTime.MinValue;
            estado.Estado = BLL.Estados.Produccion[0];
            estado.Observaciones = "Estado inicial de la orden";
            gestado.Agregar(estado);
        }

        // Stock disponible del producto (producto terminado).
        internal static int StockActual(int idStock)
        {
            return new BLL.Stock().ListarCatalogo2()
                .Where(s => s.Idstock == idStock).Select(s => s.Cantidad_actual).FirstOrDefault();
        }

        // Crea una orden de producción por cada producto del presupuesto del pedido.
        // Se usa primero el stock que ya hay, y se DESCUENTA del stock (script 13):
        //  - si alcanza, la orden queda Terminada "desde stock" y se descuenta todo lo pedido;
        //  - si no alcanza, se descuenta lo que hay y la orden se fabrica por lo que falta.
        // Lo que se fabrica para un pedido va al cliente: al terminar la orden no suma al stock.
        internal static List<int> GenerarOrdenes(int idPedido, int idPresupuesto)
        {
            string aviso;
            return GenerarOrdenes(idPedido, idPresupuesto, out aviso);
        }

        internal static List<int> GenerarOrdenes(int idPedido, int idPresupuesto, out string avisoStock)
        {
            List<int> ids = new List<int>();
            List<string> desdeStock = new List<string>();
            List<string> prioridad = new List<string>();
            List<string> sinStockCreado = new List<string>();
            BLL.OrdenProduccion gop = new BLL.OrdenProduccion();
            Dictionary<int, int> disponible = new BLL.Stock().ListarCatalogo2()
                .GroupBy(s => s.Idstock).ToDictionary(g => g.Key, g => Math.Max(0, g.First().Cantidad_actual));
            foreach (BE.cls36_PresupuestoDetalle d in new BLL.PresupuestoDetalle().Listar(idPresupuesto))
            {
                if (d.IdStock <= 0)
                {
                    // El producto del catálogo no tiene registro de stock: no se le puede crear orden.
                    sinStockCreado.Add("  ✖ " + d.Producto + " (" + d.Cantidad + " u.): no tiene stock creado. Cargalo en Stock → Formulario de alta y creá la orden a mano.");
                    continue;
                }
                int hay = disponible.ContainsKey(d.IdStock) ? disponible[d.IdStock] : 0;
                bool alcanza = hay >= d.Cantidad;
                int fabricar = alcanza ? 0 : d.Cantidad - hay;
                disponible[d.IdStock] = alcanza ? hay - d.Cantidad : 0;

                BE.cls14_OrdenProduccion op = new BE.cls14_OrdenProduccion();
                op.Idordenproduccion = gop.Max(op) + 1;
                op.Fechaorden = DateTime.Today;
                op.Idstock = d.IdStock;
                op.Cantidad = alcanza ? d.Cantidad : fabricar;
                string obs = "Ped. " + idPedido + " - " + d.Producto + (alcanza ? " (desde stock)" : " (PRIORIDAD)");
                op.Observaciones = obs.Length > 50 ? obs.Substring(0, 50) : obs;
                op.IdPedido = idPedido;
                if (gop.Agregar(op) == 0) continue;
                ids.Add(op.Idordenproduccion);
                int usado = alcanza ? d.Cantidad : hay;
                if (usado > 0)
                    new BLL.Stock().DescontarStockPedido(op.Idordenproduccion, d.IdStock, usado);
                if (alcanza)
                {
                    RegistrarEstado(op, "Terminado", "Cubierta con stock existente");
                    desdeStock.Add("  • " + d.Producto + ": se usan " + d.Cantidad + " del stock (había " + hay + ").");
                }
                else
                {
                    RegistrarEstadoInicial(op);
                    prioridad.Add(hay == 0
                        ? "  ⚠ " + d.Producto + ": SIN STOCK. Hay que fabricar " + fabricar + "."
                        : "  ⚠ " + d.Producto + ": STOCK BAJO (hay " + hay + ", el pedido lleva " + d.Cantidad + "). Se usan las " + hay + " del stock y hay que fabricar " + fabricar + ".");
                }
            }
            avisoStock = "";
            if (desdeStock.Count > 0)
                avisoStock += "\n\nSe entregan desde el stock (sin fabricar):\n" + string.Join("\n", desdeStock);
            if (prioridad.Count > 0)
                avisoStock += "\n\nAlerta de stock — darle PRIORIDAD a estas producciones:\n" + string.Join("\n", prioridad);
            if (sinStockCreado.Count > 0)
                avisoStock += "\n\nAtención — PRIORIDAD: estos productos no generaron orden:\n" + string.Join("\n", sinStockCreado);
            return ids;
        }

        internal static void RegistrarEstado(BE.cls14_OrdenProduccion orden, string estadoNuevo, string observaciones)
        {
            BLL.Estado gestado = new BLL.Estado();
            BE.cls15_Estado estado = new BE.cls15_Estado();
            estado.Idestado = gestado.Max(estado) + 1;
            estado.Idordenproduccion = orden.Idordenproduccion;
            estado.Fechaorden = orden.Fechaorden;
            estado.Fechainicioproduccion = orden.Fechaorden;
            estado.Fechafinproduccion = FechasEstado.Termino(estadoNuevo) ? orden.Fechaorden : DateTime.MinValue;
            estado.Fechaentrega = DateTime.MinValue;
            estado.Estado = estadoNuevo;
            estado.Observaciones = observaciones;
            gestado.Agregar(estado);
        }
    }

    // Cadena de compra: cada remito registra cuánto entró al stock (tabla MovimientoStockRemito, script 09).
    //  - "Recibido": suma lo que falta para completar la compra (nunca dos veces).
    //  - "Con faltantes": suma solo lo que llegó; el resto queda pendiente.
    //  - "Pendiente de entrega": no suma nada.
    internal static class CadenaCompra
    {
        public const string Recibido = "Recibido";
        public const string ConFaltantes = "Con faltantes";

        public static bool MueveStock(string estado)
        {
            estado = (estado ?? "").Trim();
            return estado == Recibido || estado == ConFaltantes;
        }

        // Lo que se compró para ese presupuesto (la compra indicada, o todas las de sus pedidos; si no hay, lo presupuestado).
        public static int Comprado(BE.cls18_PresupuestoProveedor presu, int idCompra, List<BE.cls16_PedidoReaprovisionamiento> pedidos)
        {
            List<int> idsPedido = pedidos.Select(p => p.Idpedidoreaprovisionamiento).ToList();
            List<BE.cls17_Compras> compras = new BLL.Compras().ListarCatalogo2()
                .Where(x => (idCompra > 0 && x.Idcompras == idCompra) || idsPedido.Contains(x.IdPedidoReaprovisionamiento))
                .ToList();
            int total = compras.Sum(x => x.Cantidad);
            return total > 0 ? total : presu.Cantidad;
        }

        // Lo que ya entró al stock por otros remitos del mismo presupuesto.
        public static int YaIngresado(int idPresupuesto, int excluirRemito)
        {
            int total = 0;
            foreach (System.Data.DataRow dr in new BLL.Stock().ListarIngresosRemito().Rows)
            {
                if (Convert.ToInt32(dr["IdPresupuestoProveedor"]) == idPresupuesto &&
                    Convert.ToInt32(dr["IdRemitoProveedor"]) != excluirRemito)
                    total += Convert.ToInt32(dr["Cantidad"]);
            }
            return total;
        }

        // Pide cuántas unidades llegaron. Devuelve -1 si se cancela.
        public static int PedirCantidadRecibida(int maximo)
        {
            using (Form f = new Form())
            {
                f.Text = "Remito con faltantes";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterScreen;
                f.MinimizeBox = false; f.MaximizeBox = false;
                f.ClientSize = new System.Drawing.Size(340, 130);
                Label l = new Label { Text = "¿Cuántas unidades llegaron? (faltaban " + maximo + ")", Left = 12, Top = 15, Width = 316 };
                NumericUpDown n = new NumericUpDown { Left = 12, Top = 45, Width = 120, Minimum = 0, Maximum = Math.Max(0, maximo), Value = 0 };
                Button ok = new Button { Text = "Aceptar", Left = 150, Top = 85, Width = 85, DialogResult = DialogResult.OK };
                Button no = new Button { Text = "Cancelar", Left = 243, Top = 85, Width = 85, DialogResult = DialogResult.Cancel };
                f.Controls.AddRange(new Control[] { l, n, ok, no });
                f.AcceptButton = ok; f.CancelButton = no;
                return f.ShowDialog() == DialogResult.OK ? (int)n.Value : -1;
            }
        }

        // Registra la entrada de mercadería del remito. Devuelve el texto para avisarle al usuario.
        // cantidadRecibida solo se usa con "Con faltantes" (-1 = preguntarla).
        public static string IngresarMercaderia(int idPresupuesto, int idRemito, int idCompra, string estado, int cantidadRecibida = -1)
        {
            estado = (estado ?? "").Trim();
            if (!MueveStock(estado)) return "";

            BE.cls18_PresupuestoProveedor presu = new BLL.PresupuestoProveedor().ListarCatalogo2()
                .FirstOrDefault(p => p.Idpresupuestoproveedor == idPresupuesto);
            if (presu == null) return "";

            List<BE.cls16_PedidoReaprovisionamiento> pedidos = new BLL.PedidoReaprovisionamiento().ListarCatalogo2()
                .Where(p => p.IdPresupuestoProveedor == idPresupuesto).ToList();

            int comprado = Comprado(presu, idCompra, pedidos);
            int otros = YaIngresado(idPresupuesto, idRemito);
            int pendiente = Math.Max(0, comprado - otros);

            int cantidad;
            if (estado == Recibido)
                cantidad = pendiente;
            else
            {
                if (cantidadRecibida < 0) cantidadRecibida = PedirCantidadRecibida(pendiente);
                if (cantidadRecibida < 0) return "\nNo se cargó la cantidad recibida: el stock no se modificó.";
                cantidad = Math.Min(cantidadRecibida, pendiente);
            }

            new BLL.Stock().IngresarStockRemito(idRemito, idPresupuesto, presu.Idstock, cantidad);

            int faltan = pendiente - cantidad;
            string texto;
            if (otros >= comprado && estado == Recibido)
                texto = "\nEsta compra ya había entrado completa al stock: no se volvió a sumar.";
            else
                texto = "\nEntraron " + cantidad + " unidades al stock de " + presu.Nombre + ".";

            if (faltan > 0)
            {
                texto += "\nFaltan " + faltan + " unidades. Cuando lleguen, cargá otro remito o pasá este a Recibido.";
            }
            else
            {
                foreach (BE.cls16_PedidoReaprovisionamiento p in pedidos)
                    new BLL.PedidoReaprovisionamiento().ActualizarEstado(p.Idpedidoreaprovisionamiento, Recibido);
                if (pedidos.Count > 0) texto += "\nLa compra está completa: el pedido de reaprovisionamiento quedó Recibido.";
            }
            return texto;
        }
    }

    // Filtros tipo reporte para las grillas de gestión (ventas, cobros, compras, pagos).
    // Se usa desde "Ver tabla" cuando no hay un registro elegido: muestra una ventana con
    // fechas y combos, filtra lo que ya está en la grilla y agrega una línea de totales.
    //   filtros: "Cliente=NombreCliente+Apellidocliente;Estado=Estado"
    //   totales: "Total vendido=Total;Cobrado=TotalCobrado"
    internal static class FiltroReporte
    {
        private const string Todos = "(Todos)";
        private const string NombreEtiqueta = "lblTotalesFiltro";

        // nombre: columna que se agrega al principio con el nombre completo, p. ej. "Cliente=Nombre+Apellido".
        // Las columnas de origen se ocultan para no repetir el dato.
        public static bool Mostrar(DataGridView grilla, string titulo, string columnaFecha, string filtros, string totales, string nombre = null)
        {
            DataTable datos = ATabla(grilla.DataSource);
            if (datos == null) return false;

            List<string> ocultas = ColumnasOcultas(grilla);
            string primera = AgregarNombre(datos, nombre, ocultas);
            Enlazar(grilla, datos, ocultas, primera);

            List<KeyValuePair<string, string[]>> defs = Parsear(filtros);
            bool hayFecha = !string.IsNullOrEmpty(columnaFecha) && datos.Columns.Contains(columnaFecha);

            using (Form f = new Form())
            {
                f.Text = "Filtrar " + titulo;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.MinimizeBox = false; f.MaximizeBox = false;
                f.Font = new Font("Segoe UI", 10f);
                int y = 15;

                DateTimePicker desde = null, hasta = null;
                if (hayFecha)
                {
                    f.Controls.Add(new Label { Text = "Desde:", Left = 15, Top = y + 4, Width = 110 });
                    desde = new DateTimePicker { Left = 130, Top = y, Width = 230, Format = DateTimePickerFormat.Short, ShowCheckBox = true, Checked = false };
                    f.Controls.Add(desde); y += 34;
                    f.Controls.Add(new Label { Text = "Hasta:", Left = 15, Top = y + 4, Width = 110 });
                    hasta = new DateTimePicker { Left = 130, Top = y, Width = 230, Format = DateTimePickerFormat.Short, ShowCheckBox = true, Checked = false };
                    f.Controls.Add(hasta); y += 36;

                    DateTimePicker d = desde, h = hasta;
                    string[] rapidos = { "Hoy", "Este mes", "Este año", "Sin fecha" };
                    for (int i = 0; i < rapidos.Length; i++)
                    {
                        Button b = new Button { Text = rapidos[i], Left = 15 + i * 87, Top = y, Width = 82, Height = 30 };
                        string cual = rapidos[i];
                        b.Click += (s, e) =>
                        {
                            DateTime hoy = DateTime.Today;
                            if (cual == "Sin fecha") { d.Checked = false; h.Checked = false; return; }
                            DateTime ini = cual == "Hoy" ? hoy : cual == "Este mes" ? new DateTime(hoy.Year, hoy.Month, 1) : new DateTime(hoy.Year, 1, 1);
                            DateTime fin = cual == "Hoy" ? hoy : cual == "Este mes" ? ini.AddMonths(1).AddDays(-1) : new DateTime(hoy.Year, 12, 31);
                            d.Value = ini; h.Value = fin; d.Checked = true; h.Checked = true;
                        };
                        f.Controls.Add(b);
                    }
                    y += 44;
                }

                List<ComboBox> combos = new List<ComboBox>();
                foreach (KeyValuePair<string, string[]> def in defs)
                {
                    if (!def.Value.All(datos.Columns.Contains)) { combos.Add(null); continue; }
                    f.Controls.Add(new Label { Text = def.Key + ":", Left = 15, Top = y + 4, Width = 110 });
                    ComboBox cb = new ComboBox { Left = 130, Top = y, Width = 230, DropDownStyle = ComboBoxStyle.DropDownList };
                    cb.Items.Add(Todos);
                    foreach (string v in datos.Rows.Cast<DataRow>().Select(r => Valor(r, def.Value))
                                 .Where(v => v.Length > 0).Distinct().OrderBy(v => v))
                        cb.Items.Add(v);
                    cb.SelectedIndex = 0;
                    f.Controls.Add(cb); combos.Add(cb); y += 34;
                }

                // Se leen los valores ANTES de que la ventana se cierre: después de cerrarse,
                // DateTimePicker.Checked puede devolver false aunque la casilla se haya tildado
                // con los botones (Hoy / Este mes / Este año), y el filtro de fecha se perdía.
                bool usarDesde = false, usarHasta = false;
                DateTime valorDesde = DateTime.Today, valorHasta = DateTime.Today;
                string[] elegidos = new string[defs.Count];
                f.FormClosing += (s, e) =>
                {
                    if (f.DialogResult != DialogResult.OK) return;
                    if (desde != null) { usarDesde = desde.Checked; valorDesde = desde.Value.Date; }
                    if (hasta != null) { usarHasta = hasta.Checked; valorHasta = hasta.Value.Date; }
                    for (int i = 0; i < defs.Count; i++)
                        elegidos[i] = combos[i] != null && combos[i].SelectedIndex > 0 ? combos[i].SelectedItem.ToString() : null;
                };

                Button ok = new Button { Text = "Buscar", Left = 160, Top = y + 10, Width = 95, Height = 32, DialogResult = DialogResult.OK };
                Button no = new Button { Text = "Cancelar", Left = 265, Top = y + 10, Width = 95, Height = 32, DialogResult = DialogResult.Cancel };
                f.Controls.Add(ok); f.Controls.Add(no);
                f.AcceptButton = ok; f.CancelButton = no;
                f.ClientSize = new Size(378, y + 55);

                if (f.ShowDialog(grilla.FindForm()) != DialogResult.OK) { OcultarTotales(grilla); return false; }

                DateTime? ini2 = usarDesde ? valorDesde : (DateTime?)null;
                DateTime? fin2 = usarHasta ? valorHasta : (DateTime?)null;
                if (ini2.HasValue && fin2.HasValue && ini2.Value > fin2.Value)
                {
                    DateTime aux = ini2.Value; ini2 = fin2; fin2 = aux;
                }
                List<string> descripcion = new List<string>();
                if (ini2.HasValue || fin2.HasValue)
                    descripcion.Add((ini2.HasValue ? ini2.Value.ToShortDateString() : "…") + " al " + (fin2.HasValue ? fin2.Value.ToShortDateString() : "…"));

                IEnumerable<DataRow> filas = datos.Rows.Cast<DataRow>();
                if (ini2.HasValue || fin2.HasValue)
                {
                    filas = filas.Where(r =>
                    {
                        if (r[columnaFecha] == DBNull.Value) return false;
                        DateTime fe = Convert.ToDateTime(r[columnaFecha]).Date;
                        return (!ini2.HasValue || fe >= ini2.Value) && (!fin2.HasValue || fe <= fin2.Value);
                    });
                }
                for (int i = 0; i < defs.Count; i++)
                {
                    string elegido = elegidos[i];
                    if (elegido == null) continue;
                    string[] cols = defs[i].Value;
                    filas = filas.Where(r => Valor(r, cols) == elegido);
                    descripcion.Add(defs[i].Key + ": " + elegido);
                }

                DataTable resultado = datos.Clone();
                foreach (DataRow r in filas) resultado.ImportRow(r);
                Enlazar(grilla, resultado, ocultas, primera);

                MostrarTotales(grilla, resultado, descripcion, Parsear(totales));
                return true;
            }
        }

        // Para la vista de un solo registro (Buscar o Ver tabla con un número elegido):
        // nombre del cliente/proveedor al principio y sin columnas de Id.
        public static void PonerNombre(DataGridView grilla, string nombre)
        {
            DataTable datos = ATabla(grilla.DataSource);
            if (datos == null) return;
            List<string> ocultas = ColumnasOcultas(grilla);
            string primera = AgregarNombre(datos, nombre, ocultas);
            Enlazar(grilla, datos, ocultas, primera);
        }

        private static List<string> ColumnasOcultas(DataGridView grilla)
        {
            List<string> ocultas = new List<string>();
            foreach (DataGridViewColumn col in grilla.Columns)
                if (!col.Visible) ocultas.Add(string.IsNullOrEmpty(col.DataPropertyName) ? col.Name : col.DataPropertyName);
            return ocultas;
        }

        // Devuelve el nombre de la columna agregada (o null si no se pudo armar).
        private static string AgregarNombre(DataTable datos, string nombre, List<string> ocultas)
        {
            KeyValuePair<string, string[]> def = Parsear(nombre).FirstOrDefault();
            if (def.Key == null) return null;
            if (datos.Columns.Contains(def.Key)) return def.Key;
            if (!def.Value.All(datos.Columns.Contains)) return null;
            DataColumn columna = datos.Columns.Add(def.Key, typeof(string));
            foreach (DataRow r in datos.Rows) r[columna] = Valor(r, def.Value);
            columna.SetOrdinal(0);
            foreach (string o in def.Value)
                if (!ocultas.Contains(o)) ocultas.Add(o);
            return def.Key;
        }

        private static void Enlazar(DataGridView grilla, DataTable datos, List<string> ocultas, string primera)
        {
            // En los reportes no se muestra ningún Id (ni del registro ni de personas):
            // con Tag "-" AjusteFormularios oculta todas las columnas que empiezan con "Id".
            grilla.Tag = "-";
            grilla.DataSource = datos;
            foreach (string o in ocultas)
                if (grilla.Columns.Contains(o)) grilla.Columns[o].Visible = false;
            foreach (DataGridViewColumn c in grilla.Columns)
                if (c.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase)) c.Visible = false;
            if (primera != null && grilla.Columns.Contains(primera))
            {
                grilla.Columns[primera].Visible = true;
                grilla.Columns[primera].DisplayIndex = 0;
            }
        }

        public static void OcultarTotales(DataGridView grilla)
        {
            Label lbl = grilla.Parent == null ? null : grilla.Parent.Controls[NombreEtiqueta] as Label;
            if (lbl != null) lbl.Visible = false;
        }

        private static void MostrarTotales(DataGridView grilla, DataTable datos, List<string> filtros, List<KeyValuePair<string, string[]>> totales)
        {
            Control padre = grilla.Parent;
            if (padre == null) return;
            Label lbl = padre.Controls[NombreEtiqueta] as Label;
            if (lbl == null)
            {
                grilla.Height -= 42;
                lbl = new Label
                {
                    Name = NombreEtiqueta, AutoSize = false, AutoEllipsis = true,
                    Left = grilla.Left, Top = grilla.Bottom + 2, Width = grilla.Width, Height = 40,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(9, 44, 74)
                };
                AnchorStyles a = grilla.Anchor & (AnchorStyles.Left | AnchorStyles.Right);
                lbl.Anchor = a | ((grilla.Anchor & AnchorStyles.Bottom) != 0 ? AnchorStyles.Bottom : AnchorStyles.Top);
                padre.Controls.Add(lbl);
            }
            // Los pagos anulados no suman.
            IEnumerable<DataRow> validas = datos.Rows.Cast<DataRow>();
            if (datos.Columns.Contains("Anulado"))
                validas = validas.Where(r => !(r["Anulado"] is bool) || !(bool)r["Anulado"]);
            List<string> partes = new List<string> { datos.Rows.Count + " registro(s)" };
            foreach (KeyValuePair<string, string[]> t in totales)
            {
                string col = t.Value[0];
                if (!datos.Columns.Contains(col)) continue;
                decimal suma = validas.Where(r => r[col] != DBNull.Value).Sum(r => Convert.ToDecimal(r[col]));
                partes.Add(t.Key + ": $ " + suma.ToString("N2"));
            }
            lbl.Text = (filtros.Count > 0 ? "Filtro: " + string.Join(" · ", filtros) + "\n" : "") + string.Join("   ·   ", partes);
            lbl.Visible = true;
            lbl.BringToFront();
        }

        private static List<KeyValuePair<string, string[]>> Parsear(string spec)
        {
            List<KeyValuePair<string, string[]>> l = new List<KeyValuePair<string, string[]>>();
            foreach (string parte in (spec ?? "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] kv = parte.Split('=');
                if (kv.Length == 2) l.Add(new KeyValuePair<string, string[]>(kv[0].Trim(), kv[1].Split('+').Select(x => x.Trim()).ToArray()));
            }
            return l;
        }

        private static string Valor(DataRow r, string[] columnas)
        {
            return string.Join(" ", columnas.Select(c =>
            {
                object v = r[c];
                if (v == DBNull.Value || v == null) return "";
                if (v is bool) return (bool)v ? "Sí" : "No";
                return v.ToString().Trim();
            }).Where(x => x.Length > 0));
        }

        // Pasa el origen de la grilla (lista de objetos o DataTable) a un DataTable.
        private static DataTable ATabla(object fuente)
        {
            BindingSource bs = fuente as BindingSource;
            if (bs != null) fuente = bs.DataSource;
            DataTable dt = fuente as DataTable;
            if (dt != null) return dt.Copy();
            System.Collections.IEnumerable lista = fuente as System.Collections.IEnumerable;
            if (lista == null) return null;
            DataTable tabla = new DataTable();
            System.Reflection.PropertyInfo[] props = null;
            foreach (object item in lista)
            {
                if (item == null) continue;
                if (props == null)
                {
                    props = item.GetType().GetProperties().Where(pp => pp.CanRead && pp.GetIndexParameters().Length == 0).ToArray();
                    foreach (System.Reflection.PropertyInfo pp in props)
                    {
                        Type tipo = Nullable.GetUnderlyingType(pp.PropertyType) ?? pp.PropertyType;
                        // DataTable no distingue mayúsculas: se salta un nombre repetido (p. ej. Idcliente / IdCliente).
                        if ((tipo.IsPrimitive || tipo == typeof(string) || tipo == typeof(decimal) || tipo == typeof(DateTime))
                            && !tabla.Columns.Contains(pp.Name))
                            tabla.Columns.Add(pp.Name, tipo);
                    }
                }
                DataRow fila = tabla.NewRow();
                foreach (DataColumn col in tabla.Columns)
                {
                    object v = null;
                    System.Reflection.PropertyInfo pi = props.FirstOrDefault(pp => pp.Name == col.ColumnName);
                    try { if (pi != null) v = pi.GetValue(item, null); } catch { }
                    fila[col.ColumnName] = v ?? DBNull.Value;
                }
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
    }

    // Borrado seguro en las gestiones:
    //  - siempre se borra el registro ELEGIDO en el combo (antes se borraba el último buscado);
    //  - no se deja borrar un registro que otros registros usan (no hay claves foráneas en la base).
    internal static class Borrado
    {
        // Devuelve el motivo por el que NO se puede borrar, o null si se puede.
        public static string Motivo(string entidad, int id)
        {
            try
            {
                switch (entidad)
                {
                    case "Persona":
                    {
                        BE.cls00_Persona p = new BE.cls00_Persona();
                        new BLL.Persona().Consultar(p, id);
                        if (p.Idlogin > 0) return "la persona es un usuario del sistema.";
                        if (new BLL.Cliente().Listar2().Any(c => c.Idpersona == id)) return "la persona está cargada como cliente.";
                        if (new BLL.Proveedor().ListarCatalogo().Any(c => c.Idpersona == id)) return "la persona está cargada como proveedor.";
                        return null;
                    }
                    case "Inventario":
                        if (new BLL.Stock().ListarCatalogo2().Any(s => s.Idinventario == id)) return "el elemento tiene stock cargado.";
                        if (new BLL.Catalogo().Listar2().Any(c => c.Idinventario == id)) return "el elemento está en el catálogo.";
                        return null;
                    case "Stock":
                        if (new BLL.OrdenProduccion().ListarCatalogo2().Any(o => o.Idstock == id)) return "el producto tiene órdenes de producción.";
                        if (new BLL.PresupuestoProveedor().ListarCatalogo2().Any(o => o.Idstock == id)) return "el producto tiene presupuestos de proveedores.";
                        if (new BLL.Compras().ListarCatalogo2().Any(o => o.Idstock == id)) return "el producto tiene compras.";
                        return null;
                    case "Cliente":
                        if (new BLL.PresupuestroCliente().ListarCatalogo().Any(p => p.Idcliente == id)) return "el cliente tiene presupuestos.";
                        if (new BLL.Factura().ListarCatalogo2().Any(f => f.IdCliente == id)) return "el cliente tiene facturas.";
                        return null;
                    case "Proveedor":
                        if (new BLL.PresupuestoProveedor().ListarCatalogo2().Any(p => p.Idproveedor == id)) return "el proveedor tiene presupuestos.";
                        if (new BLL.PedidoReaprovisionamiento().ListarCatalogo2().Any(p => p.Idproveedor == id)) return "el proveedor tiene pedidos de reaprovisionamiento.";
                        if (new BLL.Pagos().ListarCatalogo2().Any(p => p.IdProveedor == id && !p.Anulado)) return "el proveedor tiene pagos.";
                        return null;
                    case "Factura":
                        if (new BLL.Cobro().ListarCatalogo2().Any(c => c.Idfactura == id)) return "la factura tiene cobros registrados.";
                        if (new BLL.Ventas().ListarCatalogo2().Any(v => v.Idfactura == id)) return "la factura tiene una venta registrada.";
                        return null;
                    case "Cobro":
                        if (new BLL.Ventas().ListarCatalogo2().Any(v => v.IdCobro == id)) return "el cobro tiene una venta registrada.";
                        return null;
                    case "Catalogo":
                        if (new BLL.ListaPrecios().ListarCatalogo2().Any(l => l.Idcatalogo == id)) return "el producto tiene lista de precios.";
                        if (new BLL.PresupuestroCliente().ListarCatalogo().Any(p => p.Idcatalogo == id)) return "el producto está en presupuestos de clientes.";
                        return null;
                    case "OrdenProduccion":
                    {
                        BE.cls14_OrdenProduccion orden = new BLL.OrdenProduccion().ListarCatalogo2().FirstOrDefault(o => o.Idordenproduccion == id);
                        if (orden != null && orden.IdPedido > 0) return "la orden pertenece al pedido N° " + orden.IdPedido + " (se elimina junto con el pedido).";
                        if (new BLL.Produccion().ListarCatalogo2().Any(p => p.Idordenproduccion == id)) return "la orden ya tiene producción registrada.";
                        if (new BLL.Estado().ListarCatalogo2().Any(e => e.Idordenproduccion == id && !EsPendiente(e.Estado))) return "la orden ya avanzó (tiene estados cargados).";
                        return null;
                    }
                    case "Estado":
                    {
                        BE.cls15_Estado est = new BLL.Estado().ListarCatalogo2().FirstOrDefault(e => e.Idestado == id);
                        if (est != null && FechasEstado.Termino(est.Estado)) return "es un estado \"" + est.Estado.Trim() + "\" y la cantidad ya se sumó al stock.";
                        return null;
                    }
                    case "PedidoReaprovisionamiento":
                        if (new BLL.Compras().ListarCatalogo2().Any(c => c.IdPedidoReaprovisionamiento == id)) return "el pedido tiene compras registradas.";
                        return null;
                    case "Compras":
                    {
                        if (new BLL.Pagos().ListarCatalogo2().Any(p => p.IdCompras == id && !p.Anulado)) return "la compra tiene pagos registrados.";
                        BE.cls17_Compras compra = new BLL.Compras().ListarCatalogo2().FirstOrDefault(c => c.Idcompras == id);
                        if (compra != null && compra.IdPedidoReaprovisionamiento > 0)
                        {
                            BE.cls16_PedidoReaprovisionamiento ped = new BLL.PedidoReaprovisionamiento().ListarCatalogo2()
                                .FirstOrDefault(p => p.Idpedidoreaprovisionamiento == compra.IdPedidoReaprovisionamiento);
                            if (ped != null && ped.IdPresupuestoProveedor > 0 && CadenaCompra.YaIngresado(ped.IdPresupuestoProveedor, 0) > 0)
                                return "la mercadería de la compra ya ingresó al stock por remito.";
                        }
                        return null;
                    }
                    case "PresupuestoProveedor":
                        if (new BLL.PedidoReaprovisionamiento().ListarCatalogo2().Any(p => p.IdPresupuestoProveedor == id)) return "el presupuesto ya generó un pedido de reaprovisionamiento.";
                        return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                return "no se pudo verificar si tiene registros asociados (" + ex.Message + ").";
            }
        }

        private static bool EsPendiente(string estado)
        {
            return string.Equals((estado ?? "").Trim(), "Pendiente", StringComparison.OrdinalIgnoreCase);
        }

        // Valida que haya un registro elegido. Devuelve el id o 0 (y avisa).
        public static int IdElegido(ComboBox combo, string que)
        {
            int id = AjusteFormularios.IdSeleccionado(combo);
            if (id <= 0)
            {
                MessageBox.Show("Elegí " + que + " de la lista para eliminar.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (combo != null) combo.Focus();
            }
            return id;
        }

        // Revisa las relaciones y avisa si no se puede borrar.
        public static bool SePuede(string entidad, int id, string que)
        {
            string motivo = Motivo(entidad, id);
            if (motivo == null) return true;
            MessageBox.Show("No se puede eliminar " + que + ": " + motivo, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Los procedimientos con NOCOUNT devuelven -1: cualquier valor distinto de 0 es éxito.
        public static bool Informar(int filas, string que)
        {
            if (filas != 0)
            {
                MessageBox.Show("Se eliminó " + que + " correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            MessageBox.Show("No se pudo eliminar " + que + ".", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }

    // Bienes de uso (herramientas, máquinas, muebles): se registran solo en Inventario y no entran
    // al circuito Stock → Catálogo → Lista de precios. Se marcan con el valor "Bien de uso" en el campo Tipo.
    internal static class BienDeUso
    {
        internal const string Tipo = "Bien de uso";

        internal static bool Es(string tipo)
        {
            return string.Equals((tipo ?? "").Trim(), Tipo, StringComparison.OrdinalIgnoreCase);
        }
    }
}
