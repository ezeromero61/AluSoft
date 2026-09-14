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
            parametro[1] = new SqlParameter("@IdCliente", pago.IdCliente);
            parametro[2] = new SqlParameter("@IdFactura", pago.IdFactura);
            parametro[3] = new SqlParameter("@FechaPago", pago.FechaPago);
            parametro[4] = new SqlParameter("@Importe", pago.Importe);
            parametro[5] = new SqlParameter("@FormaPago", pago.FormaPago);
            parametro[6] = new SqlParameter("@NumeroComprobante", pago.NumeroComprobante);
            parametro[7] = new SqlParameter("@Observaciones", pago.Observaciones);
            parametro[8] = new SqlParameter("@Anulado", pago.Anulado);

            fa = acc.Escribir("AgregarPago", parametro);

            return fa;
        }

        public int Editar(BE.cls24_Pagos pago)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[9];

            parametro[0] = new SqlParameter("@IdPago", pago.IdPago);
            parametro[1] = new SqlParameter("@IdCliente", pago.IdCliente);
            parametro[2] = new SqlParameter("@IdFactura", pago.IdFactura);
            parametro[3] = new SqlParameter("@FechaPago", pago.FechaPago);
            parametro[4] = new SqlParameter("@Importe", pago.Importe);
            parametro[5] = new SqlParameter("@FormaPago", pago.FormaPago);
            parametro[6] = new SqlParameter("@NumeroComprobante", pago.NumeroComprobante);
            parametro[7] = new SqlParameter("@Observaciones", pago.Observaciones);
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
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                pago.IdPago = int.Parse(dr["IdPago"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = pago.IdPago
                ;
        }
        public List<BE.cls24_Pagos> Listar()
        {
            List<BE.cls24_Pagos> ls = new List<BE.cls24_Pagos>();

            DataTable tabla = acc.Leer("ListarPagos", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls24_Pagos pago = new BE.cls24_Pagos();

                pago.IdPago = int.Parse(dr["IdPago"].ToString());
                pago.IdCliente = int.Parse(dr["IdCliente"].ToString());
                pago.IdFactura = int.Parse(dr["IdFactura"].ToString());
                pago.FechaPago = DateTime.Parse(dr["FechaPago"].ToString());
                pago.Importe = decimal.Parse(dr["Importe"].ToString());
                pago.FormaPago = dr["FormaPago"].ToString();
                pago.NumeroComprobante = dr["NumeroComprobante"].ToString();
                pago.Observaciones = dr["Observaciones"].ToString();
                pago.Anulado = bool.Parse(dr["Anulado"].ToString());

                ls.Add(pago);
            }

            return ls;
        }
    }
}

