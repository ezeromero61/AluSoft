using BE;
using DocumentFormat.OpenXml.Office2010.Excel;
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
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
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
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                cliente.Apellido = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                cliente.Combo =  cliente.Nombre + " " + cliente.Apellido;
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
                cliente.Idpersona = int.Parse(dr["IdPersona"].ToString());
                cliente.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                cliente.Apellido =clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                cliente.Combo =   cliente.Nombre + " " + cliente.Apellido;
                ls.Add(cliente);
            }
            return ls;
        }
        public List<BE.cls03_Cliente> Listar3(BE.cls03_Cliente cliente, int id)
        {
            List<BE.cls03_Cliente> ls = new List<BE.cls03_Cliente>();
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPersona", id);
            DataTable tabla = acc.LeerConParametro("BusquedaIdPersonaIdCliente", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Idpersona = int.Parse(dr["IdPersona"].ToString());
                cliente.Idlogin = dr["IdLogin"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdLogin"]); // [CORREGIDO] los clientes no tienen usuario (IdLogin vacío)
                cliente.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                cliente.Apellido = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                cliente.Fecha_nacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                cliente.Genero = clsCifrado.DesencriptarString(dr["Genero"].ToString());
                cliente.Domicilio = clsCifrado.DesencriptarString(dr["Domicilio"].ToString());
                cliente.Correo = clsCifrado.DesencriptarString(dr["Correo"].ToString());
                cliente.Telefono = double.Parse(dr["Telefono"].ToString());
                cliente.Dni = double.Parse(dr["DNI"].ToString());
                cliente.Localidad = clsCifrado.DesencriptarString(dr["Localidad"].ToString());
                cliente.Idrol = dr["IdRol"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdRol"]);
                cliente.Fecha_alta = DateTime.Parse(dr["FechaAlta"].ToString());
                if (dr["FechaBaja"] != DBNull.Value)
                    cliente.Fecha_baja = DateTime.Parse(dr["FechaBaja"].ToString());
                cliente.Cuil = double.Parse(dr["CUIL"].ToString());
                cliente.Combo = cliente.Nombre + " " + cliente.Apellido;
                ls.Add(cliente);
            }
            return ls;
        }
        public List<BE.cls03_Cliente> ListarIdClienteNombreApellido()
        {
            List<BE.cls03_Cliente> ls = new List<BE.cls03_Cliente>();
            DataTable tabla = acc.Leer("Obtener_03_IdClienteNombreApellido", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls03_Cliente cliente = new BE.cls03_Cliente();
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                cliente.Apellido = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                string combo=  cliente.Nombre + " " + cliente.Apellido;
                ls.Add(cliente);
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
                cliente.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                cliente.Apellido = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                cliente.Combo= cliente.Nombre + " " + cliente.Apellido;
                ls.Add(cliente);
            }
            return ls;
        }
        // [NUEVO] Igual que ConsultarIdPersonaIdCliente pero buscando por IdCliente. Factura y Venta
        // guardan el IdCliente; antes se lo pasaban a la búsqueda por IdPersona y salía otro cliente.
        public DataTable ConsultarPorIdCliente(BE.cls03_Cliente cliente, int idCliente)
        {
            SqlParameter[] parametro = { new SqlParameter("@IdCliente", idCliente) };
            return CompletarCombo(cliente, acc.LeerConParametro("BusquedaClientePorIdCliente", parametro));
        }
        public DataTable ConsultarIdPersonaIdCliente(BE.cls03_Cliente cliente, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPersona", id);
            return CompletarCombo(cliente, acc.LeerConParametro("BusquedaIdPersonaIdCliente", parametro));
        }
        private DataTable CompletarCombo(BE.cls03_Cliente cliente, DataTable tabla)
        {
            if (!tabla.Columns.Contains("Combo"))
            {
                tabla.Columns.Add("Combo", typeof(string));
            }
            foreach (DataRow dr in tabla.Rows)
            {
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Idpersona = int.Parse(dr["IdPersona"].ToString());
                cliente.Idlogin = dr["IdLogin"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdLogin"]); // [CORREGIDO] los clientes no tienen usuario (IdLogin vacío)
                cliente.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                cliente.Apellido = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                cliente.Fecha_nacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                cliente.Genero = clsCifrado.DesencriptarString(dr["Genero"].ToString());
                cliente.Domicilio = clsCifrado.DesencriptarString(dr["Domicilio"].ToString());
                cliente.Correo = clsCifrado.DesencriptarString(dr["Correo"].ToString());
                cliente.Telefono = double.Parse(dr["Telefono"].ToString());
                cliente.Dni = double.Parse(dr["DNI"].ToString());
                cliente.Localidad = clsCifrado.DesencriptarString(dr["Localidad"].ToString());
                cliente.Idrol = dr["IdRol"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdRol"]);
                cliente.Fecha_alta = DateTime.Parse(dr["FechaAlta"].ToString());
                if (dr["FechaBaja"] != DBNull.Value)
                cliente.Fecha_baja = DateTime.Parse(dr["FechaBaja"].ToString());
                cliente.Cuil = double.Parse(dr["CUIL"].ToString());
                dr["Combo"]= cliente.Nombre + " " + cliente.Apellido;
                cliente.Combo = dr["Combo"].ToString();
            }
            // La tabla se muestra en la grilla: se devuelven los datos descifrados.
            clsCifrado.DescifrarColumnas(tabla, "Nombre", "Apellido", "Genero", "Domicilio", "Correo", "Localidad");
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
                cliente.Idlogin = dr["IdLogin"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdLogin"]); // [CORREGIDO] los clientes no tienen usuario (IdLogin vacío)
                cliente.Idrol = dr["IdRol"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdRol"]);
            }
            return tabla;
        }
    }
}
