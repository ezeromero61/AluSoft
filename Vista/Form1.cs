using AluSoft;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BE.cls05_Login login;
        BE.cls35_Bitacora bitacora;
        BLL.Login glogin = new BLL.Login();
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BLL.clsPerdurables gperdurable = new BLL.clsPerdurables();
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            txbUsuario.Focus();
        }
        private void CargarBitacora(int tabla, int accion)
        {
            #region Bitacora 
            int fu;
            bitacora = new BE.cls35_Bitacora();
            bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
            bitacora.idlogin = clsPerdurables.Id_Login;
            bitacora.idtabla = tabla;
            bitacora.idaccion = accion;
            bitacora.fecha = (DateTime.Now);
            bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
            fu = gbitacora.Agregar(bitacora);
            #endregion
        }
        private void log_ingresar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            login = new BE.cls05_Login();
            login.usuario = Cifrado.EncriptarString(txbUsuario.Text);
            login.contraseña = Cifrado.EncriptarString(txbContraseña.Text);
            int caso = glogin.ObtenerIdRolMedianteUsuarioYContraseña(login);
            if (caso >= 1 && caso <= 4 && !glogin.VerificarDigitoVerificador(login))
            {
                MessageBox.Show("No se puede ingresar: los datos de este usuario fueron modificados por fuera del sistema " +
                    "(el dígito verificador no coincide). Consultá con el administrador.",
                    "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (caso >= 1 && caso <= 4)
            {
                MessageBox.Show("Acceso Correcto", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsPerdurables.Id_Rol = caso;
                switch (caso)
                {
                    case 1:
                        Menu_Gerente2 Prueba2_Alumnoss = new Menu_Gerente2();
                        Prueba2_Alumnoss.Show(); this.Hide();
                        clsPerdurables.Id_Login = glogin.ObtenerIDLoginMedianteUsuarioYContraseña(login);
                        CargarBitacora(6, 7);
                        break;
                    case 2:
                        Menu_Soporte Prueba2_Profesoress = new Menu_Soporte();
                        Prueba2_Profesoress.Show(); this.Hide();
                        clsPerdurables.Id_Login = glogin.ObtenerIDLoginMedianteUsuarioYContraseña(login);
                        CargarBitacora(6, 7);
                        break;
                    case 3:
                        Menu_Administrativo2 Prueba2_Preceptors = new Menu_Administrativo2();
                        Prueba2_Preceptors.Show(); this.Hide();
                        clsPerdurables.Id_Login = glogin.ObtenerIDLoginMedianteUsuarioYContraseña(login);
                        CargarBitacora(6, 7);
                        break;
                    case 4:
                        Menu_Supervisor2 guardar_cursada = new Menu_Supervisor2();
                        guardar_cursada.Show(); this.Hide();
                        clsPerdurables.Id_Login = glogin.ObtenerIDLoginMedianteUsuarioYContraseña(login);
                        CargarBitacora(6, 7);
                        break;
                }
            }
            else
            {
                RegistrarContraseñaIncorrecta(login);
                MessageBox.Show("Incorrecto, verifique sus credenciales", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Si el usuario existe pero la contraseña no coincide, queda registrado en la bitácora
        // a nombre de ese usuario (tabla 6 = Login, acción 8 = Contraseña incorrecta, script 11).
        private void RegistrarContraseñaIncorrecta(BE.cls05_Login intento)
        {
            try
            {
                int idLogin = glogin.ObtenerIdLoginMedianteUsuario(intento);
                if (idLogin <= 0) return; // usuario inexistente: no se registra
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = idLogin;
                bitacora.idtabla = 6;
                bitacora.idaccion = 8;
                bitacora.fecha = DateTime.Now;
                bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                gbitacora.Agregar(bitacora);
            }
            catch
            {
                // La bitácora no debe impedir el aviso de credenciales incorrectas.
            }
        }

        private void btnMostrarContraseña_Click(object sender, EventArgs e)
        {
            txbContraseña.UseSystemPasswordChar = false;
            btnMostrarContraseña.Visible = false;
            btnOcultarContraseña.Visible = true;
            txbContraseña.Focus();
        }

        private void btnOcultarContraseña_Click(object sender, EventArgs e)
        {
            txbContraseña.UseSystemPasswordChar = true;
            btnMostrarContraseña.Visible = true;
            btnOcultarContraseña.Visible = false;
            txbContraseña.Focus();
        }

        private void log_recuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recuperar_Contraseña recuperar = new Recuperar_Contraseña();
            recuperar.Show(); this.Hide();
        }
    }
}
