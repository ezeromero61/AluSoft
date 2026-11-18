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

namespace AluSoftPresentacion16_6
{
    public partial class frm03_Cliente : Form
    {
        public frm03_Cliente()
        {
            InitializeComponent();
        }
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
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
                    //((ComboBox)control).SelectedIndex = -1;
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

        private void frm03_Cliente_Load(object sender, EventArgs e)
        {
            persona = new BE.cls00_Persona();
            CargarBitacora(4,7);
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbAlto, BLL.Estados.Genero);
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {          
            int fi = 0;
            int fa = 0;
            if (!ValidarCampos()) return;
            try
            {
                persona = new BE.cls00_Persona();
                cliente = new BE.cls03_Cliente();
                persona.Idpersona = (gpersona.Max(persona) + 1);
                cliente.Idcliente = (gcliente.Max(cliente) + 1);
                cliente.Idpersona = persona.Idpersona;
                persona.Idlogin = clsPerdurables.Id_Login;
                persona.Nombre = (txbNombre.Text);
                persona.Apellido = (txbDescripcion.Text);
                persona.Fecha_nacimiento = clsValidacionesPerdurables.FechaNacimiento(DateTime.Parse(dateTimePicker3.Text), "Fecha Nacimiento"); // [CORREGIDO] antes aceptaba la fecha de hoy
                persona.Genero = (txbAlto.Text);
                persona.Domicilio = (txbLargo.Text);
                persona.Correo =(txtAncho.Text);
                persona.Telefono = (clsValidacionesPerdurables.NumeroLargo(txtMaterial.Text, "Telefono"));
                persona.Dni = (clsValidacionesPerdurables.NumeroLargo(txtColor.Text, "Dni"));
                persona.Localidad = (textBox7.Text);
                persona.Idrol = ((clsPerdurables.Id_Rol));
                persona.Fecha_alta = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker1.Text), "Fecha Alta");
                persona.Fecha_baja = null;
                persona.Cuil = (clsValidacionesPerdurables.SoloNumerosDouble((textBox4.Text), "Cuil"));
                fi = gpersona.Agregar(persona);
                fa = gcliente.Agregar(cliente);
                if (fa != 0)
                {
                    MessageBox.Show("El cliente se guardó correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(4, 1);
                    if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés armarle un presupuesto a este cliente?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm07_PresupuestoCliente(cliente.Idcliente));
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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Complete el formulario con los datos correctos y presione guardar. " +
          "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
          "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
          "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }
    }
}
