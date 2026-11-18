using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AluSoftPresentacion16_6
{
    public partial class frm21_Produccion_1 : Form
    {
        public frm21_Produccion_1()
        {
            InitializeComponent();
        }

        private int idOrdenInicial;

        public frm21_Produccion_1(int idOrden) : this()
        {
            idOrdenInicial = idOrden;
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls14_OrdenProduccion op = new BE.cls14_OrdenProduccion();
        BLL.OrdenProduccion gop = new BLL.OrdenProduccion();
        BE.cls21_Produccion prod;
        BLL.Produccion gprod = new BLL.Produccion();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        #region Auxiliares
        private List<BE.cls03_Cliente> listaPersonasOriginal;
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
                    ((ComboBox)control).SelectedIndex = -1;
                    ((ComboBox)control).Text = "";
                }
                else if (control is System.Windows.Forms.CheckBox)
                {
                    ((System.Windows.Forms.CheckBox)control).Checked = false;
                }
                else if (control is System.Windows.Forms.RadioButton)
                {
                    ((System.Windows.Forms.RadioButton)control).Checked = false;
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
            cbxIdordeproduccion.DataSource = null;
            cbxIdordeproduccion.DisplayMember = "Combo";
            cbxIdordeproduccion.ValueMember = "IdOrdenProduccion";
            // Solo órdenes que todavía no tienen producción registrada y no están terminadas.
            HashSet<int> conProduccion = new HashSet<int>(gprod.ListarCatalogo().Select(p => p.Idordenproduccion));
            List<BE.cls15_Estado> estados = new BLL.Estado().ListarCatalogo();
            cbxIdordeproduccion.DataSource = gop.ListarCatalogo2().Where(o =>
            {
                if (conProduccion.Contains(o.Idordenproduccion)) return false;
                BE.cls15_Estado ultimo = estados.Where(e => e.Idordenproduccion == o.Idordenproduccion)
                    .OrderByDescending(e => e.Idestado).FirstOrDefault();
                string est = ultimo == null ? "" : (ultimo.Estado ?? "").Trim();
                return !global::AluSoft.UI.FechasEstado.Termino(est) && est != "Cancelado";
            }).ToList();
            cbxIdordeproduccion.SelectedIndex = -1;
            cbxIdordeproduccion.DropDownStyle = ComboBoxStyle.DropDownList;

            cbxidstock.DataSource = null;
            cbxidstock.DisplayMember = "Nombre";
            cbxidstock.ValueMember = "Idstock";
            cbxidstock.DataSource = gstock.ListarCatalogo2();
            cbxidstock.SelectedIndex = -1;
            cbxidstock.DropDownStyle = ComboBoxStyle.DropDownList;
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
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                prod = new BE.cls21_Produccion();
                if (!ValidarCampos()) return;
                prod.Idproduccion = (gprod.Max(prod)+1);
                prod.Idordenproduccion = int.Parse(cbxIdordeproduccion.SelectedValue.ToString());
                prod.Idstock = int.Parse(cbxidstock.SelectedValue.ToString());
                prod.Fecha = DateTime.Parse(dateTimePicker3.Text);
                string estadoElegido = txbEstado.Text;
                BE.cls14_OrdenProduccion ordenElegida = cbxIdordeproduccion.SelectedItem as BE.cls14_OrdenProduccion;
                // Orden de un pedido terminada acá: la producción se guarda "en curso" y la terminación se carga
                // como estado (así no suma al stock: lo fabricado para un pedido va al cliente).
                bool terminaPedido = ordenElegida != null && ordenElegida.IdPedido > 0 && global::AluSoft.UI.FechasEstado.Termino(estadoElegido);
                prod.Estado = terminaPedido ? BLL.Estados.Produccion[1] : estadoElegido;
                fa = gprod.Agregar(prod);
                if (fa != 0 && terminaPedido)
                {
                    BLL.Estado gestado = new BLL.Estado();
                    BE.cls15_Estado fin = new BE.cls15_Estado();
                    fin.Idestado = gestado.Max(fin) + 1;
                    fin.Idordenproduccion = ordenElegida.Idordenproduccion;
                    fin.Fechaorden = ordenElegida.Fechaorden;
                    fin.Fechainicioproduccion = prod.Fecha;
                    fin.Fechafinproduccion = prod.Fecha;
                    fin.Fechaentrega = estadoElegido == "Entregado" ? prod.Fecha : DateTime.MinValue;
                    fin.Estado = estadoElegido;
                    fin.Observaciones = "Terminada desde Producción";
                    gestado.Agregar(fin);
                }

                if (fa != 0)
                {
                    MessageBox.Show("La producción se registró correctamente. Estado de la orden: " + estadoElegido + ".", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(22,1);
                    BE.cls14_OrdenProduccion orden = ordenElegida;
                    CargarCombo();
                    if (orden != null && orden.IdPedido > 0)
                        global::AluSoft.UI.CadenaVenta.SiguientePaso(this, orden.IdPedido, orden.Idordenproduccion);
                }
                else
                {
                    MessageBox.Show("Error");
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);          
        }

        private void frm21_Produccion_1_Load(object sender, EventArgs e)
        {
            // Registrar la producción significa que la orden ya arrancó: no se ofrece "Pendiente" ni "Cancelado".
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado,
                BLL.Estados.Produccion.Where(s => s != "Pendiente" && s != "Cancelado").ToArray(), BLL.Estados.Produccion[1]);
            lblStockDisponible = new Label();
            lblStockDisponible.AutoSize = true;
            lblStockDisponible.ForeColor = System.Drawing.Color.FromArgb(0, 102, 153);
            lblStockDisponible.Location = new System.Drawing.Point(txbEstado.Left, txbEstado.Bottom + 10);
            groupBox2.Controls.Add(lblStockDisponible);
            CargarCombo();
            txbCantidad.Text = "";
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdordeproduccion, idOrdenInicial);
            cbxidstock.Enabled = false;   // el producto es siempre el de la orden
            CargarBitacora(22,7);
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdordeproduccion);
                if (val != 0)
                {
                    dataGridView1.DataSource = gop.Consultar(op, val);
                }
                else
                {
                    dataGridView1.DataSource = gop.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdordeproduccion);
                CargarBitacora(22, 5);
        
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

        private void cbxIdordeproduccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIdordeproduccion.SelectedIndex < 0 ||
        cbxIdordeproduccion.SelectedValue == null)
                return;

            int idOrden;
            if (!int.TryParse(cbxIdordeproduccion.SelectedValue.ToString(), out idOrden))
                return;

            op = new BE.cls14_OrdenProduccion();

            DataTable datos = gop.Consultar(op, idOrden);

            if (datos == null || datos.Rows.Count == 0)
                return;

            // Selecciona el stock asociado a la orden.
            cbxidstock.SelectedValue = op.Idstock;
            txbCantidad.Text = Convert.ToString(op.Cantidad);
            if (lblStockDisponible != null)
            {
                int hay = global::AluSoft.UI.CadenaVenta.StockActual(op.Idstock);
                lblStockDisponible.ForeColor = hay > 0 ? System.Drawing.Color.FromArgb(0, 102, 153) : System.Drawing.Color.Firebrick;
                lblStockDisponible.Text = hay > 0
                    ? "En stock: " + hay + " unidad(es)"
                    : "⚠ Sin stock de este producto: darle prioridad a esta producción";
            }
        }
        private Label lblStockDisponible;
    }
}
