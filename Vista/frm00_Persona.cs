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
    public partial class frm00_Persona : Form
    {
        public frm00_Persona()
            : this(false)
        {
        }

        public frm00_Persona(bool habilitarAsignacionAcceso)
        {
            InitializeComponent();
            puedeAsignarAcceso = habilitarAsignacionAcceso && clsPerdurables.Id_Rol == 2;
            ConfigurarAcceso();
        }
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private List<BE.cls21_Produccion> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private bool puedeAsignarAcceso;
        private readonly BLL.Rol gestorRoles = new BLL.Rol();
        private GroupBox grupoAcceso;
        private CheckBox chkAsignarAcceso;
        private ComboBox cbxRolAcceso;
        private TextBox txbUsuarioAcceso;
        private TextBox txbContrasenaAcceso;

        private void ConfigurarAcceso()
        {
            grupoAcceso = new GroupBox { Name = "grupoAcceso", Text = "Acceso al sistema", Location = new Point(15, 145), Size = new Size(580, 245), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            chkAsignarAcceso = new CheckBox { Name = "chkAsignarAcceso", Text = "Crear una cuenta para esta persona", Location = new Point(14, 25), AutoSize = true, TabIndex = 0 };
            Label lblRol = new Label { Text = "Rol:", Location = new Point(16, 61), AutoSize = true, TabIndex = 1 };
            cbxRolAcceso = new ComboBox { Name = "cbxRolAcceso", Location = new Point(175, 57), Size = new Size(375, 28), DropDownStyle = ComboBoxStyle.DropDownList, TabIndex = 2 };
            Label lblUsuario = new Label { Text = "Usuario:", Location = new Point(16, 97), AutoSize = true, TabIndex = 3 };
            txbUsuarioAcceso = new TextBox { Name = "txbUsuarioAcceso", Location = new Point(175, 93), Size = new Size(375, 26), MaxLength = 50, TabIndex = 4 };
            Label lblContrasena = new Label { Text = "Contraseña inicial:", Location = new Point(16, 133), AutoSize = true, TabIndex = 5 };
            txbContrasenaAcceso = new TextBox { Name = "txbContrasenaAcceso", Location = new Point(175, 129), Size = new Size(375, 26), MaxLength = 255, UseSystemPasswordChar = true, TabIndex = 6 };
            Label lblAyuda = new Label { Text = "La persona podrá cambiarla luego desde Seguridad.", Location = new Point(16, 171), AutoSize = true, ForeColor = SystemColors.GrayText, TabIndex = 7 };
            grupoAcceso.Controls.AddRange(new Control[] { chkAsignarAcceso, lblRol, cbxRolAcceso, lblUsuario, txbUsuarioAcceso, lblContrasena, txbContrasenaAcceso, lblAyuda });
            groupBox1.Controls.Add(grupoAcceso);
            chkAsignarAcceso.CheckedChanged += (sender, e) => ActualizarControlesAcceso();
            chkAsignarAcceso.Enabled = puedeAsignarAcceso;
            grupoAcceso.Enabled = puedeAsignarAcceso;
            if (puedeAsignarAcceso)
                CargarRolesAcceso();
            ActualizarControlesAcceso();
        }

        private void CargarRolesAcceso()
        {
            List<BE.cls25_Rol> roles = gestorRoles.ListarRol()
                .Where(r => r.IdRol == 1 || r.IdRol == 3 || r.IdRol == 4)
                .ToList();
            cbxRolAcceso.DisplayMember = "Nombre";
            cbxRolAcceso.ValueMember = "IdRol";
            cbxRolAcceso.DataSource = roles;
            cbxRolAcceso.SelectedIndex = -1;
        }

        private void ActualizarControlesAcceso()
        {
            bool habilitado = puedeAsignarAcceso && chkAsignarAcceso.Checked;
            cbxRolAcceso.Enabled = habilitado;
            txbUsuarioAcceso.Enabled = habilitado;
            txbContrasenaAcceso.Enabled = habilitado;
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
                    ((ComboBox)control).Text = "";
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
        
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                int fa = 0;
                persona = new BE.cls00_Persona();
                persona.Idpersona = (gpersona.Max(persona) + 1);
                persona.Idlogin = 0;
                persona.Nombre = (txbNombre.Text);
                persona.Apellido = (txbApellido.Text);
                persona.Fecha_nacimiento = clsValidacionesPerdurables.FechaNacimiento(DateTime.Parse(dateTimePicker3.Text), "Fecha de nacimiento"); // [CORREGIDO] antes aceptaba la fecha de hoy
                persona.Genero = (txbGenero.Text);
                persona.Domicilio = txbDomicilio.Text;
                persona.Correo = (txbCorreo.Text);
                persona.Telefono = clsValidacionesPerdurables.NumeroLargo(txbTelefono.Text,"Teléfono");
                persona.Dni = clsValidacionesPerdurables.NumeroLargo(txbDni.Text, "Dni");
                persona.Localidad = txbLocalidad.Text;
                persona.Idrol = 0;
                persona.Fecha_alta = clsValidacionesPerdurables.FechaNoFutura(DateTime.Parse(dateTimePicker1.Text), "Fecha de alta");
                persona.Cuil = clsValidacionesPerdurables.SoloNumerosDouble(txbCuil.Text,"Cuil");
                if (chkAsignarAcceso.Checked && puedeAsignarAcceso)
                {
                    persona.Idrol = Convert.ToInt32(cbxRolAcceso.SelectedValue);
                    fa = gpersona.AgregarConAcceso(persona, txbUsuarioAcceso.Text, txbContrasenaAcceso.Text);
                }
                else
                {
                    fa = gpersona.Agregar(persona);
                }
                if (fa != 0)
                {
                    MessageBox.Show("La persona se guardó correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(1,1);
                    LimpiarControles(this);
                }
                else
                {
                    MessageBox.Show("Error");
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frm00_Persona_Load(object sender, EventArgs e)
        {
            CargarBitacora(1,7);
            ActualizarControlesAcceso();
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbGenero, BLL.Estados.Genero);
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
