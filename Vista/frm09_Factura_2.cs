using BLL;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluSoftPresentacion16_6
{
    public partial class frm09_Factura_2 : Form
    {
        public frm09_Factura_2()
        {
            InitializeComponent();
        }
        BE.cls08_PedidoCliente pedido = new BE.cls08_PedidoCliente();
        BLL.PedidoCliente gpedido = new BLL.PedidoCliente();
        BE.cls03_Cliente cliente = new BE.cls03_Cliente();
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls09_Factura factura = new BE.cls09_Factura();
        BLL.Factura gfactura = new BLL.Factura();
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls04_Proveedor prov;
        BLL.Proveedor gprov = new BLL.Proveedor();
        BE.cls35_Bitacora bitacora = new BE.cls35_Bitacora();
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls16_PedidoReaprovisionamiento reaprov;
        BLL.PedidoReaprovisionamiento greaprov = new BLL.PedidoReaprovisionamiento();
        #region Auxiliares
        // Los importes de la factura pueden venir con decimales desde la base ("1635000,00"):
        // se leen como decimal en vez de exigir solo números enteros.
        private static decimal LeerImporte(string texto, string campo)
        {
            decimal v;
            texto = (texto ?? "").Trim().Replace("$", "");
            if (decimal.TryParse(texto, NumberStyles.Number, CultureInfo.CurrentCulture, out v) ||
                decimal.TryParse(texto, NumberStyles.Number, CultureInfo.InvariantCulture, out v))
            {
                if (v < 0) throw new ArgumentException("El campo " + campo + " no puede ser negativo.");
                return v;
            }
            throw new ArgumentException("El campo " + campo + " debe ser un importe válido.");
        }
        private static string MostrarImporte(decimal v)
        {
            return v.ToString("0.##", CultureInfo.CurrentCulture);
        }
        // El IVA de la factura es el importe (21 % de subtotal − descuento), no el porcentaje.
        private bool RecalcularTotalFactura()
        {
            decimal subtotal, descuento;
            try
            {
                subtotal = LeerImporte(txbSubtotal.Text, "Subtotal");
                descuento = LeerImporte(txbDescuento.Text, "Descuento");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (descuento > subtotal)
            {
                MessageBox.Show("El descuento no puede superar el subtotal.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            decimal baseImponible = subtotal - descuento;
            decimal importeIVA = Math.Round(baseImponible * 0.21m, 2);
            txbIVA.Text = MostrarImporte(importeIVA);
            txbTotal.Text = MostrarImporte(baseImponible + importeIVA);
            return true;
        }
        private List<BE.cls09_Factura> listaPersonasOriginal;
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
            listaPersonasOriginal = gfactura.ListarCatalogo2();
            cbxIdFactura.DataSource = listaPersonasOriginal;
            cbxIdFactura.DisplayMember = "Combo";
            cbxIdFactura.ValueMember = "IdFactura";
            cbxIdFactura.SelectedIndex = -1;
            cbxIdFactura.DropDownStyle = ComboBoxStyle.DropDown;
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
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdFactura);
                if (val != 0)
                {
                    dataGridView1.DataSource = gfactura.Consultar(factura, val);
                }
                else
                {
                    dataGridView1.DataSource = gfactura.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdFactura);
                CargarBitacora(10,1);
        
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
                if (cbxIdFactura.SelectedValue == null)
                {
                    MessageBox.Show( "Debe seleccionar una persona de la lista.","AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdFactura.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdFactura.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("La persona seleccionada no es válida.", "AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa persona.");
                    return;
                }
                gfactura.Consultar(factura, val);
                txbTipofactura.Text = (factura.TipoFactura.ToString());

                cbxIdPedido.DataSource = gpedido.Consultar(pedido, factura.IdPedido);
                cbxIdPedido.DisplayMember = "IdPedido";
                cbxIdPedido.ValueMember = "IdPedido";

                cbxIdCliente.DataSource = gcliente.ConsultarPorIdCliente(cliente, factura.IdCliente); // [CORREGIDO] buscaba por IdPersona y mostraba otro cliente
                cbxIdCliente.DisplayMember = "Combo";
                cbxIdCliente.ValueMember = "IdCliente";

                txbCondicionIVA.Text = factura.CondicionIVA.ToString();
                txbDireccionFiscal.Text = factura.DireccionFiscal;
                dateTimePicker1.Text = factura.FechaEmision.ToString();
                dateTimePicker2.Text = factura.FechaVencimiento.ToString();
                txbSubtotal.Text = MostrarImporte(factura.Subtotal);
                txbDescuento.Text = MostrarImporte(factura.Descuento);
                txbIVA.Text = MostrarImporte(factura.IVA);
                txbTotal.Text = MostrarImporte(factura.Total);
                txbFormaPago.Text = factura.Formapago;
                txbEstado.Text = factura.Estado.ToString();
                txbCAE.Text = factura.CAE ?? "";
                dateTimePicker3.Value = factura.FechaVencimientoCAE ?? factura.FechaEmision;
                txbObservaciones.Text = factura.Observaciones.ToString();
                dataGridView1.DataSource = gfactura.Consultar(factura, val);
                CargarBitacora(10,4);
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
                if (cbxIdFactura.SelectedValue == null)
                {
                    MessageBox.Show( "Debe seleccionar un elemento de la lista.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdFactura.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdFactura.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show( "El elemento seleccionado no es válido.","AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                DialogResult respuesta = MessageBox.Show("¿Querés recalcular el IVA (21 %) y el total con el descuento actual?","Recalcular factura",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes && !RecalcularTotalFactura())
                    return;

                if (!ValidarCampos())
                    return;
                int fa = 0;
                factura = new BE.cls09_Factura();
                factura.Idfactura = val;
                factura.TipoFactura = (txbTipofactura.Text);
                factura.IdPedido = clsValidacionesPerdurables.SoloNumeros(cbxIdPedido.SelectedValue.ToString(),"Id pedido");
                factura.IdCliente = clsValidacionesPerdurables.SoloNumeros(cbxIdCliente.SelectedValue.ToString(), "Id cliente");
                factura.CondicionIVA = txbCondicionIVA.Text;
                factura.DireccionFiscal = txbDireccionFiscal.Text;
                factura.FechaEmision = clsValidacionesPerdurables.FechaObligatoria(dateTimePicker1.Value, "Fecha de emisión");
                factura.FechaVencimiento = clsValidacionesPerdurables.FechaPosterior(dateTimePicker2.Value, dateTimePicker1.Value, "Fecha de vencimiento");
                factura.Subtotal = LeerImporte(txbSubtotal.Text, "Subtotal");
                factura.Descuento = LeerImporte(txbDescuento.Text, "Descuento");
                factura.IVA = LeerImporte(txbIVA.Text, "IVA");
                factura.Total = LeerImporte(txbTotal.Text, "Total");
                factura.Formapago = txbFormaPago.Text;
                factura.Estado = txbEstado.Text;
                factura.CAE = txbCAE.Text;
                // El CAE no se usa (factura B a consumidor final): su vencimiento acompaña la emisión.
                factura.FechaVencimientoCAE = string.IsNullOrWhiteSpace(txbCAE.Text) ? factura.FechaEmision : dateTimePicker3.Value;
                factura.Observaciones = txbObservaciones.Text;
                fa = gfactura.Editar(factura);
                if (fa != 0)
                {
                    MessageBox.Show("Factura N° " + val + " modificada.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCombo();
                    LimpiarControles(this);
                    CargarBitacora(10, 2);        
                }
                else
                {
                    MessageBox.Show("Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Ocurrió un error: " + ex.Message,"AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdFactura.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdFactura.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdFactura.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show( "El elemento seleccionado no es válido.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                DialogResult resultado = MessageBox.Show("¿Seguro que querés eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // Se borra el registro ELEGIDO en el combo (antes se borraba el último buscado).
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdFactura, "una factura");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Factura", idBorrar, "la factura")) return;
                    factura = new BE.cls09_Factura();
                    factura.Idfactura = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(gfactura.Eliminar(factura), "la factura")) return;
                    LimpiarControles(this);
                    CargarBitacora(10,3);
                    CargarCombo();                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Ocurrió un error: " + ex.Message,"AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);           
        }
        private void frm09_Factura_2_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Factura);
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbFormaPago, BLL.Estados.FormaPago);
            CargarCombo();
            CargarBitacora(10,7);
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Facturas a Excel";
                guardar.FileName = "AluSoft_Facturas_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Facturas");

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
        private void cbxIdFactura_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdFactura.Text;
                List<BE.cls09_Factura> filtrados;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    filtrados = listaPersonasOriginal;
                }
                else
                {
                    filtrados = listaPersonasOriginal.Where(x => x.Combo != null && x.Combo.IndexOf(texto,StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                cbxIdFactura.DataSource = null;
                cbxIdFactura.DataSource = filtrados;
                cbxIdFactura.DisplayMember = "Combo";
                cbxIdFactura.ValueMember = "IdFactura";
                cbxIdFactura.Text = texto;
                cbxIdFactura.SelectionStart = texto.Length;
                cbxIdFactura.SelectionLength = 0;
                cbxIdFactura.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
