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
    public partial class frm24_Pagos_2 : Form
    {
        BE.cls03_Cliente cliente = new BE.cls03_Cliente();
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls09_Factura factura = new BE.cls09_Factura();
        BLL.Factura gfactura = new BLL.Factura();
        private readonly BLL.Pagos gpago = new BLL.Pagos();
        private int? idPagoCargado;
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls24_Pagos> listaPersonasOriginal;
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
                if (control.Visible && control.Enabled && !global::AluSoft.UI.ValidacionCampos.EsOpcional(control) && control != txbObservaciones)
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
        public frm24_Pagos_2()
        {
            InitializeComponent();
        }

        private void frm24_Pagos_2_Load(object sender, EventArgs e)
        {
            // La anulación de pagos se quitó de la pantalla. El check queda oculto solo para
            // conservar el valor que ya tenga un pago viejo al modificarlo (no se reactiva sin querer).
            chkAnulado.Visible = false;

            cbxFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFormaPago.Items.Clear();
            cbxFormaPago.Items.AddRange(BLL.Estados.FormaPago);

            lblcbxIdCliente.Text = "Proveedor:";
            lblcbxIdFactura.Text = "Compra:";
            nudImporte.Maximum = 1000000000;
            Ejecutar(delegate
            {
                CargarPagos();
                LimpiarControles();
            });
        }
        private void CargarPagos()
        {
            listaPersonasOriginal = gpago.ListarCatalogo2();
            cbxIdPago.DataSource = listaPersonasOriginal;
            cbxIdPago.DisplayMember = "Combo";
            cbxIdPago.ValueMember = "IdPago";        
            cbxIdPago.SelectedIndex = -1;
            cbxIdPago.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private bool ObtenerIdPago(out int id)
        {
            id = 0;
            if (cbxIdPago.SelectedValue == null ||
                !int.TryParse(cbxIdPago.SelectedValue.ToString(), out id) ||
                id <= 0)
            {
                MessageBox.Show("Seleccione un pago.");
                return false;
            }
            return true;
        }
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                bool individual = cbxIdPago.SelectedIndex >= 0;
                Ejecutar(delegate
                {
                    // Sin un pago elegido se usa la lista completa (trae el nombre del proveedor para filtrar).
                    var lista = gpago.ListarCatalogo2();
                    if (individual)
                    {
                        int id;
                        if (!ObtenerIdPago(out id)) return;
                        lista = lista.FindAll(p => p.IdPago == id);
                    }
                    dataGridView1.DataSource = lista;
                });
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPago);
                if (dataGridView1.Columns.Contains("Anulado")) dataGridView1.Columns["Anulado"].Visible = false;
                // Sin un pago elegido: filtros tipo reporte (fechas, proveedor, forma de pago) y totales.
                if (individual)
                {
                    global::AluSoft.UI.FiltroReporte.PonerNombre(dataGridView1, "Proveedor=Nombre+Apellido");
                    global::AluSoft.UI.FiltroReporte.OcultarTotales(dataGridView1);
                }
                else
                    global::AluSoft.UI.FiltroReporte.Mostrar(dataGridView1, "pagos", "FechaPago",
                        "Proveedor=Proveedor;Forma de pago=FormaPago",
                        "Total pagado=Importe",
                        "Proveedor=Nombre+Apellido");
                CargarBitacora(25,5);
        
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
                Ejecutar(delegate
                {
                    int id;
                    if (!ObtenerIdPago(out id)) return;
                    idPagoCargado = null;
                    var pago = gpago.ListarCatalogo().Find(p => p.IdPago == id);
                    if (pago == null)
                    {
                        LimpiarControles();
                        MessageBox.Show("El pago ya no existe. Actualice el listado.");
                        return;
                    }
                    if (pago.FechaPago < dtpFechaPago.MinDate ||
                        pago.FechaPago > dtpFechaPago.MaxDate ||
                        pago.Importe < nudImporte.Minimum ||
                        pago.Importe > nudImporte.Maximum ||
                        decimal.Round(pago.Importe, nudImporte.DecimalPlaces) != pago.Importe)
                    {
                        MessageBox.Show("La fecha o el importe requiere ajustar los límites o decimales de los controles.");
                        return;
                    }
                    cbxIdCliente.DataSource = null;
                    cbxIdCliente.DisplayMember = "Combo";
                    cbxIdCliente.ValueMember = "IdProveedor";
                    cbxIdCliente.DataSource = new BLL.Proveedor().Listar2();
                    cbxIdCliente.SelectedValue = pago.IdProveedor;

                    cbxIdFactura.DataSource = null;
                    cbxIdFactura.DisplayMember = "Combo";
                    cbxIdFactura.ValueMember = "Idcompras";
                    cbxIdFactura.DataSource = new BLL.Compras().ListarCatalogo2();
                    cbxIdFactura.SelectedValue = pago.IdCompras;
                    dtpFechaPago.Value = pago.FechaPago;
                    nudImporte.Value = pago.Importe;
                    if (!string.IsNullOrEmpty(pago.FormaPago) && cbxFormaPago.FindStringExact(pago.FormaPago) < 0)
                        cbxFormaPago.Items.Add(pago.FormaPago);
                    cbxFormaPago.SelectedIndex = cbxFormaPago.FindStringExact(pago.FormaPago);
                    txbNumeroComprobante.Text = pago.NumeroComprobante;
                    txbObservaciones.Text = pago.Observaciones;
                    chkAnulado.Checked = pago.Anulado;
                    dataGridView1.DataSource = gpago.ListarCatalogo2().FindAll(p => p.IdPago == id);
                    if (dataGridView1.Columns.Contains("Anulado")) dataGridView1.Columns["Anulado"].Visible = false;
                    global::AluSoft.UI.FiltroReporte.PonerNombre(dataGridView1, "Proveedor=Nombre+Apellido");
                    idPagoCargado = id;
                });
                CargarBitacora(25,4);
        
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
                Ejecutar(delegate
                {
                    int id;
                    if (!ObtenerIdPago(out id)) return;
                    if (idPagoCargado != id)
                    {
                        MessageBox.Show("Presione Buscar para cargar este pago antes de modificarlo.");
                        return;
                    }
                    int cliente = Convert.ToInt32(cbxIdCliente.SelectedValue);
                    int factura = Convert.ToInt32(cbxIdFactura.SelectedValue);
                    if (cliente <= 0 || factura <= 0)
                    {
                        MessageBox.Show("Elegí el proveedor y la compra.");
                        return;
                    }

                    BE.cls24_Pagos pago = new BE.cls24_Pagos();
                    pago.IdPago = id;
                    pago.IdProveedor = cliente;
                    pago.IdCompras = factura;
                    pago.FechaPago = dtpFechaPago.Value;
                    pago.Importe = nudImporte.Value;
                    pago.FormaPago = cbxFormaPago.Text;
                    pago.NumeroComprobante = txbNumeroComprobante.Text;
                    pago.Observaciones = txbObservaciones.Text;
                    pago.Anulado = chkAnulado.Checked;
                    int fa = gpago.Editar(pago);
                    MostrarResultado(fa, "modificación");
                    if (fa != 0) ActualizarDespuesDeEscritura();
                });
                CargarBitacora(25,2);
        
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
                Ejecutar(delegate
                {
                    int id;
                    if (!ObtenerIdPago(out id)) return;
                    if (MessageBox.Show("¿Desea eliminar el pago " + id + "?", "Confirmar eliminación", MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                    BE.cls24_Pagos pago = new BE.cls24_Pagos();
                    pago.IdPago = id;
                    int fa = gpago.Eliminar(pago);
                    MostrarResultado(fa, "eliminación");
                    if (fa != 0) ActualizarDespuesDeEscritura();
                });
                CargarBitacora(25,3);
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void MostrarResultado(int fa, string accion)
        {
            if (fa > 0)
                MessageBox.Show("Operación de " + accion + " completada. Filas informadas: " + fa + ".");
            else if (fa == 0)
                MessageBox.Show("No se informaron filas afectadas.");
            else
                MessageBox.Show("El procedimiento finalizó sin informar una cantidad de filas. Verifique el listado.");
        }
        private void ActualizarDespuesDeEscritura()
        {
            LimpiarControles();
            try
            {
                CargarPagos();
                dataGridView1.DataSource = gpago.ListarCatalogo2();
                if (dataGridView1.Columns.Contains("Anulado")) dataGridView1.Columns["Anulado"].Visible = false;
                global::AluSoft.UI.FiltroReporte.PonerNombre(dataGridView1, "Proveedor=Nombre+Apellido");
            }
            catch (Exception ex)
            {
                MessageBox.Show("La escritura ya fue ejecutada, pero no se pudo actualizar el listado: " + ex.Message);
            }
        }
        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
        private void LimpiarControles()
        {
            idPagoCargado = null;
            cbxIdPago.SelectedIndex = -1;
            cbxIdCliente.SelectedIndex = -1;
            cbxIdCliente.Text = string.Empty;
            cbxIdFactura.SelectedIndex = -1;
            cbxIdFactura.Text = string.Empty;
            dtpFechaPago.Value = DateTime.Today;
            nudImporte.Value = 0;
            cbxFormaPago.SelectedIndex = -1;
            cbxFormaPago.Text = string.Empty;
            txbNumeroComprobante.Clear();
            txbObservaciones.Clear();
            chkAnulado.Checked = false;
            dataGridView1.DataSource = null;
        }
        private void Ejecutar(Action accion)
        {
            try { accion(); }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message,"Pagos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Pagos Proveedores a Excel";
                guardar.FileName = "AluSoft_Pagos_Proveedores_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Pagos Proveedores");

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
        private void cbxIdPago_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdPago.Text;
                List<BE.cls24_Pagos> filtrados;
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
                cbxIdPago.DataSource = null;
                cbxIdPago.DataSource = filtrados;
                cbxIdPago.DisplayMember = "Combo";
                cbxIdPago.ValueMember = "IdPago";
                cbxIdPago.Text = texto;
                cbxIdPago.SelectionStart = texto.Length;
                cbxIdPago.SelectionLength = 0;
                cbxIdPago.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
