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
    public partial class frm19_Maximo_2 : Form
    {
        public frm19_Maximo_2()
        {
            InitializeComponent();
        }
        BE.cls19_Maximo max;
        BLL.Maximo gmax = new BLL.Maximo();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();
        private void af_tabla_Click(object sender, EventArgs e)
        {

        }

        private void af_buscar_Click(object sender, EventArgs e)
        {

        }

        private void af_modificar_Click(object sender, EventArgs e)
        {

        }

        private void af_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este elemento?. Are you sure you want to delete this item?. Êtes-vous sûr de vouloir supprimer cet élément ?", "Confirmar eliminación. Confirm delete. Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Comprobar el resultado del cuadro de mensaje
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Se han eliminado " + gmax.Eliminar(max) + " filas");
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

        private void af_limpiar_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frm19_Maximo_2_Load(object sender, EventArgs e)
        {
            //max = new BE.cls19_Maximo();
            //#region Presupuesto cliente
            //cbxIdMax.DataSource = gmax.ListarCatalogo2();
            //cbxIdMax.DisplayMember = "Combo";
            //cbxIdPedicbxIdMaxdoReaprovionamiento.ValueMember = "IdPedidoReaprovisionamiento";
            //cbxIdPedidcbxIdMaxoReaprovionamiento.Text = null;
            //#endregion
        }
    }
}
