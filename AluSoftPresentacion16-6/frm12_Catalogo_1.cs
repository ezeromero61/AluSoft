using BLL;
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
        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void frm12_Catalogo_1_Load(object sender, EventArgs e)
        {
            inventario = new BE.cls01_Inventario();
            catalogo = new BE.cls12_Catalogo();

            cbxIdTipoDoc.DataSource = ginventario.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");   

            cbxIdTipoDoc.DisplayMember = "Nombre";       // Lo que ve el usuario
            cbxIdTipoDoc.ValueMember = "IdInventario";

            //cbxIdTipoDoc.ValueMember = "Nombre";
            cbxIdTipoDoc.Text = null;
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            catalogo = new BE.cls12_Catalogo();
            catalogo.Idinventario = Convert.ToInt32(cbxIdTipoDoc.SelectedValue);
            catalogo.Idcatalogo = (gcatalogo.Max(catalogo) + 1);
            catalogo.Preciounitario = int.Parse(txbPrecio.Text);
            catalogo.Disponibilidad = txbDisponibilidad.Text;
            catalogo.Cantidad = int.Parse(txbCantidad.Text);
            fa = gcatalogo.Agregar(catalogo);

            if (fa != 0)
            {
                MessageBox.Show("Se agregaron " + fa + " filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 13;
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
