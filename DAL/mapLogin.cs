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
        public int ObtenerLoginMedianteUsuario(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            datareader1 = acceso.LeerConDataReader("Obtener_10_LoginMedianteUsuario", parametro);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            acceso.Desconectar();
            return verificacion;
        }
        public int ObtenerIdLoginMedianteUsuario(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdLoginMedianteUsuario", parametro);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            acceso.Desconectar();
            return verificacion;
        }
        public int ObtenerIdRolMedianteUsuario(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdRolMedianteUsuario", parametro);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            acceso.Desconectar();
            return verificacion;
        }
        public int ObtenerDigitoVerificadorMedianteUsuario(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            SqlDataReader datareader1;
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            datareader1 = acceso.LeerConDataReader("Obtener_10_DigitoVerificadorMedianteUsuario", parametro);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            acceso.Desconectar();
            return verificacion;
        }
        public int ObtenerIdRolMedianteUsuarioYContraseña(BE.cls05_Login login)
        {
            int verificacion = 0;
            SqlParameter[] parametro = new SqlParameter[2];
            SqlDataReader datareader1;
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            parametro[1] = new SqlParameter("@Contraseña", login.contraseña);
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdRolMedianteUsuarioContraseña", parametro);
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
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdLoginMedianteUsuarioContraseña", parametro);
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
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdProfesorMedianteUsuarioContraseña", parametro);
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
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdPreceptorMedianteUsuarioContraseña", parametro);
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
            datareader1 = acceso.LeerConDataReader("Obtener_10_IdPreceptorMedianteUsuarioContraseña", parametro);
            while (datareader1.Read())
            {
                verificacion = (datareader1.GetInt32(0));
            }
            return verificacion;
        }
        public string ObtenerCorreoMedianteUsuario(BE.cls05_Login login)
        {
            string correo = null;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            SqlDataReader datareader1 = acceso.LeerConDataReader("Obtener_10_CorreoMedianteUsuario", parametro);
            while (datareader1.Read())
            {
                if (!datareader1.IsDBNull(0)) correo = datareader1.GetString(0).Trim();
            }
            acceso.Desconectar();
            return correo;
        }

        public bool ObtenerDatosParaVerificar(BE.cls05_Login login, out int idRol, out int digitoGuardado)
        {
            bool encontrado = false; idRol = 0; digitoGuardado = 0;
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            parametro[1] = new SqlParameter("@Contrasena", login.Contraseña);
            SqlDataReader datareader1 = acceso.LeerConDataReader("Obtener_10_LoginParaVerificar", parametro);
            while (datareader1.Read())
            {
                encontrado = true;
                idRol = datareader1.IsDBNull(0) ? 0 : datareader1.GetInt32(0);
                digitoGuardado = datareader1.IsDBNull(1) ? 0 : datareader1.GetInt32(1);
            }
            acceso.Desconectar();
            return encontrado;
        }

        public int ActualizarContraseña(BE.cls05_Login login, int digitoVerificador)
        {
            SqlParameter[] parametro = new SqlParameter[3];
            parametro[0] = new SqlParameter("@Usuario", login.Usuario);
            parametro[1] = new SqlParameter("@Contrasena", login.Contraseña);
            parametro[2] = new SqlParameter("@DigitoVerificador", digitoVerificador);
            return acceso.Escribir("ActualizarContrasenaLogin", parametro);
        }

        public BE.cls05_Login ObtenerPorId(int idLogin)
        {
            SqlParameter[] parametro = { new SqlParameter("@IdLogin", idLogin) };
            DataTable tabla = acceso.LeerConParametro("Obtener_10_LoginPorId", parametro);
            if (tabla.Rows.Count == 0) return null;
            DataRow fila = tabla.Rows[0];
            BE.cls05_Login login = new BE.cls05_Login();
            login.IdLogin = Convert.ToInt32(fila["IdLogin"]);
            login.idrol = fila["IdRol"] == DBNull.Value ? 0 : Convert.ToInt32(fila["IdRol"]);
            login.Usuario = Convert.ToString(fila["Usuario"]);
            login.Contraseña = Convert.ToString(fila["Contrasena"]);
            login.digitoverificador = fila["DigitoVerificador"] == DBNull.Value ? 0 : Convert.ToInt32(fila["DigitoVerificador"]);
            return login;
        }

        public int ActualizarRolPersona(int idPersona, int idLogin, int idRol, int digitoVerificador)
        {
            SqlParameter[] parametro = {
                new SqlParameter("@IdPersona", idPersona),
                new SqlParameter("@IdLogin", idLogin),
                new SqlParameter("@IdRol", idRol),
                new SqlParameter("@DigitoVerificador", digitoVerificador)
            };
            return acceso.Escribir("ActualizarRolPersona", parametro);
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
            parametro[3] = new SqlParameter("@Contrasena", login.Contraseña);
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
                login.idlogin = int.Parse(dr["IdLogin"].ToString());
            }

            return ls = login.idlogin;
        }
        public List<BE.cls05_Login> Listar2()
        {
            List<BE.cls05_Login> ls = new List<BE.cls05_Login>();
            DataTable tabla = acceso.Leer("Obtener_05_IdLoginEspecial", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls05_Login login = new BE.cls05_Login();
                login.IdLogin = int.Parse(dr["IdLogin"].ToString());
                login.Usuario = clsCifrado.DesencriptarString(dr["Usuario"].ToString());
                ls.Add(login);
            }
            return ls;
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
