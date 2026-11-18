using BLL;
using ClosedXML.Excel;
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

namespace AluSoftPresentacion16_6
{
    public partial class frm21_Produccion_2 : Form
    {
        public frm21_Produccion_2()
        {
            InitializeComponent();
        }

        private BE.cls02_Stock stock = new BE.cls02_Stock();
        private BLL.Stock gstock = new BLL.Stock();

        private BE.cls14_OrdenProduccion orden = new BE.cls14_OrdenProduccion();
        private BLL.OrdenProduccion gorden = new BLL.OrdenProduccion();

        private BE.cls35_Bitacora bitacora;
        private BLL.Bitacora gbitacora = new BLL.Bitacora();

        private BE.cls21_Produccion prod = new BE.cls21_Produccion();
        private BLL.Produccion gprod = new BLL.Produccion();

        private List<BE.cls21_Produccion> listaProduccionesOriginal;
        private bool filtrandoCombo = false;
        private void ComboIndividual(int val)
        {
            dataGridView1.DataSource = gprod.ListarCatalogo2();
            global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdProduccion);
        }
        private void ComboCompleto()
        {
            dataGridView1.DataSource = gprod.ListarCatalogo2();
        }
        private void CargarBitacora(int tabla, int accion)
        {
            bitacora = new BE.cls35_Bitacora();
            bitacora.idbitacora = gbitacora.Max(bitacora) + 1;
            bitacora.idlogin = clsPerdurables.Id_Login;
            bitacora.idtabla = tabla;
            bitacora.idaccion = accion;
            bitacora.fecha = DateTime.Now;
            bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));

            gbitacora.Agregar(bitacora);
        }
        private void CargarComboProduccion()
        {
            listaProduccionesOriginal = gprod.ListarCatalogo2();

            cbxIdProduccion.DataSource = null;
            cbxIdProduccion.DisplayMember = "Combo";
            cbxIdProduccion.ValueMember = "IdProduccion";
            cbxIdProduccion.DataSource = listaProduccionesOriginal;
            cbxIdProduccion.SelectedIndex = -1;
            cbxIdProduccion.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private void CargarComboOrdenYStock()
        {
            cbxIdordeproduccion.DataSource = null;
            cbxIdordeproduccion.DisplayMember = "Combo";
            cbxIdordeproduccion.ValueMember = "IdOrdenProduccion";
            cbxIdordeproduccion.DataSource = gorden.ListarCatalogo2();
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

            global::AluSoft.UI.ValidacionCampos.ValidarTipos(
                this,
                errorProvider1,
                ref valido,
                ref primerControlInvalido);

            primerControlInvalido =
                global::AluSoft.UI.ValidacionCampos.PrimeroConError(this, errorProvider1)
                ?? primerControlInvalido;

            if (!valido && primerControlInvalido != null)
                primerControlInvalido.Focus();

            return valido;
        }
        private void ValidarControlesRecursivamente(Control contenedor,ref bool valido,ref Control primerControlInvalido)
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
                            errorProvider1.SetError(
                                textBox,
                                "Tenés que completar este campo.");

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
                            errorProvider1.SetError(
                                comboBox,
                                "Tenés que seleccionar una opción.");

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
                    ComboBox combo = (ComboBox)control;
                    combo.SelectedIndex = -1;
                    combo.Text = "";
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
                    LimpiarControles(control);
            }

            errorProvider1.Clear();
        }
        private void frm21_Produccion_2_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Produccion);
            try
            {
                CargarComboProduccion();
                CargarComboOrdenYStock();
                CargarBitacora(22, 7);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void af_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdProduccion.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Seleccioná una producción de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdProduccion.Focus();
                    return;
                }

                int idProduccion;
                if (!int.TryParse(
                        cbxIdProduccion.SelectedValue.ToString(),
                        out idProduccion) ||
                    idProduccion <= 0)
                {
                    MessageBox.Show(
                        "La producción seleccionada no es válida.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                prod = new BE.cls21_Produccion();

                DataTable datos = gprod.Consultar(prod, idProduccion);

                if (datos == null || datos.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos para esa producción.");
                    return;
                }

                // Estos combos ya están cargados con sus listas completas.
                cbxIdordeproduccion.SelectedValue = prod.Idordenproduccion;
                cbxidstock.SelectedValue = prod.Idstock;

                dateTimePicker3.Value = prod.Fecha;
                txbEstado.Text = prod.Estado;

                ComboIndividual(idProduccion);

                CargarBitacora(22, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdProduccion.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Seleccioná una producción de la lista.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cbxIdProduccion.Focus();
                    return;
                }

                int idProduccion;
                if (!int.TryParse(
                        cbxIdProduccion.SelectedValue.ToString(),
                        out idProduccion) ||
                    idProduccion <= 0)
                {
                    MessageBox.Show(
                        "La producción seleccionada no es válida.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                    return;

                if (cbxIdordeproduccion.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná un número de orden de producción.");
                    cbxIdordeproduccion.Focus();
                    return;
                }

                if (cbxidstock.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná un producto del stock.");
                    cbxidstock.Focus();
                    return;
                }

                prod = new BE.cls21_Produccion();
                prod.Idproduccion = idProduccion;

                // SelectedValue devuelve el ID seleccionado.
                // ValueMember solo contiene el nombre de la propiedad.
                prod.Idordenproduccion =
                    Convert.ToInt32(cbxIdordeproduccion.SelectedValue);

                prod.Idstock =
                    Convert.ToInt32(cbxidstock.SelectedValue);

                prod.Fecha = dateTimePicker3.Value;
                prod.Estado = txbEstado.Text;
                dataGridView1.DataSource = gprod.Consultar(new BE.cls21_Produccion(), idProduccion);
                int filasAfectadas = gprod.Editar(prod);

                if (filasAfectadas > 0)
                {
                    MessageBox.Show(
                        "La producción se modificó correctamente.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarBitacora(22, 2);
                    CargarComboProduccion();
                    LimpiarControles(this);
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo modificar la producción.",
                        "AluSoft",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdProduccion.SelectedValue == null)
                {
                    MessageBox.Show("Seleccioná una producción de la lista.");
                    cbxIdProduccion.Focus();
                    return;
                }

                int idProduccion;
                if (!int.TryParse(
                        cbxIdProduccion.SelectedValue.ToString(),
                        out idProduccion) ||
                    idProduccion <= 0)
                {
                    MessageBox.Show("La producción seleccionada no es válida.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar esta producción?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                prod = new BE.cls21_Produccion();
                prod.Idproduccion = idProduccion;

                int filasAfectadas = gprod.Eliminar(prod);

                MessageBox.Show("Se eliminaron " + filasAfectadas + " filas.");

                if (filasAfectadas > 0)
                {
                    LimpiarControles(this);
                    CargarComboProduccion();
                    CargarBitacora(22, 3);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int idProduccion;
                object valor = cbxIdProduccion.SelectedValue;

                if (valor != null &&int.TryParse(valor.ToString(), out idProduccion) &&idProduccion > 0)
                {
                    dataGridView1.DataSource = gprod.ListarCatalogo2();
                }
                else
                {
                    dataGridView1.DataSource = gprod.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdProduccion);

                if (global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdProduccion) != 0)
                    global::AluSoft.UI.FiltroReporte.OcultarTotales(dataGridView1);
                else
                    global::AluSoft.UI.FiltroReporte.Mostrar(dataGridView1, "producción", "Fecha",
                        "Producto=Nombre;Estado=Estado", "");

                CargarBitacora(22, 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo completar la operación: " + ex.Message,
                    "AluSoft",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void cbxIdProduccion_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo || listaProduccionesOriginal == null)
                return;

            try
            {
                filtrandoCombo = true;

                string texto = cbxIdProduccion.Text;

                List<BE.cls21_Produccion> filtrados;

                if (string.IsNullOrWhiteSpace(texto))
                {
                    filtrados = listaProduccionesOriginal;
                }
                else
                {
                    filtrados = listaProduccionesOriginal
                        .Where(x => x.Combo != null &&
                            x.Combo.IndexOf(
                                texto,
                                StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                }

                cbxIdProduccion.DataSource = null;
                cbxIdProduccion.DisplayMember = "Combo";
                cbxIdProduccion.ValueMember = "IdProduccion";
                cbxIdProduccion.DataSource = filtrados;

                cbxIdProduccion.Text = texto;
                cbxIdProduccion.SelectionStart = texto.Length;
                cbxIdProduccion.SelectionLength = 0;
                cbxIdProduccion.DroppedDown = true;
            }
            finally
            {
                filtrandoCombo = false;
            }
        }

        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Este formulario permite buscar, modificar y eliminar producciones. " +
                "Seleccioná la producción y completá los datos antes de modificarla.");
        }
    }
}
