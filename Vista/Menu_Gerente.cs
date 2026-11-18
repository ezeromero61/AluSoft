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
    public partial class Menu_Gerente : Form
    {
        private readonly ToolStrip barraGerente = new ToolStrip();
        private readonly Panel panelContenidoGerente = new Panel();

        public Menu_Gerente()
        {
            InitializeComponent();
            ConfigurarInterfaz();
            ConfigurarMenus();
        }

        private void Menu_Gerente_Load(object sender, EventArgs e)
        {
            // La interfaz y los menús se configuran en el constructor.
        }

        private void ConfigurarInterfaz()
        {
            SuspendLayout();
            try
            {
                Text = "AluSoft - Gerente";
                StartPosition = FormStartPosition.CenterScreen;
                WindowState = FormWindowState.Maximized;

                barraGerente.Name = "barraGerente";
                barraGerente.Dock = DockStyle.Top;
                barraGerente.GripStyle = ToolStripGripStyle.Hidden;
                barraGerente.BackColor = SystemColors.Control;

                panelContenidoGerente.Name = "panelContenidoGerente";
                panelContenidoGerente.Dock = DockStyle.Fill;

                Controls.Add(panelContenidoGerente);
                Controls.Add(barraGerente);
            }
            finally
            {
                ResumeLayout(true);
            }
        }

        private void ConfigurarMenus()
        {
            ToolStripSplitButton comercial = CrearGrupo("Comercial");
            ToolStripMenuItem consultasComercial = CrearSubmenu(comercial, "Consultas");
            AgregarConsulta(consultasComercial, "Clientes", () => new frm03_Cliente_2());
            AgregarConsulta(consultasComercial, "Presupuestos de clientes", () => new frm07_PresupuestoCliente_2());
            AgregarConsulta(consultasComercial, "Pedidos de clientes", () => new frm08_PedidoCliente_2());
            AgregarConsulta(consultasComercial, "Facturas", () => new frm09_Factura_2());
            AgregarConsulta(consultasComercial, "Cobros", () => new frm10_Cobro_2());
            AgregarConsulta(consultasComercial, "Ventas", () => new frm11_Ventas_2());

            ToolStripSplitButton personas = CrearGrupo("Personas");
            ToolStripMenuItem altasPersonas = CrearSubmenu(personas, "Formularios de alta");
            AgregarOpcion(altasPersonas, "Crear persona", () => new frm00_Persona(false));

            ToolStripSplitButton stock = CrearGrupo("Stock");
            ToolStripMenuItem altasStock = CrearSubmenu(stock, "Formularios de alta");
            ToolStripMenuItem gestionStock = CrearSubmenu(stock, "Formularios de gestión");
            ToolStripMenuItem consultasStock = CrearSubmenu(stock, "Consultas");
            AgregarOpcion(altasStock, "Inventario", () => new frm01_Inventario_1());
            AgregarOpcion(gestionStock, "Inventario", () => new frm01_Inventario_2());
            AgregarOpcion(altasStock, "Catálogo", () => new frm12_Catalogo_1());
            AgregarOpcion(gestionStock, "Catálogo", () => new frm12_Catalogo_2());
            AgregarOpcion(altasStock, "Lista de precios", () => new frm13_ListaPrecios_1());
            AgregarOpcion(gestionStock, "Lista de precios", () => new frm13_ListaPrecios_2());
            AgregarConsulta(consultasStock, "Stock", () => new frm02_Stock_2());

            ToolStripSplitButton produccion = CrearGrupo("Producción");
            ToolStripMenuItem consultasproduccion = CrearSubmenu(produccion, "Consultas");
            AgregarConsulta(consultasproduccion, "Órdenes de producción", () => new frm14_OrdenProduccion_2());
            AgregarConsulta(consultasproduccion, "Estado", () => new frm15_Estado_2());
            AgregarConsulta(consultasproduccion, "Producción", () => new frm21_Produccion_2());

            ToolStripSplitButton reaprovisionamiento = CrearGrupo("Reaprovisionamiento");
            ToolStripMenuItem consultasreaprovisionamiento = CrearSubmenu(reaprovisionamiento, "Consultas");
            AgregarConsulta(consultasreaprovisionamiento, "Pedidos de reaprovisionamiento", () => new frm16_PedidoReaprovisionamiento_2());
            AgregarConsulta(consultasreaprovisionamiento, "Proveedores", () => new frm04_Proveedor_2());
            AgregarConsulta(consultasreaprovisionamiento, "Presupuestos de proveedores", () => new frm18_PresupuestoProveedor_2());
            AgregarConsulta(consultasreaprovisionamiento, "Remitos de proveedores", () => new frm23_Remito_2());
            AgregarConsulta(consultasreaprovisionamiento, "Pagos", () => new frm24_Pagos_2());
            AgregarConsulta(consultasreaprovisionamiento, "Compras", () => new frm17_Compras_2());

            ToolStripSplitButton seguridad = CrearGrupo("Seguridad");
            ToolStripMenuItem opcionesSeguridad = CrearSubmenu(seguridad, "Cuenta");
            AgregarOpcion(opcionesSeguridad, "Cambiar contraseña", () => new Cambiar_Contraseña());

        }

        private ToolStripSplitButton CrearGrupo(string texto)
        {
            ToolStripSplitButton grupo = new ToolStripSplitButton(texto);
            grupo.DisplayStyle = ToolStripItemDisplayStyle.Text;
            grupo.ButtonClick += (sender, e) => grupo.ShowDropDown();
            barraGerente.Items.Add(grupo);
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

        private void AgregarConsulta(ToolStripMenuItem submenu, string texto,
                              Func<Form> crearFormulario)
        {
            AgregarOpcion(submenu, texto, crearFormulario);
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            panelContenidoGerente.SuspendLayout();
            try
            {
                LimpiarPanel();
                global::AluSoft.UI.AjusteFormularios.PrepararParaPanel(formulario);
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;

                panelContenidoGerente.Controls.Add(formulario);
                panelContenidoGerente.Tag = formulario;
                formulario.Show();
            }
            finally
            {
                panelContenidoGerente.ResumeLayout(true);
            }
        }

        private void LimpiarPanel()
        {
            panelContenidoGerente.Tag = null;
            while (panelContenidoGerente.Controls.Count > 0)
            {
                Control control = panelContenidoGerente.Controls[0];
                panelContenidoGerente.Controls.Remove(control);
                control.Dispose();
            }
        }
    }

}
