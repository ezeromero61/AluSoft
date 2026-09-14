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
    public partial class frm00_Persona_2 : Form
    {
        public frm00_Persona_2()
        {
            InitializeComponent();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();


        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls07_PresupuestoCliente presupuesto;
        BLL.PresupuestroCliente gpresupuesto = new BLL.PresupuestroCliente();
        private void frm00_Persona_2_Load(object sender, EventArgs e)
        {
            #region Catalogo
            catalogo = new BE.cls12_Catalogo();
            cbxIdPersona.DataSource = gpersona.ListarCatalogo2();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdPersona.DisplayMember = "Combo";
            cbxIdPersona.ValueMember = "DNI";
            cbxIdPersona.Text = null;
            #endregion
        }

        private void af_Titulo_Gestion_Click(object sender, EventArgs e)
        {

        }
    }
}
