using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapPersona
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls00_Persona persona)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[15];

            parametro[0] = new SqlParameter("@IdPersona", persona.Idpersona);
            parametro[1] = new SqlParameter("@IdLogin", persona.Idlogin);
            parametro[2] = new SqlParameter("@Nombre", persona.Nombre);
            parametro[3] = new SqlParameter("@Apellido", persona.Apellido);
            parametro[4] = new SqlParameter("@FechaNacimiento", persona.Fecha_nacimiento);
            parametro[5] = new SqlParameter("@Genero", persona.Genero);
            parametro[6] = new SqlParameter("@Domicilio", persona.Domicilio);
            parametro[7] = new SqlParameter("@Correo", persona.Correo);
            parametro[8] = new SqlParameter("@Telefono", persona.Telefono);
            parametro[9] = new SqlParameter("@DNI", persona.Dni);
            parametro[10] = new SqlParameter("@Localidad", persona.Localidad);
            parametro[11] = new SqlParameter("@IdRol", persona.Idrol);
            parametro[12] = new SqlParameter("@FechaAlta", persona.Fecha_alta);
            parametro[13] = new SqlParameter("@FechaBaja", persona.Fecha_baja);
            parametro[14] = new SqlParameter("@CUIL", persona.Cuil);

            fa = acc.Escribir("AgregarPersona", parametro);

            return fa;
        }
        public int Editar(BE.cls00_Persona persona)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[15];

            parametro[0] = new SqlParameter("@IdPersona", persona.Idpersona);
            parametro[1] = new SqlParameter("@IdLogin", persona.Idlogin);
            parametro[2] = new SqlParameter("@Nombre", persona.Nombre);
            parametro[3] = new SqlParameter("@Apellido", persona.Apellido);
            parametro[4] = new SqlParameter("@FechaNacimiento", persona.Fecha_nacimiento);
            parametro[5] = new SqlParameter("@Genero", persona.Genero);
            parametro[6] = new SqlParameter("@Domicilio", persona.Domicilio);
            parametro[7] = new SqlParameter("@Correo", persona.Correo);
            parametro[8] = new SqlParameter("@Telefono", persona.Telefono);
            parametro[9] = new SqlParameter("@DNI", persona.Dni);
            parametro[10] = new SqlParameter("@Localidad", persona.Localidad);
            parametro[11] = new SqlParameter("@IdRol", persona.Idrol);
            parametro[12] = new SqlParameter("@FechaAlta", persona.Fecha_alta);
            parametro[13] = new SqlParameter("@FechaBaja", persona.Fecha_baja);
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
                persona.Idpersona = int.Parse(dr["IdPersona"].ToString());
                persona.Idlogin = int.Parse( dr["IdLogin"].ToString());
                persona.Nombre = dr["Nombre"].ToString();
                persona.Apellido = dr["Apellido"].ToString();
                persona.Fecha_nacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                persona.Genero = (dr["Genero"].ToString());
                persona.Domicilio = (dr["Domicilio"].ToString());
                persona.Correo = dr["Correo"].ToString();
                persona.Telefono = int.Parse(dr["Telefono"].ToString());
                persona.Dni = int.Parse(dr["DNI"].ToString());
                persona.Localidad = dr["Localidad"].ToString();
                persona.Idrol = int.Parse(dr["IdRol"].ToString());
                persona.Fecha_alta = DateTime.Parse(dr["FechaAlta"].ToString());
                persona.Fecha_baja = DateTime.Parse(dr["FechaBaja"].ToString());
                persona.Cuil = double.Parse(dr["CUIL"].ToString());
                persona.DigitoVerificador = int.Parse(dr["DigitoVerificador"].ToString());
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
            DataTable tabla = acc.Leer("MAXIdIdPersona", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                persona.Idpersona = int.Parse(dr["IdPersona"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = persona.Idpersona;
        }
        public List<BE.cls00_Persona> Listar2()
        {
            List<BE.cls00_Persona> ls = new List<BE.cls00_Persona>();
            DataTable tabla = acc.Leer("ListarPersona", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls00_Persona persona = new BE.cls00_Persona();
                persona.Idpersona = int.Parse(dr["IdPersona"].ToString());
                persona.Idlogin = int.Parse(dr["IdLogin"].ToString());
                persona.Nombre = dr["Nombre"].ToString();
                persona.Apellido = dr["Apellido"].ToString();
                persona.Dni = int.Parse(dr["DNI"].ToString());
                persona.Combo = "(DNI: " + persona.Idpersona + ") " + persona.Nombre + " " + persona.Apellido;
                ls.Add(persona);
            }
            return ls;
        }       
        public List<BE.cls00_Persona> Listar()
        {
            List<BE.cls00_Persona> ls = new List<BE.cls00_Persona>();

            DataTable tabla = acc.Leer("ListarPersona", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls00_Persona persona = new BE.cls00_Persona();

                persona.Idpersona = int.Parse(dr["IdPersona"].ToString());
                persona.Idlogin = int.Parse(dr["IdLogin"].ToString());
                persona.Nombre = dr["Nombre"].ToString();
                persona.Apellido = dr["Apellido"].ToString();
                persona.Fecha_nacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                persona.Genero = dr["Genero"].ToString();
                persona.Domicilio = dr["Domicilio"].ToString();
                persona.Correo = dr["Correo"].ToString();
                persona.Telefono = int.Parse(dr["Telefono"].ToString());
                persona.Dni = int.Parse(dr["DNI"].ToString());
                persona.Localidad = dr["Localidad"].ToString();
                persona.Idrol = int.Parse(dr["IdRol"].ToString());
                persona.Fecha_alta = DateTime.Parse(dr["FechaAlta"].ToString());

                if (dr["FechaBaja"] != DBNull.Value)
                    persona.Fecha_baja = DateTime.Parse(dr["FechaBaja"].ToString());

                persona.Cuil = double.Parse(dr["CUIL"].ToString());

                ls.Add(persona);
            }

            return ls;
        }
    }
}

