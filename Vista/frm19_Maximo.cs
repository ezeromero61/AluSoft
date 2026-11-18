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
    public partial class frm19_Maximo : Form
    {
        public frm19_Maximo()
        {
            InitializeComponent();
        }
        BE.cls01_Inventario inventario;
        BLL.Inventario ginventario = new BLL.Inventario();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        BE.cls19_Maximo maximo;
        BLL.Maximo gmaximo = new BLL.Maximo();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!global::AluSoft.UI.ValidacionCampos.Validar(this)) return;
                int fa = 0;
                maximo = new BE.cls19_Maximo();
                maximo.Idmaximo = Convert.ToInt32(cbxIdStock.SelectedValue);
                maximo.Idmaximo = (gmaximo.Max(maximo) + 1);
                maximo.Idstock = Convert.ToInt32(cbxIdStock.SelectedValue);
                maximo.Fecha = DateTime.Parse(dateTimePicker1.Text);
                maximo.Cantidad = int.Parse(txbCant.Text);
                maximo.DigitoVerificador = 1;
                fa = gmaximo.Agregar(maximo);

                if (fa != 0)
                {
                    MessageBox.Show("Se agregaron " + fa + " filas.");
                    #region Bitacora 
                    bitacora = new BE.cls35_Bitacora();
                    bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                    bitacora.idlogin = clsPerdurables.Id_Login;
                    bitacora.idtabla = 20;
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
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frm19_Maximo_Load(object sender, EventArgs e)
        {
            inventario = new BE.cls01_Inventario();
            stock = new BE.cls02_Stock();
            cbxIdStock.DataSource = gmaximo.ListarCatalogo();
            cbxIdStock.DisplayMember = "Nombre";
            cbxIdStock.ValueMember = "IdStock";
            cbxIdStock.Text = null;
        }
    }
}
