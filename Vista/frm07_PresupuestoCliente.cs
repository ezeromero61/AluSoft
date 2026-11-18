using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AluSoftPresentacion16_6
{
    public partial class frm07_PresupuestoCliente : Form
    {
        public frm07_PresupuestoCliente()
        {
            InitializeComponent();
        }

        private int idClienteInicial;

        public frm07_PresupuestoCliente(int idCliente) : this()
        {
            idClienteInicial = idCliente;
        }

        private BE.cls35_Bitacora bitacora;
        private BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls13_ListaPrecios lpre = new BE.cls13_ListaPrecios();
        BLL.ListaPrecios glpre = new BLL.ListaPrecios();
        private BE.cls03_Cliente cliente;
        private BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls02_Stock stock = new BE.cls02_Stock();
        BLL.Stock gstock = new BLL.Stock();
        private BE.cls12_Catalogo catalogo;
        private BLL.Catalogo gcatalogo = new BLL.Catalogo();
        private BE.cls07_PresupuestoCliente presupuesto;
        private BLL.PresupuestroCliente gpresupuesto =new BLL.PresupuestroCliente();
        #region Métodos auxiliares
        private List<BE.cls12_Catalogo> listacatalogo;
        private List<BE.cls03_Cliente> listaPersonasOriginal;
        private bool filtrandoCombo = false; // [UNIFICADO 3.1.6] búsqueda mientras se escribe
        private List<BE.cls13_ListaPrecios> lista;
        private global::AluSoft.UI.PanelRenglones renglones;
        private BLL.PresupuestoDetalle gdetalle = new BLL.PresupuestoDetalle();

        private void AgregarRenglon(bool avisar)
        {
            BE.cls13_ListaPrecios producto = cbxIdCatalogo.SelectedItem as BE.cls13_ListaPrecios;
            if (producto == null || cbxCantidades.SelectedItem == null)
            {
                if (avisar)
                    MessageBox.Show("Elegí el producto del catálogo y la cantidad.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            renglones.Agregar(producto.Idcatalogo, producto.Nombre, Convert.ToInt32(cbxCantidades.SelectedItem), producto.Precio);
        }
        private void ActualizarSubTotal()
        {
            if (txbImpuestos.Text.Trim().Length == 0) txbImpuestos.Text = "21";
            decimal precio = 0;
            decimal cantidad = 0;
            decimal porcentajeImpuesto;
            decimal descuento;

            bool hayRenglones = renglones != null && renglones.Renglones.Count > 0;
            if ((!hayRenglones &&
                 (!decimal.TryParse(txbPrecio.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out precio) ||
                  !decimal.TryParse(cbxCantidades.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out cantidad))) ||
                !decimal.TryParse(txbImpuestos.Text, NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out porcentajeImpuesto) ||
                !decimal.TryParse(txbDescuento.Text, NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out descuento))
            {
                txbSubtotal.Clear();
                txbTotal.Clear();
                return;
            }

            decimal subtotal = hayRenglones ? renglones.Subtotal : precio * cantidad;
            errorProvider1.SetError(txbDescuento, "");
            if (descuento < 0 || descuento > subtotal)
            {
                errorProvider1.SetError(txbDescuento, "El descuento no puede ser negativo ni superar el subtotal.");
                txbSubtotal.Text = subtotal.ToString("0");
                txbTotal.Clear();
                return;
            }

            decimal total = Math.Round((subtotal - descuento) * (1 + porcentajeImpuesto / 100m), 0);

            txbSubtotal.Text = subtotal.ToString(/*"N2", CultureInfo.CurrentCulture*/);
            txbTotal.Text = total.ToString(/*"N2", CultureInfo.CurrentCulture*/);
        }
        private void CargarComboNumeros(System.Windows.Forms.ComboBox combo, int hasta)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            for (int numero = 1; numero <= hasta; numero++)
            {
                combo.Items.Add(numero);
            }

            combo.SelectedIndex = -1;
        }
        private void LimpiarControles(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)control).Clear();
                }
                else if (control is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox combo = (System.Windows.Forms.ComboBox)control;
                    combo.SelectedIndex = -1;
                    combo.Text = "";
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Today;
                }
                else if (control is NumericUpDown)
                {
                    NumericUpDown numeric = (NumericUpDown)control;
                    numeric.Value = numeric.Minimum;
                }
                else if (control is DataGridView)
                {
                    ((DataGridView)control).DataSource = null;
                }

                if (control.HasChildren)
                {
                    LimpiarControles(control);
                }
            }

            errorProvider1.Clear();
        }
        private void CargarComboListaPrecios()
        {
            lista = glpre.ListarCatalogo2()
                .GroupBy(l => l.Idcatalogo)
                .Select(g => g.OrderByDescending(l => l.Fecha).ThenByDescending(l => l.Idlista).First())
                .OrderBy(l => l.Nombre)
                .ToList();

            cbxIdCatalogo.DataSource = null;
            cbxIdCatalogo.DisplayMember = "Nombre";
            cbxIdCatalogo.ValueMember = "Idcatalogo";
            cbxIdCatalogo.DataSource = lista;
            cbxIdCatalogo.SelectedIndex = -1;
            cbxIdCatalogo.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxCantidades.DataSource = null;
            cbxCantidades.Items.Clear();

            txbPrecio.Clear(); // Usá aquí el nombre real de tu TextBox
        }
        private void CargarComboCatalogo()
        {
            listacatalogo = gcatalogo.Listar2();
            cbxIdCatalogo.DataSource = listacatalogo;
            cbxIdCatalogo.DisplayMember = "Nombre";
            cbxIdCatalogo.ValueMember = "IdCatalogo";
            cbxIdCatalogo.Text = null;
            cbxIdCatalogo.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void CargarComboStock()
        {
        }
        private void CargarComboCliente()
        {
            cliente = new BE.cls03_Cliente();
            listaPersonasOriginal = gcliente.Listar2();
            cbxIdCliente.DataSource = listaPersonasOriginal;
            cbxIdCliente.DisplayMember = "Combo";
            cbxIdCliente.ValueMember = "IdCliente";
            cbxIdCliente.SelectedIndex = -1;
            cbxIdCliente.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void CargarBitacora(int tabla, int accion)
        {
            bitacora = new BE.cls35_Bitacora();

            bitacora.idbitacora = gbitacora.Max(bitacora) + 1;
            bitacora.idlogin = clsPerdurables.Id_Login;
            bitacora.idtabla = tabla;
            bitacora.idaccion = accion;
            bitacora.fecha = DateTime.Now;
            bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));

            gbitacora.Agregar(bitacora);
        }
        private bool ValidarCampos()
        {
            errorProvider1.Clear();

            Control primerControlInvalido = null;
            bool valido = true;

            ValidarControlesRecursivamente(
                this,
                ref valido,
                ref primerControlInvalido);
            global::AluSoft.UI.ValidacionCampos.ValidarTipos(this, errorProvider1, ref valido, ref primerControlInvalido);
            primerControlInvalido = global::AluSoft.UI.ValidacionCampos.PrimeroConError(this, errorProvider1) ?? primerControlInvalido;
            if (!valido && primerControlInvalido != null)
                global::AluSoft.UI.ValidacionCampos.EnfocarYMostrar(primerControlInvalido);

            ValidarNumeroEntero(txbSubtotal, "Ingresá un subtotal válido.",
                ref valido, ref primerControlInvalido);

            ValidarNumeroEntero(txbDescuento, "Ingresá un descuento válido.",
                ref valido, ref primerControlInvalido);

            ValidarNumeroEntero(txbImpuestos, "Ingresá un importe de impuestos válido.",
                ref valido, ref primerControlInvalido);

            ValidarNumeroEntero(txbTotal, "Ingresá un total válido.",
                ref valido, ref primerControlInvalido);

            ValidarNumeroEntero(txbPlazoEntrega, "Ingresá un plazo válido.",
                ref valido, ref primerControlInvalido);

            int subtotal;
            int descuento;

            if (int.TryParse(txbSubtotal.Text, out subtotal) &&
                int.TryParse(txbDescuento.Text, out descuento))
            {
                if (descuento > subtotal)
                {
                    errorProvider1.SetError(
                        txbDescuento,
                        "El descuento no puede superar el subtotal.");

                    if (primerControlInvalido == null)
                        primerControlInvalido = txbDescuento;

                    valido = false;
                }
            }

            if (dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            {
                errorProvider1.SetError(
                    dateTimePicker2,
                    "La fecha de validez no puede ser anterior a la fecha de creación.");

                if (primerControlInvalido == null)
                    primerControlInvalido = dateTimePicker2;

                valido = false;
            }

            if (!valido && primerControlInvalido != null)
            {
                primerControlInvalido.Focus();
            }

            return valido;
        }
        private void ValidarControlesRecursivamente( Control contenedor,ref bool valido,ref Control primerControlInvalido)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control.Visible && control.Enabled && !global::AluSoft.UI.ValidacionCampos.EsOpcional(control))
                {
                    if (control is System.Windows.Forms.TextBox && !((System.Windows.Forms.TextBox)control).ReadOnly)
                    {
                        System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)control;

                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            errorProvider1.SetError(
                                textBox,
                                "Tenés que completar este campo.");

                            if (primerControlInvalido == null)
                                primerControlInvalido = textBox;

                            valido = false;
                        }
                    }
                    else if (control is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)control;

                        if (comboBox.SelectedIndex == -1)
                        {
                            errorProvider1.SetError(
                                comboBox,
                                "Tenés que seleccionar una opción.");

                            if (primerControlInvalido == null)
                                primerControlInvalido = comboBox;

                            valido = false;
                        }
                    }
                }

                if (control.HasChildren)
                {
                    ValidarControlesRecursivamente(
                        control,
                        ref valido,
                        ref primerControlInvalido);
                }
            }
        }
        private void ValidarNumeroEntero(System.Windows.Forms.TextBox textBox, string mensaje,ref bool valido,ref Control primerControlInvalido)
        {
            int numero;

            if (!int.TryParse(textBox.Text, out numero))
            {
                errorProvider1.SetError(textBox, mensaje);

                if (primerControlInvalido == null)
                    primerControlInvalido = textBox;

                valido = false;
            }
            else if (numero < 0)
            {
                errorProvider1.SetError(
                    textBox,
                    "El valor no puede ser negativo.");

                if (primerControlInvalido == null)
                    primerControlInvalido = textBox;

                valido = false;
            }
        }
        #endregion

        private void frm07_PresupuestoCliente_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Presupuesto, "Pendiente");
            // Paneles, columnas, campos de solo lectura y filas ocultas (impuestos, subtotal, forma de
            // pago y descripción) quedan configurados en el diseño. El IVA es siempre 21 por ciento.
            renglones = new global::AluSoft.UI.PanelRenglones(this, tableLayoutPanel1);
            renglones.BtnAgregar.Click += delegate { AgregarRenglon(true); };
            renglones.Cambio += ActualizarSubTotal;
            // [CORREGIDO] En pantallas chicas la grilla de productos tapaba Observaciones, Forma de
            // pago y Descripción: la grilla se acopla abajo DESPUÉS de que el panel con los datos ya
            // ocupó todo el alto, así que quedaba encima. Se trae al frente el panel de los datos
            // para que se acomode arriba de la grilla, y se le da el alto real de los datos para
            // que aparezca la barra de desplazamiento y se llegue a todos los campos.
            int altoDatos = Math.Max(groupBox1.Bottom, groupBox2.Bottom) + 16;
            tableLayoutPanel1.AutoScrollMinSize = new Size(1042, altoDatos);
            Control contenedor = tableLayoutPanel1.Parent;
            if (contenedor != null && contenedor != this)
            {
                contenedor.BringToFront();
                if (contenedor is ScrollableControl desplazable)
                    desplazable.AutoScrollMinSize = new Size(desplazable.AutoScrollMinSize.Width,
                        Math.Max(desplazable.AutoScrollMinSize.Height, tableLayoutPanel1.Top + altoDatos + 20));
            }
            try
            {
                txbImpuestos.Text = (21).ToString();
                txbDescuento.Text = (0).ToString();
                CargarComboListaPrecios();
                CargarComboCliente();
                global::AluSoft.UI.Navegacion.Seleccionar(cbxIdCliente, idClienteInicial);
                CargarBitacora(8, 7);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos: " + ex.Message,"AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                if (renglones.Renglones.Count == 0)
                    AgregarRenglon(false);
                if (renglones.Renglones.Count == 0)
                    throw new ArgumentException("Agregá al menos un producto al presupuesto.");
                ActualizarSubTotal();
                presupuesto = new BE.cls07_PresupuestoCliente();
                presupuesto.Idpresupuesto = gpresupuesto.Max(presupuesto) + 1;
                presupuesto.Idcliente = Convert.ToInt32(cbxIdCliente.SelectedValue);
                presupuesto.Idcatalogo = renglones.Renglones[0].IdCatalogo;
                presupuesto.Cantidad = renglones.Renglones[0].Cantidad;
                presupuesto.FechaCreacion =clsValidacionesPerdurables.FechaNoFutura( dateTimePicker1.Value,"Fecha de creación");
                presupuesto.FechaValidez =clsValidacionesPerdurables.FechaPosterior(dateTimePicker2.Value,presupuesto.FechaCreacion, "Fecha de validez");
                presupuesto.Estado = txbEstado.Text;
                presupuesto.Descripcion = renglones.Resumen;
                presupuesto.Observaciones = txbObservaciones.Text;
                presupuesto.Subtotal = renglones.Subtotal;
                presupuesto.Descuento = clsValidacionesPerdurables.SoloNumeros(txbDescuento.Text, "Descuento");
                presupuesto.Impuestos = 21;
                presupuesto.Total = clsValidacionesPerdurables.SoloNumeros( txbTotal.Text, "Total");
                presupuesto.FormaPago = "";
                presupuesto.PlazoEntregaDias =clsValidacionesPerdurables.SoloNumeros( txbPlazoEntrega.Text, "Plazo de entrega");
                int filasAfectadas = gpresupuesto.Agregar(presupuesto);

                if (filasAfectadas != 0)
                {
                    gdetalle.Guardar(presupuesto.Idpresupuesto, renglones.Renglones);
                    MessageBox.Show("Se agregó el presupuesto correctamente.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    CargarBitacora(8, 1);
                    if (global::AluSoft.UI.Navegacion.Preguntar("¿El cliente aceptó el presupuesto? ¿Querés generar el pedido?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm08_PedidoCliente_1(presupuesto.Idpresupuesto));
                        return;
                    }
                    LimpiarControles(this);
                    CargarComboCatalogo();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el presupuesto.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar el presupuesto: " + ex.Message,"AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
            txbImpuestos.Text = "21";
            txbDescuento.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Complete el formulario con los datos correctos y presione guardar. " +
          "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
          "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
          "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }

        private void cbxIdCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BE.cls13_ListaPrecios seleccionado =cbxIdCatalogo.SelectedItem as BE.cls13_ListaPrecios;
            if (seleccionado == null)
                return;
            txbPrecio.Text = seleccionado.Precio.ToString();
            // El presupuesto no depende del stock: lo que falte se fabrica.
            // Se ofrecen al menos 100 unidades aunque el stock esté en 0.
            CargarComboNumeros(cbxCantidades, Math.Max(100, seleccionado.Cantidad));
            cbxCantidades.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cbxCantidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarSubTotal();
        }

        private void txbImpuestos_TextChanged(object sender, EventArgs e)
        {
            ActualizarSubTotal();
        }

        private void txbPrecio_TextChanged(object sender, EventArgs e)
        {
            ActualizarSubTotal();
        }

        private void txbDescuento_TextChanged(object sender, EventArgs e)
        {
            ActualizarSubTotal();
        }
        // [UNIFICADO 3.1.6] Filtra la lista de clientes mientras se escribe.
        private void cbxIdCliente_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdCliente.Text;
                List<BE.cls03_Cliente> filtrados;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    filtrados = listaPersonasOriginal;
                }
                else
                {
                    filtrados = listaPersonasOriginal
                        .Where(x => x.Combo != null &&
                                    x.Combo.IndexOf(
                                        texto,
                                        StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                }
                cbxIdCliente.DataSource = null;
                cbxIdCliente.DataSource = filtrados;
                cbxIdCliente.DisplayMember = "Combo";
                cbxIdCliente.ValueMember = "IdCliente";
                cbxIdCliente.Text = texto;
                cbxIdCliente.SelectionStart = texto.Length;
                cbxIdCliente.SelectionLength = 0;
                cbxIdCliente.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
