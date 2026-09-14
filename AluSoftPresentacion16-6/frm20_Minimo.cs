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

namespace AluSoftPresentacion16_6
{
    public partial class frm20_Minimo : Form
    {
        public frm20_Minimo()
        {
            InitializeComponent();
        }
        BE.cls20_Minimo minimo;
        BLL.Minimo gminimo = new BLL.Minimo();
        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
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

        private void frm20_Minimo_Load(object sender, EventArgs e)
        {
            inventario = new BE.cls01_Inventario();
            stock = new BE.cls02_Stock();
            minimo = new BE.cls20_Minimo();
            cbxIdStock.DataSource = gminimo.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");   
            cbxIdStock.DisplayMember = "Nombre";       // Lo que ve el usuario
            cbxIdStock.ValueMember = "IdStock";
            cbxIdStock.Text = null;
        }
    }
}
