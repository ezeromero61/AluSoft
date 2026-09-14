using AluSoftPresentacion16_6;
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
    public partial class Menu_Soporte : Form
    {
        public Menu_Soporte()
        {
            InitializeComponent();
        }
        private string rolUsuario;

        public Menu_Soporte(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
            ConfigurarMenuPorRol();
        }
        #region configurar menu
     
           private void ConfigurarMenuPorRol()
        {
            switch (rolUsuario)
            {
                case "Admin":
                    lblPerfil.Text = "Bienvenido Administratador";

                    inventarioToolStripMenuItem.Visible = false;
                    clienteToolStripMenuItem.Visible = false;
                    presupuestoProveedorToolStripMenuItem.Visible = false;
                    listaDePreciosToolStripMenuItem.Visible = false;
                    stockToolStripMenuItem.Visible = false;
                    reaprovisionamientoToolStripMenuItem.Visible = false;
                    presupuestoClienteToolStripMenuItem.Visible = false;
                    catalogoToolStripMenuItem.Visible = false;
                    máximoToolStripMenuItem.Visible = false;
                    mínimoStockToolStripMenuItem.Visible = false;
                    personaToolStripMenuItem.Visible = false;
                    cargarInventarioToolStripMenuItem.Visible = false;
                    cargarStockToolStripMenuItem.Visible = false;
                    cargarCatàlogoToolStripMenuItem.Visible = false;
                    cargarListaPreciosToolStripMenuItem.Visible = false;
                    cargarPresupuestoProveedorToolStripMenuItem.Visible = false;
                    cargarPresupuestoClienteToolStripMenuItem.Visible = false;
                    cargarReaprovisionamientoToolStripMenuItem.Visible = false;
                    cargarMàximoToolStripMenuItem.Visible = false;
                    cargarMìnimoToolStripMenuItem.Visible = false;
                    break;
                case "Gerente":
                    lblPerfil.Text = "Bienvenido Gerente";

                    inventarioToolStripMenuItem.Visible = false;
                    clienteToolStripMenuItem.Visible = false;
                    presupuestoProveedorToolStripMenuItem.Visible = false;
                    listaDePreciosToolStripMenuItem.Visible = false;
                    stockToolStripMenuItem.Visible = false;
                    reaprovisionamientoToolStripMenuItem.Visible = false;
                    presupuestoClienteToolStripMenuItem.Visible = false;
                    catalogoToolStripMenuItem.Visible = false;
                    máximoToolStripMenuItem.Visible = false;
                    mínimoStockToolStripMenuItem.Visible = false;
                    personaToolStripMenuItem.Visible = false;
                    cargarInventarioToolStripMenuItem.Visible = false;
                    cargarStockToolStripMenuItem.Visible = false;
                    cargarCatàlogoToolStripMenuItem.Visible = false;
                    cargarListaPreciosToolStripMenuItem.Visible = false;
                    cargarPresupuestoProveedorToolStripMenuItem.Visible = false;
                    cargarPresupuestoClienteToolStripMenuItem.Visible = false;
                    cargarReaprovisionamientoToolStripMenuItem.Visible = false;
                    cargarMàximoToolStripMenuItem.Visible = false;
                    cargarMìnimoToolStripMenuItem.Visible = false;
                    break;
                case "Soporte":
                    lblPerfil.Text = "Bienvenido Soporte";

                    inventarioToolStripMenuItem.Visible = false;
                    clienteToolStripMenuItem.Visible = false;
                    presupuestoProveedorToolStripMenuItem.Visible = false;
                    listaDePreciosToolStripMenuItem.Visible = false;
                    stockToolStripMenuItem.Visible = false;
                    reaprovisionamientoToolStripMenuItem.Visible = false;
                    presupuestoClienteToolStripMenuItem.Visible = false;
                    catalogoToolStripMenuItem.Visible = false;
                    máximoToolStripMenuItem.Visible = false;
                    mínimoStockToolStripMenuItem.Visible = false;
                    personaToolStripMenuItem.Visible = false;
                    cargarInventarioToolStripMenuItem.Visible = false;
                    cargarStockToolStripMenuItem.Visible = false;
                    cargarCatàlogoToolStripMenuItem.Visible = false;
                    cargarListaPreciosToolStripMenuItem.Visible = false;
                    cargarPresupuestoProveedorToolStripMenuItem.Visible = false;
                    cargarPresupuestoClienteToolStripMenuItem.Visible = false;
                    cargarReaprovisionamientoToolStripMenuItem.Visible = false;
                    cargarMàximoToolStripMenuItem.Visible = false;
                    cargarMìnimoToolStripMenuItem.Visible = false;
                    break;
                case "Administrativo":
                    lblPerfil.Text = "Bienvenido Administrativo";

                    inventarioToolStripMenuItem.Visible = false;
                    clienteToolStripMenuItem.Visible = false;
                    presupuestoProveedorToolStripMenuItem.Visible = false;
                    listaDePreciosToolStripMenuItem.Visible = false;
                    stockToolStripMenuItem.Visible = false;
                    reaprovisionamientoToolStripMenuItem.Visible = false;
                    presupuestoClienteToolStripMenuItem.Visible = false;
                    catalogoToolStripMenuItem.Visible = false;
                    máximoToolStripMenuItem.Visible = false;
                    mínimoStockToolStripMenuItem.Visible = false;
                    personaToolStripMenuItem.Visible = false;
                    cargarInventarioToolStripMenuItem.Visible = false;
                    cargarStockToolStripMenuItem.Visible = false;
                    cargarCatàlogoToolStripMenuItem.Visible = false;
                    cargarListaPreciosToolStripMenuItem.Visible = false;
                    cargarPresupuestoProveedorToolStripMenuItem.Visible = false;
                    cargarPresupuestoClienteToolStripMenuItem.Visible = false;
                    cargarReaprovisionamientoToolStripMenuItem.Visible = false;
                    cargarMàximoToolStripMenuItem.Visible = false;
                    cargarMìnimoToolStripMenuItem.Visible = false;

                    break;

                case "Supervisor":
                    lblPerfil.Text = "Bienvenido Supervisor";
                  
                    inventarioToolStripMenuItem.Visible = false;
                    clienteToolStripMenuItem.Visible = false;
                    presupuestoProveedorToolStripMenuItem.Visible = false;
                    listaDePreciosToolStripMenuItem.Visible = false;
                    stockToolStripMenuItem.Visible = false;
                    reaprovisionamientoToolStripMenuItem.Visible = false;
                    presupuestoClienteToolStripMenuItem.Visible = false;
                    catalogoToolStripMenuItem.Visible = false;
                    máximoToolStripMenuItem.Visible = false;
                    mínimoStockToolStripMenuItem.Visible = false;
                    personaToolStripMenuItem.Visible = false;
                    cargarInventarioToolStripMenuItem.Visible = false;
                    cargarStockToolStripMenuItem.Visible = false;
                    cargarCatàlogoToolStripMenuItem.Visible = false;
                    cargarListaPreciosToolStripMenuItem.Visible = false;
                    cargarPresupuestoProveedorToolStripMenuItem.Visible = false;
                    cargarPresupuestoClienteToolStripMenuItem.Visible = false;
                    cargarReaprovisionamientoToolStripMenuItem.Visible = false;
                    cargarMàximoToolStripMenuItem.Visible = false;
                    cargarMìnimoToolStripMenuItem.Visible = false;

                    // Dejamos visibles solo Estado y Orden de Producción
                  
                    break;
            }
        }
       
        #endregion

        #region Formulario
        public void LimpiarPanel()
        {
            // Verificar si el panel tiene controles y eliminarlos
            if (panel1.Controls.Count > 0)
            {
                foreach (Control control in panel1.Controls)
                {
                    control.Dispose();  // Liberar los recursos de cada control
                }
                panel1.Controls.Clear(); // Limpiar la colección de controles
            }
        }
       
        
        public void AbrirFormularioEnPanel(Form frm00_Persona_2)
        {
            // Limpiar el panel contenedor
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
                panel1.Controls.Clear();
            }
            // Configurar el formulario hijo
            frm00_Persona_2.TopLevel = false;
            frm00_Persona_2.Dock = DockStyle.Fill;
            frm00_Persona_2.FormBorderStyle = FormBorderStyle.None;
            // Agregar el formulario hijo al panel
            panel1.Controls.Add(frm00_Persona_2);
            panel1.Tag = frm00_Persona_2;
            // Mostrar el formulario hijo
            frm00_Persona_2.Show();
        }      
        
        #endregion


        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
       
        #region botones no se usan 
        private void tscbxInscripcionCarrera_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void menu_alum_volver_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
       
        }
        #endregion
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frm35_Bitacora asd = new frm35_Bitacora();
            AbrirFormularioEnPanel(asd);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
        
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
     
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
  
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
         
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm01_Inventario_2 asd = new frm01_Inventario_2();
            AbrirFormularioEnPanel(asd);
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm02_Stock_2 asd = new frm02_Stock_2();
            AbrirFormularioEnPanel(asd); 
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm03_Cliente_2 asd = new frm03_Cliente_2();
            AbrirFormularioEnPanel(asd);
        }

        private void presupuestoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm07_PresupuestoCliente_2 asd = new frm07_PresupuestoCliente_2();
            AbrirFormularioEnPanel(asd);
        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm12_Catalogo_2 asd = new frm12_Catalogo_2();
            AbrirFormularioEnPanel(asd);
        }

        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm13_ListaPrecios_2 asd = new frm13_ListaPrecios_2();
            AbrirFormularioEnPanel(asd);
        }

        private void reaprovisionamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm16_PedidoReaprovisionamiento_2 asd = new frm16_PedidoReaprovisionamiento_2();
            AbrirFormularioEnPanel(asd);
        }

        private void presupuestoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm18_PresupuestoProveedor_2 asd = new frm18_PresupuestoProveedor_2();
            AbrirFormularioEnPanel(asd);
        }

        private void máximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm19_Maximo_2 asd = new frm19_Maximo_2();
            AbrirFormularioEnPanel(asd);
        }

        private void mínimoStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm20_Minimo_2 asd = new frm20_Minimo_2();
            AbrirFormularioEnPanel(asd);
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm00_Persona_2 asd = new frm00_Persona_2();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm01_Inventario_1 asd = new frm01_Inventario_1();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm02_Stock_1 asd = new frm02_Stock_1();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarCatàlogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm12_Catalogo_1 asd = new frm12_Catalogo_1();
            AbrirFormularioEnPanel(asd);
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {

        }

        private void cargarListaPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm13_ListaPrecios_1 asd = new frm13_ListaPrecios_1();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarPresupuestoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm18_PresupuestoProveedor_1 asd = new frm18_PresupuestoProveedor_1();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarPresupuestoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm07_PresupuestoCliente asd = new frm07_PresupuestoCliente();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarReaprovisionamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm16_PedidoReaprovisionamiento asd = new frm16_PedidoReaprovisionamiento();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarMàximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm19_Maximo asd = new frm19_Maximo();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarMìnimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm20_Minimo asd = new frm20_Minimo();
            AbrirFormularioEnPanel(asd);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cargarPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm00_Persona asd = new frm00_Persona();
            AbrirFormularioEnPanel(asd);
        }

        private void cargarCienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm03_Cliente asd = new frm03_Cliente();
            AbrirFormularioEnPanel(asd);

        }
    }
}
