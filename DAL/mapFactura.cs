using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapFactura
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls09_Factura factura)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[22];

            parametro[0] = new SqlParameter("@IdFactura", factura.Idfactura);
            parametro[1] = new SqlParameter("@NumeroFactura", factura.NumeroFactura);
            parametro[2] = new SqlParameter("@TipoFactura", factura.TipoFactura);
            parametro[3] = new SqlParameter("@IdPedido", factura.IdPedido);
            parametro[4] = new SqlParameter("@IdCliente", factura.IdCliente);
            parametro[5] = new SqlParameter("@NombreCliente", factura.NombreCliente);
            parametro[6] = new SqlParameter("@Documento", factura.Documento);
            parametro[7] = new SqlParameter("@CUIT", factura.CUIT);
            parametro[8] = new SqlParameter("@CondicionIVA", factura.CondicionIVA);
            parametro[9] = new SqlParameter("@DireccionFiscal", factura.DireccionFiscal);
            parametro[10] = new SqlParameter("@FechaEmision", factura.FechaEmision);
            parametro[11] = new SqlParameter("@FechaVencimiento", factura.FechaVencimiento);
            parametro[12] = new SqlParameter("@Subtotal", factura.Subtotal);
            parametro[13] = new SqlParameter("@Descuento", factura.Descuento);
            parametro[14] = new SqlParameter("@IVA", factura.IVA);
            parametro[15] = new SqlParameter("@Total", factura.Total);
            parametro[16] = new SqlParameter("@FormaPago", factura.Formapago);
            parametro[17] = new SqlParameter("@Pagada", factura.Pagada);
            parametro[18] = new SqlParameter("@Estado", factura.Estado);
            parametro[19] = new SqlParameter("@CAE", factura.CAE);
            parametro[20] = new SqlParameter("@FechaVencimientoCAE", factura.FechaVencimientoCAE);
            parametro[21] = new SqlParameter("@Observaciones", factura.Observaciones);

            fa = acc.Escribir("AgregarFactura", parametro);
            return fa;
        }
        public int Editar(BE.cls09_Factura factura)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[23];

            parametro[0] = new SqlParameter("@IdFactura", factura.Idfactura);
            parametro[1] = new SqlParameter("@NumeroFactura", factura.NumeroFactura);
            parametro[2] = new SqlParameter("@TipoFactura", factura.TipoFactura);
            parametro[3] = new SqlParameter("@IdPedido", factura.IdPedido);
            parametro[4] = new SqlParameter("@IdCliente", factura.IdCliente);
            parametro[5] = new SqlParameter("@NombreCliente", factura.NombreCliente);
            parametro[6] = new SqlParameter("@Documento", factura.Documento);
            parametro[7] = new SqlParameter("@CUIT", factura.CUIT);
            parametro[8] = new SqlParameter("@CondicionIVA", factura.CondicionIVA);
            parametro[9] = new SqlParameter("@DireccionFiscal", factura.DireccionFiscal);
            parametro[10] = new SqlParameter("@FechaEmision", factura.FechaEmision);
            parametro[11] = new SqlParameter("@FechaVencimiento", factura.FechaVencimiento);
            parametro[12] = new SqlParameter("@Subtotal", factura.Subtotal);
            parametro[13] = new SqlParameter("@Descuento", factura.Descuento);
            parametro[14] = new SqlParameter("@IVA", factura.IVA);
            parametro[15] = new SqlParameter("@Total", factura.Total);
            parametro[16] = new SqlParameter("@FormaPago", factura.Formapago);
            parametro[17] = new SqlParameter("@Pagada", factura.Pagada);
            parametro[18] = new SqlParameter("@Estado", factura.Estado);
            parametro[19] = new SqlParameter("@CAE", factura.CAE);
            parametro[20] = new SqlParameter("@FechaVencimientoCAE", factura.FechaVencimientoCAE);
            parametro[21] = new SqlParameter("@Observaciones", factura.Observaciones);
            parametro[22] = new SqlParameter("@IdLogin", factura.Idlogin);

            fa = acc.Escribir("EditarFactura", parametro);
            return fa;
        }
        public int Eliminar(BE.cls09_Factura factura)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdFactura", factura.Idfactura);

            fa = acc.Escribir("EliminarFactura", parametro);
            return fa;
        }
        public int MaxId(BE.cls09_Factura factura)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdFactura", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                factura.Idfactura = int.Parse(dr["IdFactura"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = factura.Idfactura;
        }
        public List<BE.cls09_Factura> Listar()
        {
            List<BE.cls09_Factura> ls = new List<BE.cls09_Factura>();

            DataTable tabla = acc.Leer("ListarFactura", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls09_Factura factura = new BE.cls09_Factura();

                factura.Idfactura = int.Parse(dr["IdFactura"].ToString());
                factura.NumeroFactura = dr["NumeroFactura"].ToString();
                factura.TipoFactura = dr["TipoFactura"].ToString();
                factura.IdPedido = int.Parse(dr["IdPedido"].ToString());
                factura.IdCliente = int.Parse(dr["IdCliente"].ToString());
                factura.NombreCliente = dr["NombreCliente"].ToString();
                factura.Documento = dr["Documento"].ToString();
                factura.CUIT = dr["CUIT"].ToString();
                factura.CondicionIVA = dr["CondicionIVA"].ToString();
                factura.DireccionFiscal = dr["DireccionFiscal"].ToString();
                if (dr["FechaEmision"] != DBNull.Value)
                    factura.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]);
                if (dr["FechaVencimiento"] != DBNull.Value)
                    factura.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                factura.Subtotal = decimal.Parse(dr["Subtotal"].ToString());
                factura.Descuento = decimal.Parse(dr["Descuento"].ToString());
                factura.IVA = decimal.Parse(dr["IVA"].ToString());
                factura.Total = decimal.Parse(dr["Total"].ToString());
                factura.Formapago = dr["FormaPago"].ToString();
                factura.Pagada = bool.Parse(dr["Pagada"].ToString());
                factura.Estado = dr["Estado"].ToString();
                factura.CAE = dr["CAE"].ToString();
                if (dr["FechaVencimientoCAE"] != DBNull.Value)
                factura.FechaVencimientoCAE = Convert.ToDateTime(dr["FechaVencimientoCAE"]);
                factura.Observaciones = dr["Observaciones"].ToString();
                factura.Idlogin = int.Parse(dr["IdLogin"].ToString());

                ls.Add(factura);
            }

            return ls;
        }
    }
}
