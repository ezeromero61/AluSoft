using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Login
    {
        mapLogin mapper = new mapLogin();
       public bool ComparaUsuario(BE.cls05_Login login)
       {
         bool fa;
         fa=mapper.comparar_usuario(login);
         return fa;
        }
        public bool ComparaContraseña(BE.cls05_Login login)
        {
            bool fa;
            fa = mapper.comparar_contraseña(login);
            return fa;
        }
        public int DireccionarUsuarios(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.Direccionar_Usuarios(login);
            return fa;
        }
        public int ObtenerIdRolMedianteUsuarioYContraseña(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.ObtenerIdRolMedianteUsuarioYContraseña(login);
            return fa;
        }
        public int ObtenerIDLoginMedianteUsuarioYContraseña(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.ObtenerIDLoginMedianteUsuarioYContraseña(login);
            return fa;
        }
        public int DireccionarAdministrativo(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.DireccionarAdministrativo(login);
            return fa;
        }
        public int DireccionarGerente(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.DireccionarGerente(login);
            return fa;
        }
        public int DireccionarSupervisor(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.DireccionarSupervisor(login);
            return fa;
        }
        public int Max(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.MaxId(login);
            return fa;
        }
    }
}
