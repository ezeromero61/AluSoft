using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapCompras
    {
        clsAcceso acc = new clsAcceso();

        public int Agregar(BE.cls17_Compras compra)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[5];

            parametro[0] = new SqlParameter("@IdStock", compra.Idstock);
            parametro[1] = new SqlParameter("@Cantidad", compra.Cantidad);
            parametro[2] = new SqlParameter("@Fecha", compra.Fecha);
            parametro[3] = new SqlParameter("@Subtotal", compra.Subtotal);
            parametro[4] = new SqlParameter("@Total", compra.Total);

            fa = acc.Escribir("AgregarCompras", parametro);

            return fa;
        }

        public int Editar(BE.cls17_Compras compra)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[6];

            parametro[0] = new SqlParameter("@IdCompras", compra.Idcompras);
            parametro[1] = new SqlParameter("@IdStock", compra.Idstock);
            parametro[2] = new SqlParameter("@Cantidad", compra.Cantidad);
            parametro[3] = new SqlParameter("@Fecha", compra.Fecha);
            parametro[4] = new SqlParameter("@Subtotal", compra.Subtotal);
            parametro[5] = new SqlParameter("@Total", compra.Total);

            fa = acc.Escribir("EditarCompras", parametro);

            return fa;
        }

        public int Eliminar(BE.cls17_Compras compra)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdCompras", compra.Idcompras);

            fa = acc.Escribir("EliminarCompras", parametro);

            return fa;
        }

        public int MaxId(BE.cls17_Compras compra)
        {
            int ls = 0;

            DataTable tabla = acc.Leer("MAXIdCompras", null);

            foreach (DataRow dr in tabla.Rows)
            {
                compra.Idcompras = int.Parse(dr["IdCompras"].ToString());
            }

            return ls = compra.Idcompras;
        }

        public List<BE.cls17_Compras> Listar()
        {
            List<BE.cls17_Compras> ls = new List<BE.cls17_Compras>();

            DataTable tabla = acc.Leer("ListarCompras", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls17_Compras compra = new BE.cls17_Compras();

                compra.Idcompras = int.Parse(dr["IdCompras"].ToString());
                compra.Idstock = int.Parse(dr["IdStock"].ToString());
                compra.Cantidad = int.Parse(dr["Cantidad"].ToString());
                compra.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                compra.Subtotal = int.Parse(dr["Subtotal"].ToString());
                compra.Total = int.Parse(dr["Total"].ToString());

                ls.Add(compra);
            }

            return ls;
        }

        public DataTable Consultar(BE.cls17_Compras compra, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdCompras", id);

            DataTable tabla = acc.LeerConParametro(
                "BusquedaConIdCompras",
                parametro
            );

            foreach (DataRow dr in tabla.Rows)
            {
                compra.Idcompras = int.Parse(dr["IdCompras"].ToString());
                compra.Idstock = int.Parse(dr["IdStock"].ToString());
                compra.Cantidad = int.Parse(dr["Cantidad"].ToString());
                compra.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                compra.Subtotal = int.Parse(dr["Subtotal"].ToString());
                compra.Total = int.Parse(dr["Total"].ToString());
            }

            return tabla;
        }
    }
}
