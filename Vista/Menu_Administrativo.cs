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
    public partial class Menu_Administrativo : Form
    {
        public Menu_Administrativo()
        {
            InitializeComponent();
            ConfigurarMenuSeguridad();
        }

        private void ConfigurarMenuSeguridad()
        {
            // Esta versión del formulario no inicializa el ToolStrip declarado
            // por el diseñador, así que se crea aquí para exponer Seguridad.
            toolStrip1 = new ToolStrip();
            toolStrip1.Dock = DockStyle.Top;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;

            ToolStripSplitButton seguridad = new ToolStripSplitButton("Seguridad");
            seguridad.DisplayStyle = ToolStripItemDisplayStyle.Text;
            seguridad.ButtonClick += (sender, e) => seguridad.ShowDropDown();

            ToolStripMenuItem cambiar = new ToolStripMenuItem("Cambiar contraseña");
            cambiar.Click += (sender, e) => AbrirCambioContraseña();
            seguridad.DropDownItems.Add(cambiar);
            toolStrip1.Items.Add(seguridad);
            Controls.Add(toolStrip1);
            toolStrip1.BringToFront();
        }

        private void AbrirCambioContraseña()
        {
            using (Cambiar_Contraseña formulario = new Cambiar_Contraseña())
                formulario.ShowDialog(this);
        }

        private void Menu_Administrativo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void Grupo_ButtonClick(object sender, EventArgs e)
        {
            ((ToolStripSplitButton)sender).ShowDropDown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarPanel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccioná un área y luego Formularios de alta o Formularios de gestión. " +
                "Limpiar cierra el formulario abierto en el panel.",
                "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menu_alum_volver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void alta03Cliente1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm03_Cliente());
        }

        private void gestion03Cliente2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm03_Cliente_2());
        }

        private void alta07PresupuestoClienteMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm07_PresupuestoCliente());
        }

        private void gestion07PresupuestoCliente2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm07_PresupuestoCliente_2());
        }

        private void alta08PedidoCliente1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm08_PedidoCliente_1());
        }

        private void gestion08PedidoCliente2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm08_PedidoCliente_2());
        }

        private void alta09Factura1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm09_Factura_1());
        }

        private void gestion09Factura2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm09_Factura_2());
        }

        private void gestion10Cobro2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm10_Cobro_2());
        }

        private void gestion11Ventas2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm11_Ventas_2());
        }

        private void alta02Stock1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm02_Stock_1());
        }

        private void gestion02Stock2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm02_Stock_2());
        }

        private void alta13ListaPrecios1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm13_ListaPrecios_1());
        }

        private void gestion13ListaPrecios2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm13_ListaPrecios_2());
        }

        private void alta12Catalogo1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm12_Catalogo_1());
        }

        private void gestion12Catalogo2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm12_Catalogo_2());
        }

        private void alta01Inventario1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm01_Inventario_1());
        }

        private void gestion01Inventario2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm01_Inventario_2());
        }

        private void alta19MaximoMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm19_Maximo());
        }

        private void gestion19Maximo2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm19_Maximo_2());
        }

        private void alta20MinimoMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm20_Minimo());
        }

        private void gestion20Minimo2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm20_Minimo_2());
        }

        private void gestion14OrdenProduccion2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm14_OrdenProduccion_2());
        }

        private void gestion15Estado2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm15_Estado_2());
        }

        private void gestion21Produccion2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm21_Produccion_2());
        }

        private void alta16PedidoReaprovisionamientoMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm16_PedidoReaprovisionamiento());
        }

        private void gestion16PedidoReaprovisionamiento2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm16_PedidoReaprovisionamiento_2());
        }

        private void alta04Proveedor1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm04_Proveedor_1());
        }

        private void gestion04Proveedor2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm04_Proveedor_2());
        }

        private void alta18PresupuestoProveedor1MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm18_PresupuestoProveedor_1());
        }

        private void gestion18PresupuestoProveedor2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm18_PresupuestoProveedor_2());
        }

        private void gestion23Remito2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm23_Remito_2());
        }

        private void gestion24Pagos2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm24_Pagos_2());
        }

        private void gestion17Compras2MenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm17_Compras_2());
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            panel1.SuspendLayout();
            try
            {
                LimpiarPanel();
                global::AluSoft.UI.AjusteFormularios.PrepararParaPanel(formulario);
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;

                panel1.Controls.Add(formulario);
                panel1.Tag = formulario;
                formulario.Show();
            }
            finally
            {
                panel1.ResumeLayout(true);
            }
        }

        private void LimpiarPanel()
        {
            panel1.Tag = null;
            while (panel1.Controls.Count > 0)
            {
                Control control = panel1.Controls[0];
                panel1.Controls.Remove(control);
                control.Dispose();
            }
        }

        private void Menu_Administrativo_Load_1(object sender, EventArgs e)
        {

        }

        private void Menu_Administrativo_Load_2(object sender, EventArgs e)
        {

        }
    }

}

