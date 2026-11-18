using BLL;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluSoft
{
    public partial class frm12_Catalogo_1 : Form
    {
        public frm12_Catalogo_1()
        {
            InitializeComponent();
        }
        // Se abre desde el alta de Stock con el elemento ya elegido.
        private readonly int idInventarioInicial;
        public frm12_Catalogo_1(int idInventario) : this()
        {
            idInventarioInicial = idInventario;
        }
        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();
        BLL.Stock gstock = new BLL.Stock();
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls02_Stock> listaStockDisponible;
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

        private void CargarCombo()
        {
            // Catálogo solo puede elegir elementos que ya tengan un registro de Stock.
            // Y que todavía no estén en el catálogo (un artículo por elemento).
            HashSet<int> enCatalogo = new HashSet<int>(gcatalogo.Listar2().Select(c => c.Idinventario));
            // Los bienes de uso no van al catálogo (ni, por lo tanto, a la lista de precios).
            foreach (BE.cls01_Inventario i in ginventario.ListarCatalogo())
                if (global::AluSoft.UI.BienDeUso.Es(i.Tipo)) enCatalogo.Add(i.Idinventario);
            listaStockDisponible = gstock.ListarCatalogo2()
                .Where(s => !enCatalogo.Contains(s.Idinventario) || s.Idinventario == idInventarioInicial)
                .ToList();
            foreach (BE.cls02_Stock elemento in listaStockDisponible)
                elemento.Combo = "Nº-" + elemento.Idinventario + "-" + elemento.Nombre + " - Stock: " + elemento.Cantidad_actual;
            cbxIdTipoDoc.DataSource = null;
            cbxIdTipoDoc.DisplayMember = "Combo";
            cbxIdTipoDoc.ValueMember = "IdInventario";
            cbxIdTipoDoc.DataSource = listaStockDisponible;
            cbxIdTipoDoc.SelectedIndex = -1;
            cbxIdTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            txbCantidad.ReadOnly = true;
        }

        private void cbxIdTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BE.cls02_Stock elemento = cbxIdTipoDoc.SelectedItem as BE.cls02_Stock;
            txbCantidad.Text = elemento == null ? string.Empty : elemento.Cantidad_actual.ToString();
            // Disponibilidad sugerida según el stock (se puede cambiar).
            if (elemento != null && (string.IsNullOrWhiteSpace(txbDisponibilidad.Text) || txbDisponibilidad.Text == "Disponible" || txbDisponibilidad.Text == "A pedido"))
                txbDisponibilidad.Text = elemento.Cantidad_actual > 0 ? "Disponible" : "A pedido";
        }
        #endregion

        private void frm12_Catalogo_1_Load(object sender, EventArgs e)
        {
            inventario = new BE.cls01_Inventario();
            catalogo = new BE.cls12_Catalogo();
            dataGridView1.DataSource = gcatalogo.Listar2();
            CargarCombo();
            cbxIdTipoDoc.SelectedIndexChanged += cbxIdTipoDoc_SelectedIndexChanged;
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdTipoDoc, idInventarioInicial);
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                if (!ValidarCampos()) return;
                catalogo = new BE.cls12_Catalogo();
                catalogo.Idinventario = clsValidacionesPerdurables.SoloNumeros(cbxIdTipoDoc.SelectedValue.ToString(),"Id Inventario");
                catalogo.Idcatalogo = (gcatalogo.Max(catalogo) + 1);
                catalogo.Preciounitario = clsValidacionesPerdurables.SoloNumeros(txbPrecio.Text,"Precio unitario");
                catalogo.Disponibilidad = txbDisponibilidad.Text;
                catalogo.Cantidad = clsValidacionesPerdurables.SoloNumeros(txbCantidad.Text,"Cantidad");
                BE.cls12_Catalogo existente = gcatalogo.Listar2().FirstOrDefault(c => c.Idinventario == catalogo.Idinventario);
                if (existente != null)
                {
                    MessageBox.Show("Este elemento ya está en el catálogo (N° " + existente.Idcatalogo + "). Modificalo desde la gestión de catálogo.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                fa = gcatalogo.Agregar(catalogo);
                if (fa != 0)
                {
                    MessageBox.Show("Elemento agregado al catálogo con el N° " + catalogo.Idcatalogo + ".", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(13, 1);
                    if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés crearlo en la lista de precios?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm13_ListaPrecios_1(catalogo.Idcatalogo));
                        return;
                    }
                    LimpiarControles(this);
                    dataGridView1.DataSource = gcatalogo.Listar2();
                    CargarCombo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = gcatalogo.Listar2();
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdTipoDoc, "IdInventario");
                CargarBitacora(13,5);
        
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
