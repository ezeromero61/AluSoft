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
    public partial class Menu_Supervisor : Form
    {
        private readonly ToolStrip barraSupervisor = new ToolStrip();
        private readonly Panel panelContenidoSupervisor = new Panel();

        public Menu_Supervisor()
        {
            InitializeComponent();
            ConfigurarInterfaz();
            ConfigurarMenus();
        }

        private void ConfigurarInterfaz()
        {
            SuspendLayout();
            try
            {
                Text = "AluSoft - Supervisor";
                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Maximized;

                barraSupervisor.Name = "barraSupervisor";
                barraSupervisor.Dock = DockStyle.Top;
                barraSupervisor.GripStyle = ToolStripGripStyle.Hidden;
                barraSupervisor.BackColor = SystemColors.Control;

                panelContenidoSupervisor.Name = "panelContenidoSupervisor";
                panelContenidoSupervisor.Dock = DockStyle.Fill;

                Controls.Add(panelContenidoSupervisor);
                Controls.Add(barraSupervisor);
            }
            finally
            {
                ResumeLayout(true);
            }
        }

        private void ConfigurarMenus()
        {
            ToolStripSplitButton stock = CrearGrupo("Stock");
            ToolStripMenuItem altasStock = CrearSubmenu(stock, "Formularios de alta");
            ToolStripMenuItem gestionStock = CrearSubmenu(stock, "Formularios de gestión");

            AgregarOpcion(altasStock, "Stock", () => new frm02_Stock_1());
            AgregarOpcion(gestionStock, "Stock", () => new frm02_Stock_2());

            ToolStripSplitButton produccion = CrearGrupo("Producción");
            ToolStripMenuItem altasProduccion = CrearSubmenu(produccion, "Formularios de alta");
            ToolStripMenuItem gestionProduccion = CrearSubmenu(produccion, "Formularios de gestión");

            AgregarOpcion(altasProduccion, "Orden de producción", () => new frm14_OrdenProduccion_1());
            AgregarOpcion(altasProduccion, "Estado", () => new frm15_Estado_1());
            AgregarOpcion(gestionProduccion, "Orden de producción", () => new frm14_OrdenProduccion_2());
            AgregarOpcion(gestionProduccion, "Estado", () => new frm15_Estado_2());

            ToolStripSplitButton reaprovisionamiento = CrearGrupo("Reaprovisionamiento");
            ToolStripMenuItem altasProveedores = CrearSubmenu(reaprovisionamiento, "Formularios de alta");
            ToolStripMenuItem gestionProveedores = CrearSubmenu(reaprovisionamiento, "Formularios de gestión");

            AgregarOpcion(altasProveedores, "Proveedores", () => new frm04_Proveedor_1());
            AgregarOpcion(gestionProveedores, "Proveedores", () => new frm04_Proveedor_2());

            ToolStripSplitButton seguridad = CrearGrupo("Seguridad");
            ToolStripMenuItem opcionesSeguridad = CrearSubmenu(seguridad, "Cuenta");
            AgregarOpcion(opcionesSeguridad, "Cambiar contraseña", () => new Cambiar_Contraseña());

        }

        private ToolStripSplitButton CrearGrupo(string texto)
        {
            ToolStripSplitButton grupo = new ToolStripSplitButton(texto);
            grupo.DisplayStyle = ToolStripItemDisplayStyle.Text;
            grupo.ButtonClick += (sender, e) => grupo.ShowDropDown();
            barraSupervisor.Items.Add(grupo);
            return grupo;
        }

        private ToolStripMenuItem CrearSubmenu(ToolStripSplitButton grupo, string texto)
        {
            ToolStripMenuItem submenu = new ToolStripMenuItem(texto);
            grupo.DropDownItems.Add(submenu);
            return submenu;
        }

        private void AgregarOpcion(ToolStripMenuItem submenu, string texto,
                                  Func<Form> crearFormulario)
        {
            ToolStripMenuItem opcion = new ToolStripMenuItem(texto);
            opcion.Click += (sender, e) => AbrirFormularioEnPanel(crearFormulario());
            submenu.DropDownItems.Add(opcion);
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            panelContenidoSupervisor.SuspendLayout();
            try
            {
                LimpiarPanel();
                global::AluSoft.UI.AjusteFormularios.PrepararParaPanel(formulario);
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;

                panelContenidoSupervisor.Controls.Add(formulario);
                panelContenidoSupervisor.Tag = formulario;
                formulario.Show();
            }
            finally
            {
                panelContenidoSupervisor.ResumeLayout(true);
            }
        }

        private void LimpiarPanel()
        {
            panelContenidoSupervisor.Tag = null;
            while (panelContenidoSupervisor.Controls.Count > 0)
            {
                Control control = panelContenidoSupervisor.Controls[0];
                panelContenidoSupervisor.Controls.Remove(control);
                control.Dispose();
            }
        }

        private void Menu_Supervisor_Load(object sender, EventArgs e)
        {

        }
    }
}
