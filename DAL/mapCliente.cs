using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapCliente
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls03_Cliente cliente) 
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[2];

            parametro[0] = new SqlParameter("@IdCliente", cliente.Idcliente);
            parametro[1] = new SqlParameter("@IdPersona", cliente.Idpersona);

            fa = acc.Escribir("AgregarCliente", parametro);
            return fa;
        }

        public int Editar(BE.cls03_Cliente cliente)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[2];

            parametro[0] = new SqlParameter("@IdCliente", cliente.Idcliente);
            parametro[1] = new SqlParameter("@IdPersona", cliente.Idpersona);

            fa = acc.Escribir("EditarCliente", parametro);
            return fa;
        }

        public int Eliminar(BE.cls03_Cliente cliente)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdCliente", cliente.Idcliente);

            fa = acc.Escribir("EliminarCliente", parametro);
            return fa;
        }
        public int MaxId(BE.cls03_Cliente cliente)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdCliente", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = cliente.Idcliente;
        }

        public List<BE.cls03_Cliente> Listar()
        {
            List<BE.cls03_Cliente> ls = new List<BE.cls03_Cliente>();

            DataTable tabla = acc.Leer("Obtener_03_IdClienteNombreApellido", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls03_Cliente cliente = new BE.cls03_Cliente();

                //cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                //cliente.Idpersona = int.Parse(dr["IdPersona"].ToString());
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Nombre = (dr["Nombre"].ToString());
                cliente.Apellido = (dr["Apellido"].ToString());
                cliente.Combo = "(ID: " + cliente.Idcliente + ") " + cliente.Nombre + " " + cliente.Apellido;
                ls.Add(cliente);
            }

            return ls;
        }
        public List<BE.cls03_Cliente> Listar2()
        {
            List<BE.cls03_Cliente> ls = new List<BE.cls03_Cliente>();
            DataTable tabla = acc.Leer("Obtener_03_IdClienteNombreApellido", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls03_Cliente cliente = new BE.cls03_Cliente();
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Nombre = (dr["Nombre"].ToString());
                cliente.Apellido = (dr["Apellido"].ToString());
                cliente.Combo = "(ID: " + cliente.Idcliente + ") " + cliente.Nombre + " " + cliente.Apellido;
                ls.Add(cliente);
            }
            return ls;
        }
        public List<string> ListarIdNombreApellido()
        {
            List<string> ls = new List<string>();
            DataTable tabla = acc.Leer("Obtener_03_IdClienteNombreApellido", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls03_Cliente cliente = new BE.cls03_Cliente();
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Nombre = (dr["Nombre"].ToString());
                cliente.Apellido = (dr["Apellido"].ToString());
                string combo= "(ID: "+cliente.Idcliente +") " + cliente.Nombre + " " + cliente.Apellido;
                ls.Add(combo);
            }
            return ls;
        }
        public List<cls00_Persona> ListarIdPersonaNombreApellido()
        {
            List<cls00_Persona> ls = new List<cls00_Persona>();
            DataTable tabla = acc.Leer("ListarPersona", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls00_Persona cliente = new BE.cls00_Persona();
                cliente.Idpersona = int.Parse(dr["IdPersona"].ToString());
                cliente.Nombre = (dr["Nombre"].ToString());
                cliente.Apellido = (dr["Apellido"].ToString());
                cliente.Combo= "(ID: " + cliente.Idpersona + ") " + cliente.Nombre + " " + cliente.Apellido;
                ls.Add(cliente);
            }
            return ls;
        }
        public DataTable ConsultarIdPersonaIdCliente(BE.cls03_Cliente cliente, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPersona", id);
            DataTable tabla = acc.LeerConParametro("BusquedaIdPersonaIdCliente", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());

                cliente.Idpersona = int.Parse(dr["IdPersona"].ToString());
                cliente.Idlogin = int.Parse(dr["IdLogin"].ToString());
                cliente.Nombre = dr["Nombre"].ToString();
                cliente.Apellido = dr["Apellido"].ToString();
                cliente.Fecha_nacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                cliente.Genero = dr["Genero"].ToString();
                cliente.Domicilio = dr["Domicilio"].ToString();
                cliente.Correo = dr["Correo"].ToString();
                cliente.Telefono = int.Parse(dr["Telefono"].ToString());
                cliente.Dni = int.Parse(dr["DNI"].ToString());
                cliente.Localidad = dr["Localidad"].ToString();
                cliente.Idrol = int.Parse(dr["IdRol"].ToString());
                cliente.Fecha_alta = DateTime.Parse(dr["FechaAlta"].ToString());
                if (dr["FechaBaja"] != DBNull.Value)
                    cliente.Fecha_baja = DateTime.Parse(dr["FechaBaja"].ToString());
                cliente.Cuil = double.Parse(dr["CUIL"].ToString());
            }
            return tabla;
        }
        public DataTable ConsultarIdUsuario(BE.cls03_Cliente cliente, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPersona", id);
            DataTable tabla = acc.LeerConParametro("BusquedaIdClienteConIdPersona", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Idlogin = int.Parse(dr["IdLogin"].ToString());
                cliente.Idrol = int.Parse(dr["IdRol"].ToString());
            }
            return tabla;
        }
    }
}
