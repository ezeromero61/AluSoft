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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AluSoftPresentacion16_6
{
    public partial class frm07_PresupuestoCliente : Form
    {
        public frm07_PresupuestoCliente()
        {
            InitializeComponent();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls07_PresupuestoCliente presupuesto;
        BLL.PresupuestroCliente gpresupuesto = new BLL.PresupuestroCliente();
        public int ObtenerId(string texto)
        {
            int inicio = texto.IndexOf("ID: ") + 4;
            int fin = texto.IndexOf(")", inicio);

            string id = texto.Substring(inicio, fin - inicio);

            return Convert.ToInt32(id);
        }
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            presupuesto = new BE.cls07_PresupuestoCliente();
            int fa = 0;
            presupuesto.Idpresupuesto = (gpresupuesto.Max(presupuesto) + 1);
            presupuesto.Idcliente = Convert.ToInt32(cbxIdCliente.SelectedValue);
            presupuesto.Idcatalogo = Convert.ToInt32(cbxIdCatalogo.SelectedValue);
            presupuesto.FechaCreacion = DateTime.Parse(dateTimePicker1.Text);
            presupuesto.FechaValidez = DateTime.Parse(dateTimePicker2.Text);
            presupuesto.Estado = (txbEstado.Text);
            presupuesto.Descripcion = (txbDescripcion.Text);
            presupuesto.Observaciones = txbObservaciones.Text;
            presupuesto.Subtotal = int.Parse(txbSubtotal.Text);
            presupuesto.Descuento = int.Parse(txbDescuento.Text);
            presupuesto.Impuestos = int.Parse(txbImpuestos.Text);
            presupuesto.Total = int.Parse(txbTotal.Text);
            presupuesto.FormaPago = (txbFormaPago.Text);
            presupuesto.PlazoEntregaDias = int.Parse(txbPlazoEntrega.Text);
            presupuesto.Idlogin = clsPerdurables.Id_Login;
            fa = gpresupuesto.Agregar(presupuesto);

            if (fa != 0)
            {
                MessageBox.Show("Se agrego");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 8;
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

        private void frm07_PresupuestoCliente_Load(object sender, EventArgs e)
        {
            #region Catalogo
            catalogo = new BE.cls12_Catalogo();
            cbxIdCatalogo.DataSource = gcatalogo.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdCatalogo.DisplayMember = "Combo";
            cbxIdCatalogo.ValueMember = "IdCatalogo";
            cbxIdCatalogo.Text = null;
            #endregion
            #region Cliente
            cliente = new BE.cls03_Cliente();
            cbxIdCliente.DataSource = gcliente.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdCliente.DisplayMember = "Combo";
            cbxIdCliente.ValueMember = "IdCliente";
            cbxIdCliente.Text = null;
            #endregion
        }
    }
}
