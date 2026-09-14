using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapVentas
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls11_Ventas venta)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[16];

            parametro[0] = new SqlParameter("@IdVenta", venta.Idventa);
            parametro[1] = new SqlParameter("@NumeroVenta", venta.Numeroventa);
            parametro[2] = new SqlParameter("@IdPedido", venta.Idpedido);
            parametro[3] = new SqlParameter("@IdFactura", venta.Fdfactura);
            parametro[4] = new SqlParameter("@IdCliente", venta.Idcliente);
            parametro[5] = new SqlParameter("@IdCobro", venta.Idcobro);
            parametro[6] = new SqlParameter("@FechaVenta", venta.Fechaventa);
            parametro[7] = new SqlParameter("@FechaEntrega", (object)venta.Fechaentrega ?? DBNull.Value);
            parametro[8] = new SqlParameter("@Subtotal", venta.Subtotal);
            parametro[9] = new SqlParameter("@Descuento", venta.Descuento);
            parametro[10] = new SqlParameter("@Impuestos", venta.Impuestos);
            parametro[11] = new SqlParameter("@Total", venta.Total);
            parametro[12] = new SqlParameter("@TotalCobrado", venta.Totalcobrado);
            parametro[13] = new SqlParameter("@SaldoPendiente", venta.Saldopendiente);
            parametro[14] = new SqlParameter("@Estado", venta.Estado);
            parametro[15] = new SqlParameter("@Observaciones", venta.Observaciones);

            fa = acc.Escribir("AgregarVenta", parametro);
            return fa;
        }

        public int Editar(BE.cls11_Ventas venta)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[17];

            parametro[0] = new SqlParameter("@IdVenta", venta.Idventa);
            parametro[1] = new SqlParameter("@NumeroVenta", venta.Numeroventa);
            parametro[2] = new SqlParameter("@IdPedido", venta.Idpedido);
            parametro[3] = new SqlParameter("@IdFactura", venta.Fdfactura);
            parametro[4] = new SqlParameter("@IdCliente", venta.Idcliente);
            parametro[5] = new SqlParameter("@IdCobro", venta.Idcobro);
            parametro[6] = new SqlParameter("@FechaVenta", venta.Fechaventa);
            parametro[7] = new SqlParameter("@FechaEntrega", (object)venta.Fechaentrega ?? DBNull.Value);
            parametro[8] = new SqlParameter("@Subtotal", venta.Subtotal);
            parametro[9] = new SqlParameter("@Descuento", venta.Descuento);
            parametro[10] = new SqlParameter("@Impuestos", venta.Impuestos);
            parametro[11] = new SqlParameter("@Total", venta.Total);
            parametro[12] = new SqlParameter("@TotalCobrado", venta.Totalcobrado);
            parametro[13] = new SqlParameter("@SaldoPendiente", venta.Saldopendiente);
            parametro[14] = new SqlParameter("@Estado", venta.Estado);
            parametro[15] = new SqlParameter("@Observaciones", venta.Observaciones);
            parametro[16] = new SqlParameter("@IdLogin", venta.Idlogin);

            fa = acc.Escribir("EditarVenta", parametro);
            return fa;
        }

        public int Eliminar(BE.cls11_Ventas venta)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdVenta", venta.Idventa);

            fa = acc.Escribir("EliminarVenta", parametro);
            return fa;
        }
        public int MaxId(BE.cls11_Ventas venta)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdVenta", null);
            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                venta.Idventa = int.Parse(dr["IdVenta"].ToString());
                //ls=(inventario.Idinventario);
            }
            return ls = venta.Idventa;
        }
        public List<BE.cls11_Ventas> Listar()
        {
            List<BE.cls11_Ventas> ls = new List<BE.cls11_Ventas>();

            DataTable tabla = acc.Leer("ListarVenta", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls11_Ventas venta = new BE.cls11_Ventas();

                venta.Idventa = Convert.ToInt32(dr["IdVenta"]);
                venta.Numeroventa = dr["NumeroVenta"].ToString();
                venta.Idpedido = Convert.ToInt32(dr["IdPedido"]);
                venta.Fdfactura = Convert.ToInt32(dr["IdFactura"]);
                venta.Idcliente = Convert.ToInt32(dr["IdCliente"]);
                venta.Idcobro = Convert.ToInt32(dr["IdCobro"]);
                venta.Fechaventa = Convert.ToDateTime(dr["FechaVenta"]);

                if (dr["FechaEntrega"] != DBNull.Value)
                    venta.Fechaentrega = Convert.ToDateTime(dr["FechaEntrega"]);

                venta.Subtotal = Convert.ToDecimal(dr["Subtotal"]);
                venta.Descuento = Convert.ToDecimal(dr["Descuento"]);
                venta.Impuestos = Convert.ToDecimal(dr["Impuestos"]);
                venta.Total = Convert.ToDecimal(dr["Total"]);
                venta.Totalcobrado = Convert.ToDecimal(dr["TotalCobrado"]);
                venta.Saldopendiente = Convert.ToDecimal(dr["SaldoPendiente"]);
                venta.Estado = dr["Estado"].ToString();
                venta.Observaciones = dr["Observaciones"].ToString();
                venta.Idlogin = Convert.ToInt32(dr["IdLogin"]);

                ls.Add(venta);
            }

            return ls;
        }
    }
}


