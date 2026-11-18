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
    public partial class Recuperar_Contraseña : Form
    {
        BLL.Login glogin = new BLL.Login();
        public Recuperar_Contraseña()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txbUsuario.Text))
            {
                errorProvider1.SetError(txbUsuario, "Tenés que completar este campo.");
                txbUsuario.Focus();
                return;
            }
            Cursor = Cursors.WaitCursor;
            btnEnviar.Enabled = false;
            try
            {
                string correo = glogin.RecuperarContraseña(txbUsuario.Text.Trim());
                MessageBox.Show("Te enviamos una contraseña nueva a " + correo + ".\n\nIngresá con esa contraseña.",
                    "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Volver();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnEnviar.Enabled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Volver();
        }
        private void Volver()
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }
    }
}
