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
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls13_ListaPrecios lista;
        BLL.ListaPrecios glista = new BLL.ListaPrecios();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void frm13_ListaPrecios_1_Load(object sender, EventArgs e)
        {
            lista = new BE.cls13_ListaPrecios();
            catalogo = new BE.cls12_Catalogo();
            cbxIdTipoDoc.DataSource = glista.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");   
            cbxIdTipoDoc.DisplayMember = "Nombre";       // Lo que ve el usuario
            cbxIdTipoDoc.ValueMember = "IdLista";
            //cbxIdTipoDoc.ValueMember = "Nombre";
            cbxIdTipoDoc.Text = null;
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            lista = new BE.cls13_ListaPrecios();
            lista.Idcatalogo = Convert.ToInt32(cbxIdTipoDoc.SelectedValue);
            lista.Idlista = (glista.Max(lista) + 1);
            lista.Fecha = DateTime.Parse(dateTimePicker1.Text);
            lista.Precio = int.Parse(txbPrecio.Text);
            fa = glista.Agregar(lista);

            if (fa != 0)
            {
                MessageBox.Show("Se agregaron " + fa + " filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 14;
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
