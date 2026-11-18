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

namespace AluSoftPresentacion16_6
{
    public partial class frm16_PedidoReaprovisionamiento : Form
    {

            private int idPresupuestoInicial;
            public frm16_PedidoReaprovisionamiento(int idPresupuesto) : this()
            {
                idPresupuestoInicial = idPresupuesto;
            }

            public frm16_PedidoReaprovisionamiento()
            {
                InitializeComponent();

                errorProvider1.ContainerControl = this;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            }

            private BE.cls18_PresupuestoProveedor presupuesto =
                new BE.cls18_PresupuestoProveedor();

            private BLL.PresupuestoProveedor gpresupuesto =
                new BLL.PresupuestoProveedor();

            private BE.cls35_Bitacora bitacora;
            private BLL.Bitacora gbitacora = new BLL.Bitacora();

            private BE.cls04_Proveedor proveedor;
            private BLL.Proveedor gproveedor = new BLL.Proveedor();

            private BE.cls16_PedidoReaprovisionamiento pedido;
            private BLL.PedidoReaprovisionamiento gpedido =
                new BLL.PedidoReaprovisionamiento();

            private List<BE.cls04_Proveedor> listaPersonasOriginal;
            private List<BE.cls18_PresupuestoProveedor> listaPersonasOriginal2;

            #region Cálculos

            private void ActualizarSubtotalYTotal()
            {
                decimal cantidad;
                decimal precio;
                decimal porcentajeIVA;

                if (!decimal.TryParse(
                        txbCantidad.Text,
                        NumberStyles.Number,
                        CultureInfo.CurrentCulture,
                        out cantidad) ||
                    !decimal.TryParse(
                        txbPrecio.Text,
                        NumberStyles.Number,
                        CultureInfo.CurrentCulture,
                        out precio) ||
                    !decimal.TryParse(
                        txbIVA.Text,
                        NumberStyles.Number,
                        CultureInfo.CurrentCulture,
                        out porcentajeIVA))
                {
                    txbSubtotal.Clear();
                    txbTotal.Clear();
                    return;
                }

                if (cantidad < 0 || precio < 0 || porcentajeIVA < 0)
                {
                    txbSubtotal.Clear();
                    txbTotal.Clear();
                    return;
                }

                decimal subtotal = Math.Round(
                    cantidad * precio,
                    0,
                    MidpointRounding.AwayFromZero);

                decimal importeIVA = subtotal * porcentajeIVA / 100m;

                decimal total = Math.Round(
                    subtotal + importeIVA,
                    0,
                    MidpointRounding.AwayFromZero);

                txbSubtotal.Text = subtotal.ToString(
                    "0",
                    CultureInfo.CurrentCulture);

                txbTotal.Text = total.ToString(
                    "0",
                    CultureInfo.CurrentCulture);
            }

            private void txbCantidad_TextChanged(object sender, EventArgs e)
            {
                ActualizarSubtotalYTotal();
            }

            private void txbPrecio_TextChanged(object sender, EventArgs e)
            {
                ActualizarSubtotalYTotal();
            }

            private void txbIVA_TextChanged(object sender, EventArgs e)
            {
                ActualizarSubtotalYTotal();
            }

            #endregion

            #region Carga de combos

            private void CargarComboPresupuesto()
            {
                listaPersonasOriginal2 = gpresupuesto.ListarCatalogo2();

                cbxIdPresupuestoProveedor.DataSource = listaPersonasOriginal2;
                cbxIdPresupuestoProveedor.DisplayMember = "Combo";
                cbxIdPresupuestoProveedor.ValueMember = "IdPresupuestoProveedor";
                cbxIdPresupuestoProveedor.SelectedIndex = -1;
                cbxIdPresupuestoProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            private void CargarComboProveedor()
            {
                listaPersonasOriginal = gproveedor.Listar2();

                cbxIdProveedor.DataSource = listaPersonasOriginal;
                cbxIdProveedor.DisplayMember = "Combo";
                cbxIdProveedor.ValueMember = "IdProveedor";
                cbxIdProveedor.SelectedIndex = -1;
                cbxIdProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            #endregion

            #region Validación

            private void MarcarError(
                Control control,
                string mensaje,
                ref bool valido,
                ref Control primerControlInvalido)
            {
                errorProvider1.SetError(control, mensaje);

                if (primerControlInvalido == null)
                    primerControlInvalido = control;

                valido = false;
            }

            private void ValidarCombo(
                ComboBox combo,
                string nombreCampo,
                ref bool valido,
                ref Control primerControlInvalido)
            {
                int valor;

                if (combo.SelectedIndex < 0 ||
                    combo.SelectedValue == null ||
                    combo.SelectedValue == DBNull.Value ||
                    !int.TryParse(
                        Convert.ToString(combo.SelectedValue),
                        out valor) ||
                    valor <= 0)
                {
                    MarcarError(
                        combo,
                        "Seleccioná " + nombreCampo + ".",
                        ref valido,
                        ref primerControlInvalido);
                }
            }

            private void ValidarTexto(
                TextBox textBox,
                string nombreCampo,
                ref bool valido,
                ref Control primerControlInvalido)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MarcarError(
                        textBox,
                        "Completá " + nombreCampo + ".",
                        ref valido,
                        ref primerControlInvalido);
                }
            }

