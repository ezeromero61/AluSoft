using BLL;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluSoft
{
    public partial class frm02_Stock_1 : Form
    {
        public frm02_Stock_1()
        {
            InitializeComponent();
        }
        // Se abre desde el alta de Inventario con el elemento ya elegido.
        private readonly int idInventarioInicial;
        public frm02_Stock_1(int idInventario) : this()
        {
            idInventarioInicial = idInventario;
        }
        BE.cls01_Inventario inventario = new BE.cls01_Inventario();
        BLL.Inventario ginventario = new BLL.Inventario();
        BE.cls02_Stock stock = new BE.cls02_Stock();
        BLL.Stock gstock = new BLL.Stock();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls01_Inventario> listaPersonasOriginal;
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
        private void CargarCombo()
        {
            // Solo se ofrecen los elementos que todavía no tienen stock (un registro de stock por elemento).
            HashSet<int> conStock = new HashSet<int>(gstock.ListarCatalogo2().Select(s => s.Idinventario));
            listaPersonasOriginal = ginventario.ListarCatalogo()
                .Where(i => !global::AluSoft.UI.BienDeUso.Es(i.Tipo))   // los bienes de uso no llevan stock
                .Where(i => !conStock.Contains(i.Idinventario) || i.Idinventario == idInventarioInicial)
                .ToList();
            cbxIdTipoDoc.DataSource = listaPersonasOriginal;
            cbxIdTipoDoc.DisplayMember = "Nombre";
            cbxIdTipoDoc.ValueMember = "IdInventario";
            cbxIdTipoDoc.SelectedIndex = -1;
            cbxIdTipoDoc.DropDownStyle = ComboBoxStyle.DropDown;
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
        private void frm02_Stock_1_Load(object sender, EventArgs e)
        {
            CargarCombo();
            cbxIdTipoDoc.DropDown += (s, ev) =>
            {
                if (cbxIdTipoDoc.Items.Count == 0)
                    MessageBox.Show("Todos los elementos del inventario ya tienen su stock cargado.\n\n" +
                        "Para agregar uno nuevo, primero cargalo en Inventario. Para cambiar cantidades usá la gestión de Stock.",
                        "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdTipoDoc, idInventarioInicial);
            CargarBitacora(3,7);
        }
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                int actual = clsValidacionesPerdurables.SoloNumeros(txbCantActual.Text, "Cantidad actual");
                int minima = clsValidacionesPerdurables.SoloNumeros(txbCantMin.Text, "Cantidad mínima");
                int maxima = clsValidacionesPerdurables.SoloNumeros(txbCantMax.Text, "Cantidad máxima");
                if (maxima < minima)
                {
                    MessageBox.Show("La cantidad máxima no puede ser menor que la mínima.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (actual > maxima)
                {
                    MessageBox.Show("El stock actual es mayor que el máximo aceptado.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idInventario = Convert.ToInt32(cbxIdTipoDoc.SelectedValue);
                BE.cls02_Stock existente = gstock.ListarCatalogo2().FirstOrDefault(s => s.Idinventario == idInventario);
                if (existente != null)
                {
                    MessageBox.Show("Este elemento ya tiene stock cargado (N° " + existente.Idstock + "). Modificalo desde la gestión de stock.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                stock = new BE.cls02_Stock();
                stock.Idinventario = idInventario;
                stock.Idstock = (gstock.Max(stock) + 1);
                stock.Cantidad_actual = actual;
                stock.Cantidad_minima = minima;
                stock.Cantidad_maxima = maxima;
                int fa = gstock.Agregar(stock);
                if (fa != 0)
                {
                    // Un elemento nuevo puede arrancar sin stock: se guarda igual y solo se avisa.
                    bool bajo = actual < minima;
                    string aviso = "Stock N° " + stock.Idstock + " guardado.";
                    if (bajo)
                        aviso += "\n\nEl stock actual (" + actual + ") está por debajo del mínimo (" + minima + "). Conviene hacer un pedido de reaprovisionamiento.";
                    MessageBox.Show(aviso, "AluSoft", MessageBoxButtons.OK, bajo ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
                    CargarBitacora(3, 1);
                    if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés cargar este elemento en el catálogo?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm12_Catalogo_1(idInventario));
                        return;
                    }
                    LimpiarControles(this);
                    CargarCombo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el stock: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxIdTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdTipoDoc.SelectedIndex;         
            if (selectedIndex >= 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ginventario.ListarCatalogo();
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
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdTipoDoc);
                if (val != 0)
                {
                    dataGridView1.DataSource = ginventario.Consultar(inventario, val);
                }
                else
                {
                    dataGridView1.DataSource = ginventario.ListarCatalogo();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdTipoDoc);
                CargarBitacora(3, 5);
        
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
    }
}
