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
    public partial class frm12_Catalogo_2 : Form
    {
        public frm12_Catalogo_2()
        {
            InitializeComponent();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls12_Catalogo catalogo = new BE.cls12_Catalogo();
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls01_Inventario inventario;
        BLL.Inventario ginv = new BLL.Inventario();
        #region Auxiliares
        private List<BE.cls12_Catalogo> listaPersonasOriginal;
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
        private void CargarCombo()
        {
            listaPersonasOriginal = gcatalogo.Listar2();
            cbxIdCatalogo.DataSource = listaPersonasOriginal;
            cbxIdCatalogo.DisplayMember = "Nombre";
            cbxIdCatalogo.ValueMember = "IdCatalogo";
            cbxIdCatalogo.Text = null;
            cbxIdCatalogo.DropDownStyle = ComboBoxStyle.DropDown;
        }
        #endregion
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdCatalogo);
                if (val != 0)
                {
                    dataGridView1.DataSource = gcatalogo.Consultar(catalogo, val);
                }
                else
                {
                    dataGridView1.DataSource = gcatalogo.Listar2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdCatalogo);
                CargarBitacora(13,5);
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void frm12_Catalogo_2_Load(object sender, EventArgs e)
        {
            // La cantidad es la del Stock real (script 11): se muestra, pero se modifica desde Stock.
            txbCantidad.ReadOnly = true;
            CargarCombo();
            CargarBitacora(13,7);
        }
        private void af_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdCatalogo.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una persona de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdCatalogo.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdCatalogo.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("La persona seleccionada no es válida.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa persona.");
                    return;
                }
                #region 07_Asistencias_Alumnos
                gcatalogo.Consultar(catalogo, val);
                txbPrecioUnitario.Text = (catalogo.Preciounitario.ToString());
                txbDisponibilidad.Text = catalogo.Disponibilidad.ToString();
                txbCantidad.Text = catalogo.Cantidad.ToString();
                #endregion 
                gcatalogo.Consultar(catalogo, val);
                CargarBitacora(13,4);
                dataGridView1.DataSource= gcatalogo.Consultar(catalogo, val);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdCatalogo.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdCatalogo.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdCatalogo.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.","AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                #region Cliente
                int fa = 0;
                catalogo.Preciounitario = clsValidacionesPerdurables.SoloNumeros(txbPrecioUnitario.Text, "Precio unitario");
                catalogo.Disponibilidad = txbDisponibilidad.Text;
                catalogo.Cantidad = clsValidacionesPerdurables.SoloNumeros(txbCantidad.Text, "Cantidad");
                fa = gcatalogo.Editar(catalogo);
                if (fa != 0)
                {
                    MessageBox.Show("Se agrego " + fa + " filas.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCombo();
                    LimpiarControles(this);
                    CargarBitacora(13,2);     
                }
                else
                {
                    MessageBox.Show("Error");
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Ocurrió un error: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdCatalogo.SelectedValue == null)
                {
                    MessageBox.Show( "Debe seleccionar un elemento de la lista.", "AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdCatalogo.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdCatalogo.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdCatalogo, "un producto del catálogo");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Catalogo", idBorrar, "el producto del catálogo")) return;
                    catalogo = new BE.cls12_Catalogo();
                    catalogo.Idcatalogo = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gcatalogo.Eliminar(catalogo), "el producto del catálogo")) return;
                    LimpiarControles(this);
                    CargarCombo();
                    CargarBitacora(13,3);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);         
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Catalogo a Excel";
                guardar.FileName = "AluSoft_Catalogo_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Catalogo");

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
        private void cbxIdCatalogo_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdCatalogo.Text;
                List<BE.cls12_Catalogo> filtrados;
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
                cbxIdCatalogo.DataSource = null;
                cbxIdCatalogo.DataSource = filtrados;
                cbxIdCatalogo.DisplayMember = "Nombre";
                cbxIdCatalogo.ValueMember = "IdCatalogo";
                cbxIdCatalogo.Text = texto;
                cbxIdCatalogo.SelectionStart = texto.Length;
                cbxIdCatalogo.SelectionLength = 0;
                cbxIdCatalogo.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