            private void ValidarEntero(
                TextBox textBox,
                string nombreCampo,
                int minimo,
                int maximo,
                ref bool valido,
                ref Control primerControlInvalido)
            {
                int numero;

                if (!int.TryParse(
                        textBox.Text,
                        NumberStyles.Integer,
                        CultureInfo.CurrentCulture,
                        out numero))
                {
                    MarcarError(
                        textBox,
                        nombreCampo + " debe ser un número entero.",
                        ref valido,
                        ref primerControlInvalido);
                    return;
                }

                if (numero < minimo || numero > maximo)
                {
                    MarcarError(
                        textBox,
                        nombreCampo + " debe estar entre " +
                        minimo + " y " + maximo + ".",
                        ref valido,
                        ref primerControlInvalido);
                }
            }

            private bool ValidarCampos()
            {
                errorProvider1.Clear();

                bool valido = true;
                Control primerControlInvalido = null;

                // Solo se validan los campos necesarios para guardar el pedido.
                ValidarCombo(
                    cbxIdPresupuestoProveedor,
                    "un presupuesto de proveedor",
                    ref valido,
                    ref primerControlInvalido);

                ValidarCombo(
                    cbxIdProveedor,
                    "un proveedor",
                    ref valido,
                    ref primerControlInvalido);

                ValidarEntero(
                    txbCantidad,
                    "La cantidad",
                    1,
                    int.MaxValue,
                    ref valido,
                    ref primerControlInvalido);

                ValidarEntero(
                    txbPrecio,
                    "El precio",
                    0,
                    int.MaxValue,
                    ref valido,
                    ref primerControlInvalido);

                ValidarEntero(
                    txbIVA,
                    "El IVA",
                    0,
                    100,
                    ref valido,
                    ref primerControlInvalido);

                ValidarTexto(
                    txbEstado,
                    "el estado",
                    ref valido,
                    ref primerControlInvalido);

                ValidarTexto(
                    txbPrioridad,
                    "la prioridad",
                    ref valido,
                    ref primerControlInvalido);

                if (valido)
                {
                    // Se recalculan aquí para no depender de que los eventos
                    // TextChanged estén conectados desde el diseñador.
                    ActualizarSubtotalYTotal();

                    ValidarEntero(
                        txbSubtotal,
                        "El subtotal calculado",
                        0,
                        int.MaxValue,
                        ref valido,
                        ref primerControlInvalido);

                    ValidarEntero(
                        txbTotal,
                        "El total calculado",
                        0,
                        int.MaxValue,
                        ref valido,
                        ref primerControlInvalido);
                }

                if (!valido && primerControlInvalido != null)
                    primerControlInvalido.Focus();

                return valido;
            }

            #endregion

            #region Bitácora y limpieza

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

