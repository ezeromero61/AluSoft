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
    public partial class frm02_Stock_2 : Form
    {
        public frm02_Stock_2()
        {
            InitializeComponent();
        }
        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();
        BE.cls02_Stock stock=new BE.cls02_Stock();
        BLL.Stock gstock = new BLL.Stock();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();

        #region Auxiliares
        private List<BE.cls02_Stock> listaPersonasOriginal;
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
            listaPersonasOriginal = gstock.ListarCatalogo2();
            cbxIdStock.DataSource = listaPersonasOriginal;
            cbxIdStock.DisplayMember = "Combo";
            cbxIdStock.ValueMember = "IdStock";
            cbxIdStock.SelectedIndex = -1;
            cbxIdStock.DropDownStyle = ComboBoxStyle.DropDown;

            cbxIdinventario.DataSource = new BLL.Inventario().ListarCatalogo();
            cbxIdinventario.DisplayMember = "Nombre";
            cbxIdinventario.ValueMember = "IdInventario";
            cbxIdinventario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxIdinventario.SelectedIndex = -1;
        }
        private bool ValidarCampos()
        {
            errorProvider1.Clear();
            Control primerControlInvalido = null;
            bool valido = true;
            ValidarControlesRecursivamente(this,ref valido,ref primerControlInvalido);
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
                        ComboBox textBox = (ComboBox)control;
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            errorProvider1.SetError(textBox, "Tenés que completar este campo.");
                            if (primerControlInvalido == null)
                                primerControlInvalido = textBox;
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
        #endregion
        private void frm02_Stock_2_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CargarBitacora(3,7);
            // En la grilla no se muestran los números internos (Id): la primera columna es la cantidad actual.
            dataGridView1.DataBindingComplete += (s, ev) =>
            {
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                    if (c.Name.StartsWith("Id", StringComparison.OrdinalIgnoreCase)) c.Visible = false;
                foreach (string nombre in new[] { "Cantidad_actual", "CantidadActual" })
                    if (dataGridView1.Columns.Contains(nombre))
                    {
                        dataGridView1.Columns[nombre].DisplayIndex = 0;
                        dataGridView1.Columns[nombre].HeaderText = "Cantidad actual";
                    }
            };
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
                CargarBitacora(3,5);
        
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
        }
        private void af_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdStock.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdStock.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdStock.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                gstock.Consultar(stock, val);
                cbxIdinventario.SelectedValue = stock.Idinventario;
                txbActual.Text = Convert.ToString(stock.Cantidad_actual);
                txbMinima.Text = Convert.ToString(stock.Cantidad_minima);
                txbMaxima.Text = Convert.ToString(stock.Cantidad_maxima);
                CargarBitacora(3,4);                
                dataGridView1.DataSource = gstock.Consultar(stock, val);
                if (stock.Cantidad_actual <= stock.Cantidad_maxima)
                {
                    if (stock.Cantidad_actual < stock.Cantidad_minima)
                    { MessageBox.Show("El stock actual es menor que el mínimo aceptado. Puede realizar un pedido de reaprovisionamiento."); }
                }
                else { MessageBox.Show("El stock actual es mayor que el máximo aceptado."); }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Ocurrió un error: " + ex.Message,"AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdStock.SelectedValue == null)
                {
                    MessageBox.Show( "Debe seleccionar un elemento de la lista.","AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdStock.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdStock.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                #region Editar
                int fa = 0;
                stock = new BE.cls02_Stock();
                if (cbxIdinventario.SelectedValue == null)
                {
                    MessageBox.Show("Debe elegir el elemento de inventario.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                stock.Idinventario = Convert.ToInt32(cbxIdinventario.SelectedValue);
                stock.Idstock = Convert.ToInt32(cbxIdStock.SelectedValue);
                stock.Cantidad_actual = clsValidacionesPerdurables.SoloNumeros(txbActual.Text,"Cantidad actual");
                stock.Cantidad_minima = clsValidacionesPerdurables.SoloNumeros(txbMinima.Text, "Cantidad mínima");
                stock.Cantidad_maxima = clsValidacionesPerdurables.SoloNumeros(txbMaxima.Text, "Cantidad máxima");
                if (stock.Cantidad_maxima < stock.Cantidad_minima)
                {
                    MessageBox.Show("La cantidad máxima no puede ser menor que la mínima.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (stock.Cantidad_actual > stock.Cantidad_maxima)
                {
                    MessageBox.Show("El stock actual es mayor que el máximo aceptado.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                fa = gstock.Editar(stock);

                if (fa != 0)
                {
                    string aviso = "Stock N° " + stock.Idstock + " modificado.";
                    if (stock.Cantidad_actual < stock.Cantidad_minima)
                        aviso += "\n\nEl stock actual está por debajo del mínimo. Conviene hacer un pedido de reaprovisionamiento.";
                    MessageBox.Show(aviso, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCombo();
                    LimpiarControles(this);
                    CargarBitacora(3,2);
                }
                else
                {
                    MessageBox.Show("Error");
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }          
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdStock.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdStock.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdStock.SelectedValue.ToString(), out val))
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
                #region Eliminar
                DialogResult resultado = MessageBox.Show("¿Seguro que querés eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // Se borra el registro ELEGIDO en el combo (antes se borraba el último buscado).
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdStock, "un stock");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Stock", idBorrar, "el stock")) return;
                    stock = new BE.cls02_Stock();
                    stock.Idstock = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gstock.Eliminar(stock), "el stock")) return;                
                    LimpiarControles(this);
                    CargarCombo();
                    CargarBitacora(3,3);
                }
                else
                {
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
        private void cbxIdStock_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;

            try
            {
                filtrandoCombo = true;
                string texto = cbxIdStock.Text;
                List<BE.cls02_Stock> filtrados;
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
                cbxIdStock.DataSource = null;
                cbxIdStock.DataSource = filtrados;
                cbxIdStock.DisplayMember = "Combo";
                cbxIdStock.ValueMember = "IdStock";
                cbxIdStock.Text = texto;
                cbxIdStock.SelectionStart = texto.Length;
                cbxIdStock.SelectionLength = 0;
                cbxIdStock.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }

        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Stock a Excel";
                guardar.FileName = "AluSoft_Stock_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Stock");

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

        private void cbxIdStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdStock.SelectedIndex;
            if (selectedIndex >= 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = gstock.ListarCatalogo2();
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
