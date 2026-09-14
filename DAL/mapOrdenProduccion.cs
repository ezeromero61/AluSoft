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
            parametro[5] = new SqlParameter("@IdLogin", orden.Idlogin);

            fa = acc.Escribir("AgregarOrdenProduccion", parametro);

            return fa;
        }

        public int Editar(BE.cls14_OrdenProduccion orden)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[6];

            parametro[0] = new SqlParameter("@IdOrdenProduccion", orden.Idordenproduccion);
            parametro[1] = new SqlParameter("@FechaOrden", orden.Fechaorden);
            parametro[2] = new SqlParameter("@IdStock", orden.Idstock);
            parametro[3] = new SqlParameter("@Cantidad", orden.Cantidad);
            parametro[4] = new SqlParameter("@Observaciones", orden.Observaciones);
            parametro[5] = new SqlParameter("@IdLogin", orden.Idlogin);

            fa = acc.Escribir("EditarOrdenProduccion", parametro);

            return fa;
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
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                orden.Idordenproduccion = int.Parse(dr["IdOrdenProduccion"].ToString());
                //ls=(inventario.Idinventario);
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
                orden.Idlogin = int.Parse(dr["IdLogin"].ToString());

                ls.Add(orden);
            }

            return ls;
        }
    }
}