            private void LimpiarControles(Control contenedor)
            {
                if (contenedor == this)
                    errorProvider1.Clear();

                foreach (Control control in contenedor.Controls)
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Clear();
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).SelectedIndex = -1;
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
                        LimpiarControles(control);
                }
            }

            #endregion

            private void alum_guardar_Click(object sender, EventArgs e)
            {
                try
                {
                    if (!ValidarCampos())
                    {
                        MessageBox.Show(
                            "Revisá los campos marcados con el ícono de advertencia.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    pedido = new BE.cls16_PedidoReaprovisionamiento();

                    pedido.Idpedidoreaprovisionamiento = gpedido.Max(pedido) + 1;
                    pedido.IdPresupuestoProveedor =
                        Convert.ToInt32(cbxIdPresupuestoProveedor.SelectedValue);
                    pedido.Idproveedor =
                        Convert.ToInt32(cbxIdProveedor.SelectedValue);

                    pedido.Fechapedido = dateTimePicker1.Value;
                    pedido.Fechaentregaestimada = dateTimePicker2.Value;
                    pedido.Fechaentregareal = dateTimePicker3.Value;

                    pedido.Cantidad = int.Parse(
                        txbCantidad.Text,
                        CultureInfo.CurrentCulture);

                    pedido.Precio = int.Parse(
                        txbPrecio.Text,
                        CultureInfo.CurrentCulture);

                    pedido.IVA = int.Parse(
                        txbIVA.Text,
                        CultureInfo.CurrentCulture);

                    pedido.Subtotal = int.Parse(
                        txbSubtotal.Text,
                        CultureInfo.CurrentCulture);

                    pedido.Total = int.Parse(
                        txbTotal.Text,
                        CultureInfo.CurrentCulture);

                    pedido.Estado = txbEstado.Text.Trim();
                    pedido.Prioridad = txbPrioridad.Text.Trim();

                    // Observaciones es opcional.
                    pedido.Observaciones = txbObservaciones.Text.Trim();

                    pedido.Idlogin = clsPerdurables.Id_Login;
                    pedido.DigitoVerificador = 1;

                    int filasAfectadas = gpedido.Agregar(pedido);

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show(
                            "Se agregó el pedido correctamente.",
                            "AluSoft",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CargarBitacora(17, 1);
                        if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés registrar la compra de este pedido?"))
                        {
                            global::AluSoft.UI.Navegacion.Abrir(this, new frm17_Compras_1(pedido.Idpedidoreaprovisionamiento));
                            return;
                        }
                        LimpiarControles(this);
                        CargarComboPresupuesto();
                        txbEstado.Text = BLL.Estados.Reaprovisionamiento[0];
                        txbPrioridad.Text = BLL.Estados.Prioridad[1];
                    }
                    else
                    {
                        MessageBox.Show(
                            "No se agregó el pedido. La operación no afectó filas.",
                            "AluSoft",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo guardar el pedido: " + ex.Message,
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            private void frm16_PedidoReaprovisionamiento_Load(
                object sender,
                EventArgs e)
            {               
                CargarComboPresupuesto();
                CargarComboProveedor();
                CargarBitacora(17, 7);
                LimpiarControles(this);
                global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Reaprovisionamiento, BLL.Estados.Reaprovisionamiento[0]);
                global::AluSoft.UI.EstadosCombo.Reemplazar(txbPrioridad, BLL.Estados.Prioridad, BLL.Estados.Prioridad[1]);
                global::AluSoft.UI.Navegacion.Seleccionar(cbxIdPresupuestoProveedor, idPresupuestoInicial);
            }

            private void af_tabla_Click(object sender, EventArgs e)
            {
                try
                {
                    int idProveedor;

                    if (cbxIdProveedor.SelectedValue != null &&
                        int.TryParse(
                            Convert.ToString(cbxIdProveedor.SelectedValue),
                            out idProveedor) &&
                        idProveedor > 0)
                    {
                        proveedor = new BE.cls04_Proveedor();
                        dataGridView1.DataSource =
                            gproveedor.Consultar(proveedor, idProveedor);
                    }
                    else
                    {
                        dataGridView1.DataSource = gproveedor.ListarCatalogo();
                    }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdProveedor);

                    CargarBitacora(17, 5);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo completar la operación: " + ex.Message,
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            private void button2_Click(object sender, EventArgs e)
            {
                MessageBox.Show(
                    "Completá el formulario con los datos del pedido y presioná Guardar. " +
                    "Las observaciones son opcionales.",
                    "Ayuda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            private void cbxIdPresupuestoProveedor_SelectedIndexChanged(
                object sender,
                EventArgs e)
            {
                BE.cls18_PresupuestoProveedor seleccionado =cbxIdPresupuestoProveedor.SelectedItem as BE.cls18_PresupuestoProveedor;

                if (seleccionado == null)
                    return;

                // Al seleccionar el presupuesto, se completan proveedor,
                // precio y cantidad desde ese registro.
                if (cbxIdProveedor.DataSource != null)
                {
                    cbxIdProveedor.SelectedValue = seleccionado.Idproveedor;
                }

                txbPrecio.Text = seleccionado.Precio.ToString(
                    CultureInfo.CurrentCulture);

                txbCantidad.Text = seleccionado.Cantidad.ToString(
                    CultureInfo.CurrentCulture);

                txbIVA.Text = seleccionado.Iva.ToString(
                    CultureInfo.CurrentCulture);
            }

            private void alum_limpiar_Click(object sender, EventArgs e)
            {
                LimpiarControles(this);
            }
        }
    }
    
