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
    public partial class frm15_Estado_1 : Form
    {
        public frm15_Estado_1()
        {
            InitializeComponent();
        }
        private int idOrdenInicial;
        public frm15_Estado_1(int idOrden) : this()
        {
            idOrdenInicial = idOrden;
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls15_Estado estado = new BE.cls15_Estado();
        BLL.Estado gestado = new BLL.Estado();
        BE.cls14_OrdenProduccion op = new BE.cls14_OrdenProduccion();
        BLL.OrdenProduccion gop = new BLL.OrdenProduccion();
        #region Auxiliares
        private List<BE.cls14_OrdenProduccion> listaPersonasOriginal;
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
                else if (control is System.Windows.Forms. CheckBox)
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
            listaPersonasOriginal = gop.ListarCatalogo2();
            cbxIdOrdeProduccion.DataSource = listaPersonasOriginal;
            cbxIdOrdeProduccion.DisplayMember = "Combo";
            cbxIdOrdeProduccion.ValueMember = "IdOrdenProduccion";
            cbxIdOrdeProduccion.SelectedIndex = -1;
            cbxIdOrdeProduccion.DropDownStyle = ComboBoxStyle.DropDown;
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
                estado = new BE.cls15_Estado();
                if (!ValidarCampos()) return;
                estado.Idestado = (gestado.Max(estado) + 1);
                estado.Idordenproduccion = clsValidacionesPerdurables.SoloNumeros(cbxIdOrdeProduccion.SelectedValue.ToString(),"Id Orden de producción");
                BE.cls14_OrdenProduccion orden = cbxIdOrdeProduccion.SelectedItem as BE.cls14_OrdenProduccion;
                estado.Fechaorden = orden != null && orden.Fechaorden.Year > 1900 ? orden.Fechaorden : DateTime.Today;
                estado.Fechainicioproduccion = clsValidacionesPerdurables.FechaObligatoria(dateTimePicker2.Value.Date, "Fecha de inicio");
                bool termino = global::AluSoft.UI.FechasEstado.Termino(txbEstado.Text);
                estado.Fechafinproduccion = termino
                    ? clsValidacionesPerdurables.FechaPosterior(dateTimePicker3.Value.Date, dateTimePicker2.Value.Date, "Fecha de fin")
                    : DateTime.MinValue;
                estado.Fechaentrega = txbEstado.Text == "Entregado" ? estado.Fechafinproduccion : DateTime.MinValue;
                estado.Estado = txbEstado.Text;
                estado.Observaciones = (txbObservaciones.Text);
                fa = gestado.Agregar(estado);
                if (fa != 0)
                {
                    MessageBox.Show("El estado se guardó correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(16, 1);
                    if (orden != null && orden.IdPedido > 0)
                    {
                        global::AluSoft.UI.CadenaVenta.SiguientePaso(this, orden.IdPedido, orden.Idordenproduccion);
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

        private void frm15_Estado_1_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Produccion, "Pendiente");
            CargarCombo();
            CargarBitacora(16,7);
            global::AluSoft.UI.FechasEstado.Configurar(txbEstado, dateTimePicker3, checkBox1);
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdOrdeProduccion, idOrdenInicial);
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdOrdeProduccion);
                if (val != 0)
                {
                    dataGridView1.DataSource = gop.Consultar(op, val);
                }
                else
                {
                    dataGridView1.DataSource = gop.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdOrdeProduccion);
                CargarBitacora(16, 5);
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                dateTimePicker4.Enabled = true;
            }
            else
            {
                dateTimePicker4.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker3.Enabled = true;
            }
            else
            {
                dateTimePicker3.Enabled = false;
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
