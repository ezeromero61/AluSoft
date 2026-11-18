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

namespace AluSoft
{
    public partial class frm13_ListaPrecios_1 : Form
    {
        public frm13_ListaPrecios_1()
        {
            InitializeComponent();
        }
        // Se abre desde el alta de Catálogo con el artículo ya elegido.
        private readonly int idCatalogoInicial;
        public frm13_ListaPrecios_1(int idCatalogo) : this()
        {
            idCatalogoInicial = idCatalogo;
        }
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls13_ListaPrecios lista;
        BLL.ListaPrecios glista = new BLL.ListaPrecios();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls12_Catalogo> listaCatalogo;
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
        private void CargarComboo()
        {
            #region Cliente
            // La lista de precios se relaciona con los artículos del Catálogo,
            // no con registros históricos de esta misma lista.
            listaCatalogo = gcatalogo.Listar2();
            foreach (BE.cls12_Catalogo elemento in listaCatalogo)
                elemento.Combo = "Nº" + elemento.Idcatalogo + "-" + elemento.Nombre;
            cbxIdTipoDoc.DataSource = null;
            cbxIdTipoDoc.DisplayMember = "Combo";
            cbxIdTipoDoc.ValueMember = "IdCatalogo";
            cbxIdTipoDoc.DataSource = listaCatalogo;
            cbxIdTipoDoc.SelectedIndex = -1;
            cbxIdTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion
        }
        private void cbxIdTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BE.cls12_Catalogo elemento = cbxIdTipoDoc.SelectedItem as BE.cls12_Catalogo;
            txbPrecio.Text = elemento == null ? string.Empty : elemento.Preciounitario.ToString();
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
        private void frm13_ListaPrecios_1_Load(object sender, EventArgs e)
        {
            CargarComboo();
            cbxIdTipoDoc.SelectedIndexChanged += cbxIdTipoDoc_SelectedIndexChanged;
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdTipoDoc, idCatalogoInicial);
            CargarBitacora(14,7);
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                if (!ValidarCampos()) return;
                lista = new BE.cls13_ListaPrecios();
                lista.Idcatalogo = clsValidacionesPerdurables.SoloNumeros(cbxIdTipoDoc.SelectedValue.ToString(),"Id Catalogo");
                lista.Idlista = (glista.Max(lista) + 1);
                lista.Fecha = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker1.Text),"Fecha");
                lista.Precio = clsValidacionesPerdurables.SoloNumeros(txbPrecio.Text,"Precio");
                fa = glista.Agregar(lista);
                if (fa != 0)
                {
                    // Último paso del circuito: con precio vigente, el producto ya aparece para presupuestar.
                    MessageBox.Show("Precio guardado en la lista de precios (N° " + lista.Idlista + ").\n\nEl producto ya se puede usar en los presupuestos de clientes.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(14, 1);
                    LimpiarControles(this);
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
                dataGridView1.DataSource = glista.ListarCatalogo2();
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdTipoDoc, "IdCatalogo");
                CargarBitacora(14,5);
        
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
