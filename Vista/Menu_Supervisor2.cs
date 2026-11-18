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
    public partial class Menu_Supervisor2 : Form
    {
        public Menu_Supervisor2()
        {
            InitializeComponent();
            global::AluSoft.UI.TemaMenus.Aplicar(this, toolStrip1, panel1, "Supervisor");
            AgregarMenuCambioContraseña();
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
        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm02_Stock_1());
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm02_Stock_2());
        }

        private void ordenDeProducciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm14_OrdenProduccion_1());
        }

        private void estadoDeProduciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm15_Estado_1());
        }

        private void ordenDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm14_OrdenProduccion_2());
        }

        private void estadoDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm15_Estado_2());
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm04_Proveedor_1());
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm04_Proveedor_2());
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
            MessageBox.Show("Usted está en la pantalla del supervisor, estará dedicada a gestionar el stock y la producción. " +
            "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }
    }
}
