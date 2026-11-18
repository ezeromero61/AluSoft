using BE;
using BLL;
using ClosedXML.Excel;
using System;
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
    public partial class frm01_Inventario_2 : Form
    {
        public frm01_Inventario_2()
        {
            InitializeComponent();
        }
        BE.cls01_Inventario inv;
        BLL.Inventario ginv = new BLL.Inventario();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();

        #region Auxiliares
        private List<BE.cls01_Inventario> listaPersonasOriginal;
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
            listaPersonasOriginal = ginv.ListarCatalogo2();
            cbxIdInventario.DataSource = listaPersonasOriginal;
            cbxIdInventario.DisplayMember = "Combo";
            cbxIdInventario.ValueMember = "IdInventario";
            cbxIdInventario.SelectedIndex = -1;
            cbxIdInventario.DropDownStyle = ComboBoxStyle.DropDown;
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

        private void frm01_Inventario_2_Load(object sender, EventArgs e)
        {
            inv = new BE.cls12_Catalogo();
            CargarCombo();
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

        private void af_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdInventario.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdInventario.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdInventario.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                #region 07_Asistencias_Alumnos
                ginv.Consultar(inv, val);
                txbNombre.Text = inv.Nombre;
                txbDescripcion.Text = inv.Descripcion;
                txbTipo.Text = inv.Tipo;
                chkBienUso.Checked = global::AluSoft.UI.BienDeUso.Es(inv.Tipo);
                txbAlto.Text = Convert.ToString(inv.Alto);
                txbLargo.Text = Convert.ToString(inv.Largo);
                txtAncho.Text = Convert.ToString(inv.Ancho);
                txbMaterial.Text = inv.Material;
                txbColor.Text = inv.Color;
                #endregion
                dataGridView1.DataSource = ginv.Consultar(inv, val);
                CargarBitacora(2,4);
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Ocurrió un error: " + ex.Message,"AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }        
        }

        private void af_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }

        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxIdInventario.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    cbxIdInventario.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdInventario.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show( "El elemento seleccionado no es válido.","AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                #region Eliminar
                DialogResult resultado = MessageBox.Show("¿Seguro que querés eliminar el registro seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    // Se borra el registro ELEGIDO en el combo (antes se borraba el último buscado).
                    int idBorrar = global::AluSoft.UI.Borrado.IdElegido(cbxIdInventario, "un elemento de inventario");
                    if (idBorrar <= 0) return;
                    if (!global::AluSoft.UI.Borrado.SePuede("Inventario", idBorrar, "el elemento de inventario")) return;
                    inv = new BE.cls01_Inventario();
                    inv.Idinventario = idBorrar;
                    if (!global::AluSoft.UI.Borrado.Informar(ginv.Eliminar(inv), "el elemento de inventario")) return;
                    LimpiarControles(this);
                    CargarBitacora(2,3);
                    CargarCombo();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Ocurrió un error: " + ex.Message, "AluSoft", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
           
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdInventario);
                if (val != 0)
                {
                    dataGridView1.DataSource = ginv.Consultar(inv,val);
                }
                else
                {
                    dataGridView1.DataSource = ginv.ListarCatalogo();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdInventario);
                CargarBitacora(2,5);
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;
                if (cbxIdInventario.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento de la lista.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbxIdInventario.Focus();
                    return;
                }
                int val;
                if (!int.TryParse(cbxIdInventario.SelectedValue.ToString(), out val))
                {
                    MessageBox.Show("El elemento seleccionado no es válido.", "AluSoft",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (val <= 0)
                {
                    MessageBox.Show("No existe registro para esa elemento.");
                    return;
                }
                int fa = 0;
                inv = new BE.cls01_Inventario();
                inv.Idinventario = int.Parse(cbxIdInventario.SelectedValue.ToString());
                inv.Nombre = txbNombre.Text;
                inv.Descripcion = (txbDescripcion.Text);
                inv.Tipo = (txbTipo.Text);
                // Solo se puede pasar a bien de uso un elemento que todavía no tiene stock creado.
                if (global::AluSoft.UI.BienDeUso.Es(inv.Tipo) && new BLL.Stock().ListarCatalogo2().Any(s => s.Idinventario == inv.Idinventario))
                {
                    MessageBox.Show("No se puede marcar como bien de uso: el elemento ya tiene stock creado (está en el circuito de stock).", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                inv.Alto = clsValidacionesPerdurables.SoloNumeros((txbAlto.Text),"Alto");
                inv.Largo = clsValidacionesPerdurables.SoloNumeros((txbLargo.Text),"Largo");
                inv.Ancho = clsValidacionesPerdurables.SoloNumeros((txtAncho.Text),"Ancho");
                inv.Material = txbMaterial.Text;
                inv.Color = (txbColor.Text);
                fa = ginv.Editar(inv);
                if (fa != 0)
                {
                    MessageBox.Show("Se editó " + fa + " filas.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles(this);
                    CargarBitacora(2,2);
                    CargarCombo();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message,"AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxIdInventario_TextUpdate(object sender, EventArgs e)
        {
            if (filtrandoCombo)
                return;

            try
            {
                filtrandoCombo = true;

                string texto = cbxIdInventario.Text;

                List<BE.cls01_Inventario> filtrados;

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
                cbxIdInventario.DataSource = null;
                cbxIdInventario.DataSource = filtrados;

                cbxIdInventario.DisplayMember = "Combo";
                cbxIdInventario.ValueMember = "IdInventario";

                cbxIdInventario.Text = texto;
                cbxIdInventario.SelectionStart = texto.Length;
                cbxIdInventario.SelectionLength = 0;

                cbxIdInventario.DroppedDown = true;
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
                guardar.Title = "Exportar Inventario a Excel";
                guardar.FileName = "AluSoft_Inventario_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Inventario");

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
#endregion