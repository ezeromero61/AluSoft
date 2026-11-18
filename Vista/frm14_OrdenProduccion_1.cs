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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AluSoftPresentacion16_6
{
    public partial class frm14_OrdenProduccion_1 : Form
    {
        public frm14_OrdenProduccion_1()
        {
            InitializeComponent();
        }

        private void RegistrarEstadoInicial(BE.cls14_OrdenProduccion orden)
        {
            try
            {
                global::AluSoft.UI.CadenaVenta.RegistrarEstadoInicial(orden);
            }
            catch (Exception ex)
            {
                MessageBox.Show("La orden se guardó, pero no se pudo registrar su estado inicial: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls14_OrdenProduccion op;
        BLL.OrdenProduccion gop = new BLL.OrdenProduccion();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        #region Auxiliares
        private List<BE.cls02_Stock> listaPersonasOriginal;
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
            stock = new BE.cls02_Stock();
            listaPersonasOriginal = gstock.ListarCatalogo2();
            cbxIdStock.DataSource = listaPersonasOriginal;
            cbxIdStock.DisplayMember = "Nombre";
            cbxIdStock.ValueMember = "IdStock";
            cbxIdStock.SelectedIndex = -1;
            cbxIdStock.DropDownStyle = ComboBoxStyle.DropDown;
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
                    ValidarControlesRecursivamente(control,ref valido,ref primerControlInvalido);
                }
            }
        }

        #endregion

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                op = new BE.cls14_OrdenProduccion();
                if (!ValidarCampos()) return;
                op.Idordenproduccion = (gop.Max(op) + 1);
                op.Fechaorden = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker1.Value.ToString()), "Fecha de orden");
                op.Idstock = clsValidacionesPerdurables.SoloNumeros(cbxIdStock.SelectedValue.ToString(), "Id Stock");
                op.Cantidad = clsValidacionesPerdurables.SoloNumeros(txbCantidad.Text, "Cantidad");
                op.IdPedido = 0;   // el alta manual es solo de reposición de stock
                op.Observaciones = string.IsNullOrWhiteSpace(txbObservaciones.Text)
                    ? "Reposición de stock" : txbObservaciones.Text;
                fa = gop.Agregar(op);
                if (fa != 0)
                {
                    RegistrarEstadoInicial(op);
                    MessageBox.Show("La orden de producción se guardó correctamente. Estado: Pendiente." +
                        "\nEs una orden de reposición de stock (sin pedido): al terminarla se suma al stock.",
                        "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(15, 1);
                    if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés registrar la producción de esta orden?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm21_Produccion_1(op.Idordenproduccion));
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

        private void frm14_OrdenProduccion_1_Load(object sender, EventArgs e)
        {
            CargarCombo();
            // El alta manual de órdenes es solo para reponer stock: no se asocia a un pedido.
            // Las órdenes de los pedidos se generan solas al guardar el pedido de cliente.
            // El aviso de stock se conecta después de cargar el combo, para que la carga inicial
            // no complete una cantidad sugerida.
            cbxIdStock.SelectedIndexChanged += cbxIdStock_SelectedIndexChanged;
            CargarBitacora(15, 7);
        }

        // Orden sin pedido (reposición de stock): al elegir el producto se muestra su stock
        // y se sugiere producir lo que falta para llegar al máximo.
        private void cbxIdStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            BE.cls02_Stock s = cbxIdStock.SelectedItem as BE.cls02_Stock;
            if (s == null) { lblStockOrden.Text = ""; return; }
            lblStockOrden.ForeColor = s.Cantidad_actual < s.Cantidad_minima ? Color.Firebrick : Color.FromArgb(0, 102, 153);
            lblStockOrden.Text = "Stock actual: " + s.Cantidad_actual + "  ·  mínimo: " + s.Cantidad_minima +
                "  ·  máximo: " + s.Cantidad_maxima +
                (s.Cantidad_actual < s.Cantidad_minima ? "  ⚠ bajo stock" : "") +
                "\nOrden de reposición de stock.";
            int sugerida = s.Cantidad_maxima - s.Cantidad_actual;
            if (sugerida > 0) txbCantidad.Text = sugerida.ToString();
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdStock);
                if (val != 0)
                {
                    dataGridView1.DataSource = gstock.Consultar(stock, val);
                }
                else
                {
                    dataGridView1.DataSource = gstock.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdStock);
                CargarBitacora(15, 5);
        
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
