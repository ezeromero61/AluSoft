using BE;
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
    public partial class Cambiar_Contraseña : Form
    {
        public Cambiar_Contraseña()
        {
            InitializeComponent();
        }
        BE.cls05_Login login;
        BE.cls35_Bitacora bitacora;
        BLL.Login glogin = new BLL.Login();
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BLL.clsPerdurables gperdurable = new BLL.clsPerdurables();
        private void pro_modificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbUsuario.Text))
            {
                MessageBox.Show("No se pudo identificar el usuario de la sesión.", "Cambiar contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbNuevaContraseña.Text))
            {
                MessageBox.Show("Ingresá la nueva contraseña.", "Cambiar contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbNuevaContraseña.Focus();
                return;
            }

            if (txbNuevaContraseña.Text != txbRepetirContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Cambiar contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbRepetirContraseña.Focus();
                return;
            }

            try
            {
                // El usuario se obtiene por el IdLogin de la sesión; no se confía
                // en un valor escrito o modificado desde el formulario.
                BE.cls05_Login cuentaActual = glogin.ListarCompleto()
                    .FirstOrDefault(x => x.IdLogin == BLL.clsPerdurables.Id_Login);

                if (cuentaActual == null || string.IsNullOrWhiteSpace(cuentaActual.Usuario))
                {
                    MessageBox.Show("No se encontró la cuenta asociada a la sesión actual.", "Cambiar contraseña",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                login = new BE.cls05_Login();
                login.Usuario = Cifrado.EncriptarString(cuentaActual.Usuario);
                login.Contraseña = Cifrado.EncriptarString(txbNuevaContraseña.Text);

                int filasAfectadas = glogin.CambiarContraseña(login);
                if (filasAfectadas <= 0)
                {
                    MessageBox.Show("No se pudo actualizar la contraseña.", "Cambiar contraseña",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = gbitacora.Max(bitacora) + 1;
                bitacora.idlogin = BLL.clsPerdurables.Id_Login;
                bitacora.idtabla = 4;
                bitacora.idaccion = 1;
                bitacora.fecha = DateTime.Now;
                bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                gbitacora.Agregar(bitacora);

                MessageBox.Show("La contraseña se cambió correctamente.", "Cambiar contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNuevaContraseña.Clear();
                txbRepetirContraseña.Clear();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar la contraseña:\n" + ex.Message, "Cambiar contraseña",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cambiar_Contraseña_Load(object sender, EventArgs e)
        {
            txbUsuario.ReadOnly = true;
            txbUsuario.TabStop = false;
            txbUsuario.Clear();

            try
            {
                if (BLL.clsPerdurables.Id_Login <= 0)
                {
                    MessageBox.Show("No hay una sesión iniciada. Ingresá nuevamente al sistema.",
                        "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pro_modificar.Enabled = false;
                    return;
                }

                BE.cls05_Login cuentaActual = glogin.ListarCompleto()
                    .FirstOrDefault(x => x.IdLogin == BLL.clsPerdurables.Id_Login);
                if (cuentaActual == null)
                {
                    MessageBox.Show("No se encontró el usuario de la sesión actual.",
                        "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pro_modificar.Enabled = false;
                    return;
                }

                txbUsuario.Text = cuentaActual.Usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el usuario de la sesión:\n" + ex.Message,
                    "Cambiar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pro_modificar.Enabled = false;
            }
        }

        private void VerContraseña(TextBox cuadro, Button ojoAbierto, Button ojoTachado, bool ver)
        {
            cuadro.UseSystemPasswordChar = !ver;
            ojoAbierto.Visible = !ver;
            ojoTachado.Visible = ver;
            cuadro.Focus();
        }
        private void btnMostrarNueva_Click(object sender, EventArgs e) { VerContraseña(txbNuevaContraseña, btnMostrarNueva, btnOcultarNueva, true); }
        private void btnOcultarNueva_Click(object sender, EventArgs e) { VerContraseña(txbNuevaContraseña, btnMostrarNueva, btnOcultarNueva, false); }
        private void btnMostrarRepetir_Click(object sender, EventArgs e) { VerContraseña(txbRepetirContraseña, btnMostrarRepetir, btnOcultarRepetir, true); }
        private void btnOcultarRepetir_Click(object sender, EventArgs e) { VerContraseña(txbRepetirContraseña, btnMostrarRepetir, btnOcultarRepetir, false); }

        private void pro_volver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
