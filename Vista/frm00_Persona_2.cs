using BLL;
using ClosedXML.Excel;
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
    public partial class frm00_Persona_2 : Form
    {
        public frm00_Persona_2()
        {
            InitializeComponent();
            ConfigurarControlesAcceso();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls07_PresupuestoCliente presupuesto;
        BLL.PresupuestroCliente gpresupuesto = new BLL.PresupuestroCliente();
        private BLL.Rol gestorRoles = new BLL.Rol();

        // El recuadro "Acceso y rol" está en el diseño. Solo el rol 2 puede cambiar accesos.
        private void ConfigurarControlesAcceso()
        {
            chkCambiarAcceso.Enabled = clsPerdurables.Id_Rol == 2;
            CargarRolesAcceso();
            ActualizarControlesAcceso();
        }

        private void chkCambiarAcceso_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarControlesAcceso();
        }

        private void CargarRolesAcceso()
        {
            cbxRolAcceso.DisplayMember = "Nombre";
            cbxRolAcceso.ValueMember = "IdRol";
            cbxRolAcceso.DataSource = gestorRoles.ListarRol()
                .Where(r => r.IdRol == 1 || r.IdRol == 3 || r.IdRol == 4)
                .ToList();
            cbxRolAcceso.SelectedIndex = -1;
        }

        private void ActualizarControlesAcceso()
        {
            bool habilitado = chkCambiarAcceso.Enabled && chkCambiarAcceso.Checked;
            cbxRolAcceso.Enabled = habilitado;
            bool necesitaCuenta = habilitado && persona != null && persona.Idlogin <= 0;
            txbUsuarioAcceso.Enabled = necesitaCuenta;
            txbContrasenaAcceso.Enabled = necesitaCuenta;
        }

        private void MostrarAccesoActual()
        {
            cbxRolAcceso.SelectedValue = persona != null && persona.Idrol > 0 ? (object)persona.Idrol : null;
            if (persona == null || cbxIdPersona.SelectedIndex < 0)
                lblEstadoAcceso.Text = "Seleccioná una persona para ver su acceso.";
            else if (persona.Idlogin > 0)
                lblEstadoAcceso.Text = "Esta persona ya tiene una cuenta. Al guardar, se actualizará su rol.";
            else
                lblEstadoAcceso.Text = "Esta persona no tiene cuenta. Completá usuario y contraseña para habilitar el acceso.";
            ActualizarControlesAcceso();
        }
        #region Auxiliares
        private List<BE.cls00_Persona> listaPersonasOriginal;
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
        private void CargarCombo()
        {
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
                            errorProvider1.SetError( textBox,"Tenés que completar este campo.");
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
                            errorProvider1.SetError( comboBox,"Tenés que seleccionar una opción.");
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
        private void frm00_Persona_2_Load(object sender, EventArgs e)
        {
            persona = new BE.cls00_Persona();
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbGenero, BLL.Estados.Genero);
            CargarBitacora(1,7);
            CargarCombo();
            checkBox1.Checked = false;
            dateTimePicker3.Enabled = false;
            ActualizarControlesAcceso();
        }
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdPersona);
                if (val != 0)
                {
                    dataGridView1.DataSource = gpersona.Consultar(persona, val);
                }
                else
                {
                    dataGridView1.DataSource = gpersona.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPersona);
                CargarBitacora(1,5);
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void af_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdPersona.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdPersona.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPersona.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show( "El elemento seleccionado no es válido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese elemento.");
                    return;
                }
                chkCambiarAcceso.Checked = false;
                #region 07_Asistencias_Alumnos
                gpersona.Consultar(persona, val);
                txbNombre.Text = Convert.ToString(persona.Nombre);
                txbApellido.Text = Convert.ToString(persona.Apellido);
                dateTimePicker1.Text = Convert.ToString(persona.Fecha_nacimiento);
                txbGenero.Text = Convert.ToString(persona.Genero);
                txbDomicilio.Text = Convert.ToString(persona.Domicilio);
                txbCorreo.Text = Convert.ToString(persona.Correo);
                txbTelefono.Text = Convert.ToString(persona.Telefono);
                txbDni.Text = Convert.ToString(persona.Dni);
                txbLocalidad.Text = Convert.ToString(persona.Localidad);
                dateTimePicker2.Text = Convert.ToString(persona.Fecha_alta);
                dateTimePicker3.Text = Convert.ToString(persona.Fecha_baja);
                txbCuil.Text = Convert.ToString(persona.Cuil);
                MostrarAccesoActual();
                #endregion 
                dataGridView1.DataSource = gpersona.Consultar(persona, val);
                CargarBitacora(1, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft", MessageBoxButtons.OK,  MessageBoxIcon.Error);
            }           
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdPersona.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdPersona.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPersona.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show( "El elemento seleccionado no es válido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                #region Modificar persona              
                persona.Nombre = (txbNombre.Text);
                persona.Apellido = (txbApellido.Text);
                persona.Fecha_nacimiento = clsValidacionesPerdurables.FechaNacimiento(DateTime.Parse(dateTimePicker1.Text), "Fecha de nacimiento"); // [CORREGIDO] antes aceptaba la fecha de hoy
                persona.Genero = (txbGenero.Text);
                persona.Domicilio = txbDomicilio.Text;
                persona.Correo = (txbCorreo.Text);
                persona.Telefono = clsValidacionesPerdurables.NumeroLargo(txbTelefono.Text, "Teléfono");
                persona.Dni = clsValidacionesPerdurables.NumeroLargo(txbDni.Text,"DNI");
                persona.Localidad = txbLocalidad.Text;
                persona.Fecha_alta = clsValidacionesPerdurables.FechaNoFutura(DateTime.Parse(dateTimePicker2.Text), "Fecha de alta");
                persona.Fecha_baja = clsValidacionesPerdurables.FechaPosterior(DateTime.Parse(dateTimePicker3.Text), persona.Fecha_alta, "Fecha de baja");
                persona.Cuil = clsValidacionesPerdurables.SoloNumerosDouble(txbCuil.Text, "Cuil");
                fa = gpersona.Editar(persona);               
                if (fa != 0)
                {
                    if (chkCambiarAcceso.Checked)
                    {
                        int nuevoRol = Convert.ToInt32(cbxRolAcceso.SelectedValue);
                        if (persona.Idlogin > 0)
                            gpersona.ActualizarRolAcceso(persona.Idpersona, persona.Idlogin, nuevoRol);
                        else
                            gpersona.AsignarAcceso(persona.Idpersona, nuevoRol, txbUsuarioAcceso.Text, txbContrasenaAcceso.Text);
                        persona.Idrol = nuevoRol;
                    }
                    MessageBox.Show("Los datos de la persona se guardaron correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(1, 2);
                    CargarCombo();
                    LimpiarControles(this);
                    persona = new BE.cls00_Persona();
                    MostrarAccesoActual();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }         
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Seguro que querés eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // Se borra el registro ELEGIDO en el combo (antes se borraba el último buscado).
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdPersona, "una persona");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Persona", idBorrar, "la persona")) return;
                    persona = new BE.cls00_Persona();
                    persona.Idpersona = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gpersona.Eliminar(persona), "la persona")) return;
                    LimpiarControles(this);
                    CargarBitacora(1,3);
                }
                else
                {
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
            persona = new BE.cls00_Persona();
            MostrarAccesoActual();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked== true)
            {
                dateTimePicker3.Enabled = true;
            }
            else
            {
                dateTimePicker3.Enabled = false;
            }
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Personas a Excel";
                guardar.FileName = "AluSoft_Personas_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Personas");

                        for (int columna = 0; columna < dataGridView1.Columns.Count; columna++)
                        {
                            if (dataGridView1.Columns[columna].Visible)
                            {
                                hoja.Cell(1, columna + 1).Value =
                                    dataGridView1.Columns[columna].HeaderText;
                            }
                        }

                        int filaExcel = 2;

                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            if (fila.IsNewRow)
                                continue;

                            for (int columna = 0; columna < dataGridView1.Columns.Count; columna++)
                            {
                                if (!dataGridView1.Columns[columna].Visible)
                                    continue;

                                object valor = fila.Cells[columna].Value;
                                var celda = hoja.Cell(filaExcel, columna + 1);

                                if (valor == null || valor == DBNull.Value)
                                {
                                    celda.Value = "";
                                }
                                else if (valor is DateTime fecha)
                                {
                                    celda.Value = fecha;
                                    celda.Style.DateFormat.Format = "dd/MM/yyyy";
                                }
                                else if (valor is bool booleano)
                                {
                                    celda.Value = booleano;
                                }
                                else if (valor is byte || valor is short || valor is int ||
                                         valor is long || valor is float || valor is double ||
                                         valor is decimal)
                                {
                                    celda.Value = Convert.ToDouble(valor);
                                }
                                else
                                {
                                    celda.Value = valor.ToString();
                                }
                            }

                            filaExcel++;
                        }

                        hoja.Columns().AdjustToContents();
                        libro.SaveAs(guardar.FileName);
                    }

                    }
                    MessageBox.Show("La tabla se exportó correctamente.",
                        "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo exportar la tabla: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este formulario es de gestión de datos ya cargados en el sistema, puede buscarlos, enlistarlos, modificarlos y borrarlos. " +
                "Complete el formulario con los datos correctos y presione el botón con la acción que va a realizar. " +
                "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
                "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
                "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.");
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
