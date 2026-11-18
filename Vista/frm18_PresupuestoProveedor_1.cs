using BLL;
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

namespace AluSoft
{
    public partial class frm18_PresupuestoProveedor_1 : Form
    {
        public frm18_PresupuestoProveedor_1()
        {
            InitializeComponent();
        }
        private int idProveedorInicial;
        public frm18_PresupuestoProveedor_1(int idProveedor) : this()
        {
            idProveedorInicial = idProveedor;
        }
        BE.cls04_Proveedor proveedor;
        BLL.Proveedor gproveedor = new BLL.Proveedor();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        BE.cls18_PresupuestoProveedor presu;
        BLL.PresupuestoProveedor gpresu = new BLL.PresupuestoProveedor();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls04_Proveedor> listaPersonasOriginal;
        private List<BE.cls02_Stock> listaPersonasOriginal2;
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
        private void ActualizarImportes()
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
                txbSubtotal.Clear();
                txbTotal.Clear();
                return;
            }

            decimal subtotal = cantidad * precio;
            decimal importeIva = subtotal * porcentajeIva / 100m;
            decimal total = Math.Round(subtotal + importeIva, 0);

            txbSubtotal.Text = Math.Round(subtotal, 0).ToString("0", CultureInfo.CurrentCulture);
            txbTotal.Text = total.ToString("0", CultureInfo.CurrentCulture);
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
                    ((ComboBox)control).SelectedIndex = -1;
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
        private void CargarComboProv()
        {
            proveedor = new BE.cls04_Proveedor();
            listaPersonasOriginal = gproveedor.Listar2();
            cbxIdProveedor.DataSource = listaPersonasOriginal;
            cbxIdProveedor.DisplayMember = "Combo";
            cbxIdProveedor.ValueMember = "IdProveedor";
            cbxIdProveedor.SelectedIndex = -1;
            cbxIdProveedor.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void CargarComboStock()
        {
            stock = new BE.cls02_Stock();
            // Primero los productos por debajo del stock mínimo (los que hay que reponer).
            listaPersonasOriginal2 = gstock.ListarCatalogo2()
                .OrderBy(s => s.Cantidad_actual < s.Cantidad_minima ? 0 : 1)
                .ThenBy(s => s.Combo)
                .ToList();
            foreach (BE.cls02_Stock s in listaPersonasOriginal2)
            {
                if (s.Cantidad_actual < s.Cantidad_minima)
                    s.Combo = "⚠ " + s.Combo + " (stock " + s.Cantidad_actual + " / mín " + s.Cantidad_minima + ")";
                else
                    s.Combo = s.Combo + " (stock " + s.Cantidad_actual + ")";
            }
            cbxIdStock.DataSource = listaPersonasOriginal2;
            cbxIdStock.DisplayMember = "Combo";
            cbxIdStock.ValueMember = "IdStock";
            cbxIdStock.SelectedIndex = -1;
            cbxIdStock.DropDownStyle = ComboBoxStyle.DropDown;
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
                global::AluSoft.UI.ValidacionCampos.EnfocarYMostrar(primerControlInvalido);
            return valido;
        }
        private void ValidarControlesRecursivamente(Control contenedor, ref bool valido, ref Control primerControlInvalido)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control.Visible && control.Enabled && !global::AluSoft.UI.ValidacionCampos.EsOpcional(control))
                {
                    if (control is TextBox && !((TextBox)control).ReadOnly)
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

        private void frm18_PresupuestoProveedor_1_Load(object sender, EventArgs e)
        {
            txbSubtotal.ReadOnly = true;
            txbSubtotal.TabStop = false;
            txbTotal.ReadOnly = true;
            txbTotal.TabStop = false;
            CargarComboStock();
            CargarComboProv();
            CargarBitacora(19,7);
            cbxIdStock.SelectedIndexChanged += delegate { SugerirCantidad(); };
            if (string.IsNullOrWhiteSpace(txbIva.Text)) txbIva.Text = "21";
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdProveedor, idProveedorInicial);
        }

        // Sugiere reponer hasta el stock máximo.
        private void SugerirCantidad()
        {
            BE.cls02_Stock s = cbxIdStock.SelectedItem as BE.cls02_Stock;
            if (s == null) return;
            int sugerida = s.Cantidad_maxima - s.Cantidad_actual;
            if (sugerida > 0) txbCantidad.Text = sugerida.ToString();
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                if (!ValidarCampos()) return;
                presu = new BE.cls18_PresupuestoProveedor();
                presu.Idpresupuestoproveedor = (gpresu.Max(presu) + 1);
                presu.Idproveedor = Convert.ToInt32(cbxIdProveedor.SelectedValue);
                presu.Idstock = Convert.ToInt32(cbxIdStock.SelectedValue);
                presu.Precio = int.Parse(txbPrecio.Text);
                presu.Cantidad = int.Parse(txbCantidad.Text);
                presu.Fechapresupuesto = DateTime.Parse(dateTimePicker1.Text);
                presu.Fechavalidez = DateTime.Parse(dateTimePicker2.Text);
                presu.Idlogin = clsPerdurables.Id_Login;
                presu.Subtotal = int.Parse(txbSubtotal.Text);
                presu.Iva = int.Parse(txbIva.Text);
                presu.Total = int.Parse(txbTotal.Text);
                fa = gpresu.Agregar(presu);

                if (fa != 0)
                {
                    MessageBox.Show("Presupuesto N° " + presu.Idpresupuestoproveedor + " guardado.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(19,1);
                    if (global::AluSoft.UI.Navegacion.Preguntar("¡Presupuesto aprobado! ¿Querés generar el pedido de reaprovisionamiento?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new global::AluSoftPresentacion16_6.frm16_PedidoReaprovisionamiento(presu.Idpresupuestoproveedor));
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                    return;
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);           
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdProveedor);
                if (val != 0)
                {
                    dataGridView1.DataSource = gproveedor.Consultar(proveedor, val);
                }
                else
                {
                    dataGridView1.DataSource = gproveedor.ListarCatalogo();
                }
                #region Bitacora 
                int fu;
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 19;
                bitacora.idaccion = 5;
                bitacora.fecha = (DateTime.Now);
                bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                fu = gbitacora.Agregar(bitacora);
                #endregion
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdProveedor);
            }
               
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Complete el formulario con los datos correctos y presione guardar. " +
          "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
          "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
          "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }

        private void cbxIdProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIdProveedor.SelectedIndex < 0 ||cbxIdProveedor.SelectedValue == null)
                return;

            int idProveedor;

            if (!int.TryParse(cbxIdProveedor.SelectedValue.ToString(),out idProveedor))
                return;

            proveedor = new BE.cls04_Proveedor();

            DataTable datos = gproveedor.Consultar(proveedor, idProveedor);

            if (datos == null || datos.Rows.Count == 0)
                return;

            // Acá asigná las propiedades del proveedor a sus TextBox.
            // Ejemplo, si tenés un TextBox llamado txbNombreEmpresa:
            // txbNombreEmpresa.Text = proveedor.NombreEmpresa;
        }

        private void txbCantidad_TextChanged(object sender, EventArgs e)
        {
            ActualizarImportes();
        }

        private void txbPrecio_TextChanged(object sender, EventArgs e)
        {
            ActualizarImportes();
        }

        private void txbIva_TextChanged(object sender, EventArgs e)
        {
            ActualizarImportes();
        }
    }
}
