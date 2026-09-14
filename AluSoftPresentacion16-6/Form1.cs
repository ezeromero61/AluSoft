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
        private void log_ingresar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            login = new BE.cls05_Login();
            login.usuario = Cifrado.EncriptarString(txbUsuario.Text);//txbUsuario.Text;
            login.contraseña = Cifrado.EncriptarString(txbContraseña.Text);// txbContraseña.Text;
            bool username = glogin.ComparaUsuario(login);//Login.comparar_usuario(usuario);
            bool password = glogin.ComparaContraseña(login);
            if (username == true && password == true)
            {
                MessageBox.Show("Acceso Correcto");
                int caso = glogin.ObtenerIdRolMedianteUsuarioYContraseña(login);
                switch (caso)
                {
                    case 1:
                        Menu_Gerente Prueba2_Alumnoss = new Menu_Gerente();
                        Prueba2_Alumnoss.Show(); this.Hide();
                        clsPerdurables.Id_Login = glogin.ObtenerIDLoginMedianteUsuarioYContraseña(login);
                        #region Bitacora 
                        bitacora = new BE.cls35_Bitacora();
                        bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);//(generica.BUSQUEDA_MAX_ID_NUMERICO("busqueda_MAX_35_Bitacora", "Id_Tabla")) + 1;
                        bitacora.idlogin = clsPerdurables.Id_Login;
                        bitacora.idtabla = 6;
                        bitacora.idaccion = 7;
                        bitacora.fecha = (DateTime.Now);
                        bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                        fa = gbitacora.Agregar(bitacora);
                        #endregion
                        break;
                    case 2:
                        Menu_Soporte Prueba2_Profesoress = new Menu_Soporte();
                        Prueba2_Profesoress.Show(); this.Hide();
                        clsPerdurables.Id_Login = glogin.ObtenerIDLoginMedianteUsuarioYContraseña(login);
                        #region Bitacora 
                        bitacora = new BE.cls35_Bitacora();
                        bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);//(generica.BUSQUEDA_MAX_ID_NUMERICO("busqueda_MAX_35_Bitacora", "Id_Tabla")) + 1;
                        bitacora.idlogin = clsPerdurables.Id_Login;
                        bitacora.idtabla = 6;
                        bitacora.idaccion = 7;
                        bitacora.fecha = (DateTime.Now);
                        bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                        fa = gbitacora.Agregar(bitacora);
                        #endregion
                        break;
                    case 3:
                        Menu_Administrativo Prueba2_Preceptors = new Menu_Administrativo();
                        Prueba2_Preceptors.Show(); this.Hide();
                        clsPerdurables.Id_Login = glogin.ObtenerIDLoginMedianteUsuarioYContraseña(login);
                        #region Bitacora 
                        bitacora = new BE.cls35_Bitacora();
                        bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);//(generica.BUSQUEDA_MAX_ID_NUMERICO("busqueda_MAX_35_Bitacora", "Id_Tabla")) + 1;
                        bitacora.idlogin = clsPerdurables.Id_Login;
                        bitacora.idtabla = 6;
                        bitacora.idaccion = 7;
                        bitacora.fecha = (DateTime.Now);
                        bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                        fa = gbitacora.Agregar(bitacora);
                        #endregion
                        break;
                    case 4:
                        Menu_Supervisor guardar_cursada = new Menu_Supervisor();
                        guardar_cursada.Show(); this.Hide();
                        clsPerdurables.Id_Login = glogin.ObtenerIDLoginMedianteUsuarioYContraseña(login);
                        #region Bitacora 
                        bitacora = new BE.cls35_Bitacora();
                        bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);//(generica.BUSQUEDA_MAX_ID_NUMERICO("busqueda_MAX_35_Bitacora", "Id_Tabla")) + 1;
                        bitacora.idlogin = clsPerdurables.Id_Login;
                        bitacora.idtabla = 6;
                        bitacora.idaccion = 7;
                        bitacora.fecha = (DateTime.Now);
                        bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                        fa = gbitacora.Agregar(bitacora);
                        #endregion
                        break;
                }
            }
            else
            {
                MessageBox.Show("Incorrecto, verifique sus credenciales");
            }
        }

        
    }
}
