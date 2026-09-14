using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapReportes
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls22_Reportes reporte)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[6];

            parametro[0] = new SqlParameter("@IdReporte", reporte.Idreporte);
            parametro[1] = new SqlParameter("@IdLogin", reporte.Idlogin);
            parametro[2] = new SqlParameter("@IdVenta", reporte.Idventa);
            parametro[3] = new SqlParameter("@IdCompras", reporte.Idcompras);
            parametro[4] = new SqlParameter("@IdProduccion", reporte.Idproduccion);
            parametro[5] = new SqlParameter("@Fecha", reporte.Fecha);

            fa = acc.Escribir("AgregarReporte", parametro);

            return fa;
        }

        public int Editar(BE.cls22_Reportes reporte)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[6];

            parametro[0] = new SqlParameter("@IdReporte", reporte.Idreporte);
            parametro[1] = new SqlParameter("@IdLogin", reporte.Idlogin);
            parametro[2] = new SqlParameter("@IdVenta", reporte.Idventa);
            parametro[3] = new SqlParameter("@IdCompras", reporte.Idcompras);
            parametro[4] = new SqlParameter("@IdProduccion", reporte.Idproduccion);
            parametro[5] = new SqlParameter("@Fecha", reporte.Fecha);

            fa = acc.Escribir("EditarReporte", parametro);

            return fa;
        }

        public int Eliminar(BE.cls22_Reportes reporte)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdReporte", reporte.Idreporte);

            fa = acc.Escribir("EliminarReporte", parametro);

            return fa;
        }
        public int MaxId(BE.cls22_Reportes reporte)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdReporte", null);
            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                reporte.Idreporte = int.Parse(dr["IdReporte"].ToString());
                //ls=(inventario.Idinventario);
            }
            return ls = reporte.Idreporte;
        }
        public List<BE.cls22_Reportes> Listar()
        {
            List<BE.cls22_Reportes> ls = new List<BE.cls22_Reportes>();

            DataTable tabla = acc.Leer("ListarReporte", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls22_Reportes reporte = new BE.cls22_Reportes();

                reporte.Idreporte = int.Parse(dr["IdReporte"].ToString());
                reporte.Idlogin = int.Parse(dr["IdLogin"].ToString());
                reporte.Idventa = int.Parse(dr["IdVenta"].ToString());
                reporte.Idcompras = int.Parse(dr["IdCompras"].ToString());
                reporte.Idproduccion = int.Parse(dr["IdProduccion"].ToString());
                reporte.Fecha = Convert.ToDateTime(dr["Fecha"]);

                ls.Add(reporte);
            }

            return ls;
        }
    }
}

