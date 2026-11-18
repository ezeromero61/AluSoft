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
    public partial class frm03_Cliente_Demo : Form
    {
        public frm03_Cliente_Demo()
        {
            InitializeComponent();
        }
        BE.cls00_Persona persona = new BE.cls00_Persona();
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls03_Cliente cliente = new BE.cls03_Cliente();
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls00_Persona> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private void ComboIndividual(int val)
        {
            dataGridView1.DataSource = gcliente.Listar3(cliente, val);
            dataGridView1.Columns["IdPersona"].Visible = false;
            dataGridView1.Columns["IdCliente"].Visible = false;
            dataGridView1.Columns["IdLogin"].Visible = false;
            dataGridView1.Columns["IdRol"].Visible = false;
            dataGridView1.Columns["DigitoVerificador"].Visible = false;
            dataGridView1.Columns["Combo"].Visible = false;
        }
        private void ComboCompleto()
        {
            dataGridView1.DataSource = gpersona.ListarCatalogo();
            dataGridView1.Columns["Idpersona"].Visible = false;
            dataGridView1.Columns["Idlogin"].Visible = false;
            dataGridView1.Columns["Idrol"].Visible = false;
            dataGridView1.Columns["DigitoVerificador"].Visible = false;
            dataGridView1.Columns["Combo"].Visible = false;
        }
        public void AbrirFormularioEnPanel(Form formulario)
        {
            panel1.Controls.Clear();

            global::AluSoft.UI.AjusteFormularios.PrepararParaPanel(formulario);
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            formulario.FormBorderStyle = FormBorderStyle.None;

            panel1.Controls.Add(formulario);
            panel1.Tag = formulario;
            formulario.Show();
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
        private void CargarCombo()
        {
            cliente = new BE.cls03_Cliente();
            listaPersonasOriginal = gpersona.ListarCatalogo2();
            cbxIdPersona.DataSource = listaPersonasOriginal;
            cbxIdPersona.DisplayMember = "Combo";
            cbxIdPersona.ValueMember = "IdPersona";
            cbxIdPersona.SelectedIndex = -1;
            cbxIdPersona.DropDownStyle = ComboBoxStyle.DropDown;
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
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdPersona);
                if (val != 0)
                {
                    ComboIndividual(val);
                }
                else
                {
                    ComboCompleto();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPersona, "IdCliente,IdPersona");
                CargarBitacora(4, 5);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frm03_Cliente_Demo_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            groupBox2.Enabled = false;
            CargarCombo();
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbGenero, BLL.Estados.Genero);
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
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
                    persona.Apellido = (txbApellido.Text);
                    persona.Fecha_nacimiento = clsValidacionesPerdurables.FechaNacimiento(dateTimePicker3.Value.Date, "Fecha de nacimiento");
                    persona.Genero = (txbGenero.Text);
                    persona.Domicilio = (txbDomicilio.Text);
                    persona.Correo = (txbCorreo.Text);
                    persona.Telefono = (clsValidacionesPerdurables.NumeroLargo(txbTelefono.Text, "Telefono"));
                    persona.Dni = (clsValidacionesPerdurables.NumeroLargo(txbDni.Text, "Dni"));
                    persona.Localidad = (txbLocalidad.Text);
                    persona.Idrol = ((clsPerdurables.Id_Rol));
                    persona.Fecha_alta = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker1.Text), "Fecha Alta");
                    persona.Fecha_baja = null;
                    persona.Cuil = (clsValidacionesPerdurables.SoloNumerosDouble((txbCuil.Text), "Cuil"));
                    fi = gpersona.Agregar(persona);
                    fa = gcliente.Agregar(cliente);
                    if (fa != 0)
                    {
                        ClienteGuardado();
                        return;
                    }
                    MessageBox.Show("La persona se guardó pero no se pudo crear el cliente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el cliente: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int fa = 0;
                if (!ValidarCampos()) return;
                try
                {                 
                    // [CORREGIDO] Antes tomaba siempre la ÚLTIMA persona cargada, no la elegida en la lista.
                    int idPersona = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdPersona);
                    if (idPersona <= 0)
                    {
                        MessageBox.Show("Elegí una persona de la lista.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (gcliente.Listar2().Any(c => c.Idpersona == idPersona))
                    {
                        MessageBox.Show("Esa persona ya está cargada como cliente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    cliente = new BE.cls03_Cliente();
                    cliente.Idcliente = (gcliente.Max(cliente) + 1);
                    cliente.Idpersona = idPersona;
                    fa = gcliente.Agregar(cliente);
                    if (fa != 0)
                    {
                        ClienteGuardado();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }         
        }

        // Después de guardar: ofrece seguir con el presupuesto, igual que la otra pantalla de clientes.
        private void ClienteGuardado()
        {
            MessageBox.Show("El cliente se guardó correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarBitacora(4, 1);
            if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés armarle un presupuesto a este cliente?"))
            {
                global::AluSoft.UI.Navegacion.Abrir(this, new frm07_PresupuestoCliente(cliente.Idcliente));
                return;
            }
            LimpiarControles(this);
            CargarCombo();
            checkBox2.Checked = false;
        }

        private void af_eliminar_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = false;
                groupBox1.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker2.Enabled = true;            
            }
        }

        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }

        private void cbxIdPersona_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdPersona.Text;
                List<BE.cls00_Persona> filtrados;
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
                cbxIdPersona.DataSource = null;
                cbxIdPersona.DataSource = filtrados;
                cbxIdPersona.DisplayMember = "Combo";
                cbxIdPersona.ValueMember = "IdPersona";
                cbxIdPersona.Text = texto;
                cbxIdPersona.SelectionStart = texto.Length;
                cbxIdPersona.SelectionLength = 0;
                cbxIdPersona.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
