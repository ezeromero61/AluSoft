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
    public partial class frm08_PedidoCliente_2 : Form
    {
        public frm08_PedidoCliente_2()
        {
            InitializeComponent();
        }

        BE.cls08_PedidoCliente pedido = new BE.cls08_PedidoCliente();
        BLL.PedidoCliente gpedido = new BLL.PedidoCliente();

        BE.cls19_Maximo max;
        BLL.Maximo gmax = new BLL.Maximo();

        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();

        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();

        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();

        // Se usa para cargar el presupuesto asociado al pedido
        BLL.PresupuestroCliente gpresupuesto = new BLL.PresupuestroCliente();

        #region Auxiliares

        private List<BE.cls08_PedidoCliente> listaPersonasOriginal;
        private bool filtrandoCombo = false;

        private void CargarBitacora(int tabla, int accion)
        {
            int fu;

            bitacora = new BE.cls35_Bitacora();
            bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
            bitacora.idlogin = clsPerdurables.Id_Login;
            bitacora.idtabla = tabla;
            bitacora.idaccion = accion;
            bitacora.fecha = DateTime.Now;
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
            {
                primerControlInvalido.Focus();
            }

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
                            {
                                primerControlInvalido = textBox;
                            }

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
                            {
                                primerControlInvalido = comboBox;
                            }

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
        private string ObtenerDetallePresupuesto(string comboPresupuesto)
        {
            int posicionGuion = comboPresupuesto.IndexOf('-');

            if (posicionGuion < 0 || posicionGuion == comboPresupuesto.Length - 1)
            {
                return comboPresupuesto.Trim();
            }

            return comboPresupuesto.Substring(posicionGuion + 1).Trim();
        }
        private void CargarCombo()
        {
            listaPersonasOriginal = gpedido.Listar2();

            List<BE.cls26_Combinado> presupuestos =
                gpresupuesto.ListarCatalogo2();

            foreach (BE.cls08_PedidoCliente item in listaPersonasOriginal)
            {
                BE.cls26_Combinado presupuestoRelacionado =
                    presupuestos.FirstOrDefault(
                        p => p.Idpresupuesto == item.Idpresupuesto);

                if (presupuestoRelacionado == null ||
                    string.IsNullOrWhiteSpace(presupuestoRelacionado.Combo))
                {
                    item.Combo = "Nº " + item.IdPedido;
                    continue;
                }

                // El Combo del presupuesto comienza con su número:
                // "Nº 2-Fernando Flores-Ventiluz 40x40".
                // Se quita ese número para usar el del pedido.
                string detalle = ObtenerDetallePresupuesto(
                    presupuestoRelacionado.Combo);

                item.Combo = "Nº " + item.IdPedido + "-" + detalle;
            }

            cbxIdPedido.DataSource = null;
            cbxIdPedido.DisplayMember = "Combo";
            cbxIdPedido.ValueMember = "IdPedido";
            cbxIdPedido.DataSource = listaPersonasOriginal;
            cbxIdPedido.SelectedIndex = -1;
            cbxIdPedido.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void CargarComboPresupuestos()
        {
            cbxIdPresupuesto.DataSource = null;
            cbxIdPresupuesto.DisplayMember = "Combo";
            cbxIdPresupuesto.ValueMember = "IdPresupuesto";
            cbxIdPresupuesto.DataSource = gpresupuesto.ListarCatalogo2();
            cbxIdPresupuesto.SelectedIndex = -1;
            cbxIdPresupuesto.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void ComboIndividual(int val)
        {
            dataGridView1.DataSource = gpedido.Consultar(pedido, val);
        }

        private void ComboCompleto()
        {
            dataGridView1.DataSource = gpedido.ListarCatalogo();

            dataGridView1.Columns["Apellido"].Visible = false;
            dataGridView1.Columns["Combo"].Visible = false;
            dataGridView1.Columns["IdLogin"].Visible = false;
            dataGridView1.Columns["Idcatalogo"].Visible = false;
            dataGridView1.Columns["Descripcion"].Visible = false;
            dataGridView1.Columns["DigitoVerificador"].Visible = false;
            dataGridView1.Columns["Idcliente"].Visible = false;
            dataGridView1.Columns["PlazoEntregaDias"].Visible = false;
        }

        #endregion

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(
                    cbxIdPedido);

                if (val != 0)
                {
                    ComboIndividual(val);
                }
                else
                {
                    ComboCompleto();
                }

                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(
                    dataGridView1,
                    cbxIdPedido);

                CargarBitacora(9, 5);
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
            pedido = new BE.cls08_PedidoCliente();

            try
            {
                if (cbxIdPedido.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un pedido de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cbxIdPedido.Focus();
                    return;
                }

                int val;

                if (!int.TryParse(cbxIdPedido.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show(
                        "El pedido seleccionado no es válido.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese pedido.");
                    return;
                }

                // Consulta el pedido y carga el presupuesto asociado.
                gpedido.Consultar(pedido, val);
                cbxIdPresupuesto.SelectedValue = pedido.Idpresupuesto;

                cargandoPedido = true;
                global::AluSoft.UI.FechasPedido.Mostrar(dateTimePicker1, dateTimePicker2, dateTimePicker3,
                    pedido.Fechapedido, pedido.Fechaentregaestimada, pedido.Fechaentregareal);
                cargandoPedido = false;
                txbEstado.Text = pedido.Estado;
                txbObservaciones.Text = pedido.Observaciones.ToString();

                dataGridView1.DataSource = gpedido.Consultar(pedido, val);

                CargarBitacora(9, 4);
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
                if (!ValidarCampos())
                {
                    return;
                }

                if (cbxIdPedido.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un pedido de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cbxIdPedido.Focus();
                    return;
                }

                int val;

                if (!int.TryParse(cbxIdPedido.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show(
                        "El pedido seleccionado no es válido.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese pedido.");
                    return;
                }

                #region Editar

                int fa = 0;

                pedido = new BE.cls08_PedidoCliente();
                pedido.IdPedido = int.Parse(cbxIdPedido.SelectedValue.ToString());

                pedido.Idpresupuesto =
                    clsValidacionesPerdurables.SoloNumeros(
                        cbxIdPresupuesto.SelectedValue.ToString(),
                        "Id presupuesto");

                pedido.Fechapedido =
                    clsValidacionesPerdurables.FechaNoFutura(
                        DateTime.Parse(dateTimePicker1.Text),
                        "Fecha de pedido");

                pedido.Fechaentregaestimada =
                    clsValidacionesPerdurables.FechaPosterior(
                        DateTime.Parse(dateTimePicker2.Text),
                        pedido.Fechapedido,
                        "Fecha de entrega estimada");

                pedido.Fechaentregareal =
                    clsValidacionesPerdurables.FechaPosterior(
                        DateTime.Parse(dateTimePicker3.Text),
                        pedido.Fechapedido,
                        "Fecha de entrega real");

                pedido.Estado = txbEstado.Text;
                pedido.Observaciones = txbObservaciones.Text;

                fa = gpedido.Editar(pedido);

                if (fa != 0)
                {
                    MessageBox.Show(
                        "Se agregaron " + fa + " filas.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarCombo();
                    LimpiarControles(this);
                    CargarBitacora(9, 2);
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
                if (cbxIdPedido.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un pedido de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cbxIdPedido.Focus();
                    return;
                }

                int val;

                if (!int.TryParse(cbxIdPedido.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show(
                        "El pedido seleccionado no es válido.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese pedido.");
                    return;
                }

                #region Eliminar

                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar este elemento?. " +
                    "Are you sure you want to delete this item?. " +
                    "Êtes-vous sûr de vouloir supprimer cet élément ?",
                    "Confirmar eliminación. Confirm delete. Confirmer la suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // [CORREGIDO] Borraba el pedido cargado con "Buscar"; sin buscar antes borraba 0 filas.
                    pedido.IdPedido = val;

                    if (new BLL.Factura().ListarCatalogo().Any(f => f.IdPedido == val))
                    {
                        MessageBox.Show("No se puede eliminar: el pedido ya tiene factura.", "AluSoft",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    BLL.OrdenProduccion gorden = new BLL.OrdenProduccion();
                    List<BE.cls14_OrdenProduccion> ordenes = gorden.ListarCatalogo2().Where(o => o.IdPedido == val).ToList();
                    List<int> idsOrdenes = ordenes.Select(o => o.Idordenproduccion).ToList();
                    if (new BLL.Produccion().ListarCatalogo().Any(p => idsOrdenes.Contains(p.Idordenproduccion)))
                    {
                        MessageBox.Show("No se puede eliminar: el pedido ya tiene producción registrada.", "AluSoft",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Se devuelve al stock lo que el pedido había descontado (script 13).
                    new BLL.Stock().DevolverStockPedido(val);
                    // Las órdenes que todavía no empezaron se borran junto con el pedido.
                    BLL.Estado gest = new BLL.Estado();
                    foreach (BE.cls15_Estado est in gest.ListarCatalogo().Where(x => idsOrdenes.Contains(x.Idordenproduccion)))
                        gest.Eliminar(est);
                    foreach (BE.cls14_OrdenProduccion o in ordenes)
                        gorden.Eliminar(o);

                    int borrados = gpedido.Eliminar(pedido);
                    MessageBox.Show(borrados != 0
                        ? "Pedido eliminado" + (ordenes.Count > 0 ? " junto con sus " + ordenes.Count + " órdenes de producción pendientes." : ".")
                        : "No se encontró el pedido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarControles(this);
                    CargarBitacora(9, 3);
                    CargarCombo();
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

        private void frm08_PedidoCliente_2_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(
                txbEstado,
                BLL.Estados.Pedido);

            CargarCombo();
            CargarComboPresupuestos();
            CargarBitacora(9, 7);
            // Si se cambia la fecha del pedido, las de entrega se corren a una semana después.
            dateTimePicker1.ValueChanged += delegate
            {
                if (!cargandoPedido)
                    global::AluSoft.UI.FechasPedido.Ajustar(dateTimePicker1, dateTimePicker2, dateTimePicker3);
            };
        }
        private bool cargandoPedido = false;

        private void cbxIdPedido_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
            {
                return;
            }

            try
            {
                filtrandoCombo = true;

                string texto = cbxIdPedido.Text;
                List<BE.cls08_PedidoCliente> filtrados;

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

                cbxIdPedido.DataSource = null;
                cbxIdPedido.DisplayMember = "Combo";
                cbxIdPedido.ValueMember = "IdPedido";
                cbxIdPedido.DataSource = filtrados;

                cbxIdPedido.Text = texto;
                cbxIdPedido.SelectionStart = texto.Length;
                cbxIdPedido.SelectionLength = 0;
                cbxIdPedido.DroppedDown = true;
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
                guardar.Title = "Exportar Pedidos Clientes a Excel";
                guardar.FileName = "AluSoft_Pedidos_Clientes_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Pedidos Clientes");

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
                            {
                                continue;
                            }

                            for (int columna = 0;
                                 columna < dataGridView1.Columns.Count;
                                 columna++)
                            {
                                if (!dataGridView1.Columns[columna].Visible)
                                {
                                    continue;
                                }

                                object valor = fila.Cells[columna].Value;
                                var celda = hoja.Cell(filaExcel, columna + 1);

                                if (valor == null || valor == DBNull.Value)
                                {
                                    celda.Value = "";
                                }
                                else if (valor is DateTime)
                                {
                                    DateTime fecha = (DateTime)valor;
                                    celda.Value = fecha;
                                    celda.Style.DateFormat.Format = "dd/MM/yyyy";
                                }
                                else if (valor is bool)
                                {
                                    celda.Value = (bool)valor;
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
    }
}
