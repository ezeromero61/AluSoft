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
            SqlParameter[] parametro = new SqlParameter[8];
            parametro[0] = new SqlParameter("@IdCompras", compra.Idcompras);
            parametro[1] = new SqlParameter("@IdStock", compra.Idstock);
            parametro[2] = new SqlParameter("@Cantidad", compra.Cantidad);
            parametro[3] = new SqlParameter("@Fecha", compra.Fecha);
            parametro[4] = new SqlParameter("@Subtotal", compra.Subtotal);
            parametro[5] = new SqlParameter("@Total", compra.Total);
            parametro[6] = new SqlParameter("@IdProveedor", compra.IdProveedor > 0 ? (object)compra.IdProveedor : DBNull.Value);
            parametro[7] = new SqlParameter("@IdPedidoReaprovisionamiento", compra.IdPedidoReaprovisionamiento > 0 ? (object)compra.IdPedidoReaprovisionamiento : DBNull.Value);
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

        public DataTable Consultar(BE.cls17_Compras compras, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdCompras", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdComprasCombinado", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                compras.Idcompras = int.Parse(dr["IdCompras"].ToString());
                compras.Idstock = int.Parse(dr["IdStock"].ToString());
                compras.Cantidad = int.Parse(dr["Cantidad"].ToString());
                compras.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                compras.Subtotal = int.Parse(dr["Subtotal"].ToString());
                compras.Total = int.Parse(dr["Total"].ToString());
            }
            return tabla;
        }
        public List<BE.cls17_Compras> Listar2()
        {
            List<BE.cls17_Compras> ls = new List<BE.cls17_Compras>();
            DataTable tabla = acc.Leer("Obtener_17_ComprasCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls17_Compras compras = new BE.cls17_Compras();
                compras.Idcompras = int.Parse(dr["Idcompras"].ToString());
                compras.Idstock = int.Parse(dr["IdStock"].ToString());
                compras.Nombre = (dr["Nombre"].ToString());
                compras.Cantidad = int.Parse(dr["Cantidad"].ToString());
                compras.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                compras.Subtotal = int.Parse(dr["Subtotal"].ToString());
                compras.Total = int.Parse(dr["Total"].ToString());
                if (tabla.Columns.Contains("IdProveedor") && dr["IdProveedor"] != DBNull.Value)
                    compras.IdProveedor = Convert.ToInt32(dr["IdProveedor"]);
                if (tabla.Columns.Contains("NombreEmpresa"))
                    compras.NombreEmpresa = dr["NombreEmpresa"].ToString();
                if (tabla.Columns.Contains("IdPedidoReaprovisionamiento") && dr["IdPedidoReaprovisionamiento"] != DBNull.Value)
                    compras.IdPedidoReaprovisionamiento = Convert.ToInt32(dr["IdPedidoReaprovisionamiento"]);
                if (tabla.Columns.Contains("Pagado") && dr["Pagado"] != DBNull.Value)
                    compras.Pagado = Convert.ToDecimal(dr["Pagado"]);
                compras.Combo = "N° " + compras.Idcompras + (string.IsNullOrWhiteSpace(compras.NombreEmpresa) ? "" : " - " + compras.NombreEmpresa) + " - " + compras.Nombre + " - $" + compras.Total;
                ls.Add(compras);
            }
            return ls;
        }
    }
}
