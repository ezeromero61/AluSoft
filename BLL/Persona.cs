using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Persona
    {
        mapPersona mapper = new mapPersona();
        public int Agregar(BE.cls00_Persona persona)
        {
            int fa;
            if (persona == null)
                throw new ArgumentNullException(nameof(persona));

            if (string.IsNullOrWhiteSpace(persona.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(persona.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (persona.Dni <= 0)
                throw new Exception("El DNI debe ser válido.");

            if (string.IsNullOrWhiteSpace(persona.Correo))
                throw new Exception("El correo es obligatorio.");

            if (persona.Fecha_nacimiento == DateTime.MinValue)
                throw new Exception("La fecha de nacimiento no es válida.");

            fa = mapper.Agregar(persona);
            return fa;
        }

        public int AgregarConAcceso(BE.cls00_Persona persona, string usuario, string contrasena)
        {
            if (persona == null) throw new ArgumentNullException(nameof(persona));
            if (persona.Idrol <= 0) throw new ArgumentException("Seleccioná un rol para crear el acceso.");
            ValidarCredenciales(usuario, contrasena);
            BE.cls05_Login login = new BE.cls05_Login();
            persona.Idlogin = new Login().Max(login) + 1;
            // [CORREGIDO] El dígito verificador del login se calcula sobre el usuario y la contraseña
            // ENCRIPTADOS (así lo verifica Form1 al ingresar). Con el texto plano el usuario nuevo
            // no podía entrar porque el dígito no coincidía.
            int digito = DigitoVerificador.CalcularLogin(Cifrado.EncriptarString(usuario.Trim()), Cifrado.EncriptarString(contrasena), persona.Idrol);
            return mapper.AgregarConAcceso(persona, usuario, contrasena, digito);
        }

        public int AsignarAcceso(int idPersona, int idRol, string usuario, string contrasena)
        {
            if (idPersona <= 0 || idRol <= 0)
                throw new ArgumentException("Seleccioná una persona y un rol válidos.");
            ValidarCredenciales(usuario, contrasena);
            BE.cls05_Login login = new BE.cls05_Login();
            int idLogin = new Login().Max(login) + 1;
            // [CORREGIDO] Igual que arriba: el dígito va sobre los datos encriptados.
            int digito = DigitoVerificador.CalcularLogin(Cifrado.EncriptarString(usuario.Trim()), Cifrado.EncriptarString(contrasena), idRol);
            return mapper.AsignarAcceso(idPersona, idLogin, idRol, usuario, contrasena, digito);
        }

        public int ActualizarRolAcceso(int idPersona, int idLogin, int idRol)
        {
            if (idPersona <= 0 || idLogin <= 0 || idRol <= 0)
                throw new ArgumentException("Seleccioná una persona y un rol válidos.");
            return new Login().ActualizarRolPersona(idPersona, idLogin, idRol);
        }

        private static void ValidarCredenciales(string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
                throw new ArgumentException("Completá el usuario y la contraseña inicial.");
            if (usuario.Trim().Length > 50 || contrasena.Length > 255)
                throw new ArgumentException("El usuario admite hasta 50 caracteres y la contraseña hasta 255.");
        }
        public int Editar(BE.cls00_Persona persona)
        {
            int fa;
            fa = mapper.Editar(persona);
            return fa;
        }
        public int Eliminar(BE.cls00_Persona persona)
        {
            int fa;
            fa = mapper.Eliminar(persona);
            return fa;
        }
        public int Max(BE.cls00_Persona catalogo)
        {
            int fa;
            fa = mapper.MaxId(catalogo);
            return fa;
        }
        public List<BE.cls00_Persona> ListarCatalogo()
        {
            List<BE.cls00_Persona> persona = mapper.Listar();
            return persona;
        }
        public List<BE.cls00_Persona> ListarCatalogo2()
        {
            List<BE.cls00_Persona> persona = mapper.Listar2();
            return persona;
        }
        public DataTable Consultar(BE.cls00_Persona stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
        public DataTable Consultar2()
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar2();
            return tabla;
        }
    }
}
