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
    public partial class frm04_Proveedor_2 : Form
    {
        public frm04_Proveedor_2()
        {
            InitializeComponent();
        }
        BE.cls04_Proveedor prov = new BE.cls04_Proveedor();
        BLL.Proveedor gprov = new BLL.Proveedor();
        BE.cls00_Persona persona = new BE.cls00_Persona();
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls04_Proveedor> listaPersonasOriginal;
        private bool filtrandoCombo = false;
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
                    ((System.Windows.Forms.ComboBox)control).SelectedIndex = -1;
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
        private void CargarCombo()
        {
            listaPersonasOriginal = gprov.Listar2();
            cbxIdProveedor.DataSource = listaPersonasOriginal;
            cbxIdProveedor.DisplayMember = "Combo";
            cbxIdProveedor.ValueMember = "IdProveedor";
            cbxIdProveedor.SelectedIndex = -1;
            cbxIdProveedor.DropDownStyle = ComboBoxStyle.DropDown;
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
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdProveedor);
                if (val != 0)
                {
                    dataGridView1.DataSource = gprov.Consultar(prov, val);
                }
                else
                {
                    dataGridView1.DataSource = gprov.ListarCatalogo();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdProveedor);
                CargarBitacora(5,5);        
        
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
                if (cbxIdProveedor.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una persona de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdProveedor.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdProveedor.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show(
                        "La persona seleccionada no es válida.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa persona.");
                    return;
                }
                #region 07_Asistencias_Alumnos
                gprov.Consultar(prov, val);

                cbxIdPersona.DataSource = gpersona.Consultar(persona, prov.Idpersona);
                cbxIdPersona.DisplayMember = "Apellido";
                cbxIdPersona.ValueMember = "IdPersona";

                txbNombreEmpresa.Text = prov.Nombre_empresa;
                #endregion
                gprov.Consultar(prov, val);
                CargarBitacora(5,4);               
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdProveedor.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdProveedor.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdProveedor.SelectedValue.ToString(), out val))
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
                #region Cliente
                if (cbxIdPersona.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar una persona de la lista.", "AluSoft",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdPersona.Focus();
                    return;
                }
                int fa = 0;
                prov = new BE.cls04_Proveedor();
                prov.Idproveedor = val;
                prov.Idpersona = int.Parse(cbxIdPersona.SelectedValue.ToString());
                prov.Nombre_empresa = txbNombreEmpresa.Text.Trim();
                string repetido = frm04_Proveedor_1.ProveedorRepetido(prov.Idpersona, prov.Nombre_empresa, prov.Idproveedor);
                if (repetido != null)
                {
                    MessageBox.Show(repetido, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                fa = gprov.Editar(prov);
                if (fa != 0)
                {
                    MessageBox.Show("Se agrego " + fa + " filas.");
                    #region Cliente
                    prov = new BE.cls04_Proveedor();
                    cbxIdProveedor.DataSource = gprov.Listar2();
                    cbxIdProveedor.DisplayMember = "Combo";
                    cbxIdProveedor.ValueMember = "IdProveedor";
                    cbxIdProveedor.Text = null;
                    cbxIdProveedor.DropDownStyle = ComboBoxStyle.DropDown;
                    cbxIdProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbxIdProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
                    #endregion
                    LimpiarControles(this);
                    CargarBitacora(5,2);                  
                }
                else
                {
                    MessageBox.Show("Error");
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdProveedor.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdProveedor.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdProveedor.SelectedValue.ToString(), out val))
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
                #region eliminar cliente
                DialogResult resultado = MessageBox.Show("¿Seguro que querés eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // Se borra el registro ELEGIDO en el combo (antes se borraba el último buscado).
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdProveedor, "un proveedor");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Proveedor", idBorrar, "el proveedor")) return;
                    prov = new BE.cls04_Proveedor();
                    prov.Idproveedor = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gprov.Eliminar(prov), "el proveedor")) return;
                    LimpiarControles(this);
                    CargarCombo();
                    CargarBitacora(5, 3);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }
        private void frm04_Proveedor_2_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarBitacora(5,7);         
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Proveedores a Excel";
                guardar.FileName = "AluSoft_Proveedores_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Proveedores");

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

        private void cbxIdProveedor_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdProveedor.Text;
                List<BE.cls04_Proveedor> filtrados;
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
                cbxIdProveedor.DataSource = null;
                cbxIdProveedor.DataSource = filtrados;
                cbxIdProveedor.DisplayMember = "Combo";
                cbxIdProveedor.ValueMember = "IdProveedor";
                cbxIdProveedor.Text = texto;
                cbxIdProveedor.SelectionStart = texto.Length;
                cbxIdProveedor.SelectionLength = 0;
                cbxIdProveedor.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
