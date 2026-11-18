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
        // Lecturas tolerantes a NULL: un dato vacío (por ejemplo, una persona sin CUIL o DNI)
        // no debe romper el listado de facturas.
        private static int Entero(DataRow dr, string col)
        {
            if (!dr.Table.Columns.Contains(col) || dr[col] == DBNull.Value) return 0;
            int v; return int.TryParse(dr[col].ToString(), out v) ? v : 0;
        }
        private static long Largo(DataRow dr, string col)
        {
            if (!dr.Table.Columns.Contains(col) || dr[col] == DBNull.Value) return 0;
            long v; return long.TryParse(dr[col].ToString(), out v) ? v : 0;
        }
        private static decimal Importe(DataRow dr, string col)
        {
            if (!dr.Table.Columns.Contains(col) || dr[col] == DBNull.Value) return 0;
            return Convert.ToDecimal(dr[col]);
        }
        clsAcceso acc = new clsAcceso();
        public int ActualizarEstado(int idFactura, string estado)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdFactura", idFactura);
            parametro[1] = new SqlParameter("@Estado", estado);
            return acc.Escribir("ActualizarEstadoFactura", parametro);
        }

        public int Agregar(BE.cls09_Factura factura)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[17];
            parametro[0] = new SqlParameter("@IdFactura", factura.Idfactura);
            parametro[1] = new SqlParameter("@TipoFactura", factura.TipoFactura);
            parametro[2] = new SqlParameter("@IdPedido", factura.IdPedido);
            parametro[3] = new SqlParameter("@IdCliente", factura.IdCliente);
            parametro[4] = new SqlParameter("@CondicionIVA", factura.CondicionIVA);
            parametro[5] = new SqlParameter("@DireccionFiscal", factura.DireccionFiscal);
            parametro[6] = new SqlParameter("@FechaEmision", factura.FechaEmision);
            parametro[7] = new SqlParameter("@FechaVencimiento", factura.FechaVencimiento);
            parametro[8] = new SqlParameter("@Subtotal", factura.Subtotal);
            parametro[9] = new SqlParameter("@Descuento", factura.Descuento);
            parametro[10] = new SqlParameter("@IVA", factura.IVA);
            parametro[11] = new SqlParameter("@Total", factura.Total);
            parametro[12] = new SqlParameter("@FormaPago", factura.Formapago);
            parametro[13] = new SqlParameter("@Estado", factura.Estado);
            parametro[14] = new SqlParameter("@CAE", factura.CAE);
            parametro[15] = new SqlParameter("@FechaVencimientoCAE", factura.FechaVencimientoCAE);
            parametro[16] = new SqlParameter("@Observaciones", factura.Observaciones);

            fa = acc.Escribir("AgregarFactura", parametro);
            return fa;
        }
        public int Editar(BE.cls09_Factura factura)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[17];
            parametro[0] = new SqlParameter("@IdFactura", factura.Idfactura);
            parametro[1] = new SqlParameter("@TipoFactura", factura.TipoFactura);
            parametro[2] = new SqlParameter("@IdPedido", factura.IdPedido);
            parametro[3] = new SqlParameter("@IdCliente", factura.IdCliente);
            parametro[4] = new SqlParameter("@CondicionIVA", factura.CondicionIVA);
            parametro[5] = new SqlParameter("@DireccionFiscal", factura.DireccionFiscal);
            parametro[6] = new SqlParameter("@FechaEmision", factura.FechaEmision);
            parametro[7] = new SqlParameter("@FechaVencimiento", factura.FechaVencimiento);
            parametro[8] = new SqlParameter("@Subtotal", factura.Subtotal);
            parametro[9] = new SqlParameter("@Descuento", factura.Descuento);
            parametro[10] = new SqlParameter("@IVA", factura.IVA);
            parametro[11] = new SqlParameter("@Total", factura.Total);
            parametro[12] = new SqlParameter("@FormaPago", factura.Formapago);
            parametro[13] = new SqlParameter("@Estado", factura.Estado);
            parametro[14] = new SqlParameter("@CAE", factura.CAE);
            parametro[15] = new SqlParameter("@FechaVencimientoCAE", factura.FechaVencimientoCAE);
            parametro[16] = new SqlParameter("@Observaciones", factura.Observaciones);
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
                factura.Idfactura = int.Parse(dr["IdFactura"].ToString());
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
                factura.TipoFactura = dr["TipoFactura"].ToString();
                if (Entero(dr, "IdPedido") > 0) factura.IdPedido = Entero(dr, "IdPedido");
                if (Entero(dr, "IdCliente") > 0) factura.IdCliente = Entero(dr, "IdCliente");
                factura.CondicionIVA = dr["CondicionIVA"].ToString();
                factura.DireccionFiscal = dr["DireccionFiscal"].ToString();
                if (dr["FechaEmision"] != DBNull.Value)
                    factura.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]);
                if (dr["FechaVencimiento"] != DBNull.Value)
                    factura.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                factura.Subtotal = Importe(dr, "Subtotal");
                factura.Descuento = Importe(dr, "Descuento");
                factura.IVA = Importe(dr, "IVA");
                factura.Total = Importe(dr, "Total");
                factura.Formapago = dr["FormaPago"].ToString();
                factura.Estado = dr["Estado"].ToString();
                factura.CAE = dr["CAE"].ToString();
                if (dr["FechaVencimientoCAE"] != DBNull.Value)
                factura.FechaVencimientoCAE = Convert.ToDateTime(dr["FechaVencimientoCAE"]);
                factura.Observaciones = dr["Observaciones"].ToString();
                ls.Add(factura);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls09_Factura factura, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdFactura", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdFacturaCombinado", parametro);
            clsCifrado.DescifrarColumnas(tabla, "Expr1", "Apellido");
            foreach (DataRow dr in tabla.Rows)
            {
                factura.Idfactura = int.Parse(dr["IdFactura"].ToString());
                factura.TipoFactura = dr["TipoFactura"].ToString();
                if (Entero(dr, "IdPedido") > 0) factura.IdPedido = Entero(dr, "IdPedido");
                if (Entero(dr, "IdCliente") > 0) factura.IdCliente = Entero(dr, "IdCliente");
                factura.CondicionIVA = dr["CondicionIVA"].ToString();
                factura.DireccionFiscal = dr["DireccionFiscal"].ToString();
                if (dr["FechaEmision"] != DBNull.Value)
                    factura.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]);
                if (dr["FechaVencimiento"] != DBNull.Value)
                    factura.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                factura.Subtotal = Importe(dr, "Subtotal");
                factura.Descuento = Importe(dr, "Descuento");
                factura.IVA = Importe(dr, "IVA");
                factura.Total = Importe(dr, "Total");
                factura.Formapago = dr["FormaPago"].ToString();
                factura.Estado = dr["Estado"].ToString();
                factura.CAE = dr["CAE"].ToString();
                if (dr["FechaVencimientoCAE"] != DBNull.Value)
                    factura.FechaVencimientoCAE = Convert.ToDateTime(dr["FechaVencimientoCAE"]);
                factura.Observaciones = dr["Observaciones"].ToString();
            }
            return tabla;
        }
        public List<BE.cls09_Factura> Listar2()
        {
            List<BE.cls09_Factura> ls = new List<BE.cls09_Factura>();
            DataTable tabla = acc.Leer("Obtener_09_IdFacturaCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls09_Factura factura = new BE.cls09_Factura();
                factura.Idfactura = int.Parse(dr["IdFactura"].ToString());
                factura.TipoFactura = dr["TipoFactura"].ToString();
                if (Entero(dr, "IdPedido") > 0) factura.IdPedido = Entero(dr, "IdPedido");
                if (Entero(dr, "IdInventario") > 0) factura.Idinventario = Entero(dr, "IdInventario");
                factura.Nombreinventario = (dr["Nombre"].ToString());
                if (Entero(dr, "IdCliente") > 0) factura.IdCliente = Entero(dr, "IdCliente");
                factura.NombreCliente = clsCifrado.DesencriptarString(dr["Expr1"].ToString());
                factura.Apellidocliente = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                factura.Documento = (int)Math.Min(int.MaxValue, Math.Max(0L, Largo(dr, "DNI")));
                factura.CUIT = Largo(dr, "CUIL");
                factura.CondicionIVA = dr["CondicionIVA"].ToString();
                factura.DireccionFiscal = dr["DireccionFiscal"].ToString();
                if (dr["FechaEmision"] != DBNull.Value)
                    factura.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]);
                if (dr["FechaVencimiento"] != DBNull.Value)
                    factura.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                factura.Subtotal = Importe(dr, "Subtotal");
                factura.Descuento = Importe(dr, "Descuento");
                factura.IVA = Importe(dr, "IVA");
                factura.Total = Importe(dr, "Total");
                factura.Formapago = dr["FormaPago"].ToString();
                factura.Estado = dr["Estado"].ToString();
                factura.CAE = dr["CAE"].ToString();
                if (dr["FechaVencimientoCAE"] != DBNull.Value)
                    factura.FechaVencimientoCAE = Convert.ToDateTime(dr["FechaVencimientoCAE"]);
                factura.Observaciones = dr["Observaciones"].ToString();
                factura.Combo = "N° " + factura.Idfactura + " - " + factura.NombreCliente + " " + factura.Apellidocliente + " - $" + factura.Total;
                ls.Add(factura);
            }
            return ls;
        }
    }
}
