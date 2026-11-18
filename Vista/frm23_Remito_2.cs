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
    public partial class frm23_Remito_2 : Form
    {
        public frm23_Remito_2()
        {
            InitializeComponent();
        }
        BLL.PresupuestoProveedor gpreprov = new BLL.PresupuestoProveedor();
        BE.cls23_RemitoProveedor remito = new BE.cls23_RemitoProveedor();
        BLL.RemitoProveedor gremito = new BLL.RemitoProveedor();
        BE.cls35_Bitacora bitacora = new BE.cls35_Bitacora();
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls23_RemitoProveedor> listaPersonasOriginal;
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
        private void CargarRemitos()
        {
            listaPersonasOriginal = gremito.Listar2();
            cbxIdRemito.DataSource = listaPersonasOriginal;
            cbxIdRemito.DisplayMember = "Combo";
            cbxIdRemito.ValueMember = "Idremitoproveedor";
            cbxIdRemito.SelectedIndex = -1;
            cbxIdRemito.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void CargarPresupuestos()
        {
            cbxIdPresupuestoProveedor.DataSource = gpreprov.ListarCatalogo2();
            cbxIdPresupuestoProveedor.DisplayMember = "Combo";
            cbxIdPresupuestoProveedor.ValueMember = "IdPresupuestoProveedor";
            cbxIdPresupuestoProveedor.SelectedIndex = -1;
        }
        private void LimpiarControles()
        {
            cbxIdRemito.SelectedIndex = -1;
            cbxIdPresupuestoProveedor.SelectedIndex = -1;
            dateTimePicker2.Value = DateTime.Today;
            txbEstado.Clear();
            txbObservaciones.Clear();
            dataGridView1.DataSource = null;
        }
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdRemito.SelectedValue != null)
                {
                    int id = Convert.ToInt32(cbxIdRemito.SelectedValue);
                    remito = new BE.cls23_RemitoProveedor();
                    dataGridView1.DataSource =gremito.Consultar(remito, id);
                }
                else
                {
                    dataGridView1.DataSource =
                        gremito.ListarCatalogo();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdRemito);
                CargarBitacora(24,5);
        
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
                if (cbxIdRemito.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un remito de proveedor.");
                    return;
                }
                int id = Convert.ToInt32( cbxIdRemito.SelectedValue);
                remito = new BE.cls23_RemitoProveedor();
                DataTable tabla = gremito.Consultar(remito, id);
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró el remito seleccionado.");
                    return;
                }
                cbxIdPresupuestoProveedor.SelectedValue =remito.Idpresupuestoproveedor;
                dateTimePicker2.Value = remito.Fecha;
                txbEstado.Text = remito.Estado;
                txbObservaciones.Text = remito.Observaciones;
                dataGridView1.DataSource = tabla;
                CargarBitacora(24,4);
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdRemito.SelectedValue == null ||
                cbxIdPresupuestoProveedor.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione el remito y el presupuesto.");
                    return;
                }
                remito = new BE.cls23_RemitoProveedor();
                remito.Idremitoproveedor = Convert.ToInt32(cbxIdRemito.SelectedValue);
                remito.Idpresupuestoproveedor = Convert.ToInt32(cbxIdPresupuestoProveedor.SelectedValue);
                remito.Fecha = dateTimePicker2.Value;
                remito.Estado = txbEstado.Text.Trim();
                remito.Observaciones = txbObservaciones.Text.Trim();
                int fa = gremito.Editar(remito);
                if (fa != 0)
                {
                    string aviso = "Remito N° " + remito.Idremitoproveedor + " modificado.";
                    // Recibido / Con faltantes: se ajusta el stock por la diferencia con lo que ya había entrado.
                    aviso += global::AluSoft.UI.CadenaCompra.IngresarMercaderia(remito.Idpresupuestoproveedor, remito.Idremitoproveedor, 0, remito.Estado);
                    MessageBox.Show(aviso, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarRemitos();
                    LimpiarControles();
                    CargarBitacora(24,2);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el remito.");
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdRemito.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione el remito que desea eliminar.");
                    return;
                }
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este remito?","Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    return;
                }
                remito = new BE.cls23_RemitoProveedor();
                remito.Idremitoproveedor = Convert.ToInt32(cbxIdRemito.SelectedValue);
                int fa = gremito.Eliminar(remito);
                if (fa != 0)
                {
                    MessageBox.Show("Se eliminaron " + fa + " filas.");
                    CargarRemitos();
                    LimpiarControles();
                    CargarBitacora(24,3);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el remito.");
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
            LimpiarControles();
        }
        private void frm23_Remito_2_Load(object sender, EventArgs e)
        {
            CargarRemitos();
            CargarPresupuestos();
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Remito);
            CargarBitacora(24,7);
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Remitos Proveedores a Excel";
                guardar.FileName = "AluSoft_Remitos_Proveedores_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Remitos Proveedores");

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
        private void cbxIdRemito_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdRemito.Text;
                List<BE.cls23_RemitoProveedor> filtrados;
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
                cbxIdRemito.DataSource = null;
                cbxIdRemito.DataSource = filtrados;
                cbxIdRemito.DisplayMember = "Idremitoproveedor";
                cbxIdRemito.ValueMember = "Idremitoproveedor";
                cbxIdRemito.Text = texto;
                cbxIdRemito.SelectionStart = texto.Length;
                cbxIdRemito.SelectionLength = 0;
                cbxIdRemito.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
