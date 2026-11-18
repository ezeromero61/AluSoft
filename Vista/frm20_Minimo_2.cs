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

namespace AluSoftPresentacion16_6
{
    public partial class frm20_Minimo_2 : Form
    {
        public frm20_Minimo_2()
        {
            InitializeComponent();
        }
        BE.cls20_Minimo min;
        BLL.Minimo gmin = new BLL.Minimo();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();
        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdMin);
                if (val != 0)
                {
                    dataGridView1.DataSource = gmin.Consultar(min, val);
                }
                else
                {
                    dataGridView1.DataSource = gmin.ListarCatalogo2();
                }
        
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
                int val = int.Parse(cbxIdMin.SelectedValue.ToString());
                if (val == 0)
                {
                    MessageBox.Show("No existe registro para ese Alumno");
                }
                else
                {
                    #region 07_Asistencias_Alumnos
                    gmin.Consultar(min, val);
                    cbxIdstock.SelectedValue = min.Idstock;
                    dateTimePicker1.Text = Convert.ToString(min.Fecha);
                    txbCantidad.Text = Convert.ToString(min.Cantidad);
                    #endregion 
                    dataGridView1.DataSource = gmin.Consultar(min, val);
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            if (!global::AluSoft.UI.ValidacionCampos.Validar(this)) return;
            int fa = 0;
            if (cbxIdMin.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un elemento de la lista y presionar Buscar.", "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                min = new BE.cls20_Minimo();
                min.Idminimo = Convert.ToInt32(cbxIdMin.SelectedValue);
                min.Idstock = Convert.ToInt32(cbxIdstock.SelectedValue);
                min.Fecha = dateTimePicker1.Value;
                min.Cantidad = int.Parse(txbCantidad.Text);
                fa = gmin.Editar(min);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fa != 0)
            {
                MessageBox.Show("Se modificaron " + fa + " filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 21;
                bitacora.idaccion = 2;
                bitacora.fecha = (DateTime.Now);
                bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                fa = gbitacora.Agregar(bitacora);
                #endregion
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void af_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este elemento?. Are you sure you want to delete this item?. Êtes-vous sûr de vouloir supprimer cet élément ?", "Confirmar eliminación. Confirm delete. Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    min = new BE.cls20_Minimo();
                    min.Idminimo = Convert.ToInt32(cbxIdMin.SelectedValue);
                    MessageBox.Show("Se han eliminado " + gmin.Eliminar(min) + " filas");
                    cbxIdMin.DataSource = gmin.ListarCatalogo2();
                    foreach (Control controles in groupBox2.Controls)
                    {
                        if (controles is System.Windows.Forms.TextBox)
                        {
                            System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                            texbox.Text = string.Empty;
                        }
                        else if (controles is System.Windows.Forms.ComboBox)
                        {
                            System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                            cbx.Text = string.Empty;
                        }
                    }
                    foreach (Control controles in groupBox1.Controls)
                    {
                        if (controles is System.Windows.Forms.TextBox)
                        {
                            System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                            texbox.Text = string.Empty;
                        }
                        else if (controles is System.Windows.Forms.ComboBox)
                        {
                            System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                            cbx.Text = string.Empty;
                            cbx.SelectedValue = 0;
                        }
                    }
                    dataGridView1.DataSource = null;
                }
                else
                {
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void af_limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control controles in groupBox2.Controls)
                {
                    if (controles is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                        texbox.Text = string.Empty;
                    }
                    else if (controles is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                        cbx.Text = string.Empty;
                    }
                }
                foreach (Control controles in groupBox1.Controls)
                {
                    if (controles is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                        texbox.Text = string.Empty;
                    }
                    else if (controles is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                        cbx.Text = string.Empty;
                        cbx.SelectedValue = 0;
                    }
                }
                dataGridView1.DataSource = null;
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frm20_Minimo_2_Load(object sender, EventArgs e)
        {
            min = new BE.cls20_Minimo();
            #region Presupuesto cliente
            cbxIdMin.DataSource = gmin.ListarCatalogo2();
            cbxIdMin.DisplayMember = "Combo";
            cbxIdMin.ValueMember = "IdMinimo";
            cbxIdMin.Text = null;
            #endregion
            cbxIdstock.DataSource = gstock.ListarCatalogo2();
            cbxIdstock.DisplayMember = "Nombre";
            cbxIdstock.ValueMember = "IdStock";
            cbxIdstock.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxIdstock.SelectedIndex = -1;
        }
    }
}
