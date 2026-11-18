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
        public int ObtenerLoginMedianteUsuario(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.ObtenerLoginMedianteUsuario(login);
            return fa;
        }
        public int ObtenerIdLoginMedianteUsuario(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.ObtenerIdLoginMedianteUsuario(login);
            return fa;
        }
        public int ObtenerIdRolMedianteUsuario(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.ObtenerIdRolMedianteUsuario(login);
            return fa;
        }
        public int ObtenerDigitoVerificadorMedianteUsuario(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.ObtenerDigitoVerificadorMedianteUsuario(login);
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
        public int Editar(BE.cls05_Login login)
        {
            int fa;
            fa = mapper.Editar(login);
            return fa;
        }
        public bool VerificarDigitoVerificador(BE.cls05_Login login)
        {
            int idRol, guardado;
            if (!mapper.ObtenerDatosParaVerificar(login, out idRol, out guardado)) return false;
            int calculadoConDatosGuardados = DigitoVerificador.CalcularLogin(
                login.Usuario, login.Contraseña, idRol);
            if (guardado == calculadoConDatosGuardados)
                return true;

            // [UNIFICADO 3.1.6] Compatibilidad con cuentas creadas antes de calcular el dígito
            // usando los valores cifrados que se guardan en Login.
            string usuarioAnterior = Cifrado.DesencriptarString(login.Usuario);
            string contrasenaAnterior = Cifrado.DesencriptarString(login.Contraseña);
            int calculadoConDatosSinCifrar = DigitoVerificador.CalcularLogin(
                usuarioAnterior, contrasenaAnterior, idRol);
            return guardado == calculadoConDatosSinCifrar;
        }

        public int CambiarContraseña(BE.cls05_Login login)
        {
            int idRol = mapper.ObtenerIdRolMedianteUsuario(login);
            int dv = DigitoVerificador.CalcularLogin(login.Usuario, login.Contraseña, idRol);
            return mapper.ActualizarContraseña(login, dv);
        }

        public int ActualizarRolPersona(int idPersona, int idLogin, int idRol)
        {
            BE.cls05_Login login = mapper.ObtenerPorId(idLogin);
            if (login == null)
                throw new Exception("La persona no tiene una cuenta de acceso válida.");
            // [CORREGIDO] El dígito se calcula sobre el usuario y la contraseña tal como están
            // guardados (encriptados), igual que en VerificarDigitoVerificador.
            int digito = DigitoVerificador.CalcularLogin(login.Usuario, login.Contraseña, idRol);
            return mapper.ActualizarRolPersona(idPersona, idLogin, idRol, digito);
        }

        public string RecuperarContraseña(string usuario)
        {
            BE.cls05_Login login = new BE.cls05_Login();
            login.Usuario = Cifrado.EncriptarString(usuario);
            if (mapper.ObtenerIdLoginMedianteUsuario(login) <= 0)
                throw new Exception("No existe un usuario con ese nombre.");
            string correo = mapper.ObtenerCorreoMedianteUsuario(login);
            if (string.IsNullOrWhiteSpace(correo))
                throw new Exception("El usuario no tiene un correo registrado. Consultá con el administrador.");

            string nueva = GenerarContraseña(8);
            MailHelper.EnviarRecuperacion(correo, usuario, nueva);

            login.Contraseña = Cifrado.EncriptarString(nueva);
            if (CambiarContraseña(login) == 0)
                throw new Exception("Se envió el correo, pero no se pudo guardar la contraseña nueva. Volvé a intentarlo.");
            return EnmascararCorreo(correo);
        }

        private static string GenerarContraseña(int largo)
        {
            const string letras = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            byte[] azar = new byte[largo];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider()) rng.GetBytes(azar);
            char[] resultado = new char[largo];
            for (int i = 0; i < largo; i++) resultado[i] = letras[azar[i] % letras.Length];
            return new string(resultado);
        }

        private static string EnmascararCorreo(string correo)
        {
            int arroba = correo.IndexOf('@');
            if (arroba <= 1) return correo;
            return correo.Substring(0, 1) + new string('*', arroba - 1) + correo.Substring(arroba);
        }

        public List<BE.cls05_Login> ListarCompleto()
        {
            List<BE.cls05_Login> inventario = mapper.Listar2();
            return inventario;
        }
    }
}
