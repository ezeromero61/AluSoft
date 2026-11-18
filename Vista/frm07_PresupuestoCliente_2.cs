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
    public partial class frm07_PresupuestoCliente_2 : Form
    {
        public frm07_PresupuestoCliente_2()
        {
            InitializeComponent();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls03_Cliente cliente=new BE.cls03_Cliente();
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls12_Catalogo catalogo= new BE.cls12_Catalogo();
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls07_PresupuestoCliente presupuesto = new BE.cls07_PresupuestoCliente();
        BLL.PresupuestroCliente gpresupuesto = new BLL.PresupuestroCliente();
        BE.cls26_Combinado combinado = new BE.cls26_Combinado();
        #region Auxiliares
        private List<BE.cls26_Combinado> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private global::AluSoft.UI.PanelRenglones renglones;
        private BLL.PresupuestoDetalle gdetalle = new BLL.PresupuestoDetalle();
        private BLL.ListaPrecios glpre = new BLL.ListaPrecios();
        private List<BE.cls13_ListaPrecios> listaPrecios;

        private void CargarComboProductos(int idCatalogo)
        {
            listaPrecios = glpre.ListarCatalogo2()
                .GroupBy(l => l.Idcatalogo)
                .Select(g => g.OrderByDescending(l => l.Fecha).ThenByDescending(l => l.Idlista).First())
                .OrderBy(l => l.Nombre)
                .ToList();
            cbxIdCatalogo.DataSource = null;
            cbxIdCatalogo.DisplayMember = "Nombre";
            cbxIdCatalogo.ValueMember = "Idcatalogo";
            cbxIdCatalogo.DataSource = listaPrecios;
            cbxIdCatalogo.SelectedValue = idCatalogo;
        }

        private void AgregarRenglon()
        {
            BE.cls13_ListaPrecios producto = cbxIdCatalogo.SelectedItem as BE.cls13_ListaPrecios;
            int cantidad;
            if (producto == null || !int.TryParse(txbCantidades.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Elegí el producto del catálogo y escribí la cantidad.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            renglones.Agregar(producto.Idcatalogo, producto.Nombre, cantidad, producto.Precio);
        }

        private bool ActualizarSubTotal()
        {
            return ActualizarSubTotal(true);
        }

        private bool ActualizarSubTotal(bool avisar)
        {
            if (txbImpuestos.Text.Trim().Length == 0) txbImpuestos.Text = "21";
            decimal precio = 0;
            decimal cantidad = 0;
            decimal porcentajeImpuesto;
            decimal descuento;

            bool hayRenglones = renglones != null && renglones.Renglones.Count > 0;
            if ((!hayRenglones &&
                 (!decimal.TryParse(txbPrecio.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out precio) ||
                  !decimal.TryParse(txbCantidades.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out cantidad))) ||
                !decimal.TryParse(txbImpuestos.Text, NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out porcentajeImpuesto) ||
                !decimal.TryParse(txbDescuento.Text, NumberStyles.Number,
                                  CultureInfo.CurrentCulture, out descuento))
            {
                if (avisar)
                    MessageBox.Show("Revisá el precio, la cantidad, los impuestos y el descuento.",
                        "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal subtotal = hayRenglones ? renglones.Subtotal : precio * cantidad;

            if (descuento < 0 || descuento > subtotal)
            {
                if (avisar)
                    MessageBox.Show("El descuento no puede ser negativo ni superar el subtotal.",
                        "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal total = Math.Round((subtotal - descuento) * (1 + porcentajeImpuesto / 100m), 0);

            txbSubtotal.Text = subtotal.ToString("0");
            txbTotal.Text = total.ToString("0");

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
            listaPersonasOriginal = gpresupuesto.ListarCatalogo2();
            cbxIdPresupuestoCliente.DataSource = listaPersonasOriginal;
            cbxIdPresupuestoCliente.DisplayMember = "Combo";
            cbxIdPresupuestoCliente.ValueMember = "IdPresupuesto";
            cbxIdPresupuestoCliente.SelectedIndex = -1;
            cbxIdPresupuestoCliente.DropDownStyle = ComboBoxStyle.DropDown;
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
                    ValidarControlesRecursivamente(control, ref valido,ref primerControlInvalido);
                }
            }
        }
        private void ComboIndividual(int val)
        {
            dataGridView1.DataSource = gpresupuesto.Consultar(presupuesto, val);
            dataGridView1.Columns["Idpresupuesto"].Visible = false;
            dataGridView1.Columns["Idcliente"].Visible = false;
            dataGridView1.Columns["IdCatalogo"].Visible = false;
            dataGridView1.Columns["DigitoVerificador"].Visible = false;
        }
        private void ComboCompleto()
        {
            dataGridView1.DataSource = gpresupuesto.ListarCatalogo();
            dataGridView1.Columns["Idpresupuesto"].Visible = false;
            dataGridView1.Columns["Idcliente"].Visible = false;
            dataGridView1.Columns["IdCatalogo"].Visible = false;
            dataGridView1.Columns["IdLogin"].Visible = false;
            dataGridView1.Columns["DigitoVerificador"].Visible = false;
        }
        #endregion
        private void frm07_PresupuestoCliente_2_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Presupuesto);
            renglones = new global::AluSoft.UI.PanelRenglones(dataGridView1);
            renglones.BtnAgregar.Click += delegate { AgregarRenglon(); };
            renglones.Cambio += delegate { if (renglones.Editable) ActualizarSubTotal(false); };
            renglones.Editable = false;
            cbxIdCatalogo.SelectedIndexChanged += delegate
            {
                BE.cls13_ListaPrecios p = cbxIdCatalogo.SelectedItem as BE.cls13_ListaPrecios;
                if (p != null && renglones.Editable) txbPrecio.Text = p.Precio.ToString();
            };
            CargarCombo();
            CargarBitacora(8,7);
        }
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdPresupuestoCliente);
                if (val != 0)
                {
                    ComboIndividual(val);//dataGridView1.DataSource = gpresupuesto.Consultar(presupuesto, val);
                }
                else
                {
                    ComboCompleto();//dataGridView1.DataSource = gpresupuesto.ListarCatalogo();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPresupuestoCliente);
                CargarBitacora(8, 5);          
        
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
                if (cbxIdPresupuestoCliente.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un preesupuesto de la lista.","AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdPresupuestoCliente.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPresupuestoCliente.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El presupuesto seleccionado no es válido.","AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese presupuesto.");
                    return;
                }
                #region 07_Asistencias_Alumnos
                gpresupuesto.Consultar2(combinado, val);
                cbxIdCliente.DataSource = null;
                cbxIdCliente.DisplayMember = "Combo";
                cbxIdCliente.ValueMember = "IdCliente";
                cbxIdCliente.DataSource = gcliente.Listar2();
                cbxIdCliente.SelectedValue = combinado.Idcliente;
                renglones.Editable = false;
                CargarComboProductos(combinado.IdCatalogo);
                dateTimePicker1.Text = combinado.FechaCreacion.ToString();
                txbEstado.Text = combinado.Estado;
                txbObservaciones.Text = combinado.Observaciones;
                txbDescuento.Text = combinado.Descuento.ToString();
                txbTotal.Text = combinado.Total.ToString();
                txbPlazoEntrega.Text = combinado.PlazoEntregaDias.ToString();
                dateTimePicker2.Text = combinado.FechaValidez.ToString();
                txbDescripcion.Text = combinado.Descripcion;
                txbSubtotal.Text = combinado.Subtotal.ToString();
                txbCantidades.Text = combinado.Cantidad.ToString();
                txbPrecio.Text = combinado.Precio.ToString();
                txbImpuestos.Text = combinado.Impuestos.ToString();
                txbFormaPago.Text = combinado.FormaPago;
                ComboIndividual(val);//dataGridView1.DataSource = gpresupuesto.ListarCatalogo2();
                List<BE.cls36_PresupuestoDetalle> detalle = gdetalle.Listar(val);
                if (detalle.Count == 0 && combinado.IdCatalogo > 0)
                {
                    BE.cls13_ListaPrecios p = listaPrecios.FirstOrDefault(l => l.Idcatalogo == combinado.IdCatalogo);
                    BE.cls36_PresupuestoDetalle d = new BE.cls36_PresupuestoDetalle();
                    d.IdCatalogo = combinado.IdCatalogo;
                    d.Producto = p != null ? p.Nombre : combinado.Producto;
                    d.Cantidad = combinado.Cantidad > 0 ? combinado.Cantidad : 1;
                    d.PrecioUnitario = combinado.Precio > 0 ? combinado.Precio : (p != null ? p.Precio : 0);
                    detalle.Add(d);
                }
                renglones.Cargar(detalle);
                renglones.Editable = string.Equals(combinado.Estado, "Pendiente", StringComparison.OrdinalIgnoreCase);
                #endregion
                CargarBitacora(8,4);               
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
                if (cbxIdPresupuestoCliente.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un presupuesto de la lista.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdPresupuestoCliente.Focus();
                    return;
                }

                int val;
                if (!int.TryParse(cbxIdPresupuestoCliente.SelectedValue.ToString(), out val) ||
                    val <= 0)
                {
                    MessageBox.Show("El presupuesto seleccionado no es válido.",
                        "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (renglones.Renglones.Count == 0)
                {
                    MessageBox.Show("El presupuesto tiene que tener al menos un producto.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!ActualizarSubTotal())
                    return;

                if (!ValidarCampos())
                    return;

                presupuesto = new BE.cls07_PresupuestoCliente();
                presupuesto.Idpresupuesto = val;
                presupuesto.Idcliente = clsValidacionesPerdurables.SoloNumeros(cbxIdCliente.SelectedValue.ToString(), "Id cliente");
                presupuesto.Idcatalogo = renglones.Renglones[0].IdCatalogo;
                presupuesto.Cantidad = renglones.Renglones[0].Cantidad;
                presupuesto.FechaCreacion =clsValidacionesPerdurables.FechaNoFutura(DateTime.Parse(dateTimePicker1.Text), "Fecha de creación");
                presupuesto.FechaValidez =clsValidacionesPerdurables.FechaPosterior(DateTime.Parse(dateTimePicker2.Text),presupuesto.FechaCreacion,"Fecha de validez");
                presupuesto.Estado = txbEstado.Text;
                presupuesto.Descripcion = renglones.Renglones.Count > 0 ? renglones.Resumen : txbDescripcion.Text;
                presupuesto.Observaciones = txbObservaciones.Text;
                presupuesto.Subtotal = renglones.Renglones.Count > 0 ? renglones.Subtotal : clsValidacionesPerdurables.SoloNumeros(txbSubtotal.Text, "Subtotal");
                presupuesto.Descuento = clsValidacionesPerdurables.SoloNumeros(txbDescuento.Text, "Descuento");
                presupuesto.Impuestos = 21;
                presupuesto.Total = clsValidacionesPerdurables.SoloNumeros(txbTotal.Text, "Total");
                presupuesto.FormaPago = txbFormaPago.Text;
                presupuesto.PlazoEntregaDias = clsValidacionesPerdurables.SoloNumeros(txbPlazoEntrega.Text, "Plazo de entrega en días");
                presupuesto.Idlogin = clsPerdurables.Id_Login;

                int filasAfectadas = gpresupuesto.Editar(presupuesto);

                if (filasAfectadas != 0)
                {
                    if (renglones.Editable)
                        gdetalle.Guardar(val, renglones.Renglones);
                    MessageBox.Show("Se modificó el presupuesto correctamente.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCombo();
                    LimpiarControles(this);
                    CargarBitacora(8, 2);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el presupuesto.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdPresupuestoCliente.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un preesupuesto de la lista.", "AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdPresupuestoCliente.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdPresupuestoCliente.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El presupuesto seleccionado no es válido.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para ese presupuesto.");
                    return;
                }
                #region eliminar
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este elemento?. Are you sure you want to delete this item?. Êtes-vous sûr de vouloir supprimer cet élément ?", "Confirmar eliminación. Confirm delete. Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    presupuesto = new BE.cls07_PresupuestoCliente();
                    presupuesto.Idpresupuesto = val;
                    int fa = gpresupuesto.Eliminar(presupuesto);
                    MessageBox.Show("Se han eliminado " + fa + " filas", "AluSoft",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles(this);
                    CargarCombo();
                    CargarBitacora(8,3);                 
                }
                else
                {
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Ocurrió un error: " + ex.Message,"AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }
        private void cbxIdPresupuestoCliente_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;
            try
            {
                filtrandoCombo = true;
                string texto = cbxIdPresupuestoCliente.Text;
                List<BE.cls26_Combinado> filtrados;
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
                cbxIdPresupuestoCliente.DataSource = null;
                cbxIdPresupuestoCliente.DataSource = filtrados;
                cbxIdPresupuestoCliente.DisplayMember = "IdPresupuesto";
                cbxIdPresupuestoCliente.ValueMember = "IdPresupuesto";
                cbxIdPresupuestoCliente.Text = texto;
                cbxIdPresupuestoCliente.SelectionStart = texto.Length;
                cbxIdPresupuestoCliente.SelectionLength = 0;
                cbxIdPresupuestoCliente.DroppedDown = true;
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
                guardar.Title = "Exportar Presupuestos Clientes a Excel";
                guardar.FileName = "AluSoft_Presupuestos_Clientes_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Presupuestos Clientes");

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
    }
}
