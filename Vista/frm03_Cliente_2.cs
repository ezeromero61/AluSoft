using BLL;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Vml;
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
    public partial class frm03_Cliente_2 : Form
    {
        public frm03_Cliente_2()
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
        private void ComboIndividual(int val)
        {
            dataGridView1.DataSource = gcliente.Listar3(cliente,val);
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
        private void LimpiarControles(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)control).Clear();
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
            listaPersonasOriginal = gcliente.Listar2();
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
                    if (control is System.Windows.Forms.TextBox)
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
        private void af_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdPersona.SelectedValue == null)
                {
                    MessageBox.Show( "Debe seleccionar un elemento de la lista.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdPersona.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPersona.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show( "El elemento seleccionado no es válido.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese elemento.");
                    return;
                }
                gcliente.ConsultarIdPersonaIdCliente(cliente, val);
                cliente.Idpersona = val;
                txbNombre.Text = (cliente.Nombre);
                txbApellido.Text = (cliente.Apellido);
                dateTimePicker3.Value = (cliente.Fecha_nacimiento);
                txbGenero.Text = (cliente.Genero);
                txbDomicilio.Text = (cliente.Domicilio);
                txbCorreo.Text = (cliente.Correo);
                txbTelefono.Text = Convert.ToString(cliente.Telefono);
                txbDni.Text = (Convert.ToString(cliente.Dni));
                txbLocalidad.Text = (cliente.Localidad);
                dateTimePicker1.Value = cliente.Fecha_alta;
                dateTimePicker2.Value = DateTime.Today;
                txbCuil.Text = Convert.ToString((Convert.ToString(cliente.Cuil)));
                ComboIndividual(val);
                CargarBitacora(4,4);               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frm03_Cliente_2_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbGenero, BLL.Estados.Genero);
            comboBox1.DataSource = clsIdiomas.CambiarIdiomas(clsPerdurables.numerodeidioma);
            comboBox1.SelectedItem = clsPerdurables.StringIdiomaSeleccionado(clsPerdurables.numerodeidioma);
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            CargarCombo();
            CargarBitacora(4, 7);
            checkBox1.Checked = false;
            dateTimePicker2.Enabled = false;
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdPersona.SelectedValue == null)
                {
                    MessageBox.Show( "Debe seleccionar un elemento de la lista.", "AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdPersona.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPersona.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show( "El elemento seleccionado no es válido.","AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                gcliente.ConsultarIdUsuario(cliente, cliente.Idpersona);
                int fa = 0;
                int fu = 0;

                persona.Idpersona = int.Parse(cbxIdPersona.SelectedValue.ToString());
                cliente.Idcliente = cliente.Idcliente;
                cliente.Idpersona = int.Parse(cbxIdPersona.SelectedValue.ToString());
                persona.Idlogin = clsPerdurables.Id_Login;
                persona.Nombre = (txbNombre.Text);              
                persona.Apellido= (txbApellido.Text);
                persona.Fecha_nacimiento = clsValidacionesPerdurables.FechaNacimiento(DateTime.Parse(dateTimePicker3.Text), "Fecha Nacimiento"); // [CORREGIDO] no validaba la fecha
                persona.Genero = (txbGenero.Text);
                persona.Domicilio = (txbDomicilio.Text);
                persona.Correo = (txbCorreo.Text);
                persona.Telefono = (clsValidacionesPerdurables.NumeroLargo(txbTelefono.Text, "Telefono"));
                persona.Dni = (clsValidacionesPerdurables.NumeroLargo(txbDni .Text, "Dni"));
                persona.Localidad = (txbLocalidad.Text);
                persona.Idrol = ((clsPerdurables.Id_Rol));
                persona.Fecha_alta = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker1.Text), "Fecha Alta");
                persona.Fecha_baja = clsValidacionesPerdurables.FechaNoFutura(DateTime.Parse(dateTimePicker2.Text), "Fecha Baja");
                persona.Cuil = (double.Parse(txbCuil.Text));
                fa = gcliente.Editar(cliente);
                fu = gpersona.Editar(persona);
                if (fa != 0)
                {
                    MessageBox.Show("Se agrego " + fa + " filas.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(4,2);
                    CargarCombo();
                    LimpiarControles(this);
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
            cbxIdPersona.SelectedIndex = -1;
            comboBox1.DataSource = clsIdiomas.CambiarIdiomas(clsPerdurables.numerodeidioma);
            comboBox1.SelectedItem = clsPerdurables.StringIdiomaSeleccionado(clsPerdurables.numerodeidioma);
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdPersona.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdPersona.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPersona.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show(
                        "El elemento seleccionado no es válido.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                DialogResult resultado = MessageBox.Show("¿Seguro que querés eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // El combo elige la persona: se busca su cliente. Ya no se borra la persona (puede ser usuario o proveedor).
                    int idPersonaElegida = global::AluSoft.UI.Borrado.IdElegido(cbxIdPersona, "un cliente");
                    if (idPersonaElegida <= 0) return;
                    BE.cls03_Cliente elegido = gcliente.Listar2().FirstOrDefault(c => c.Idpersona == idPersonaElegida);
                    if (elegido == null) { MessageBox.Show("Esa persona no está cargada como cliente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    int idBorrar = elegido.Idcliente;
                    if (!global::AluSoft.UI.Borrado.SePuede("Cliente", idBorrar, "el cliente")) return;
                    cliente = new BE.cls03_Cliente();
                    cliente.Idcliente = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gcliente.Eliminar(cliente), "el cliente")) return;
                    LimpiarControles(this);
                    CargarCombo();
                    CargarBitacora(4,3);                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbxIdPersona_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdPersona.Text;
                List<BE.cls03_Cliente> filtrados;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker2.Enabled = true;
            }
            else
            {
                dateTimePicker2.Enabled = false;
            }
        }

        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Clientes a Excel";
                guardar.FileName = "AluSoft_Clientes_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Clientes");

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsPerdurables.numerodeidioma = clsPerdurables.IdiomaSeleccionado(comboBox1.SelectedItem.ToString());
            switch (clsPerdurables.numerodeidioma)
            {
                case 1:
                    af_Titulo_Gestion.Text = "Gestión de Cliente";
                    af_id_alumno.Text = "Persona:";
                    af_id_if.Text = "Nombre:";
                    af_fecha.Text = "Apellido:";
                    af_nota.Text = "Fecha de Nacimiento:";
                    af_nro_intento.Text = "Genero:";
                    af_id_carrera.Text = "Domicilio:";
                    af_id_materia.Text = "Correo:";
                    label3.Text = "Teléfono:";
                    label1.Text = "DNI:";
                    label4.Text = "Localidad:";
                    label2.Text = "Fecha de Alta:";
                    label5.Text = "Fecha de Baja:";
                    label7.Text = "CUIL:";
                    af_buscar.Text = "Buscar";
                    af_modificar.Text = "Guardar";
                    af_eliminar.Text = "Eliminar";
                    af_limpiar.Text = "Borrar";
                    af_tabla.Text = "Ver tabla";
                    bita_exportar.Text = "Exportar";
                    break;
                case 2:
                    af_Titulo_Gestion.Text = "Customer Management";
                    af_id_alumno.Text = "Person:";
                    af_id_if.Text = "First Name:";
                    af_fecha.Text = "Last Name:";
                    af_nota.Text = "Date of Birth:";
                    af_nro_intento.Text = "Gender:";
                    af_id_carrera.Text = "Address:";
                    af_id_materia.Text = "Email:";
                    label3.Text = "Phone:";
                    label1.Text = "National ID:";
                    label4.Text = "City:";
                    label2.Text = "Registration Date:";
                    label5.Text = "Deactivation Date:";
                    label7.Text = "CUIL:";
                    af_buscar.Text = "Search";
                    af_modificar.Text = "Save";
                    af_eliminar.Text = "Delete";
                    af_limpiar.Text = "Clear";
                    af_tabla.Text = "View Table";
                    bita_exportar.Text = "Export";
                    break;
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
    }
}
