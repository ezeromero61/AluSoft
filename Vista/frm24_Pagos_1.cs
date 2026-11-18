using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AluSoftPresentacion16_6
{
    public partial class frm24_Pagos_1 : Form
    {
        public frm24_Pagos_1()
        {
            InitializeComponent();
        }
        BE.cls24_Pagos pago;
        BLL.Pagos gpago = new BLL.Pagos();
        BE.cls09_Factura factura;
        BLL.Factura gfactura = new BLL.Factura();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls03_Cliente> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private void CargarBitacora(int tabla, int accion)
        {
            #region Bitacora 
            int fu;
            bitacora = new BE.cls35_Bitacora();
            bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
            bitacora.idlogin = clsPerdurables.Id_Login;
            bitacora.idtabla = tabla;
            bitacora.idaccion = accion;
            bitacora.fecha = (DateTime.Now);
            bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
            fu = gbitacora.Agregar(bitacora);
            #endregion
        }
        private void LimpiarControles(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                    ((ComboBox)control).Text = "";
                }
                else if (control is System.Windows.Forms.CheckBox)
                {
                    ((System.Windows.Forms.CheckBox)control).Checked = false;
                }
                else if (control is System.Windows.Forms.RadioButton)
                {
                    ((System.Windows.Forms.RadioButton)control).Checked = false;
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
        }
        private void CargarCombo()
        {
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
                primerControlInvalido.Focus();
            return valido;
        }
        private void ValidarControlesRecursivamente(Control contenedor, ref bool valido, ref Control primerControlInvalido)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control.Visible && control.Enabled && !global::AluSoft.UI.ValidacionCampos.EsOpcional(control) && control != txbObservaciones && control != txbNumeroComprobante)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            errorProvider1.SetError(textBox, "Tenés que completar este campo.");
                            if (primerControlInvalido == null)
                                primerControlInvalido = textBox;
                            valido = false;
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)control;
                        if (comboBox.SelectedIndex == -1)
                        {
                            errorProvider1.SetError(comboBox, "Tenés que seleccionar una opción.");
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

        #endregion
        private int idCompraInicial;
        private BLL.Proveedor gproveedor = new BLL.Proveedor();
        private BLL.Compras gcompras = new BLL.Compras();
        private List<BE.cls17_Compras> listaCompras;

        public frm24_Pagos_1(int idCompra) : this()
        {
            idCompraInicial = idCompra;
        }

        private void cbxIdFactura_CompraElegida(object sender, EventArgs e)
        {
            BE.cls17_Compras compra = cbxIdFactura.SelectedItem as BE.cls17_Compras;
            if (compra == null) return;
            if (compra.IdProveedor > 0)
                cbxIdCliente.SelectedValue = compra.IdProveedor;
            else
                cbxIdCliente.SelectedIndex = -1;
            decimal saldo = compra.Saldo > 0 ? compra.Saldo : 0;
            nudImporte.Value = Math.Min(saldo, nudImporte.Maximum);
            if (saldo <= 0)
                MessageBox.Show("Esta compra ya está pagada en su totalidad.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            pago = new BE.cls24_Pagos();
            if (!ValidarCampos()) return;
            BE.cls17_Compras compra = cbxIdFactura.SelectedItem as BE.cls17_Compras;
            try
            {
                if (compra == null)
                    throw new ArgumentException("Elegí la compra que se paga.");
                if (nudImporte.Value <= 0)
                    throw new ArgumentException("El importe tiene que ser mayor a 0.");
                if (nudImporte.Value > compra.Saldo)
                    throw new ArgumentException("El importe no puede superar el saldo de la compra ($" + compra.Saldo.ToString("0") + ").");
                pago.IdPago = (gpago.Max(pago)+1);
                pago.IdProveedor = Convert.ToInt32(cbxIdCliente.SelectedValue);
                pago.IdCompras = compra.Idcompras;
                pago.FechaPago = dtpFechaPago.Value;
                pago.Importe = nudImporte.Value;
                pago.FormaPago = cbxFormaPago.Text;
                // Si no se carga comprobante, se numera la orden de pago automáticamente.
                pago.NumeroComprobante = string.IsNullOrWhiteSpace(txbNumeroComprobante.Text)
                    ? "OP-0001-" + (pago.IdPago + 300).ToString("000000")
                    : txbNumeroComprobante.Text.Trim();
                pago.Observaciones = txbObservaciones.Text;
                pago.Anulado = false;
                fa = gpago.Agregar(pago);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el pago: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fa != 0)
            {
                decimal resta = compra.Saldo - pago.Importe;
                MessageBox.Show("El pago se guardó correctamente." + (resta > 0 ? " Queda un saldo de $" + resta.ToString("0") + "." : " La compra quedó pagada."), "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarBitacora(25,1);
                LimpiarControles(this);
                errorProvider1.Clear();
                cbxFormaPago.SelectedIndex = 0;
                CargarCompras();
            }
            else
            {
                MessageBox.Show("No se pudo guardar el pago.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarCompras()
        {
            // No ofrecer compras canceladas ni totalmente pagadas.
            listaCompras = gcompras.ListarCatalogo2()
                .Where(c => c.Saldo > 0)
                .OrderBy(c => c.Fecha)
                .ThenBy(c => c.Idcompras)
                .ToList();
            cbxIdFactura.DataSource = null;
            cbxIdFactura.DisplayMember = "Combo";
            cbxIdFactura.ValueMember = "Idcompras";
            cbxIdFactura.DataSource = listaCompras;
            cbxIdFactura.SelectedIndex = -1;
            cbxIdFactura.DropDownStyle = ComboBoxStyle.DropDownList;
            // [CORREGIDO] Al recargar la lista, el combo elegía la primera compra un instante y dejaba
            // cargados su proveedor y su importe aunque no hubiera compra seleccionada.
            // (en un combo enlazado a datos hay que pedir -1 dos veces para que quede vacío)
            cbxIdCliente.SelectedIndex = -1;
            cbxIdCliente.SelectedIndex = -1;
            nudImporte.Value = Math.Max(nudImporte.Minimum, Math.Min(0, nudImporte.Maximum));
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
            errorProvider1.Clear();
            cbxFormaPago.SelectedIndex = 0;
        }

        private void frm24_Pagos_1_Load(object sender, EventArgs e)
        {
            // La anulación de pagos se quitó: los pagos nuevos nunca se cargan anulados.
            chkAnulado.Checked = false;
            chkAnulado.Visible = false;
            cbxFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFormaPago.Items.Clear();
            cbxFormaPago.Items.AddRange(BLL.Estados.FormaPago);
            cbxFormaPago.SelectedIndex = 0;
            lblcbxIdCliente.Text = "Proveedor:";
            lblcbxIdFactura.Text = "Compra:";
            nudImporte.Maximum = 1000000000;
            nudImporte.DecimalPlaces = 0;
            cbxIdCliente.DataSource = null;
            cbxIdCliente.DisplayMember = "Combo";
            cbxIdCliente.ValueMember = "IdProveedor";
            cbxIdCliente.DataSource = gproveedor.Listar2();
            cbxIdCliente.SelectedIndex = -1;
            cbxIdCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarCompras();
            cbxIdFactura.SelectedIndexChanged += cbxIdFactura_CompraElegida;
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdFactura, idCompraInicial);
            CargarBitacora(25,7);
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdCliente);
                if (val != 0)
                {
                    dataGridView1.DataSource = gproveedor.Consultar(new BE.cls04_Proveedor(), val);
                }
                else
                {
                    dataGridView1.DataSource = gproveedor.ListarCatalogo();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdCliente, "IdProveedor");
                CargarBitacora(25, 5);
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Complete el formulario con los datos correctos y presione guardar. " +
          "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
          "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
          "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }
    }
}
