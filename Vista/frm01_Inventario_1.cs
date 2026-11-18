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

namespace AluSoft
{
    public partial class frm01_Inventario_1 : Form
    {
        public frm01_Inventario_1()
        {
            InitializeComponent();
        }
        BE.cls01_Inventario inv;
        BLL.Inventario ginv = new BLL.Inventario();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
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
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                int fa = 0;
                inv = new BE.cls01_Inventario();
                inv.Idinventario = (ginv.Max(inv) + 1);
                inv.Nombre = txbNombre.Text;
                inv.Descripcion = (txbDescripcion.Text);
                inv.Tipo = (txbTipo.Text);
                inv.Alto = clsValidacionesPerdurables.SoloNumeros((txbAlto.Text), "Alto");
                inv.Largo = clsValidacionesPerdurables.SoloNumeros((txbLargo.Text), "Largo");
                inv.Ancho = clsValidacionesPerdurables.SoloNumeros((txtAncho.Text), "Ancho");
                inv.Material = txtMaterial.Text;
                inv.Color = (txtColor.Text);
                // Aviso si ya hay un elemento con el mismo nombre (puede ser otra medida o color).
                string nombre = (inv.Nombre ?? "").Trim();
                BE.cls01_Inventario repetido = ginv.ListarCatalogo()
                    .FirstOrDefault(i => string.Equals((i.Nombre ?? "").Trim(), nombre, StringComparison.OrdinalIgnoreCase));
                if (repetido != null &&
                    !global::AluSoft.UI.Navegacion.Preguntar("Ya existe un elemento llamado \"" + nombre + "\" (N° " + repetido.Idinventario + "). ¿Querés agregarlo igual?"))
                    return;
                fa = ginv.Agregar(inv);
                if (fa != 0)
                {
                    MessageBox.Show("Elemento N° " + inv.Idinventario + " agregado al inventario.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(2, 1);
                    // Un bien de uso queda solo en inventario: no se ofrece el stock.
                    if (global::AluSoft.UI.BienDeUso.Es(inv.Tipo))
                    {
                        MessageBox.Show("Quedó registrado como bien de uso: no entra en stock, catálogo ni lista de precios.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarControles(this);
                        return;
                    }
                    // Siguiente paso del circuito: Inventario → Stock → Catálogo → Lista de precios.
                    if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés generar el stock de este elemento?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm02_Stock_1(inv.Idinventario));
                        return;
                    }
                    LimpiarControles(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm01_Inventario_1_Load(object sender, EventArgs e)
        {
            CargarBitacora(2,7);
        }

        // Check "Bien de uso": tildado completa el Tipo y lo bloquea; destildado devuelve lo que había.
        private string tipoAnterior = "";
        private void chkBienUso_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBienUso.Checked)
            {
                if (!global::AluSoft.UI.BienDeUso.Es(txbTipo.Text)) tipoAnterior = txbTipo.Text;
                txbTipo.Text = global::AluSoft.UI.BienDeUso.Tipo;
            }
            else if (global::AluSoft.UI.BienDeUso.Es(txbTipo.Text))
                txbTipo.Text = tipoAnterior;
            txbTipo.ReadOnly = chkBienUso.Checked;
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);

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
