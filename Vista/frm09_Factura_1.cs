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

namespace AluSoftPresentacion16_6
{
    public partial class frm09_Factura_1 : Form
    {
        public frm09_Factura_1()
        {
            InitializeComponent();
        }

        private int idPedidoInicial;
        private int idClientePedido;

        public frm09_Factura_1(int idPedido) : this()
        {
            idPedidoInicial = idPedido;
        }
        BE.cls09_Factura factura;
        BLL.Factura gfactura = new BLL.Factura();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls08_PedidoCliente pedidoCliente;
        BLL.PedidoCliente gpedidocliente = new BLL.PedidoCliente();
        BE.cls16_PedidoReaprovisionamiento reaprov;
        BLL.PedidoReaprovisionamiento greaprov = new BLL.PedidoReaprovisionamiento();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
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
        }
        private void CargarComboPedido()
        {
            pedidoCliente = new BE.cls08_PedidoCliente();
            // Solo pedidos que todavía no tienen factura (no se factura dos veces el mismo pedido).
            HashSet<int> facturados = new HashSet<int>(gfactura.ListarCatalogo().Select(f => f.IdPedido));
            cbxIdPedido.DataSource = gpedidocliente.Listar2().Where(p => !facturados.Contains(p.IdPedido)).ToList();
            cbxIdPedido.DisplayMember = "Combo";
            cbxIdPedido.ValueMember = "IdPedido";
            cbxIdPedido.SelectedIndex = -1;
            cbxIdPedido.DropDownStyle = ComboBoxStyle.DropDown;

        }
        private void CargarComboCliente()
        {
            cliente = new BE.cls03_Cliente();
            listaPersonasOriginal = gcliente.Listar2();

            cbxIdCliente.DataSource = null;
            cbxIdCliente.DisplayMember = "Combo";
            cbxIdCliente.ValueMember = "IdCliente";
            cbxIdCliente.DataSource = listaPersonasOriginal;
            cbxIdCliente.SelectedIndex = -1;
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
        #endregion
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                if (!ValidarCampos()) return;
                int pedidoSeleccionado = Convert.ToInt32(cbxIdPedido.SelectedValue);
                string motivoProduccion;
                if (!global::AluSoft.UI.CadenaVenta.PuedeFacturarPedido(
                        pedidoSeleccionado, out motivoProduccion))
                {
                    MessageBox.Show(motivoProduccion + " No se puede emitir la factura todavía.",
                        "Producción incompleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                factura = new BE.cls09_Factura();
                factura.Idfactura = (gfactura.Max(factura) + 1);
                factura.TipoFactura = string.IsNullOrWhiteSpace(txbTipofactura.Text) ? "B" : txbTipofactura.Text.Trim().ToUpper();
                factura.IdPedido = pedidoSeleccionado;
                if (idClientePedido <= 0)
                    throw new ArgumentException("Elegí un pedido.");
                factura.IdCliente = idClientePedido;
                factura.CondicionIVA = string.IsNullOrWhiteSpace(txbCondicionIVA.Text) ? "Consumidor Final" : txbCondicionIVA.Text;
                factura.DireccionFiscal = txbDireccionFiscal.Text;
                factura.FechaEmision = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker1.Text), "Fecha de emisión");
                factura.FechaVencimiento = clsValidacionesPerdurables.FechaPosterior(dateTimePicker2.Value, factura.FechaEmision, "Fecha de vencimiento");
                factura.Subtotal = clsValidacionesPerdurables.SoloNumeros((txbSubtotal.Text), "Subtotal");
                factura.Descuento = clsValidacionesPerdurables.SoloNumeros(txbDescuento.Text, "");
                factura.IVA = clsValidacionesPerdurables.SoloNumeros(txbIVA.Text, "");
                factura.Total = clsValidacionesPerdurables.SoloNumeros(txbTotal.Text, "");
                factura.Formapago = txbFormaPago.Text;
                factura.Estado = txbEstado.Text;
                factura.CAE = txbCAE.Text;
                factura.FechaVencimientoCAE = factura.FechaEmision;
                factura.Observaciones = txbObservaciones.Text;
                fa = gfactura.Agregar(factura);
                if (fa != 0)
                {
                    MessageBox.Show("La factura se guardó correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(10, 1);
                    if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés registrar el cobro de esta factura?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm10_Cobro_1(factura.Idfactura));
                        return;
                    }
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
        private void frm09_Factura_1_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Factura, "Pendiente");
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbFormaPago, BLL.Estados.FormaPago, "Efectivo");
            CargarComboCliente();
            CargarComboPedido();
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdPedido, idPedidoInicial);
            CargarBitacora(10,7);           
            dataGridView1.DataSource = gfactura.ListarCatalogo2();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = gfactura.ListarCatalogo2();
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPedido, "IdFactura");
                CargarBitacora(10,5);
        
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

        private void cbxIdPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIdPedido.SelectedIndex < 0 || cbxIdPedido.SelectedValue == null)
                return;

            int idPedido;
            if (!int.TryParse(cbxIdPedido.SelectedValue.ToString(), out idPedido))
                return;

            pedidoCliente = new BE.cls08_PedidoCliente();

            DataTable datos = gpedidocliente.Consultar(pedidoCliente, idPedido);

            if (datos == null || datos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos para el pedido seleccionado.");
                return;
            }
            idClientePedido = pedidoCliente.Idcliente;
            cbxIdCliente.SelectedValue = pedidoCliente.Idcliente;
            txbDireccionFiscal.Text = pedidoCliente.Direccion;
            txbSubtotal.Text = pedidoCliente.Subtotal.ToString();
            txbDescuento.Text = pedidoCliente.Descuento.ToString();
            txbIVA.Text = (pedidoCliente.Total - (pedidoCliente.Subtotal - pedidoCliente.Descuento)).ToString();
            txbTotal.Text = pedidoCliente.Total.ToString();
            if (!string.IsNullOrWhiteSpace(pedidoCliente.FormaPago)) txbFormaPago.Text = pedidoCliente.FormaPago;
            txbEstado.Text = "Pendiente";
            txbObservaciones.Text = pedidoCliente.Observaciones;
        }
    }
}
