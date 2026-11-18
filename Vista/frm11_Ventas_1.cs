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
    public partial class frm11_Ventas_1 : Form
    {
        public frm11_Ventas_1()
        {
            InitializeComponent();
        }

        private int idCobroInicial;

        public frm11_Ventas_1(int idCobro) : this()
        {
            idCobroInicial = idCobro;
        }
        BE.cls06_Venta venta;
        BLL.Ventas gventa = new BLL.Ventas();
        BE.cls09_Factura factura = new BE.cls09_Factura();
        BLL.Factura gfactura = new BLL.Factura();
        BE.cls08_PedidoCliente pedido;
        BLL.PedidoCliente gpedido = new BLL.PedidoCliente();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls10_Cobro cobro;
        BLL.Cobro gcobro = new BLL.Cobro();
        #region Auxiliares
        private List<BE.cls03_Cliente> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private void CargarCombosRelacionados()
        {
            cbxIdPedido.DataSource = null;
            cbxIdPedido.DisplayMember = "Combo";
            cbxIdPedido.ValueMember = "IdPedido";
            cbxIdPedido.DataSource = gpedido.Listar2();
            cbxIdPedido.SelectedIndex = -1;

            cbxIdCliente.DataSource = null;
            cbxIdCliente.DisplayMember = "Combo";
            cbxIdCliente.ValueMember = "IdCliente";
            cbxIdCliente.DataSource = gcliente.Listar2();
            cbxIdCliente.SelectedIndex = -1;
        }
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
                if (control.Visible && control.Enabled && !global::AluSoft.UI.ValidacionCampos.EsOpcional(control))
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
        private List<BE.cls10_Cobro> listaCobros;

        private void CargarComboCobro()
        {
            listaCobros = gcobro.ListarCatalogo2();
            cbxIdCobro.DataSource = null;
            cbxIdCobro.DisplayMember = "Combo";
            cbxIdCobro.ValueMember = "Idcobro";
            cbxIdCobro.DataSource = listaCobros;
            cbxIdCobro.SelectedIndex = -1;
            cbxIdCobro.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void CargarCombo()
        {
            factura = new BE.cls09_Factura();
            cbxIdFactura.DataSource = gfactura.ListarCatalogo2();
            cbxIdFactura.DisplayMember = "Combo";
            cbxIdFactura.ValueMember = "IdFactura";
            cbxIdFactura.Text = null;
            cbxIdFactura.DropDownStyle = ComboBoxStyle.DropDown;
        }
        #endregion
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                if (!ValidarCampos()) return;
                venta = new BE.cls06_Venta();
                venta.Idventa = (gventa.Max(venta) + 1);
                venta.IdPedido = clsValidacionesPerdurables.SoloNumeros(cbxIdPedido.SelectedValue.ToString(),"Id Pedido");
                venta.Idfactura = clsValidacionesPerdurables.SoloNumeros(cbxIdFactura.SelectedValue.ToString(),"Id Factura");
                venta.IdCliente = clsValidacionesPerdurables.SoloNumeros(cbxIdCliente.SelectedValue.ToString(),"Id Cliente");
                venta.IdCobro = clsValidacionesPerdurables.SoloNumeros(cbxIdCobro.SelectedValue.ToString(),"Id Cobro");
                venta.FechaVenta = clsValidacionesPerdurables.FechaNoFutura(DateTime.Parse(dateTimePicker1.Text),"Fecha venta");
                venta.FechaEntrega = clsValidacionesPerdurables.FechaPosterior(dateTimePicker2.Value, venta.FechaVenta, "Fecha de entrega");
                venta.Subtotal = clsValidacionesPerdurables.SoloNumeros(txbSubtotal.Text,"Subtotal");
                venta.Descuento = clsValidacionesPerdurables.SoloNumeros(txbDescuento.Text,"Descuento");
                venta.Impuestos = clsValidacionesPerdurables.SoloNumeros(txbImpuestos.Text,"Impuesto");
                venta.Total = clsValidacionesPerdurables.SoloNumeros(txbTotal.Text,"Total");
                venta.TotalCobrado = clsValidacionesPerdurables.SoloNumeros(txbTotalCobrado.Text,"Total Cobrado");
                venta.SalfoPendiente = clsValidacionesPerdurables.SoloNumeros(txbSaldoPendiente.Text,"Saldo Pendiente");
                venta.Estado = venta.SalfoPendiente <= 0 ? "Pagada" : "Pendiente";
                venta.Observaciones = txbObservaciones.Text;
                fa = gventa.Agregar(venta);
                if (fa != 0)
                {
                    MessageBox.Show("La venta se registró correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(12, 1);
                    LimpiarControles(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);           
        }

        private void frm11_Ventas_1_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarCombosRelacionados();
            CargarComboCobro();
            txbTotalCobrado.ReadOnly = true;
            txbSaldoPendiente.ReadOnly = true;
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdCobro, idCobroInicial);
            CargarBitacora(12, 7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = gventa.ListarCatalogo2();
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPedido, "IdVenta");
                CargarBitacora(12,5);   
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Complete el formulario con los datos correctos y presione guardar. " +
          "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
          "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
          "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }

        private void cbxIdFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIdFactura.SelectedIndex < 0 || cbxIdFactura.SelectedValue == null)
                return;

            int idFactura;
            if (!int.TryParse(cbxIdFactura.SelectedValue.ToString(), out idFactura))
                return;

            factura = new BE.cls09_Factura();

            DataTable datos = gfactura.Consultar(factura, idFactura);

            if (datos == null || datos.Rows.Count == 0)
                return;

            cbxIdPedido.SelectedValue = factura.IdPedido;
            cbxIdCliente.SelectedValue = factura.IdCliente;

            txbSubtotal.Text = factura.Subtotal.ToString();
            txbDescuento.Text = factura.Descuento.ToString();
            txbImpuestos.Text = factura.IVA.ToString();
            txbTotal.Text = factura.Total.ToString();
            txbEstado.Text = factura.Estado;
            txbObservaciones.Text = factura.Observaciones;
        }

        private void cbxIdCobro_SelectedIndexChanged(object sender, EventArgs e)
        {
            BE.cls10_Cobro cobroSeleccionado =cbxIdCobro.SelectedItem as BE.cls10_Cobro;

            if (cobroSeleccionado == null)
                return;

            cbxIdFactura.SelectedValue = cobroSeleccionado.Idfactura;
            cbxIdPedido.SelectedValue = cobroSeleccionado.IdPedido;
            cbxIdCliente.SelectedValue = cobroSeleccionado.IdCliente;

            txbSubtotal.Text = cobroSeleccionado.Subtotal.ToString();
            txbDescuento.Text = cobroSeleccionado.Descuento.ToString();
            txbImpuestos.Text = cobroSeleccionado.IVA.ToString();
            txbTotal.Text = cobroSeleccionado.Total.ToString();
            txbEstado.Text = cobroSeleccionado.Estado;
            txbObservaciones.Text = cobroSeleccionado.Observaciones;

            decimal totalCobrado = listaCobros
                .Where(c => c.Idfactura == cobroSeleccionado.Idfactura)
                .Sum(c => c.Importe);

            txbTotalCobrado.Text = totalCobrado.ToString();
            txbSaldoPendiente.Text =
                (cobroSeleccionado.Total - totalCobrado).ToString();
        }
    }
}
