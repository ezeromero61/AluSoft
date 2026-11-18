using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AluSoftPresentacion16_6
{
    public partial class frm08_PedidoCliente_1 : Form
    {
        public frm08_PedidoCliente_1()
        {
            InitializeComponent();
        }

        private int idPresupuestoInicial;

        public frm08_PedidoCliente_1(int idPresupuesto) : this()
        {
            idPresupuestoInicial = idPresupuesto;
        }
        BE.cls08_PedidoCliente pedidocliente;
        BLL.PedidoCliente gpedidocliente = new BLL.PedidoCliente();
        BE.cls07_PresupuestoCliente presupuesto;
        BLL.PresupuestroCliente gpresupuesto = new BLL.PresupuestroCliente();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls26_Combinado> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private void ComboIndividual(int val)
        {
            dataGridView1.DataSource = gpresupuesto.Consultar(presupuesto, val);
            dataGridView1.Columns["Idpresupuesto"].Visible = false;
            dataGridView1.Columns["Idcliente"].Visible = false;
            dataGridView1.Columns["IdCatalogo"].Visible = false;
            dataGridView1.Columns["DigitoVerificador"].Visible = false;
        }
        private void ComboCompleto()
        {
            dataGridView1.DataSource = gpresupuesto.ListarCatalogo();
            dataGridView1.Columns["Idcliente"].Visible = false;
            dataGridView1.Columns["IdCatalogo"].Visible = false;
            dataGridView1.Columns["IdLogin"].Visible = false;
            dataGridView1.Columns["DigitoVerificador"].Visible = false;
        }
        private void CargarCombo()
        {
            listaPersonasOriginal = gpresupuesto.ListarCatalogo2();
            cbxIdPresupuesto.DataSource = listaPersonasOriginal;
            cbxIdPresupuesto.DisplayMember = "IdPresupuesto";
            cbxIdPresupuesto.ValueMember = "IdPresupuesto";
            cbxIdPresupuesto.SelectedIndex = -1;
            cbxIdPresupuesto.DropDownStyle = ComboBoxStyle.DropDown;
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
                if (control is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)control).Clear();
                }
                else if (control is System.Windows.Forms.ComboBox)
                {
                    ((System.Windows.Forms.ComboBox)control).SelectedIndex = -1;
                    ((System.Windows.Forms.ComboBox)control).Text = "";
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
                    if (control is System.Windows.Forms. TextBox)
                    {
                        System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)control;
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            errorProvider1.SetError(textBox, "Tenés que completar este campo.");
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
                int fi = 0;
                int fa = 0;
                if (!ValidarCampos()) return;
                pedidocliente = new BE.cls08_PedidoCliente();
                pedidocliente.IdPedido = (gpedidocliente.Max(pedidocliente) + 1);
                pedidocliente.Idpresupuesto = int.Parse(cbxIdPresupuesto.SelectedValue.ToString());
                pedidocliente.Fechapedido = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker1.Text),"Fecha de pedido");
                pedidocliente.Fechaentregaestimada = clsValidacionesPerdurables.FechaPosterior(dateTimePicker2.Value, pedidocliente.Fechapedido, "Fecha de entrega estimada");
                pedidocliente.Fechaentregareal = clsValidacionesPerdurables.FechaPosterior(dateTimePicker3.Value, pedidocliente.Fechapedido, "Fecha de entrega real");
                pedidocliente.Estado = (txbEstado.Text);
                pedidocliente.Observaciones = (txbObservaciones.Text);
                fa = gpedidocliente.Agregar(pedidocliente);
                if (fa != 0)
                {
                    CargarBitacora(9, 1);
                    gpresupuesto.ActualizarEstado(
                        pedidocliente.Idpresupuesto,
                        BLL.Estados.Presupuesto[1]);
                    List<int> ordenes = new List<int>();
                    string aviso = "";
                    string avisoStock = "";
                    try
                    {
                        ordenes = global::AluSoft.UI.CadenaVenta.GenerarOrdenes(pedidocliente.IdPedido, pedidocliente.Idpresupuesto, out avisoStock);
                        if (ordenes.Count > 0) CargarBitacora(15, 1);
                    }
                    catch (Exception exOrdenes)
                    {
                        aviso = "\nNo se pudieron generar las órdenes de producción: " + exOrdenes.Message;
                    }
                    MessageBox.Show("El pedido se guardó correctamente." +
                        (ordenes.Count > 0 ? "\nSe generaron " + ordenes.Count + " órdenes de producción (una por producto)." : "") + aviso + avisoStock,
                        "AluSoft", MessageBoxButtons.OK,
                        avisoStock.Contains("PRIORIDAD") ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                    if (ordenes.Count > 0)
                    {
                        // Lleva a la primera orden que hay que fabricar, o a la factura si todo salió del stock.
                        global::AluSoft.UI.CadenaVenta.SiguientePaso(this, pedidocliente.IdPedido);
                        if (IsDisposed || Parent == null) return;
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

        private void frm08_PedidoCliente_1_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Pedido, "Confirmado");
            #region Presupuesto cliente
            presupuesto = new BE.cls07_PresupuestoCliente();
            cbxIdPresupuesto.DataSource = null;
            cbxIdPresupuesto.DisplayMember = "Combo";
            cbxIdPresupuesto.ValueMember = "IdPresupuesto";
            cbxIdPresupuesto.DataSource = gpresupuesto.ListarCatalogo2();
            cbxIdPresupuesto.SelectedIndex = -1;
            cbxIdPresupuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdPresupuesto, idPresupuestoInicial);
            #endregion
            CargarBitacora(9, 7);
            global::AluSoft.UI.FechasPedido.Vincular(dateTimePicker1, dateTimePicker2, dateTimePicker3);
            ComboCompleto();//dataGridView1.DataSource = gpresupuesto.ListarCatalogo2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ComboCompleto();//dataGridView1.DataSource = gpresupuesto.ListarCatalogo2();
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPresupuesto, "IdPresupuesto");
                CargarBitacora(9,5);
        
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
