using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace AluSoft.UI
{
    internal static class AjusteFormularios
    {
        internal static void PrepararParaPanel(Form formulario)
        {
            formulario.MinimumSize = Size.Empty;
            formulario.MaximumSize = Size.Empty;

            Size diseno = formulario.ClientSize;
            formulario.SuspendLayout();

            foreach (Control c in formulario.Controls)
            {
                if (c.Dock != DockStyle.None || c.Width < diseno.Width - 2) continue;
                bool anchoCompleto = (c.Anchor & AnchorStyles.Left) != 0 && (c.Anchor & AnchorStyles.Right) != 0;
                if (!anchoCompleto) continue;
                if (c.Top <= 0 && (c.Anchor & AnchorStyles.Bottom) == 0) c.Dock = DockStyle.Top;
                else if (c.Bottom >= diseno.Height && (c.Anchor & AnchorStyles.Top) == 0) c.Dock = DockStyle.Bottom;
            }

            int arriba = 0, abajo = 0;
            foreach (Control c in formulario.Controls)
            {
                if (c.Dock == DockStyle.Top) arriba += c.Height;
                else if (c.Dock == DockStyle.Bottom) abajo += c.Height;
            }

            Panel contenido = new Panel();
            contenido.Name = "pnlContenidoAdaptable";
            contenido.AutoScroll = true;
            contenido.BackColor = formulario.BackColor;
            contenido.Bounds = new Rectangle(0, arriba, diseno.Width, Math.Max(1, diseno.Height - arriba - abajo));

            List<Control> mover = new List<Control>();
            foreach (Control c in formulario.Controls)
                if (c.Dock != DockStyle.Top && c.Dock != DockStyle.Bottom) mover.Add(c);

            for (int i = mover.Count - 1; i >= 0; i--)
            {
                Control c = mover[i];
                Point p = c.Location;
                formulario.Controls.Remove(c);
                if (c.Dock == DockStyle.None) c.Location = new Point(p.X, p.Y - arriba);
                contenido.Controls.Add(c);
                contenido.Controls.SetChildIndex(c, 0);
            }

            contenido.AutoScrollMinSize = new Size(0, Math.Max(100, AltoNecesario(contenido) + 8));

            formulario.Controls.Add(contenido);
            contenido.Dock = DockStyle.Fill;
            contenido.BringToFront();
            formulario.ResumeLayout(true);

            ValidacionCampos.LimitarLargo(contenido);
            ValidacionCampos.DejarLugarParaIcono(contenido);
            PrepararGrillas(formulario);
            OrdenarTabulacion(formulario);
        }

        internal static int IdSeleccionado(ComboBox combo)
        {
            if (combo == null || combo.SelectedIndex < 0 || combo.SelectedValue == null)
                return 0;

            int id;
            return int.TryParse(Convert.ToString(combo.SelectedValue, CultureInfo.InvariantCulture),
                NumberStyles.Integer, CultureInfo.InvariantCulture, out id) && id > 0 ? id : 0;
        }

        internal static void AplicarFiltroGrilla(DataGridView grilla, ComboBox combo)
        {
            AplicarFiltroGrilla(grilla, combo, null);
        }

        internal static void AplicarFiltroGrilla(DataGridView grilla, ComboBox combo, string columnaIdPrincipal)
        {
            if (grilla == null || combo == null || string.IsNullOrWhiteSpace(combo.ValueMember))
                return;

            string columnaFiltro = combo.ValueMember.Trim();
            grilla.Tag = string.IsNullOrWhiteSpace(columnaIdPrincipal)
                ? columnaFiltro : columnaIdPrincipal.Trim();

            int id = IdSeleccionado(combo);
            if (id > 0 && grilla.DataSource != null)
            {
                object fuente = grilla.DataSource;
                BindingSource binding = fuente as BindingSource;
                if (binding != null) fuente = binding.DataSource;
                grilla.DataSource = FiltrarFuente(fuente, columnaFiltro, id);
            }

            AplicarVisibilidadGrilla(grilla);
        }

        private static object FiltrarFuente(object fuente, string nombreColumna, object valor)
        {
            DataTable tabla = fuente as DataTable;
            if (tabla != null)
            {
                DataColumn columna = tabla.Columns.Cast<DataColumn>()
                    .FirstOrDefault(c => string.Equals(c.ColumnName, nombreColumna,
                        StringComparison.OrdinalIgnoreCase));
                // Algunas consultas ya devuelven una tabla filtrada y no incluyen
                // la clave solicitada. En ese caso conservamos esa respuesta del DAL.
                if (columna == null) return fuente;

                DataTable filtrada = tabla.Clone();
                foreach (DataRow fila in tabla.Rows)
                    if (ValoresIguales(fila[columna], valor)) filtrada.ImportRow(fila);
                return filtrada;
            }

            DataView vista = fuente as DataView;
            if (vista != null) return FiltrarFuente(vista.ToTable(), nombreColumna, valor);

            IEnumerable elementos = fuente as IEnumerable;
            if (elementos == null) return fuente;

            Type tipoElemento = ObtenerTipoElemento(fuente.GetType());
            if (tipoElemento == null)
            {
                object primero = elementos.Cast<object>().FirstOrDefault();
                if (primero == null) return fuente;
                tipoElemento = primero.GetType();
            }

            MemberInfo miembro = tipoElemento.GetMembers(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(m => (m is PropertyInfo || m is FieldInfo) &&
                    string.Equals(m.Name, nombreColumna, StringComparison.OrdinalIgnoreCase));
            if (miembro == null) return fuente;

            Type listaTipo = typeof(List<>).MakeGenericType(tipoElemento);
            IList resultado = (IList)Activator.CreateInstance(listaTipo);
            foreach (object elemento in elementos)
            {
                if (elemento == null) continue;
                object valorElemento = miembro is PropertyInfo
                    ? ((PropertyInfo)miembro).GetValue(elemento, null)
                    : ((FieldInfo)miembro).GetValue(elemento);
                if (ValoresIguales(valorElemento, valor)) resultado.Add(elemento);
            }
            return resultado;
        }

        private static Type ObtenerTipoElemento(Type tipo)
        {
            if (tipo.IsGenericType && tipo.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                return tipo.GetGenericArguments()[0];

            Type interfaz = tipo.GetInterfaces().FirstOrDefault(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            return interfaz == null ? null : interfaz.GetGenericArguments()[0];
        }

        private static bool ValoresIguales(object a, object b)
        {
            if (a == null || a == DBNull.Value || b == null || b == DBNull.Value) return false;

            decimal numeroA, numeroB;
            if (decimal.TryParse(Convert.ToString(a, CultureInfo.InvariantCulture), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out numeroA) &&
                decimal.TryParse(Convert.ToString(b, CultureInfo.InvariantCulture), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out numeroB))
                return numeroA == numeroB;

            return string.Equals(Convert.ToString(a, CultureInfo.InvariantCulture),
                Convert.ToString(b, CultureInfo.InvariantCulture), StringComparison.OrdinalIgnoreCase);
        }

        private static void PrepararGrillas(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                DataGridView grilla = control as DataGridView;
                if (grilla != null)
                {
                    grilla.AllowUserToAddRows = false;

                    if (grilla.Tag == null)
                        grilla.Tag = ColumnaIdPrincipal(contenedor.FindForm());

                    grilla.DataBindingComplete += delegate(object sender, DataGridViewBindingCompleteEventArgs e)
                    {
                        AplicarVisibilidadGrilla((DataGridView)sender);
                    };
                    AplicarVisibilidadGrilla(grilla);
                }

                if (control.HasChildren) PrepararGrillas(control);
            }
        }

        private static string ColumnaIdPrincipal(Form formulario)
        {
            if (formulario == null) return null;
            string nombre = formulario.GetType().Name;
            string[,] ids = {
                { "frm00_Persona_2", "IdPersona" }, { "frm01_Inventario_2", "IdInventario" },
                { "frm02_Stock_1", "IdInventario" }, { "frm02_Stock_2", "IdStock" },
                { "frm03_Cliente_2", "IdPersona" }, { "frm03_Cliente_Demo", "IdPersona" },
                { "frm04_Proveedor_1", "IdProveedor" }, { "frm04_Proveedor_2", "IdProveedor" },
                { "frm07_PresupuestoCliente_2", "IdPresupuesto" }, { "frm08_PedidoCliente_1", "IdPresupuesto" },
                { "frm08_PedidoCliente_2", "IdPedido" }, { "frm09_Factura_1", "IdFactura" },
                { "frm09_Factura_2", "IdFactura" }, { "frm10_Cobro_1", "IdFactura" },
                { "frm10_Cobro_2", "IdCobro" }, { "frm11_Ventas_1", "IdVenta" },
                { "frm11_Ventas_2", "IdVenta" }, { "frm12_Catalogo_1", "IdInventario" },
                { "frm12_Catalogo_2", "IdCatalogo" }, { "frm13_ListaPrecios_1", "IdCatalogo" },
                { "frm13_ListaPrecios_2", "IdLista" }, { "frm14_OrdenProduccion_1", "IdStock" },
                { "frm14_OrdenProduccion_2", "IdOrdenProduccion" }, { "frm15_Estado_1", "IdOrdenProduccion" },
                { "frm15_Estado_2", "IdEstado" }, { "frm16_PedidoReaprovisionamiento", "IdProveedor" },
                { "frm16_PedidoReaprovisionamiento_2", "IdPedidoReaprovisionamiento" },
                { "frm17_Compras_1", "IdStock" }, { "frm17_Compras_2", "IdCompras" },
                { "frm18_PresupuestoProveedor_1", "IdProveedor" },
                { "frm18_PresupuestoProveedor_2", "IdPresupuestoProveedor" },
                { "frm19_Maximo_2", "IdMaximo" }, { "frm20_Minimo_2", "IdMinimo" },
                { "frm21_Produccion_1", "IdOrdenProduccion" }, { "frm21_Produccion_2", "IdProduccion" },
                { "frm23_Remito_1", "IdPresupuestoProveedor" }, { "frm23_Remito_2", "IdRemitoProveedor" },
                { "frm24_Pagos_1", "IdProveedor" }, { "frm24_Pagos_2", "IdPago" }
            };

            for (int i = 0; i < ids.GetLength(0); i++)
                if (string.Equals(nombre, ids[i, 0], StringComparison.OrdinalIgnoreCase)) return ids[i, 1];
            return null;
        }

        // En estas gestiones la grilla muestra a la persona por su nombre: no se ve ningún Id.
        private static readonly string[] FormulariosSinIds = { "frm00_Persona_2", "frm03_Cliente_2", "frm03_Cliente_Demo" };

        private static void AplicarVisibilidadGrilla(DataGridView grilla)
        {
            string idPrincipal = Convert.ToString(grilla.Tag, CultureInfo.InvariantCulture);
            Form formulario = grilla.FindForm();
            if (formulario != null && FormulariosSinIds.Contains(formulario.GetType().Name, StringComparer.OrdinalIgnoreCase))
                idPrincipal = string.Empty;
            HashSet<string> idsPermitidos = new HashSet<string>(
                (idPrincipal ?? string.Empty).Split(',')
                    .Select(id => new string(id.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant())
                    .Where(id => id.Length > 0));
            foreach (DataGridViewColumn columna in grilla.Columns)
            {
                string nombre = new string(columna.Name.Where(char.IsLetterOrDigit).ToArray()).ToLowerInvariant();
                bool sensible = nombre == "combo" || nombre == "idlogin" || nombre == "idrol" ||
                    nombre == "digitoverificador" || nombre == "contrasena" || nombre == "password" ||
                    nombre == "clave";
                bool esId = nombre.StartsWith("id", StringComparison.Ordinal);
                if (sensible) columna.Visible = false;
                else if (esId) columna.Visible = idsPermitidos.Contains(nombre);
            }
        }

        private static void OrdenarTabulacion(Control contenedor)
        {
            List<Control> hijos = new List<Control>();
            foreach (Control c in contenedor.Controls) hijos.Add(c);
            hijos.Sort((a, b) =>
            {
                // En una tabla se respeta primero la columna y luego la fila.
                // En los demás contenedores se recorre de izquierda a derecha,
                // descendiendo por cada columna antes de pasar a la siguiente.
                TableLayoutPanel tabla = contenedor as TableLayoutPanel;
                if (tabla != null)
                {
                    TableLayoutPanelCellPosition posicionA = tabla.GetPositionFromControl(a);
                    TableLayoutPanelCellPosition posicionB = tabla.GetPositionFromControl(b);
                    int columna = posicionA.Column.CompareTo(posicionB.Column);
                    if (columna != 0) return columna;
                    int fila = posicionA.Row.CompareTo(posicionB.Row);
                    if (fila != 0) return fila;
                }

                int izquierda = a.Left.CompareTo(b.Left);
                if (izquierda != 0) return izquierda;
                int arriba = a.Top.CompareTo(b.Top);
                if (arriba != 0) return arriba;
                return a.TabIndex.CompareTo(b.TabIndex);
            });
            for (int i = 0; i < hijos.Count; i++)
            {
                hijos[i].TabIndex = i;
                if (hijos[i].HasChildren && !(hijos[i] is DataGridView)) OrdenarTabulacion(hijos[i]);
            }
        }

        private static int AltoNecesario(Control contenedor)
        {
            int alto = 0;
            foreach (Control c in contenedor.Controls)
            {
                bool acoplado = c.Dock == DockStyle.Fill || c.Dock == DockStyle.Left || c.Dock == DockStyle.Right;
                bool seEstira = acoplado || (c.Anchor & AnchorStyles.Bottom) != 0;
                int h;
                if (!seEstira) h = c.Height;
                else if (c is DataGridView) h = 80;
                else h = Math.Max(AltoNecesario(c) + 6, 40);
                alto = Math.Max(alto, (acoplado ? 0 : c.Top) + h);
            }
            return alto;
        }
    }
}
