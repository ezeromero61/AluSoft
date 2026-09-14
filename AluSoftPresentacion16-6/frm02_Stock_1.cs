using BLL;
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
        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void frm02_Stock_1_Load(object sender, EventArgs e)
        {
            inventario = new BE.cls01_Inventario();
            stock = new BE.cls02_Stock();

            cbxIdTipoDoc.DataSource = ginventario.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");   

            cbxIdTipoDoc.DisplayMember = "Nombre";       // Lo que ve el usuario
            cbxIdTipoDoc.ValueMember = "IdInventario";

            //cbxIdTipoDoc.ValueMember = "Nombre";
            cbxIdTipoDoc.Text = null;
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            stock = new BE.cls02_Stock();
            stock.Idinventario=Convert.ToInt32(cbxIdTipoDoc.SelectedValue);
            stock.Idstock = (gstock.Max(stock) + 1);
            stock.Cantidad_actual = int.Parse(txbCantActual.Text);
            stock.Cantidad_minima = int.Parse(txbCantMin.Text);
            stock.Cantidad_maxima = int.Parse(txbCantMax.Text);
            fa = gstock.Agregar(stock);

            if (fa != 0)
            {
                MessageBox.Show("Se agregaron "+fa+" filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 3;
                bitacora.idaccion = 1;
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

        private void cbxIdTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdTipoDoc.SelectedIndex;
            
            // Verifica si se ha seleccionado un elemento válido
            if (selectedIndex >= 0)
            {
                //int id = Convert.ToInt32(cbxIdTipoDoc.SelectedValue);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ginventario.ListarCatalogo();
            }           
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
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
        }
    }
}
