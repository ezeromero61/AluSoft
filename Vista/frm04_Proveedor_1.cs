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
    public partial class frm04_Proveedor_1 : Form
    {
        public frm04_Proveedor_1()
        {
            InitializeComponent();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls04_Proveedor prov;
        BLL.Proveedor gprov = new BLL.Proveedor();
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
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
        // Una persona solo puede ser un proveedor, y no puede haber dos empresas con el mismo nombre.
        internal static string ProveedorRepetido(int idPersona, string empresa, int idProveedorActual)
        {
            foreach (BE.cls04_Proveedor p in new BLL.Proveedor().ListarCatalogo())
            {
                if (p.Idproveedor == idProveedorActual) continue;
                if (p.Idpersona == idPersona)
                    return "Esa persona ya está cargada como proveedor (" + p.Nombre_empresa + ", N° " + p.Idproveedor + ").";
                if (string.Equals((p.Nombre_empresa ?? "").Trim(), empresa, StringComparison.OrdinalIgnoreCase))
                    return "Ya existe un proveedor con el nombre de empresa \"" + empresa + "\" (N° " + p.Idproveedor + ").";
            }
            return null;
        }
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                if (!ValidarCampos()) return;
                prov = new BE.cls04_Proveedor();
                prov.Idproveedor =(gprov.Max(prov) + 1);
                prov.Idpersona = int.Parse(cbxIdPersona.SelectedValue.ToString());
                prov.Nombre_empresa = txbNombreEmpresa.Text.Trim();
                prov.DigitoVerificador = 1;
                string repetido = ProveedorRepetido(prov.Idpersona, prov.Nombre_empresa, 0);
                if (repetido != null)
                {
                    MessageBox.Show(repetido, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                fa = gprov.Agregar(prov);
                if (fa != 0)
                {
                    MessageBox.Show("Proveedor agregado correctamente.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(5,1);
                    if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés pedirle un presupuesto a este proveedor?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new global::AluSoft.frm18_PresupuestoProveedor_1(prov.Idproveedor));
                        return;
                    }
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

        private void frm04_Proveedor_1_Load(object sender, EventArgs e)
        {
            #region Catalogo
            persona = new BE.cls00_Persona();
            cbxIdPersona.DataSource = gpersona.ListarCatalogo2();
            cbxIdPersona.DisplayMember = "Combo";
            cbxIdPersona.ValueMember = "IdPersona";
            cbxIdPersona.Text = null;
            cbxIdPersona.DropDownStyle = ComboBoxStyle.DropDown;
            cbxIdPersona.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxIdPersona.AutoCompleteSource = AutoCompleteSource.ListItems;
            #endregion
            CargarBitacora(5, 7);        
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = gprov.Listar2();
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPersona, "IdProveedor");
                CargarBitacora(5,5);
        
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
