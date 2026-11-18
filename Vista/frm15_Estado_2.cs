using BLL;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
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
    public partial class frm15_Estado_2 : Form
    {
        public frm15_Estado_2()
        {
            InitializeComponent();
        }
        BE.cls14_OrdenProduccion op = new BE.cls14_OrdenProduccion();
        BLL.OrdenProduccion gop = new BLL.OrdenProduccion();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls15_Estado estado= new BE.cls15_Estado();
        BLL.Estado gestado = new BLL.Estado();
        #region Auxiliares
        private List<BE.cls15_Estado> listaPersonasOriginal;
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
                    ((ComboBox)control).SelectedIndex =-1;
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
            listaPersonasOriginal = gestado.ListarCatalogo2();
            cbxIdEstado.DataSource = listaPersonasOriginal;
            cbxIdEstado.DisplayMember = "Combo";
            cbxIdEstado.ValueMember = "IdEstado";
            cbxIdEstado.SelectedIndex = -1;
            cbxIdEstado.DropDownStyle = ComboBoxStyle.DropDown;
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
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdEstado);
                if (val != 0)
                {
                    dataGridView1.DataSource = gestado.Consultar(estado, val);
                }
                else
                {
                    dataGridView1.DataSource = gestado.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdEstado);
                if (val != 0)
                    global::AluSoft.UI.FiltroReporte.OcultarTotales(dataGridView1);
                else
                    global::AluSoft.UI.FiltroReporte.Mostrar(dataGridView1, "estados de producción", "Fechainicioproduccion",
                        "Producto=Nombre;Estado=Estado", "");
                CargarBitacora(16,5);
        
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
                if (cbxIdEstado.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un estado de la lista.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdEstado.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdEstado.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El estado seleccionado no es válida.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese estado.");
                    return;
                }
                #region 07_Asistencias_Alumnos
                gestado.Consultar(estado, val);

                cbxIdOrdeProduccion.SelectedValue = estado.Idordenproduccion;

                if (estado.Fechainicioproduccion.Year > 1900) dateTimePicker2.Value = estado.Fechainicioproduccion;
                txbEstado.Text = estado.Estado;
                if (estado.Fechafinproduccion.Year > 1900) dateTimePicker3.Value = estado.Fechafinproduccion;
                txbObservaciones.Text = estado.Observaciones.ToString();
                #endregion 
                dataGridView1.DataSource = gestado.ListarCatalogo2();
                CargarBitacora(16, 4);    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdEstado.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdEstado.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdEstado.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show( "El elemento seleccionado no es válido.","AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                #region Cliente
                int fa = 0;;
                estado.Idordenproduccion = clsValidacionesPerdurables.SoloNumeros(cbxIdOrdeProduccion.SelectedValue.ToString(), "Id Orden de producción");
                if (estado.Fechaorden.Year < 1900) estado.Fechaorden = DateTime.Today;
                estado.Fechainicioproduccion = clsValidacionesPerdurables.FechaObligatoria(dateTimePicker2.Value.Date, "Fecha de inicio");
                bool termino = global::AluSoft.UI.FechasEstado.Termino(txbEstado.Text);
                estado.Fechafinproduccion = termino
                    ? clsValidacionesPerdurables.FechaPosterior(dateTimePicker3.Value.Date, dateTimePicker2.Value.Date, "Fecha de fin")
                    : DateTime.MinValue;
                estado.Fechaentrega = txbEstado.Text == "Entregado" ? estado.Fechafinproduccion : DateTime.MinValue;
                estado.Estado = txbEstado.Text;
                estado.Observaciones = (txbObservaciones.Text);
                fa = gestado.Editar(estado);
                if (fa != 0)
                {
                    MessageBox.Show("Estado modificado correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(16,2);
                    CargarCombo();
                    LimpiarControles(this);
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
                if (cbxIdEstado.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdEstado.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdEstado.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdEstado, "un estado");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Estado", idBorrar, "el estado")) return;
                    estado = new BE.cls15_Estado();
                    estado.Idestado = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gestado.Eliminar(estado), "el estado")) return;
                    LimpiarControles(this);
                    CargarCombo();
                    CargarBitacora(16, 3);
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
        private void frm15_Estado_2_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Produccion);
            CargarBitacora(16,7);
            CargarCombo();
            global::AluSoft.UI.FechasEstado.Configurar(txbEstado, dateTimePicker3, checkBox1, checkBox2);
            cbxIdEstado.DropDownWidth = 480;
            // La orden se completa sola al elegir el estado (sin tener que tocar Buscar).
            cbxIdOrdeProduccion.DataSource = gop.ListarCatalogo2();
            cbxIdOrdeProduccion.DisplayMember = "Combo";
            cbxIdOrdeProduccion.ValueMember = "IdOrdenProduccion";
            cbxIdOrdeProduccion.SelectedIndex = -1;
            cbxIdOrdeProduccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxIdOrdeProduccion.DropDownWidth = 420;
            cbxIdEstado.SelectionChangeCommitted += (s, ev) =>
            {
                if (cbxIdEstado.SelectedItem is BE.cls15_Estado) af_buscar_Click(s, ev);
            };
            // Las fechas vacías (fin y entrega de una producción sin terminar) se muestran en blanco.
            dataGridView1.CellFormatting += (s, ev) =>
            {
                if (ev.Value is DateTime && ((DateTime)ev.Value).Year < 1900) { ev.Value = ""; ev.FormattingApplied = true; }
            };
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Estados de Produccion a Excel";
                guardar.FileName = "AluSoft_Estados_de_Produccion_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Estados de Produccion");

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
            MessageBox.Show("Este formulario es de gestión de datos ya cargados en el sistema, puede buscarlos, enlistarlos, modificarlos y borrarlos. " +
                "Complete el formulario con los datos correctos y presione el botón con la acción que va a realizar. " +
                "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
                "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
                "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.");
        }

        private void cbxIdEstado_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdEstado.Text;
                List<BE.cls15_Estado> filtrados;
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
                cbxIdEstado.DataSource = null;
                cbxIdEstado.DataSource = filtrados;
                cbxIdEstado.DisplayMember = "Combo";
                cbxIdEstado.ValueMember = "IdEstado";
                cbxIdEstado.Text = texto;
                cbxIdEstado.SelectionStart = texto.Length;
                cbxIdEstado.SelectionLength = 0;
                cbxIdEstado.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
