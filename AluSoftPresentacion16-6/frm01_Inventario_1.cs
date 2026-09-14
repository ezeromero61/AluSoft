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
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            inv = new BE.cls01_Inventario();
            inv.Idinventario = (ginv.Max(inv)+1);
            inv.Nombre = txbNombre.Text;
            inv.Descripcion = (txbDescripcion.Text);
            inv.Tipo = (txbTipo.Text);
            inv.Alto = int.Parse(txbAlto.Text);
            inv.Largo = int.Parse(txbLargo.Text);
            inv.Ancho = int.Parse(txtAncho.Text);
            inv.Material = txtMaterial.Text;
            inv.Color = (txtColor.Text);
            fa = ginv.Agregar(inv);

            if (fa != 0)
            {
                MessageBox.Show("Se agrego");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 2;
                bitacora.idaccion = 1;
                bitacora.fecha = (DateTime.Now);
                bitacora.hora = Convert.ToDateTime(DateTime.Now.TimeOfDay);
                fa = gbitacora.Agregar(bitacora);
                #endregion
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void frm01_Inventario_1_Load(object sender, EventArgs e)
        {

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
