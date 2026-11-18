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
    public partial class frm11_Ventas_2 : Form
    {
        public frm11_Ventas_2()
        {
            InitializeComponent();
        }

        BE.cls10_Cobro cobro = new BE.cls10_Cobro();
        BLL.Cobro gcobro = new BLL.Cobro();
        BE.cls06_Venta venta = new BE.cls06_Venta();
        BLL.Ventas gventa = new BLL.Ventas();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls00_Persona persona = new BE.cls00_Persona();
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls03_Cliente cliente = new BE.cls03_Cliente();
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls08_PedidoCliente pedido = new BE.cls08_PedidoCliente();
        BLL.PedidoCliente gpedido = new BLL.PedidoCliente();
        BE.cls09_Factura factura = new BE.cls09_Factura();
        BLL.Factura gfactura = new BLL.Factura();

        #region Auxiliares

        private List<BE.cls06_Venta> listaPersonasOriginal;
        private bool filtrandoCombo = false;

        private void CargarBitacora(int tabla, int accion)
        {
            int fu;
            bitacora = new BE.cls35_Bitacora();
            bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
            bitacora.idlogin = clsPerdurables.Id_Login;
            bitacora.idtabla = tabla;
            bitacora.idaccion = accion;
            bitacora.fecha = (DateTime.Now);
            bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
            fu = gbitacora.Agregar(bitacora);
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

            global::AluSoft.UI.ValidacionCampos.ValidarTipos(
                this,
                errorProvider1,
                ref valido,
                ref primerControlInvalido);

            primerControlInvalido =
                global::AluSoft.UI.ValidacionCampos.PrimeroConError(
                    this,
                    errorProvider1) ?? primerControlInvalido;

            if (!valido && primerControlInvalido != null)
                primerControlInvalido.Focus();

            return valido;
        }
        private void ValidarControlesRecursivamente(Control contenedor,ref bool valido,ref Control primerControlInvalido)
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
                            errorProvider1.SetError(
                                textBox,
                                "Tenés que completar este campo.");

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
                            errorProvider1.SetError(
                                comboBox,
                                "Tenés que seleccionar una opción.");

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
            listaPersonasOriginal = gventa.ListarCatalogo2();

            // Se arma la descripción de cada venta:
            // Nº de venta - Cliente - Total
            foreach (BE.cls06_Venta item in listaPersonasOriginal)
            {
                string nombreCliente =(Convert.ToString(item.NombreCliente) + " " +Convert.ToString(item.Apellidocliente)).Trim();

                string total =
                    Convert.ToDecimal(item.Total).ToString("0.##");

                item.Combo =
                    "Nº " + item.Idventa +
                    "-" + nombreCliente +
                    "-$" + total;
            }

            cbxIdVenta.DataSource = listaPersonasOriginal;
            cbxIdVenta.DisplayMember = "Combo";
            cbxIdVenta.ValueMember = "IdVenta";
            cbxIdVenta.Text = null;
            cbxIdVenta.DropDownStyle = ComboBoxStyle.DropDown;
        }

        // Una sola venta, con las mismas columnas que el listado completo (incluye el cliente).
        private void ComboIndividual(int val)
        {
            gventa.Consultar(venta, val);
            MostrarVentas(gventa.ListarCatalogo2().FindAll(v => v.Idventa == val));
        }

        private void ComboCompleto()
        {
            MostrarVentas(gventa.ListarCatalogo2());
        }

        private void MostrarVentas(List<BE.cls06_Venta> lista)
        {
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Idventa"].Visible = false;
            dataGridView1.Columns["IdCobro"].Visible = false;
            dataGridView1.Columns["NumeroVenta"].Visible = false;
            dataGridView1.Columns["Idfactura"].Visible = false;
            dataGridView1.Columns["NumeroFactura"].Visible = false;

            dataGridView1.Columns["TipoFactura"].Visible = false;
            dataGridView1.Columns["IdPedido"].Visible = false;
            dataGridView1.Columns["Idinventario"].Visible = false;
            dataGridView1.Columns["Nombreinventario"].Visible = false;
            dataGridView1.Columns["IdCliente"].Visible = false;

            dataGridView1.Columns["NombreCliente"].Visible = false;
            dataGridView1.Columns["Apellidocliente"].Visible = false;
            dataGridView1.Columns["Documento"].Visible = false;
            dataGridView1.Columns["CUIT"].Visible = false;
            dataGridView1.Columns["CondicionIVA"].Visible = false;

            dataGridView1.Columns["DireccionFiscal"].Visible = false;
            dataGridView1.Columns["IVA"].Visible = false;
            dataGridView1.Columns["Formapago"].Visible = false;
            dataGridView1.Columns["CAE"].Visible = false;
            dataGridView1.Columns["FechaVencimientoCAE"].Visible = false;

            dataGridView1.Columns["Idlogin"].Visible = false;
            dataGridView1.Columns["Combo"].Visible = false;
        }

        #endregion

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(
                    cbxIdVenta);

                if (val != 0)
                {
                    ComboIndividual(val);
                }
                else
                {
                    ComboCompleto();
                    global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(
                        dataGridView1,
                        cbxIdVenta);
                }

                // Sin una venta elegida: filtros tipo reporte (fechas, cliente, estado) y totales.
                if (val != 0)
                {
                    global::AluSoft.UI.FiltroReporte.PonerNombre(dataGridView1, "Cliente=NombreCliente+Apellidocliente");
                    global::AluSoft.UI.FiltroReporte.OcultarTotales(dataGridView1);
                }
                else
                    global::AluSoft.UI.FiltroReporte.Mostrar(dataGridView1, "ventas", "FechaVenta",
                        "Cliente=Cliente;Estado=Estado",
                        "Total vendido=Total;Cobrado=TotalCobrado;Saldo pendiente=SalfoPendiente",
                        "Cliente=NombreCliente+Apellidocliente");

                CargarBitacora(12, 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo completar la operación: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void af_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdVenta.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cbxIdVenta.Focus();
                    return;
                }

                int val;

                if (!int.TryParse(cbxIdVenta.SelectedValue.ToString(), out val))
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

                #region 07_Asistencias_Alumnos

                gventa.Consultar(venta, val);

                cbxIdCliente.DataSource =
                    gcliente.ConsultarPorIdCliente(cliente, venta.IdCliente);
                cbxIdCliente.DisplayMember = "Combo";
                cbxIdCliente.ValueMember = "IdCliente";

                cbxIdPedido.DataSource =
                    gpedido.Consultar(pedido, venta.IdPedido);
                cbxIdPedido.DisplayMember = "IdPedido";
                cbxIdPedido.ValueMember = "IdPedido";

                cbxIdFactura.DataSource =
                    gfactura.Consultar(factura, venta.Idfactura);
                cbxIdFactura.DisplayMember = "Combo";
                cbxIdFactura.ValueMember = "IdFactura";

                cbxIdCobro.DataSource =
                    gcobro.Consultar(cobro, venta.IdCobro);
                cbxIdCobro.DisplayMember = "Combo";
                cbxIdCobro.ValueMember = "IdCobro";

                dateTimePicker1.Text = venta.FechaVenta.ToString();
                dateTimePicker2.Text = venta.FechaEntrega.ToString();
                txbSubtotal.Text = venta.Subtotal.ToString();
                txbDescuento.Text = venta.Descuento.ToString();
                txbImpuestos.Text = venta.Impuestos.ToString();
                txbTotal.Text = venta.Total.ToString();
                txbTotalCobrado.Text = venta.TotalCobrado.ToString();
                txbSaldoPendiente.Text = venta.SalfoPendiente.ToString();
                txbEstado.Text = venta.Estado.ToString();
                txbObservaciones.Text = venta.Observaciones.ToString();

                #endregion

                ComboIndividual(val);
                global::AluSoft.UI.FiltroReporte.PonerNombre(dataGridView1, "Cliente=NombreCliente+Apellidocliente");
                CargarBitacora(12, 4);
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
            int fa;

            try
            {
                if (!ValidarCampos())
                    return;

                if (cbxIdVenta.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cbxIdVenta.Focus();
                    return;
                }

                int val;

                if (!int.TryParse(cbxIdVenta.SelectedValue.ToString(), out val))
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

                venta = new BE.cls06_Venta();
                venta.Idventa = int.Parse(cbxIdVenta.SelectedValue.ToString());
                venta.IdPedido =
                    clsValidacionesPerdurables.SoloNumeros(
                        cbxIdPedido.SelectedValue.ToString(),
                        "Id Pedido");
                venta.Idfactura =
                    clsValidacionesPerdurables.SoloNumeros(
                        cbxIdFactura.SelectedValue.ToString(),
                        "Id Factura");
                venta.IdCliente =
                    clsValidacionesPerdurables.SoloNumeros(
                        cbxIdCliente.SelectedValue.ToString(),
                        "Id Cliente");
                venta.IdCobro =
                    clsValidacionesPerdurables.SoloNumeros(
                        cbxIdCobro.SelectedValue.ToString(),
                        "Id Cobro");
                venta.FechaVenta =
                    clsValidacionesPerdurables.FechaNoFutura(
                        DateTime.Parse(dateTimePicker1.Text),
                        "Fecha venta");
                venta.FechaEntrega =
                    clsValidacionesPerdurables.FechaNoFutura(
                        DateTime.Parse(dateTimePicker2.Text),
                        "Fecha Venta");
                venta.Subtotal =
                    clsValidacionesPerdurables.SoloNumeros(
                        txbSubtotal.Text,
                        "Subtotal");
                venta.Descuento =
                    clsValidacionesPerdurables.SoloNumeros(
                        txbDescuento.Text,
                        "Descuento");
                venta.Impuestos =
                    clsValidacionesPerdurables.SoloNumeros(
                        txbImpuestos.Text,
                        "Impuesto");
                venta.Total =
                    clsValidacionesPerdurables.SoloNumeros(
                        txbTotal.Text,
                        "Total");
                venta.TotalCobrado =
                    clsValidacionesPerdurables.SoloNumeros(
                        txbTotalCobrado.Text,
                        "Total Cobrado");
                venta.SalfoPendiente =
                    clsValidacionesPerdurables.SoloNumeros(
                        txbSaldoPendiente.Text,
                        "Saldo Pendiente");
                venta.Estado = txbEstado.Text;
                venta.Observaciones = txbObservaciones.Text;

                fa = gventa.Editar(venta);

                if (fa != 0)
                {
                    MessageBox.Show(
                        "Se agrego " + fa + " filas.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarCombo();
                    LimpiarControles(this);
                    CargarBitacora(12, 2);
                }
                else
                {
                    MessageBox.Show("Error");
                }
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
                if (cbxIdVenta.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cbxIdVenta.Focus();
                    return;
                }

                int val;

                if (!int.TryParse(cbxIdVenta.SelectedValue.ToString(), out val))
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

                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este elemento?. " +
                    "Are you sure you want to delete this item?. " +
                    "Êtes-vous sûr de vouloir supprimer cet élément ?",
                    "Confirmar eliminación. Confirm delete. Confirmer la suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Se borra el registro ELEGIDO en el combo (antes se borraba el último buscado).
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdVenta, "una venta");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Venta", idBorrar, "la venta")) return;
                    venta = new BE.cls06_Venta();
                    venta.Idventa = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gventa.Eliminar(venta), "la venta")) return;

                    LimpiarControles(this);
                    CargarBitacora(12, 3);
                    CargarCombo();
                }
                else
                {
                    return;
                }
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

        private void frm11_Ventas_2_Load(object sender, EventArgs e)
        {
            CargarCombo();
            cbxIdVenta.SelectedIndex = -1;
            CargarBitacora(12, 7);
        }

        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Ventas a Excel";
                guardar.FileName = "AluSoft_Ventas_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Ventas");

                        for (int columna = 0;
                             columna < dataGridView1.Columns.Count;
                             columna++)
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

                            for (int columna = 0;
                                 columna < dataGridView1.Columns.Count;
                                 columna++)
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
                                else if (valor is byte || valor is short ||
                                         valor is int || valor is long ||
                                         valor is float || valor is double ||
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

                    MessageBox.Show(
                        "La tabla se exportó correctamente.",
                        "Exportación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo exportar la tabla: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Este formulario es de gestión de datos ya cargados en el sistema, " +
                "puede buscarlos, enlistarlos, modificarlos y borrarlos. " +
                "Complete el formulario con los datos correctos y presione el botón " +
                "con la acción que va a realizar. Si hubo algún dato incorrecto, " +
                "informe a su referente o superior para corregirlo. Si algún error " +
                "aparece en pantalla, por favor guarde o anote el mensaje para " +
                "notificarlo luego. En caso de necesitar más ayuda se puede " +
                "comunicar con alusoft@gmail.com.");
        }

        private void cbxIdVenta_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;

            try
            {
                filtrandoCombo = true;

                string texto = cbxIdVenta.Text;
                List<BE.cls06_Venta> filtrados;

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

                cbxIdVenta.DataSource = null;
                cbxIdVenta.DataSource = filtrados;
                cbxIdVenta.DisplayMember = "Combo";
                cbxIdVenta.ValueMember = "IdVenta";
                cbxIdVenta.Text = texto;
                cbxIdVenta.SelectionStart = texto.Length;
                cbxIdVenta.SelectionLength = 0;
                cbxIdVenta.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
