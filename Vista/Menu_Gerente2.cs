using AluSoft;
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
    public partial class Menu_Gerente2 : Form
    {
        public Menu_Gerente2()
        {
            InitializeComponent();
            global::AluSoft.UI.TemaMenus.Aplicar(this, toolStrip1, panel1, "Gerente");
            AgregarMenuPersonas();
            AgregarMenuCambioContraseña();
        }

        private void AgregarMenuPersonas()
        {
            ToolStripDropDownButton personas = new ToolStripDropDownButton("Personas");
            ToolStripMenuItem altaPersona = new ToolStripMenuItem("Crear persona");
            altaPersona.Click += (sender, e) => AbrirFormularioEnPanel(new frm00_Persona(false));
            personas.DropDownItems.Add(altaPersona);
            toolStrip1.Items.Add(personas);
        }

        private void AgregarMenuCambioContraseña()
        {
            ToolStripDropDownButton seguridad = new ToolStripDropDownButton("Seguridad");
            ToolStripMenuItem cambiar = new ToolStripMenuItem("Cambiar contraseña");
            cambiar.Click += (sender, e) => AbrirFormularioEnPanel(new Cambiar_Contraseña());
            seguridad.DropDownItems.Add(cambiar);
            toolStrip1.Items.Add(seguridad);
        }
        #region Formulario
        public void LimpiarPanel()
        {
            if (panel1.Controls.Count > 0)
            {
                foreach (Control control in panel1.Controls)
                {
                    control.Dispose();
                }
                panel1.Controls.Clear();
            }
        }
        public void AbrirFormularioEnPanel(Form formulario)
        {
            panel1.Controls.Clear();

            global::AluSoft.UI.AjusteFormularios.PrepararParaPanel(formulario);
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            formulario.FormBorderStyle = FormBorderStyle.None;

            panel1.Controls.Add(formulario);
            panel1.Tag = formulario;
            formulario.Show();
        }
        #endregion
        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm13_ListaPrecios_1());
        }

        private void catálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm12_Catalogo_1());
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm03_Cliente_2());
        }

        private void presupuestoDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm07_PresupuestoCliente_2());
        }

        private void pedidoDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm08_PedidoCliente_2());
        }

        private void facturaDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm09_Factura_2());
        }

        private void listaDePreciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm13_ListaPrecios_2());
        }

        private void catálogoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm12_Catalogo_2());
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm01_Inventario_1());
        }

        private void máximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm19_Maximo());
        }

        private void mínimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm20_Minimo());
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm02_Stock_2());
        }

        private void inventarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm01_Inventario_2());
        }

        private void máximoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm19_Maximo_2());
        }

        private void mínimoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm20_Minimo_2());
        }

        private void ordenDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm14_OrdenProduccion_2());
        }

        private void estadoDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm15_Estado_2());
        }

        private void producciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm21_Produccion_2());
        }

        private void pedidoDeReaprovisionamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm16_PedidoReaprovisionamiento_2());
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm04_Proveedor_2());
        }

        private void remitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm23_Remito_2());
        }

        private void presupuestoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm18_PresupuestoProveedor_2());
        }

        private void cobroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm10_Cobro_2());
        }

        private void pagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm24_Pagos_2());
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm11_Ventas_2());
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm17_Compras_2());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarPanel();
        }

        private void menu_alum_volver_Click(object sender, EventArgs e)
        {
            Form1 Prueba2_Alumnoss = new Form1();
            this.Hide();
            Prueba2_Alumnoss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usted está en la pantalla del gerente, estará dedicada a gestionar la parte comercial, el stock, la producción, reportes y el reaprovisionamiento. " +
            "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }
    }
}
