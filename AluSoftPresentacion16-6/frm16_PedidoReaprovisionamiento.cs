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
    public partial class frm16_PedidoReaprovisionamiento : Form
    {
        public frm16_PedidoReaprovisionamiento()
        {
            InitializeComponent();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls04_Proveedor proveedor;
        BLL.Proveedor gproveedor = new BLL.Proveedor();
        BE.cls16_PedidoReaprovisionamiento pedido;
        BLL.PedidoReaprovisionamiento gpedido = new BLL.PedidoReaprovisionamiento();
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            pedido = new BE.cls16_PedidoReaprovisionamiento();
            pedido.Idpedidoreaprovisionamiento = (gpedido.Max(pedido) + 1);
            pedido.Idproveedor = int.Parse(cbxIdProveedor.ValueMember);
            pedido.Fechapedido = DateTime.Parse(dateTimePicker1.Text);
            pedido.Fechaentregaestimada = DateTime.Parse(dateTimePicker2.Text);
            pedido.Fechaentregareal = DateTime.Parse(dateTimePicker3.Text);
            pedido.Estado = txbEstado.Text;
            pedido.Prioridad = (txbPrioridad.Text);
            pedido.Observaciones = (txbObservaciones.Text);
            pedido.Idlogin = clsPerdurables.Id_Login;
            pedido.DigitoVerificador = 1;
            fa = gpedido.Agregar(pedido);

            if (fa != 0)
            {
                MessageBox.Show("Se agregaron " + fa + " filas.");
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
            //#region Bitacora 
            //bitacora = new BE.cls35_Bitacora();
            //bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
            //bitacora.idlogin = clsPerdurables.Id_Login;
            //bitacora.idtabla = 17;
            //bitacora.idaccion = 1;
            //bitacora.fecha = (DateTime.Now);
            //bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
            //fa = gbitacora.Agregar(bitacora);
            //#endregion
        }

        private void frm16_PedidoReaprovisionamiento_Load(object sender, EventArgs e)
        {
            proveedor = new BE.cls04_Proveedor();
            cbxIdProveedor.DataSource = gproveedor.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");   
            cbxIdProveedor.DisplayMember = "NombreEmpresa";       // Lo que ve el usuario
            cbxIdProveedor.ValueMember = "IdProveedor";
            cbxIdProveedor.Text = null;
        }
    }
}
