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
    public partial class frm18_PresupuestoProveedor_1 : Form
    {
        public frm18_PresupuestoProveedor_1()
        {
            InitializeComponent();
        }
        BE.cls04_Proveedor proveedor;
        BLL.Proveedor gproveedor = new BLL.Proveedor();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        BE.cls18_PresupuestoProveedor presu;
        BLL.PresupuestoProveedor gpresu = new BLL.PresupuestoProveedor();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void alum_nombre_Click(object sender, EventArgs e)
        {

        }

        private void frm18_PresupuestoProveedor_1_Load(object sender, EventArgs e)
        {
            #region Proveedor
            proveedor = new BE.cls04_Proveedor();
            cbxIdProveedor.DataSource = gproveedor.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdProveedor.DisplayMember = "NombreEmpresa";
            cbxIdProveedor.ValueMember = "IdProveedor";
            cbxIdProveedor.Text = null;
            #endregion
            #region Stock
            stock = new BE.cls02_Stock();
            comboBox2.DataSource = gstock.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdStock";
            comboBox2.Text = null;
            #endregion
        }

        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            presu = new BE.cls18_PresupuestoProveedor();
            presu.Idpresupuestoproveedor = (gpresu.Max(presu) + 1);
            presu.Idproveedor = Convert.ToInt32(cbxIdProveedor.SelectedValue);
            presu.Idstock = Convert.ToInt32(comboBox2.SelectedValue);
            presu.Fechapresupuesto = DateTime.Parse(dateTimePicker1.Text);
            presu.Fechavalidez = DateTime.Parse(dateTimePicker2.Text);
            presu.Idlogin = (1);
            presu.Subtotal = int.Parse(txbGenero.Text);
            presu.Iva = int.Parse(textBox1.Text);
            presu.Total = int.Parse(textBox2.Text);
            fa = gpresu.Agregar(presu);

            if (fa != 0)
            {
                MessageBox.Show("Se agregaron " + fa + " filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 19;
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
