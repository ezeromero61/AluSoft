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
            if (!global::AluSoft.UI.ValidacionCampos.Validar(this)) return;
            int fa = 0;
            if (cbxIdStock.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un producto de la lista.", "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int cantidad;
            if (!int.TryParse(txbCant.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número mayor a 0.", "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbCant.Focus();
                return;
            }
            try
            {
                minimo = new BE.cls20_Minimo();
                minimo.Idminimo = (gminimo.Max(minimo) + 1);
                minimo.Idstock = Convert.ToInt32(cbxIdStock.SelectedValue);
                minimo.Fecha = dateTimePicker1.Value.Date;
                minimo.Cantidad = cantidad;
                minimo.DigitoVerificador = 1;
                fa = gminimo.Agregar(minimo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fa != 0)
            {
                MessageBox.Show("Se agregaron " + fa + " filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 21;
                bitacora.idaccion = 1;
                bitacora.fecha = (DateTime.Now);
                bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                gbitacora.Agregar(bitacora);
                #endregion
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void frm20_Minimo_Load(object sender, EventArgs e)
        {
            inventario = new BE.cls01_Inventario();
            stock = new BE.cls02_Stock();
            minimo = new BE.cls20_Minimo();
            cbxIdStock.DataSource = gminimo.ListarCatalogo();
            cbxIdStock.DisplayMember = "Nombre";
            cbxIdStock.ValueMember = "IdStock";
            cbxIdStock.Text = null;
        }
    }
}
