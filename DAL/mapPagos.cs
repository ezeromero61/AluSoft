using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapPagos
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls24_Pagos pago)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[9];
            parametro[0] = new SqlParameter("@IdPago", pago.IdPago);
            parametro[1] = new SqlParameter("@IdProveedor", pago.IdProveedor);
            parametro[2] = new SqlParameter("@IdCompras", pago.IdCompras);
            parametro[3] = new SqlParameter("@FechaPago", pago.FechaPago);
            parametro[4] = new SqlParameter("@Importe", pago.Importe);
            parametro[5] = new SqlParameter("@FormaPago", pago.FormaPago);
            parametro[6] = new SqlParameter("@Observaciones", pago.Observaciones);
            parametro[7] = new SqlParameter("@NumeroComprobante", (object)pago.NumeroComprobante ?? DBNull.Value);
            parametro[8] = new SqlParameter("@Anulado", pago.Anulado);
            fa = acc.Escribir("AgregarPago", parametro);

            return fa;
        }
        public int Editar(BE.cls24_Pagos pago)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[9];
            parametro[0] = new SqlParameter("@IdPago", pago.IdPago);
            parametro[1] = new SqlParameter("@IdProveedor", pago.IdProveedor);
            parametro[2] = new SqlParameter("@IdCompras", pago.IdCompras);
            parametro[3] = new SqlParameter("@FechaPago", pago.FechaPago);
            parametro[4] = new SqlParameter("@Importe", pago.Importe);
            parametro[5] = new SqlParameter("@FormaPago", pago.FormaPago);
            parametro[6] = new SqlParameter("@Observaciones", pago.Observaciones);
            parametro[7] = new SqlParameter("@NumeroComprobante", (object)pago.NumeroComprobante ?? DBNull.Value);
            parametro[8] = new SqlParameter("@Anulado", pago.Anulado);
            fa = acc.Escribir("EditarPago", parametro);

            return fa;
        }
        public int Eliminar(BE.cls24_Pagos pago)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdPago", pago.IdPago);

            fa = acc.Escribir("EliminarPago", parametro);

            return fa;
        }
        public int MaxId(BE.cls24_Pagos pago)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdPago", null);

            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["IdPago"] != DBNull.Value)
                    return Convert.ToInt32(dr["IdPago"]);
            }

            return ls;
        }
        public List<BE.cls24_Pagos> Listar()
        {
            List<BE.cls24_Pagos> ls = new List<BE.cls24_Pagos>();

            DataTable tabla = acc.Leer("ListarPagos", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls24_Pagos pago = new BE.cls24_Pagos();

                pago.IdPago = int.Parse(dr["IdPago"].ToString());
                pago.IdProveedor = Convert.ToInt32(dr["IdProveedor"]);
                pago.IdCompras = Convert.ToInt32(dr["IdCompras"]);
                pago.FechaPago = DateTime.Parse(dr["FechaPago"].ToString());
                pago.Importe = decimal.Parse(dr["Importe"].ToString());
                pago.FormaPago = dr["FormaPago"].ToString();
                pago.Observaciones = dr["Observaciones"].ToString();
                if (tabla.Columns.Contains("NumeroComprobante"))
                    pago.NumeroComprobante = dr["NumeroComprobante"].ToString();
                if (tabla.Columns.Contains("Anulado") && dr["Anulado"] != DBNull.Value)
                    pago.Anulado = Convert.ToBoolean(dr["Anulado"]);
                ls.Add(pago);
            }

            return ls;
        }
        public List<BE.cls24_Pagos> Listar2()
        {
            List<BE.cls24_Pagos> ls = new List<BE.cls24_Pagos>();
            DataTable tabla = acc.Leer("Obtener_24_IdPagoCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls24_Pagos pago = new BE.cls24_Pagos();
                pago.IdPago = int.Parse(dr["IdPago"].ToString());
                pago.IdProveedor = int.Parse(dr["IdProveedor"].ToString());
                pago.Nombre = tabla.Columns.Contains("NombreEmpresa")
                    ? dr["NombreEmpresa"].ToString() : dr["Nombre"].ToString();
                pago.Apellido = tabla.Columns.Contains("Apellido") ? dr["Apellido"].ToString() : string.Empty;
                pago.IdCompras = int.Parse(dr["IdCompras"].ToString());
                pago.FechaPago = DateTime.Parse(dr["FechaPago"].ToString());
                pago.Importe = decimal.Parse(dr["Importe"].ToString());
                pago.FormaPago = dr["FormaPago"].ToString();
                pago.Observaciones = dr["Observaciones"].ToString();
                if (tabla.Columns.Contains("NumeroComprobante"))
                    pago.NumeroComprobante = dr["NumeroComprobante"].ToString();
                if (tabla.Columns.Contains("Anulado") && dr["Anulado"] != DBNull.Value)
                    pago.Anulado = Convert.ToBoolean(dr["Anulado"]);
                pago.Combo = "Nº" + pago.IdPago+"-"+pago.Nombre+"-$"+pago.Importe;
                ls.Add(pago);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls24_Pagos pago, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPago", id);

            DataTable tabla = acc.LeerConParametro(
                "BusquedaConIdPagosCombinado", parametro);

            foreach (DataRow dr in tabla.Rows)
            {
                pago.IdPago = int.Parse(dr["IdPago"].ToString());
                pago.IdProveedor = Convert.ToInt32(dr["IdProveedor"]);
                pago.IdCompras = Convert.ToInt32(dr["IdCompras"]);
                pago.FechaPago = DateTime.Parse(dr["FechaPago"].ToString());
                pago.Importe = decimal.Parse(dr["Importe"].ToString());
                pago.FormaPago = dr["FormaPago"].ToString();
                pago.Observaciones = dr["Observaciones"].ToString();
                if (tabla.Columns.Contains("NumeroComprobante"))
                    pago.NumeroComprobante = dr["NumeroComprobante"].ToString();
                if (tabla.Columns.Contains("Anulado") && dr["Anulado"] != DBNull.Value)
                    pago.Anulado = Convert.ToBoolean(dr["Anulado"]);
            }
            return tabla;
        }
    }
}

