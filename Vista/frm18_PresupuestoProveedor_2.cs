using BLL;
using ClosedXML.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AluSoftPresentacion16_6
{
    public partial class frm18_PresupuestoProveedor_2 : Form
    {
        public frm18_PresupuestoProveedor_2()
        {
            InitializeComponent();
        }
        BE.cls02_Stock stock = new BE.cls02_Stock();
        BLL.Stock gstock = new BLL.Stock();
        BE.cls18_PresupuestoProveedor presupuesto = new BE.cls18_PresupuestoProveedor();
        BLL.PresupuestoProveedor gpresupuesto = new BLL.PresupuestoProveedor();
        BE.cls04_Proveedor proveedor = new BE.cls04_Proveedor();
        BLL.Proveedor gproveedor = new BLL.Proveedor();
        BE.cls35_Bitacora bitacora = new BE.cls35_Bitacora();
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls18_PresupuestoProveedor> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private bool RecalcularImportes()
        {
            decimal cantidad;
            decimal precio;
            decimal porcentajeIva;

            if (!decimal.TryParse(txbCantidad.Text, NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out cantidad) ||
                !decimal.TryParse(txbPrecio.Text, NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out precio) ||
                !decimal.TryParse(txbIva.Text, NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out porcentajeIva))
            {
                MessageBox.Show("Revisá la cantidad, el precio y el porcentaje de IVA.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cantidad < 0 || precio < 0 || porcentajeIva < 0)
            {
                MessageBox.Show("Los valores no pueden ser negativos.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal subtotal = cantidad * precio;
            decimal iva = subtotal * porcentajeIva / 100m;
            decimal total = subtotal + iva;

            txbSubtotal.Text = Math.Round(
                subtotal, 0, MidpointRounding.AwayFromZero)
                .ToString(CultureInfo.CurrentCulture);

            txbTotal.Text = Math.Round(
                total, 0, MidpointRounding.AwayFromZero)
                .ToString(CultureInfo.CurrentCulture);

            return true;
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
        private void LimpiarControles(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is System.Windows.Forms.TextBox)
                {
                    ((System.Windows.Forms.TextBox)control).Clear();
                }
                else if (control is System.Windows.Forms.ComboBox)
                {
                    ((System.Windows.Forms.ComboBox)control).Text = "";
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
        private void CargarCombo()
        {
            listaPersonasOriginal = gpresupuesto.ListarCatalogo2();
            cbxIdPresupuestoProveedor.DataSource = listaPersonasOriginal;
            cbxIdPresupuestoProveedor.DisplayMember = "Combo";
            cbxIdPresupuestoProveedor.ValueMember = "IdPresupuestoProveedor";
            cbxIdPresupuestoProveedor.SelectedIndex = -1;
            cbxIdPresupuestoProveedor.DropDownStyle = ComboBoxStyle.DropDown;
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
                    if (control is System.Windows.Forms. TextBox)
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
                    else if (control is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)control;
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
        private void frm18_PresupuestoProveedor_2_Load(object sender, EventArgs e)
        {
            CargarCombo();
            // El precio lo fija el proveedor en su presupuesto: no se modifica desde la gestión.
            // Subtotal y total se calculan solos.
            foreach (System.Windows.Forms.TextBox t in new System.Windows.Forms.TextBox[] { txbPrecio, txbIva, txbSubtotal, txbTotal })
            {
                t.ReadOnly = true;
                t.TabStop = false;
            }
        }
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdPresupuestoProveedor);
                if (val != 0)
                {
                    dataGridView1.DataSource = gpresupuesto.Consultar(presupuesto, val);
                }
                else
                {
                    dataGridView1.DataSource = gpresupuesto.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPresupuestoProveedor);
                CargarBitacora(19,5);
        
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
                if (cbxIdPresupuestoProveedor.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdPresupuestoProveedor.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPresupuestoProveedor.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese elemento.");
                    return;
                }
                gpresupuesto.Consultar(presupuesto, val);

                cbxIdProveedor.DataSource = gproveedor.Consultar(proveedor, presupuesto.Idproveedor);
                cbxIdProveedor.DisplayMember = "NombreEmpresa";
                cbxIdProveedor.ValueMember = "IdProveedor";

                cbxIdStock.DataSource = gstock.Consultar(stock, presupuesto.Idstock);
                cbxIdStock.DisplayMember = "Nombre";
                cbxIdStock.ValueMember = "IdStock";

                txbPrecio.Text=Convert.ToString(presupuesto.Precio);
                txbCantidad.Text = Convert.ToString(presupuesto.Cantidad);

                dateTimePicker1.Text = presupuesto.Fechapresupuesto.ToString();
                dateTimePicker2.Text = presupuesto.Fechavalidez.ToString();
                txbSubtotal.Text = presupuesto.Subtotal.ToString();
                txbIva.Text = presupuesto.Iva.ToString();
                txbTotal.Text = presupuesto.Total.ToString();
                dataGridView1.DataSource = gpresupuesto.ListarCatalogo2();
                CargarBitacora(19, 4);
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
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdPresupuestoProveedor.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un presupuesto de la lista.",
                        "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdPresupuestoProveedor.Focus();
                    return;
                }

                int idPresupuesto;
                if (!int.TryParse(
                        cbxIdPresupuestoProveedor.SelectedValue.ToString(),
                        out idPresupuesto) ||
                    idPresupuesto <= 0)
                {
                    MessageBox.Show("El presupuesto seleccionado no es válido.",
                        "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Deseás recalcular el subtotal y el total con la cantidad, el precio y el IVA actuales?",
                    "Recalcular importes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes && !RecalcularImportes())
                    return;

                if (!ValidarCampos())
                    return;

                if (cbxIdProveedor.SelectedValue == null ||
                    cbxIdStock.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná un proveedor y un producto del stock.",
                        "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                presupuesto = new BE.cls18_PresupuestoProveedor();

                // Este ID es necesario para que Editar sepa qué registro modificar.
                presupuesto.Idpresupuestoproveedor = idPresupuesto;

                presupuesto.Idproveedor =
                    Convert.ToInt32(cbxIdProveedor.SelectedValue);
                presupuesto.Idstock =
                    Convert.ToInt32(cbxIdStock.SelectedValue);

                presupuesto.Precio = int.Parse(txbPrecio.Text);
                presupuesto.Cantidad = int.Parse(txbCantidad.Text);

                presupuesto.Fechapresupuesto = dateTimePicker1.Value;
                presupuesto.Fechavalidez = dateTimePicker2.Value;
                presupuesto.Idlogin = clsPerdurables.Id_Login;

                presupuesto.Subtotal = int.Parse(txbSubtotal.Text);
                presupuesto.Iva = int.Parse(txbIva.Text);
                presupuesto.Total = int.Parse(txbTotal.Text);

                int filasAfectadas = gpresupuesto.Editar(presupuesto);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("El presupuesto se modificó correctamente.",
                        "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarBitacora(19, 2);
                    CargarCombo();
                    LimpiarControles(this);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el presupuesto.",
                        "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,
                    "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdPresupuestoProveedor.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar un elemento de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdPresupuestoProveedor.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPresupuestoProveedor.SelectedValue.ToString(), out val))
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
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdPresupuestoProveedor, "un presupuesto de proveedor");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("PresupuestoProveedor", idBorrar, "el presupuesto de proveedor")) return;
                    presupuesto = new BE.cls18_PresupuestoProveedor();
                    presupuesto.Idpresupuestoproveedor = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gpresupuesto.Eliminar(presupuesto), "el presupuesto de proveedor")) return;
                    LimpiarControles(this);
                    CargarCombo();
                    CargarBitacora(19, 3);
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
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Presupuestos Proveedores a Excel";
                guardar.FileName = "AluSoft_Presupuestos_Proveedores_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Presupuestos Proveedores");

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

        private void cbxIdPresupuestoProveedor_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdPresupuestoProveedor.Text;
                List<BE.cls18_PresupuestoProveedor> filtrados;
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
                cbxIdPresupuestoProveedor.DataSource = null;
                cbxIdPresupuestoProveedor.DataSource = filtrados;
                cbxIdPresupuestoProveedor.DisplayMember = "Combo";
                cbxIdPresupuestoProveedor.ValueMember = "IdPresupuestoProveedor";
                cbxIdPresupuestoProveedor.Text = texto;
                cbxIdPresupuestoProveedor.SelectionStart = texto.Length;
                cbxIdPresupuestoProveedor.SelectionLength = 0;
                cbxIdPresupuestoProveedor.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
