using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapLogin
    {
        clsAcceso acceso = new clsAcceso();     
        public bool comparar_usuario(BE.cls05_Login login)
        {
            bool verificacion = false;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);

            datareader1 = acceso.LeerConDataReaderSinParametro("ObtenerUsuarioLogin") ;
            //datareader1 = acceso.LeerConDataReader("ObtenerUsuarioLogin", parametro);//,username);
            while (datareader1.Read())
            {
                string usuario_bdd = datareader1.GetString(datareader1.GetOrdinal("Usuario"));
                usuario_bdd = usuario_bdd.Trim();
                if (usuario_bdd == login.usuario)
                {
                    verificacion = true;
                    break;
                }
                else
                {
                    verificacion = false;
                }
            }
            acceso.Desconectar();
            return verificacion;
        }
        public bool comparar_contraseña(BE.cls05_Login login)
        {
            bool verificacion = false;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            datareader1 = acceso.LeerConDataReaderSinParametro("ObtenerContraseñaLogin");
            //datareader1 = acceso.LeerConDataReader("ObtenerContraseñaLogin", parametro);          
            while (datareader1.Read())
            {
                string usuario_bdd = datareader1.GetString(datareader1.GetOrdinal("Contraseña"));
                usuario_bdd = usuario_bdd.Trim();
                if (usuario_bdd == login.contraseña)
                {
                    verificacion = true;
                    break;
                }
                else
                {
                    verificacion = false;
                }
            }
            acceso.Desconectar();
            return verificacion;
        }              
        public int Direccionar_Usuarios(BE.cls05_Login login)
        {
            int variable = 0;
            SqlParameter[] parametro = new SqlParameter[2];
            SqlDataReader datareader1;
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdAlumnoMedianteUsuarioContraseña", parametro);
            //datareader1 = Obtener_10_IdAlumnoMedianteUsuarioContraseña(usuario, contraseña);
            //datareader1 = objetoCD.Obtener_DataReader(usuario, contraseña);
            if (datareader1.Read())
            {
                variable = 1;
            }
            return variable;
        }
        public int ObtenerIdRolMedianteUsuarioYContraseña(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[2];
            SqlDataReader datareader1;
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            parametro[1] = new SqlParameter("@Contraseña", login.contraseña);
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdRolMedianteUsuarioContraseña", parametro);//,username);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            acceso.Desconectar();
            return verificacion;
        }
        public int ObtenerIDLoginMedianteUsuarioYContraseña(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[2];
            SqlDataReader datareader1;
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            parametro[1] = new SqlParameter("@Contraseña", login.contraseña);
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdLoginMedianteUsuarioContraseña", parametro);//,username);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            acceso.Desconectar();
            return verificacion;
        }
        public int DireccionarAdministrativo(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdProfesorMedianteUsuarioContraseña", parametro);//,username);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            return verificacion;
        }
        public int DireccionarGerente(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdPreceptorMedianteUsuarioContraseña", parametro);//,username);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            return verificacion;
        }
        public int DireccionarSupervisor(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdPreceptorMedianteUsuarioContraseña", parametro);//,username);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            return verificacion;
        }
        public int Agregar(BE.cls05_Login login)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[5];

            parametro[0] = new SqlParameter("@IdLogin", login.IdLogin);
            parametro[1] = new SqlParameter("@IdRol", login.idrol);
            parametro[2] = new SqlParameter("@Usuario", login.Usuario);
            parametro[3] = new SqlParameter("@Contraseña", login.Contraseña);
            parametro[4] = new SqlParameter("@DigitoVerificador", login.DigitoVerificador);

            fa = acceso.Escribir("AgregarLogin", parametro);

            return fa;
        }
        public int Editar(BE.cls05_Login login)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[5];

            parametro[0] = new SqlParameter("@IdLogin", login.IdLogin);
            parametro[1] = new SqlParameter("@IdRol", login.idrol);
            parametro[2] = new SqlParameter("@Usuario", login.Usuario);
            parametro[3] = new SqlParameter("@Contraseña", login.Contraseña);
            parametro[4] = new SqlParameter("@DigitoVerificador", login.DigitoVerificador);

            fa = acceso.Escribir("EditarLogin", parametro);

            return fa;
        }
        public int Eliminar(BE.cls05_Login login)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdLogin", login.IdLogin);

            fa = acceso.Escribir("EliminarLogin", parametro);

            return fa;
        }
        public int MaxId(BE.cls05_Login login)
        {
            int ls = 0;
            DataTable tabla = acceso.Leer("MAXIdLogin", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                login.idlogin = int.Parse(dr["IdLogin"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = login.idlogin;
        }
        public List<BE.cls05_Login> Listar()
        {
            List<BE.cls05_Login> ls = new List<BE.cls05_Login>();

            DataTable tabla = acceso.Leer("ListarLogin", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls05_Login login = new BE.cls05_Login();

                login.IdLogin = int.Parse(dr["IdLogin"].ToString());
                login.idrol = int.Parse(dr["IdRol"].ToString());
                login.Usuario = dr["Usuario"].ToString();
                login.Contraseña = dr["Contraseña"].ToString();
                login.DigitoVerificador = int.Parse(dr["DigitoVerificador"].ToString());

                ls.Add(login);
            }

            return ls;
        }
    }
}
