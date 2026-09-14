using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapPresupuestoCliente
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[15];

            parametro[0] = new SqlParameter("@IdPresupuesto", presupuesto.Idpresupuesto);
            parametro[1] = new SqlParameter("@IdCliente", presupuesto.Idcliente);
            parametro[2] = new SqlParameter("@IdCatalogo", presupuesto.Idcatalogo);
            parametro[3] = new SqlParameter("@FechaCreacion", presupuesto.FechaCreacion);
            parametro[4] = new SqlParameter("@FechaValidez", presupuesto.FechaValidez);
            parametro[5] = new SqlParameter("@Estado", presupuesto.Estado);
            parametro[6] = new SqlParameter("@Descripcion", presupuesto.Descripcion);
            parametro[7] = new SqlParameter("@Observaciones", presupuesto.Observaciones);
            parametro[8] = new SqlParameter("@Subtotal", presupuesto.Subtotal);
            parametro[9] = new SqlParameter("@Descuento", presupuesto.Descuento);
            parametro[10] = new SqlParameter("@Impuestos", presupuesto.Impuestos);
            parametro[11] = new SqlParameter("@Total", presupuesto.Total);
            parametro[12] = new SqlParameter("@FormaPago", presupuesto.FormaPago);
            parametro[13] = new SqlParameter("@PlazoEntregaDias", presupuesto.PlazoEntregaDias);
            parametro[14] = new SqlParameter("@IdLogin", presupuesto.Idlogin);

            fa = acc.Escribir("AgregarPresupuestoCliente", parametro);

            return fa;
        }
        public int Editar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[15];

            parametro[0] = new SqlParameter("@IdPresupuesto", presupuesto.Idpresupuesto);
            parametro[1] = new SqlParameter("@IdCliente", presupuesto.Idcliente);
            parametro[2] = new SqlParameter("@IdCatalogo", presupuesto.Idcatalogo);
            parametro[3] = new SqlParameter("@FechaCreacion", presupuesto.FechaCreacion);
            parametro[4] = new SqlParameter("@FechaValidez", presupuesto.FechaValidez);
            parametro[5] = new SqlParameter("@Estado", presupuesto.Estado);
            parametro[6] = new SqlParameter("@Descripcion", presupuesto.Descripcion);
            parametro[7] = new SqlParameter("@Observaciones", presupuesto.Observaciones);
            parametro[8] = new SqlParameter("@Subtotal", presupuesto.Subtotal);
            parametro[9] = new SqlParameter("@Descuento", presupuesto.Descuento);
            parametro[10] = new SqlParameter("@Impuestos", presupuesto.Impuestos);
            parametro[11] = new SqlParameter("@Total", presupuesto.Total);
            parametro[12] = new SqlParameter("@FormaPago", presupuesto.FormaPago);
            parametro[13] = new SqlParameter("@PlazoEntregaDias", presupuesto.PlazoEntregaDias);
            parametro[14] = new SqlParameter("@IdLogin", presupuesto.Idlogin);

            fa = acc.Escribir("EditarPresupuestoCliente", parametro);

            return fa;
        }
        public int Eliminar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdPresupuesto", presupuesto.Idpresupuesto);

            fa = acc.Escribir("EliminarPresupuestoCliente", parametro);

            return fa;
        }
        public int MaxId(BE.cls07_PresupuestoCliente presupuesto)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdPresupuesto", null);
            foreach (DataRow dr in tabla.Rows)
            {
                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
            }
            return ls = presupuesto.Idpresupuesto;
        }
        public List<BE.cls26_Combinado> Listar2()
        {
            List<BE.cls26_Combinado> ls = new List<BE.cls26_Combinado>();

            DataTable tabla = acc.Leer("Obtener_07_IdPresupuestoClienteCombinado", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls26_Combinado presupuesto = new BE.cls26_Combinado();

                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                presupuesto.Idcliente = int.Parse(dr["IdCliente"].ToString());
                presupuesto.Nombre = dr["Nombre"].ToString();
                presupuesto.Apellido = dr["Apellido"].ToString();
                presupuesto.IdCatalogo = int.Parse(dr["IdCatalogo"].ToString());
                presupuesto.Producto = dr["NombreInventario"].ToString();
                presupuesto.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                presupuesto.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Estado = dr["Estado"].ToString();
                presupuesto.Descripcion = dr["Descripcion"].ToString();
                presupuesto.Observaciones = dr["Observaciones"].ToString();
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Descuento = int.Parse(dr["Descuento"].ToString());
                presupuesto.Impuestos = int.Parse(dr["Impuestos"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.FormaPago = dr["FormaPago"].ToString();
                presupuesto.PlazoEntregaDias = int.Parse(dr["PlazoEntregaDias"].ToString());
                presupuesto.Idlogin = int.Parse(dr["IdLogin"].ToString());
                presupuesto.Combo = "(ID: " + presupuesto.Idpresupuesto + ") " + presupuesto.Nombre+" " + presupuesto.Producto;
                ls.Add(presupuesto);
            }

            return ls;
        }
        public List<BE.cls07_PresupuestoCliente> Listar()
        {
            List<BE.cls07_PresupuestoCliente> ls = new List<BE.cls07_PresupuestoCliente>();

            DataTable tabla = acc.Leer("ListarPresupuestoCliente", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls07_PresupuestoCliente presupuesto = new BE.cls07_PresupuestoCliente();

                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                presupuesto.Idcliente = int.Parse(dr["IdCliente"].ToString());
                presupuesto.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                presupuesto.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                presupuesto.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Estado = dr["Estado"].ToString();
                presupuesto.Descripcion = dr["Descripcion"].ToString();
                presupuesto.Observaciones = dr["Observaciones"].ToString();
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Descuento = int.Parse(dr["Descuento"].ToString());
                presupuesto.Impuestos = int.Parse(dr["Impuestos"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.FormaPago = dr["FormaPago"].ToString();
                presupuesto.PlazoEntregaDias = int.Parse(dr["PlazoEntregaDias"].ToString());
                presupuesto.Idlogin = int.Parse(dr["IdLogin"].ToString());

                ls.Add(presupuesto);
            }

            return ls;
        }
        public DataTable Consultar(BE.cls07_PresupuestoCliente presupuesto, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPresupuesto", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdPresupuestoCliente", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                presupuesto.Idcliente = int.Parse(dr["IdCliente"].ToString());
                presupuesto.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                presupuesto.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                presupuesto.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Estado = dr["Estado"].ToString();
                presupuesto.Descripcion = dr["Descripcion"].ToString();
                presupuesto.Observaciones = dr["Observaciones"].ToString();
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Descuento = int.Parse(dr["Descuento"].ToString());
                presupuesto.Impuestos = int.Parse(dr["Impuestos"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.FormaPago = dr["FormaPago"].ToString();
                presupuesto.PlazoEntregaDias = int.Parse(dr["PlazoEntregaDias"].ToString());
                presupuesto.Idlogin = int.Parse(dr["IdLogin"].ToString());
            }
            return tabla;
        }
        public DataTable Consultar2(BE.cls26_Combinado presupuesto, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPresupuesto", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdPresupuestoClienteCombinado", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                presupuesto.Idcliente = int.Parse(dr["IdCliente"].ToString());
                presupuesto.Nombre = dr["Nombre"].ToString();
                presupuesto.Apellido = dr["Apellido"].ToString();
                presupuesto.IdCatalogo = int.Parse(dr["IdCatalogo"].ToString());
                presupuesto.Producto = dr["NombreInventario"].ToString();
                presupuesto.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                presupuesto.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Estado = dr["Estado"].ToString();
                presupuesto.Descripcion = dr["Descripcion"].ToString();
                presupuesto.Observaciones = dr["Observaciones"].ToString();
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Descuento = int.Parse(dr["Descuento"].ToString());
                presupuesto.Impuestos = int.Parse(dr["Impuestos"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.FormaPago = dr["FormaPago"].ToString();
                presupuesto.PlazoEntregaDias = int.Parse(dr["PlazoEntregaDias"].ToString());
                presupuesto.Idlogin = int.Parse(dr["IdLogin"].ToString());
                presupuesto.Combo = "(ID: " + presupuesto.Idpresupuesto + ") " + presupuesto.Nombre + " " + presupuesto.Producto;

            }
            return tabla;
        }
        public List<string> ListarCombo()
        {
            List<string> ls = new List<string>();
            DataTable tabla = acc.Leer("BusquedaConIdPresupuestoClienteCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls03_Cliente cliente = new BE.cls03_Cliente();
                cliente.Idcliente = int.Parse(dr["IdCliente"].ToString());
                cliente.Nombre = (dr["Nombre"].ToString());
                cliente.Apellido = (dr["Apellido"].ToString());
                string combo = "(ID: " + cliente.Idcliente + ") " + cliente.Nombre + " " + cliente.Apellido;
                ls.Add(combo);
            }
            return ls;
        }
    }
}

