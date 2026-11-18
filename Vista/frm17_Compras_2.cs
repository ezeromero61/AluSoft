using BLL;
using ClosedXML.Excel;
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
    public partial class frm17_Compras_2 : Form
    {
        public frm17_Compras_2()
        {
            InitializeComponent();
        }
        BE.cls02_Stock stock = new BE.cls02_Stock();
        BLL.Stock gstock = new BLL.Stock();
        BE.cls17_Compras compras = new BE.cls17_Compras();
        BLL.Compras gcompras = new BLL.Compras();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls17_Compras> listaPersonasOriginal;
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
            listaPersonasOriginal = gcompras.ListarCatalogo2();
            cbxIdCompras.DataSource = listaPersonasOriginal;
            cbxIdCompras.DisplayMember = "Combo";
            cbxIdCompras.ValueMember = "IdCompras";
            cbxIdCompras.SelectedIndex = -1;
            cbxIdCompras.DropDownStyle = ComboBoxStyle.DropDown;
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
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdCompras);
                if (val != 0)
                {
                    gcompras.Consultar(compras, val);
                    dataGridView1.DataSource = gcompras.ListarCatalogo2().FindAll(c => c.Idcompras == val);
                }
                else
                {
                    dataGridView1.DataSource = gcompras.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdCompras);
                // Sin una compra elegida: filtros tipo reporte (fechas, proveedor, producto) y totales.
                if (val != 0)
                {
                    global::AluSoft.UI.FiltroReporte.PonerNombre(dataGridView1, "Proveedor=NombreEmpresa");
                    global::AluSoft.UI.FiltroReporte.OcultarTotales(dataGridView1);
                }
                else
                    global::AluSoft.UI.FiltroReporte.Mostrar(dataGridView1, "compras", "Fecha",
                        "Proveedor=Proveedor;Producto=Nombre",
                        "Total comprado=Total;Pagado=Pagado;Saldo=Saldo",
                        "Proveedor=NombreEmpresa");
                CargarBitacora(18,5);
        
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
                if (cbxIdCompras.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdCompras.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdCompras.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese elemento.");
                    return;
                }
                gcompras.Consultar(compras, val);

                cbxIdStock.DataSource = gstock.Consultar(stock, compras.Idstock);
                cbxIdStock.DisplayMember = "Nombre";
                cbxIdStock.ValueMember = "IdStock";
                txbCantidad.Text = compras.Cantidad.ToString();
                dateTimePicker1.Text = compras.Fecha.ToString();
                txbSubtotal.Text = compras.Subtotal.ToString();
                txbTotal.Text = compras.Total.ToString();
                dataGridView1.DataSource = gcompras.ListarCatalogo2().FindAll(c => c.Idcompras == val);
                global::AluSoft.UI.FiltroReporte.PonerNombre(dataGridView1, "Proveedor=NombreEmpresa");
                CargarBitacora(18, 4);
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
                if (cbxIdCompras.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdCompras.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdCompras.SelectedValue.ToString(), out val))
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
                int fa = 0;
                compras = new BE.cls17_Compras();
                compras.Idstock = int.Parse(cbxIdStock.ValueMember.ToString());
                compras.Cantidad = int.Parse(txbCantidad.Text);
                compras.Fecha = DateTime.Parse(dateTimePicker1.Text);
                compras.Subtotal = int.Parse(txbSubtotal.Text);
                compras.Total = int.Parse(txbTotal.Text);
                fa = gcompras.Editar(compras);
                if (fa != 0)
                {
                    MessageBox.Show("Se agrego " + fa + " filas.");
                    CargarBitacora(18, 2);
                    CargarCombo();                  
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
                if (cbxIdCompras.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdCompras.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdCompras.SelectedValue.ToString(), out val))
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
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdCompras, "una compra");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Compras", idBorrar, "la compra")) return;
                    compras = new BE.cls17_Compras();
                    compras.Idcompras = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gcompras.Eliminar(compras), "la compra")) return;
                    LimpiarControles(this);
                    #region Cliente
                    CargarCombo();
                    CargarBitacora(18,3);                    
                    #endregion
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
        private void frm17_Compras_2_Load(object sender, EventArgs e)
        {
            CargarBitacora(18,7);
            CargarCombo();            
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Compras a Excel";
                guardar.FileName = "AluSoft_Compras_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Compras");

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
        private void cbxIdCompras_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdCompras.Text;
                List<BE.cls17_Compras> filtrados;
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
                cbxIdCompras.DataSource = null;
                cbxIdCompras.DataSource = filtrados;
                cbxIdCompras.DisplayMember = "Combo";
                cbxIdCompras.ValueMember = "IdCompras";
                cbxIdCompras.Text = texto;
                cbxIdCompras.SelectionStart = texto.Length;
                cbxIdCompras.SelectionLength = 0;
                cbxIdCompras.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
