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
        private static string NumeroDeVenta(BE.cls06_Venta venta)
        {
            if (!string.IsNullOrWhiteSpace(venta.NumeroVenta))
                return venta.NumeroVenta;
            return "V-" + venta.Idventa.ToString("D6");
        }

        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls06_Venta venta)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[16];
            parametro[0] = new SqlParameter("@IdVenta", venta.Idventa);
            parametro[1] = new SqlParameter("@IdPedido", venta.IdPedido);
            parametro[2] = new SqlParameter("@IdFactura", venta.Idfactura);
            parametro[3] = new SqlParameter("@IdCliente", venta.IdCliente);
            parametro[4] = new SqlParameter("@IdCobro", venta.IdCobro);
            parametro[5] = new SqlParameter("@FechaVenta", venta.FechaVenta);
            parametro[6] = new SqlParameter("@FechaEntrega", (object)venta.FechaEntrega ?? DBNull.Value);
            parametro[7] = new SqlParameter("@Subtotal", venta.Subtotal);
            parametro[8] = new SqlParameter("@Descuento", venta.Descuento);
            parametro[9] = new SqlParameter("@Impuestos", venta.Impuestos);
            parametro[10] = new SqlParameter("@Total", venta.Total);
            parametro[11] = new SqlParameter("@TotalCobrado", venta.TotalCobrado);
            parametro[12] = new SqlParameter("@SaldoPendiente", venta.SalfoPendiente);
            parametro[13] = new SqlParameter("@Estado", venta.Estado);
            parametro[14] = new SqlParameter("@Observaciones", venta.Observaciones);
            parametro[15] = new SqlParameter("@NumeroVenta", NumeroDeVenta(venta));
            fa = acc.Escribir("AgregarVenta", parametro);
            return fa;
        }
        public int Editar(BE.cls06_Venta venta)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[16];
            parametro[0] = new SqlParameter("@IdVenta", venta.Idventa);
            parametro[1] = new SqlParameter("@IdPedido", venta.IdPedido);
            parametro[2] = new SqlParameter("@IdFactura", venta.Idfactura);
            parametro[3] = new SqlParameter("@IdCliente", venta.IdCliente);
            parametro[4] = new SqlParameter("@IdCobro", venta.IdCobro);
            parametro[5] = new SqlParameter("@FechaVenta", venta.FechaVenta);
            parametro[6] = new SqlParameter("@FechaEntrega", (object)venta.FechaEntrega ?? DBNull.Value);
            parametro[7] = new SqlParameter("@Subtotal", venta.Subtotal);
            parametro[8] = new SqlParameter("@Descuento", venta.Descuento);
            parametro[9] = new SqlParameter("@Impuestos", venta.Impuestos);
            parametro[10] = new SqlParameter("@Total", venta.Total);
            parametro[11] = new SqlParameter("@TotalCobrado", venta.TotalCobrado);
            parametro[12] = new SqlParameter("@SaldoPendiente", venta.SalfoPendiente);
            parametro[13] = new SqlParameter("@Estado", venta.Estado);
            parametro[14] = new SqlParameter("@Observaciones", venta.Observaciones);
            parametro[15] = new SqlParameter("@NumeroVenta", NumeroDeVenta(venta));
            fa = acc.Escribir("EditarVenta", parametro);
            return fa;
        }
        public int Eliminar(BE.cls06_Venta venta)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdVenta", venta.Idventa);

            fa = acc.Escribir("EliminarVenta", parametro);
            return fa;
        }
        public int MaxId(BE.cls06_Venta venta)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdVenta", null);
            foreach (DataRow dr in tabla.Rows)
            {
                venta.Idventa = int.Parse(dr["IdVenta"].ToString());
            }
            return ls = venta.Idventa;
        }
        public List<BE.cls06_Venta> Listar()
        {
            List<BE.cls06_Venta> ls = new List<BE.cls06_Venta>();

            DataTable tabla = acc.Leer("ListarVenta", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls06_Venta venta = new BE.cls06_Venta();

                venta.Idventa = Convert.ToInt32(dr["IdVenta"]);
                venta.IdPedido = Convert.ToInt32(dr["IdPedido"]);
                venta.Idfactura = Convert.ToInt32(dr["IdFactura"]);
                venta.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                venta.IdCobro = Convert.ToInt32(dr["IdCobro"]);
                venta.FechaVenta = Convert.ToDateTime(dr["FechaVenta"]);
                if (dr["FechaEntrega"] != DBNull.Value)
                    venta.FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]);
                venta.Subtotal = Convert.ToInt32(dr["Subtotal"]);
                venta.Descuento = Convert.ToInt32(dr["Descuento"]);
                venta.Impuestos = Convert.ToInt32(dr["Impuestos"]);
                venta.Total = Convert.ToInt32(dr["Total"]);
                venta.TotalCobrado = Convert.ToInt32(dr["TotalCobrado"]);
                venta.SalfoPendiente = Convert.ToInt32(dr["SaldoPendiente"]);
                venta.Estado = dr["Estado"].ToString();
                venta.Observaciones = dr["Observaciones"].ToString();
                if (tabla.Columns.Contains("NumeroVenta") && dr["NumeroVenta"] != DBNull.Value)
                    venta.NumeroVenta = dr["NumeroVenta"].ToString();
                ls.Add(venta);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls06_Venta venta, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdVenta", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdVentaCombinado", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                venta.Idventa = int.Parse(dr["IdVenta"].ToString());
                venta.IdPedido = int.Parse(dr["IdPedido"].ToString());
                venta.Idfactura = int.Parse(dr["IdFactura"].ToString());
                venta.IdCliente = int.Parse(dr["IdCliente"].ToString());
                venta.IdCobro = int.Parse(dr["IdCobro"].ToString());
                if (dr["FechaVenta"] != DBNull.Value)
                    venta.FechaVenta = Convert.ToDateTime(dr["FechaVenta"]);
                if (dr["FechaEntrega"] != DBNull.Value)
                    venta.FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]);
                venta.Subtotal = decimal.Parse(dr["Subtotal"].ToString());
                venta.Descuento = decimal.Parse(dr["Descuento"].ToString());
                venta.Impuestos= int.Parse(dr["Impuestos"].ToString());
                venta.Total = int.Parse(dr["Total"].ToString());
                venta.TotalCobrado = int.Parse(dr["TotalCobrado"].ToString());
                venta.SalfoPendiente = int.Parse(dr["SaldoPendiente"].ToString());
                venta.Estado = dr["Estado"].ToString();
                venta.Observaciones = dr["Observaciones"].ToString();
            }
            return tabla;
        }
        public List<BE.cls06_Venta> Listar2()
        {
            List<BE.cls06_Venta> ls = new List<BE.cls06_Venta>();
            DataTable tabla = acc.Leer("Obtener_06_IdVentaCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls06_Venta venta = new BE.cls06_Venta();
                venta.Idventa = int.Parse(dr["IdVenta"].ToString());
                venta.IdPedido = int.Parse(dr["IdPedido"].ToString());
                venta.Idfactura = int.Parse(dr["IdFactura"].ToString());
                venta.IdCliente = int.Parse(dr["IdCliente"].ToString());
                venta.NombreCliente =clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                venta.Apellidocliente = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                venta.IdCobro = int.Parse(dr["IdCobro"].ToString());
                if (dr["FechaVenta"] != DBNull.Value)
                    venta.FechaVenta = Convert.ToDateTime(dr["FechaVenta"]);
                if (dr["FechaEntrega"] != DBNull.Value)
                    venta.FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"]);
                venta.Subtotal = decimal.Parse(dr["Subtotal"].ToString());
                venta.Descuento = decimal.Parse(dr["Descuento"].ToString());
                venta.Impuestos = int.Parse(dr["Impuestos"].ToString());
                venta.Total = int.Parse(dr["Total"].ToString());
                venta.TotalCobrado = int.Parse(dr["TotalCobrado"].ToString());
                venta.SalfoPendiente = int.Parse(dr["SaldoPendiente"].ToString());
                venta.Estado = dr["Estado"].ToString();
                venta.Observaciones = dr["Observaciones"].ToString();
                venta.Combo = "000-" + venta.Idventa;
                ls.Add(venta);
            }
            return ls;
        }
    }
}

