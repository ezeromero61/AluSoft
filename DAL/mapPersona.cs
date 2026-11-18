using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapPersona
    {
        clsAcceso acc = new clsAcceso();
        #region Auxiliar
        private static object LeerObligatorio(DataRow dr, string columna)
        {
            if (!dr.Table.Columns.Contains(columna))
                throw new InvalidOperationException(
                    "La consulta no devolvió la columna " + columna + ".");

            if (dr.IsNull(columna))
                throw new InvalidOperationException(
                    "La columna " + columna + " contiene NULL y el programa la requiere.");

            return dr[columna];
        }
        private static double LeerDoubleObligatorio(DataRow dr, string columna)
        {
            return Convert.ToDouble(
                LeerObligatorio(dr, columna),
                CultureInfo.InvariantCulture);
        }
        private static int LeerIntObligatorio(DataRow dr, string columna)
        {
            return Convert.ToInt32(
                LeerObligatorio(dr, columna),
                CultureInfo.InvariantCulture);
        }
        private static int LeerIntOpcional(DataRow dr, string columna)
        {
            return !dr.Table.Columns.Contains(columna) || dr.IsNull(columna)
                ? 0
                : Convert.ToInt32(dr[columna], CultureInfo.InvariantCulture);
        }
        private static DateTime LeerFechaObligatoria(DataRow dr, string columna)
        {
            return Convert.ToDateTime(
                LeerObligatorio(dr, columna),
                CultureInfo.InvariantCulture);
        }

        private static string LeerTexto(DataRow dr, string columna)
        {
            if (!dr.Table.Columns.Contains(columna))
                throw new InvalidOperationException(
                    "La consulta no devolvió la columna " + columna + ".");

            return dr.IsNull(columna)
                ? string.Empty
                : Convert.ToString(dr[columna], CultureInfo.InvariantCulture);
        }

        private static DateTime? LeerFechaNullable(DataRow dr, string columna)
        {
            if (!dr.Table.Columns.Contains(columna))
                throw new InvalidOperationException(
                    "La consulta no devolvió la columna " + columna + ".");

            return dr.IsNull(columna)
                ? (DateTime?)null
                : Convert.ToDateTime(dr[columna], CultureInfo.InvariantCulture);
        }
        private static void CargarPersona(DataRow dr, BE.cls00_Persona persona)
        {
            persona.Idpersona = LeerIntObligatorio(dr, "IdPersona");
            persona.Idlogin = LeerIntOpcional(dr, "IdLogin");
            persona.Nombre = clsCifrado.DesencriptarString(LeerTexto(dr, "Nombre"));
            persona.Apellido = clsCifrado.DesencriptarString(LeerTexto(dr, "Apellido"));
            persona.Fecha_nacimiento = LeerFechaObligatoria(dr, "FechaNacimiento");
            persona.Genero = clsCifrado.DesencriptarString(LeerTexto(dr, "Genero"));
            persona.Domicilio = clsCifrado.DesencriptarString(LeerTexto(dr, "Domicilio"));
            persona.Correo = clsCifrado.DesencriptarString(LeerTexto(dr, "Correo"));
            persona.Telefono = LeerDoubleObligatorio(dr, "Telefono");
            persona.Dni = LeerDoubleObligatorio(dr, "DNI");
            persona.Localidad = clsCifrado.DesencriptarString(LeerTexto(dr, "Localidad"));
            persona.Idrol = LeerIntOpcional(dr, "IdRol");
            persona.Fecha_alta = LeerFechaObligatoria(dr, "FechaAlta");
            persona.Fecha_baja = LeerFechaNullable(dr, "FechaBaja");
            persona.Cuil = Convert.ToDouble(LeerObligatorio(dr, "CUIL"),CultureInfo.InvariantCulture);
        }
        #endregion
        public int Agregar(BE.cls00_Persona persona)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[15];

            parametro[0] = new SqlParameter("@IdPersona", persona.Idpersona);
            parametro[1] = new SqlParameter("@IdLogin", persona.Idlogin > 0 ? (object)persona.Idlogin : DBNull.Value);
            parametro[2] = new SqlParameter("@Nombre", clsCifrado.EncriptarString(persona.Nombre));
            parametro[3] = new SqlParameter("@Apellido", clsCifrado.EncriptarString(persona.Apellido));
            parametro[4] = new SqlParameter("@FechaNacimiento", persona.Fecha_nacimiento);
            parametro[5] = new SqlParameter("@Genero", clsCifrado.EncriptarString(persona.Genero));
            parametro[6] = new SqlParameter("@Domicilio", clsCifrado.EncriptarString(persona.Domicilio));
            parametro[7] = new SqlParameter("@Correo", clsCifrado.EncriptarString(persona.Correo));
            parametro[8] = new SqlParameter("@Telefono", persona.Telefono);
            parametro[9] = new SqlParameter("@DNI", persona.Dni);
            parametro[10] = new SqlParameter("@Localidad", clsCifrado.EncriptarString(persona.Localidad));
            parametro[11] = new SqlParameter("@IdRol", persona.Idrol > 0 ? (object)persona.Idrol : DBNull.Value);
            parametro[12] = new SqlParameter("@FechaAlta", persona.Fecha_alta);
            parametro[13] = new SqlParameter("@FechaBaja", SqlDbType.DateTime);
            parametro[13].Value = persona.Fecha_baja.HasValue? (object)persona.Fecha_baja.Value: DBNull.Value;
            parametro[14] = new SqlParameter("@CUIL", persona.Cuil);
            fa = acc.Escribir("AgregarPersona", parametro);

            return fa;
        }
        public int AgregarConAcceso(BE.cls00_Persona persona, string usuario, string contrasena, int digitoVerificador)
        {
            SqlParameter[] parametro = new SqlParameter[18];
            parametro[0] = new SqlParameter("@IdPersona", persona.Idpersona);
            parametro[1] = new SqlParameter("@IdLogin", persona.Idlogin);
            parametro[2] = new SqlParameter("@Nombre", clsCifrado.EncriptarString(persona.Nombre));
            parametro[3] = new SqlParameter("@Apellido", clsCifrado.EncriptarString(persona.Apellido));
            parametro[4] = new SqlParameter("@FechaNacimiento", persona.Fecha_nacimiento);
            parametro[5] = new SqlParameter("@Genero", clsCifrado.EncriptarString(persona.Genero));
            parametro[6] = new SqlParameter("@Domicilio", clsCifrado.EncriptarString(persona.Domicilio));
            parametro[7] = new SqlParameter("@Correo", clsCifrado.EncriptarString(persona.Correo));
            parametro[8] = new SqlParameter("@Telefono", persona.Telefono);
            parametro[9] = new SqlParameter("@DNI", persona.Dni);
            parametro[10] = new SqlParameter("@Localidad", clsCifrado.EncriptarString(persona.Localidad));
            parametro[11] = new SqlParameter("@IdRol", persona.Idrol);
            parametro[12] = new SqlParameter("@FechaAlta", persona.Fecha_alta);
            parametro[13] = new SqlParameter("@FechaBaja", SqlDbType.DateTime) { Value = persona.Fecha_baja.HasValue ? (object)persona.Fecha_baja.Value : DBNull.Value };
            parametro[14] = new SqlParameter("@CUIL", persona.Cuil);
            parametro[15] = new SqlParameter("@Usuario", clsCifrado.EncriptarString(usuario.Trim()));
            parametro[16] = new SqlParameter("@Contrasena", clsCifrado.EncriptarString(contrasena));
            parametro[17] = new SqlParameter("@DigitoVerificador", digitoVerificador);
            return acc.Escribir("AgregarPersonaConAcceso", parametro);
        }
        public int AsignarAcceso(int idPersona, int idLogin, int idRol, string usuario, string contrasena, int digitoVerificador)
        {
            SqlParameter[] parametro = {
                new SqlParameter("@IdPersona", idPersona),
                new SqlParameter("@IdLogin", idLogin),
                new SqlParameter("@IdRol", idRol),
                new SqlParameter("@Usuario", clsCifrado.EncriptarString(usuario.Trim())),
                new SqlParameter("@Contrasena", clsCifrado.EncriptarString(contrasena)),
                new SqlParameter("@DigitoVerificador", digitoVerificador)
            };
            return acc.Escribir("AsignarAccesoPersona", parametro);
        }
        public int Editar(BE.cls00_Persona persona)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[15];

            parametro[0] = new SqlParameter("@IdPersona", persona.Idpersona);
            parametro[1] = new SqlParameter("@IdLogin", persona.Idlogin > 0 ? (object)persona.Idlogin : DBNull.Value);
            parametro[2] = new SqlParameter("@Nombre", clsCifrado.EncriptarString(persona.Nombre));
            parametro[3] = new SqlParameter("@Apellido", clsCifrado.EncriptarString(persona.Apellido));
            parametro[4] = new SqlParameter("@FechaNacimiento", persona.Fecha_nacimiento);
            parametro[5] = new SqlParameter("@Genero", clsCifrado.EncriptarString(persona.Genero));
            parametro[6] = new SqlParameter("@Domicilio", clsCifrado.EncriptarString(persona.Domicilio));
            parametro[7] = new SqlParameter("@Correo", clsCifrado.EncriptarString(persona.Correo));
            parametro[8] = new SqlParameter("@Telefono", persona.Telefono);
            parametro[9] = new SqlParameter("@DNI", persona.Dni);
            parametro[10] = new SqlParameter("@Localidad", clsCifrado.EncriptarString(persona.Localidad));
            parametro[11] = new SqlParameter("@IdRol", persona.Idrol > 0 ? (object)persona.Idrol : DBNull.Value);
            parametro[12] = new SqlParameter("@FechaAlta", persona.Fecha_alta);
            parametro[13] = new SqlParameter("@FechaBaja", SqlDbType.DateTime);
            parametro[13].Value = persona.Fecha_baja.HasValue ? (object)persona.Fecha_baja.Value: DBNull.Value;
            parametro[14] = new SqlParameter("@CUIL", persona.Cuil);
            fa = acc.Escribir("EditarPersona", parametro);

            return fa;
        }
        public DataTable Consultar(BE.cls00_Persona persona, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPersona", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdPersona", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                CargarPersona(dr, persona);
            }
            // La tabla se muestra en la grilla: se devuelven los datos descifrados.
            clsCifrado.DescifrarColumnas(tabla, "Nombre", "Apellido", "Genero", "Domicilio", "Correo", "Localidad");
            return tabla;
        }
        public DataTable Consultar2()
        {
            DataTable tabla = acc.LeerConParametro("ListarPersona", null);
            foreach (DataRow dr in tabla.Rows)
            {
                clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                Convert.ToDateTime(dr["FechaNacimiento"].ToString());
                clsCifrado.DesencriptarString(dr["Genero"].ToString());
                clsCifrado.DesencriptarString(dr["Domicilio"].ToString());
                clsCifrado.DesencriptarString(dr["Correo"].ToString());
                int.Parse(dr["Telefono"].ToString());
                int.Parse(dr["DNI"].ToString());
                clsCifrado.DesencriptarString(dr["Localidad"].ToString());
                if (dr["FechaAlta"] != DBNull.Value)
                {
                    Convert.ToDateTime(dr["FechaAlta"]);
                }
                if (dr["FechaBaja"] != DBNull.Value)
                {
                    Convert.ToDateTime(dr["FechaBaja"]);
                }
                double.Parse(dr["CUIL"].ToString());
            }
            return tabla;
        }
        public int Eliminar(BE.cls00_Persona persona)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPersona", persona.Idpersona);
            fa = acc.Escribir("EliminarPersona", parametro);
            return fa;
        }
        public int MaxId(BE.cls00_Persona persona)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdPersona", null);
            foreach (DataRow dr in tabla.Rows)
            {
                persona.Idpersona = int.Parse(dr["IdPersona"].ToString());
            }
            return ls = persona.Idpersona;
        }
        public List<BE.cls00_Persona> Listar()
        {
            List<BE.cls00_Persona> lista = new List<BE.cls00_Persona>();
            DataTable tabla = acc.Leer("ListarPersona", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls00_Persona persona = new BE.cls00_Persona();
                CargarPersona(dr, persona);
                lista.Add(persona);
            }

            return lista;
        }
        public List<BE.cls00_Persona> Listar2()
        {
            List<BE.cls00_Persona> lista = new List<BE.cls00_Persona>();
            DataTable tabla = acc.Leer("ListarPersona", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls00_Persona persona = new BE.cls00_Persona();
                CargarPersona(dr, persona);
                persona.Combo = persona.Nombre + " " + persona.Apellido;
                lista.Add(persona);
            }

            return lista;
        }
    }
}

