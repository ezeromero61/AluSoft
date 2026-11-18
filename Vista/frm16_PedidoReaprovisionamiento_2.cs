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
    public partial class frm16_PedidoReaprovisionamiento_2 : Form
    {
        public frm16_PedidoReaprovisionamiento_2()
        {
            InitializeComponent();
        }
        BE.cls00_Persona persona = new BE.cls00_Persona();
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls04_Proveedor prov = new BE.cls04_Proveedor();
        BLL.Proveedor gprov = new BLL.Proveedor();
        BE.cls35_Bitacora bitacora = new BE.cls35_Bitacora();
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls16_PedidoReaprovisionamiento reaprov = new BE.cls16_PedidoReaprovisionamiento();
        BLL.PedidoReaprovisionamiento greaprov = new BLL.PedidoReaprovisionamiento();
        #region Auxiliares
        private List<BE.cls16_PedidoReaprovisionamiento> listaPersonasOriginal;
        private List<BE.cls04_Proveedor> listaPersonasOriginal2;
        private bool filtrandoCombo = false;
        private void CargarComboProveedor()
        {
            listaPersonasOriginal2 = gprov.Listar2();

            cbxIdProveedor.DataSource = null;
            cbxIdProveedor.DataSource = listaPersonasOriginal2;
            cbxIdProveedor.DisplayMember = "NombreEmpresa";
            cbxIdProveedor.ValueMember = "IdProveedor";
            cbxIdProveedor.SelectedIndex = -1;
            cbxIdProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
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
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).Text = "";
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
            listaPersonasOriginal = greaprov.ListarCatalogo2();
            cbxIdPedidoReaprovionamiento.DataSource = listaPersonasOriginal;
            cbxIdPedidoReaprovionamiento.DisplayMember = "Combo";
            cbxIdPedidoReaprovionamiento.ValueMember = "IdPedidoReaprovisionamiento";
            cbxIdPedidoReaprovionamiento.SelectedIndex = -1;
            cbxIdPedidoReaprovionamiento.DropDownStyle = ComboBoxStyle.DropDown;
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
        private void frm16_PedidoReaprovisionamiento_2_Load(object sender, EventArgs e)
        {
            CargarComboProveedor();
            CargarComboPresupuesto();
            CargarCombo();
            CargarBitacora(17,7);
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Reaprovisionamiento);
        }
        private void MostrarProducto()
        {
            BE.cls18_PresupuestoProveedor p = cbxIdPresupuestoProveedor.SelectedItem as BE.cls18_PresupuestoProveedor;
            txbDetalleProducto.Text = p == null ? "" : p.Nombre;
        }
        private bool cargandoPedido = false;
        private void CargarComboPresupuesto()
        {
            cbxIdPresupuestoProveedor.DataSource = new BLL.PresupuestoProveedor().ListarCatalogo2();
            cbxIdPresupuestoProveedor.DisplayMember = "Combo";
            cbxIdPresupuestoProveedor.ValueMember = "IdPresupuestoProveedor";
            cbxIdPresupuestoProveedor.SelectedIndex = -1;
            cbxIdPresupuestoProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxIdPresupuestoProveedor.DropDownWidth = 420;
            cbxIdPresupuestoProveedor.SelectedIndexChanged += delegate
            {
                MostrarProducto();
                // Si se cambia el presupuesto a mano, se toman sus datos.
                if (cargandoPedido) return;
                BE.cls18_PresupuestoProveedor p = cbxIdPresupuestoProveedor.SelectedItem as BE.cls18_PresupuestoProveedor;
                if (p == null) return;
                cbxIdProveedor.SelectedValue = p.Idproveedor;
                txbPrecio.Text = p.Precio.ToString();
                txbCantidad.Text = p.Cantidad.ToString();
                txbIVA.Text = p.Iva.ToString();
                txbSubtotal.Text = p.Subtotal.ToString();
                txbTotal.Text = p.Total.ToString();
            };
        }
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdPedidoReaprovionamiento);
                if (val != 0)
                {
                    dataGridView1.DataSource = greaprov.Consultar(reaprov, val);
                }
                else
                {
                    dataGridView1.DataSource = greaprov.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPedidoReaprovionamiento);
                CargarBitacora(17,5);
        
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
                if (cbxIdPedidoReaprovionamiento.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdPedidoReaprovionamiento.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPedidoReaprovionamiento.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese elemento.");
                    return;
                }
                reaprov = new BE.cls16_PedidoReaprovisionamiento();
                greaprov.Consultar(reaprov, val);

                cargandoPedido = true;
                if (reaprov.IdPresupuestoProveedor > 0)
                    cbxIdPresupuestoProveedor.SelectedValue = reaprov.IdPresupuestoProveedor;
                else
                    cbxIdPresupuestoProveedor.SelectedIndex = -1;
                cbxIdProveedor.SelectedValue = reaprov.Idproveedor;
                cargandoPedido = false;
                MostrarProducto();

                dateTimePicker2.Text = reaprov.Fechapedido.ToString();
                dateTimePicker3.Text = reaprov.Fechaentregaestimada.ToString();
                dateTimePicker1.Text = reaprov.Fechaentregareal.ToString();

                txbPrecio.Text= reaprov.Precio.ToString();
                txbCantidad.Text = reaprov.Cantidad.ToString();
                txbIVA.Text = reaprov.IVA.ToString();
                txbSubtotal.Text = reaprov.Subtotal.ToString();
                txbTotal.Text = reaprov.Total.ToString();

                txbEstado.Text = reaprov.Estado;
                txbPrioridad.Text = reaprov.Prioridad.ToString();
                txbObservaciones.Text = reaprov.Observaciones.ToString();
                dataGridView1.DataSource = greaprov.ListarCatalogo2();
                CargarBitacora(17,4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdPedidoReaprovionamiento.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdPedidoReaprovionamiento.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPedidoReaprovionamiento.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                int fa = 0;
                reaprov = new BE.cls16_PedidoReaprovisionamiento();
                reaprov.Idpedidoreaprovisionamiento = Convert.ToInt32(cbxIdPedidoReaprovionamiento.SelectedValue);
                reaprov.Idproveedor = Convert.ToInt32(cbxIdProveedor.SelectedValue);
                reaprov.IdPresupuestoProveedor = Convert.ToInt32(cbxIdPresupuestoProveedor.SelectedValue);
                reaprov.Fechapedido = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker2.Text),"Fecha pedido");
                reaprov.Fechaentregaestimada = clsValidacionesPerdurables.FechaPosterior(DateTime.Parse(dateTimePicker3.Text), DateTime.Parse(dateTimePicker1.Text),"Fecha entrega estimada");
                reaprov.Fechaentregareal = clsValidacionesPerdurables.FechaPosterior(DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text),"Fecha entrega real");
                reaprov.Precio=clsValidacionesPerdurables.SoloNumeros(txbPrecio.Text,"Precio");
                reaprov.Cantidad=clsValidacionesPerdurables.SoloNumeros(txbCantidad.Text,"Cantidad");
                reaprov.IVA = clsValidacionesPerdurables.SoloNumeros(txbIVA.Text,"IVA");
                reaprov.Subtotal= clsValidacionesPerdurables.SoloNumeros(txbSubtotal.Text,"Subtotal");
                reaprov.Total = clsValidacionesPerdurables.SoloNumeros(txbTotal.Text,"Total");
                reaprov.Estado = txbEstado.Text;
                reaprov.Prioridad = string.IsNullOrWhiteSpace(txbPrioridad.Text) ? BLL.Estados.Prioridad[1] : txbPrioridad.Text;
                reaprov.Observaciones = (txbObservaciones.Text);
                reaprov.Idlogin = clsPerdurables.Id_Login;
                reaprov.DigitoVerificador = 1;
                fa = greaprov.Editar(reaprov);

                if (fa != 0)
                {
                    MessageBox.Show("Pedido N° " + reaprov.Idpedidoreaprovisionamiento + " modificado.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(17, 2);
                    CargarCombo();
                }
                else
                {
                    MessageBox.Show("Error");
                }
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
                if (cbxIdPedidoReaprovionamiento.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdPedidoReaprovionamiento.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPedidoReaprovionamiento.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdPedidoReaprovionamiento, "un pedido de reaprovisionamiento");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("PedidoReaprovisionamiento", idBorrar, "el pedido de reaprovisionamiento")) return;
                    reaprov = new BE.cls16_PedidoReaprovisionamiento();
                    reaprov.Idpedidoreaprovisionamiento = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(greaprov.Eliminar(reaprov), "el pedido de reaprovisionamiento")) return;
                    LimpiarControles(this);
                    #region Cliente
                    CargarCombo();
                    CargarBitacora(17,3);                   
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Pedidos Reaprovisionamiento a Excel";
                guardar.FileName = "AluSoft_Pedidos_Reaprovisionamiento_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Pedidos Reaprovisionamiento");

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
        private void cbxIdPedidoReaprovionamiento_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdPedidoReaprovionamiento.Text;
                List<BE.cls16_PedidoReaprovisionamiento> filtrados;
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
                cbxIdPedidoReaprovionamiento.DataSource = null;
                cbxIdPedidoReaprovionamiento.DataSource = filtrados;
                cbxIdPedidoReaprovionamiento.DisplayMember = "Combo";
                cbxIdPedidoReaprovionamiento.ValueMember = "IdPedidoReaprovisionamiento";
                cbxIdPedidoReaprovionamiento.Text = texto;
                cbxIdPedidoReaprovionamiento.SelectionStart = texto.Length;
                cbxIdPedidoReaprovionamiento.SelectionLength = 0;
                cbxIdPedidoReaprovionamiento.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }
    }
}
