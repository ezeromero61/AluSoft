using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapOrdenProduccion
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls14_OrdenProduccion orden)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[6];
            parametro[0] = new SqlParameter("@IdOrdenProduccion", orden.Idordenproduccion);
            parametro[1] = new SqlParameter("@FechaOrden", orden.Fechaorden);
            parametro[2] = new SqlParameter("@IdStock", orden.Idstock);
            parametro[3] = new SqlParameter("@Cantidad", orden.Cantidad);
            parametro[4] = new SqlParameter("@Observaciones", orden.Observaciones);
            parametro[5] = new SqlParameter("@IdPedido", orden.IdPedido > 0 ? (object)orden.IdPedido : DBNull.Value);
            fa = acc.Escribir("AgregarOrdenProduccion", parametro);
            return fa;
        }
        public int Editar(BE.cls14_OrdenProduccion orden)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[5];
            parametro[0] = new SqlParameter("@IdOrdenProduccion", orden.Idordenproduccion);
            parametro[1] = new SqlParameter("@FechaOrden", orden.Fechaorden);
            parametro[2] = new SqlParameter("@IdStock", orden.Idstock);
            parametro[3] = new SqlParameter("@Cantidad", orden.Cantidad);
            parametro[4] = new SqlParameter("@Observaciones", orden.Observaciones);
            fa = acc.Escribir("EditarOrdenProduccion", parametro);

            return fa;
        }
        // La orden se cubre con el stock que ya había: al terminarla no se vuelve a sumar al stock.
        public int UsarStock(int idOrden, int idStock)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdOrdenProduccion", idOrden);
            parametro[1] = new SqlParameter("@IdStock", idStock);
            return acc.Escribir("UsarStockEnOrden", parametro);
        }
        public int Eliminar(BE.cls14_OrdenProduccion orden)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdOrdenProduccion", orden.Idordenproduccion);

            fa = acc.Escribir("EliminarOrdenProduccion", parametro);

            return fa;
        }
        public int MaxId(BE.cls14_OrdenProduccion orden)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdOrdenProduccion", null);
            foreach (DataRow dr in tabla.Rows)
            {
                orden.Idordenproduccion = int.Parse(dr["IdOrdenProduccion"].ToString());
            }
            return ls = orden.Idordenproduccion
                ;
        }
        public List<BE.cls14_OrdenProduccion> Listar()
        {
            List<BE.cls14_OrdenProduccion> ls = new List<BE.cls14_OrdenProduccion>();
            DataTable tabla = acc.Leer("ListarOrdenProduccion", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls14_OrdenProduccion orden = new BE.cls14_OrdenProduccion();
                orden.Idordenproduccion = int.Parse(dr["IdOrdenProduccion"].ToString());
                orden.Fechaorden = DateTime.Parse(dr["FechaOrden"].ToString());
                orden.Idstock = int.Parse(dr["IdStock"].ToString());
                orden.Cantidad = int.Parse(dr["Cantidad"].ToString());
                orden.Observaciones = dr["Observaciones"].ToString();
                ls.Add(orden);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls14_OrdenProduccion orden, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdOrdenProduccion", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdOrdenProduccionCombinado", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                orden.Idordenproduccion = int.Parse(dr["IdOrdenProduccion"].ToString());
                orden.Fechaorden = DateTime.Parse(dr["FechaOrden"].ToString());
                orden.Idstock = int.Parse(dr["IdStock"].ToString());
                orden.Nombre = dr["Nombre"].ToString();
                orden.Cantidad = int.Parse(dr["Cantidad"].ToString());
                orden.Observaciones = (dr["Observaciones"].ToString());
                if (tabla.Columns.Contains("IdPedido") && dr["IdPedido"] != DBNull.Value)
                    orden.IdPedido = Convert.ToInt32(dr["IdPedido"]);
            }
            return tabla;
        }              
        public List<BE.cls14_OrdenProduccion> Listar2()
        {
            List<BE.cls14_OrdenProduccion> ls = new List<BE.cls14_OrdenProduccion>();
            DataTable tabla = acc.Leer("Obtener_14_IdOrdenProduccionCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls14_OrdenProduccion orden = new BE.cls14_OrdenProduccion();
                orden.Idordenproduccion = int.Parse(dr["IdOrdenProduccion"].ToString());
                orden.Fechaorden = DateTime.Parse(dr["FechaOrden"].ToString());
                orden.Idstock = int.Parse(dr["IdStock"].ToString());
                orden.Nombre = (dr["Nombre"].ToString());
                orden.Cantidad = int.Parse(dr["Cantidad"].ToString());
                orden.Observaciones = (dr["Observaciones"].ToString());
                if (tabla.Columns.Contains("IdPedido") && dr["IdPedido"] != DBNull.Value)
                orden.IdPedido = int.Parse(dr["IdPedido"].ToString());
                orden.Combo = "N° " + orden.Idordenproduccion + " - " + orden.Nombre + " x" + orden.Cantidad+ (orden.IdPedido > 0 ? " (pedido " + orden.IdPedido + ")" : "");
                ls.Add(orden);
            }
            return ls;
        }
    }
}

