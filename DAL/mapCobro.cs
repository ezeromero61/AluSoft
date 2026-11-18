using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapCobro
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls10_Cobro cobro)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[7];
            parametro[0] = new SqlParameter("@IdCobro", cobro.Idcobro);
            parametro[1] = new SqlParameter("@IdFactura", cobro.Idfactura);
            parametro[2] = new SqlParameter("@FechaCobro", cobro.Fechacobro);
            parametro[3] = new SqlParameter("@Importe", cobro.Importe);
            parametro[4] = new SqlParameter("@FormaPago", cobro.Formapago);
            parametro[5] = new SqlParameter("@Estado", cobro.Estado);
            parametro[6] = new SqlParameter("@Observaciones", cobro.Observaciones);
            fa = acc.Escribir("AgregarCobro", parametro);
            return fa;
        }
        public int Editar(BE.cls10_Cobro cobro)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[7];
            parametro[0] = new SqlParameter("@IdCobro", cobro.Idcobro);
            parametro[1] = new SqlParameter("@IdFactura", cobro.Idfactura);
            parametro[2] = new SqlParameter("@FechaCobro", cobro.Fechacobro);
            parametro[3] = new SqlParameter("@Importe", cobro.Importe);
            parametro[4] = new SqlParameter("@FormaPago", cobro.Formapago);
            parametro[5] = new SqlParameter("@Estado", cobro.Estado);
            parametro[6] = new SqlParameter("@Observaciones", cobro.Observaciones);
            fa = acc.Escribir("EditarCobro", parametro);
            return fa;
        }
        public int Eliminar(BE.cls10_Cobro cobro)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdCobro", cobro.Idcobro);

            fa = acc.Escribir("EliminarCobro", parametro);
            return fa;
        }
        public int MaxId(BE.cls10_Cobro cobro)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdCobro", null);

            foreach (DataRow dr in tabla.Rows)
            {
                cobro.Idcobro = int.Parse(dr["IdCobro"].ToString());
            }

            return ls = cobro.Idcobro;
        }
        public List<BE.cls10_Cobro> Listar()
        {
            List<BE.cls10_Cobro> ls = new List<BE.cls10_Cobro>();

            DataTable tabla = acc.Leer("ListarCobro", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls10_Cobro cobro = new BE.cls10_Cobro();

                cobro.Idcobro = int.Parse(dr["IdCobro"].ToString());
                if (tabla.Columns.Contains("NumeroCobro"))
                    cobro.Numerocobro = dr["NumeroCobro"].ToString();
                cobro.Idfactura = int.Parse(dr["IdFactura"].ToString());
                cobro.Idcliente = int.Parse(dr["IdCliente"].ToString());
                if (dr["FechaCobro"] != DBNull.Value)
                    cobro.Fechacobro = Convert.ToDateTime(dr["FechaCobro"]);
                cobro.Importe = decimal.Parse(dr["Importe"].ToString());
                cobro.Formapago = dr["FormaPago"].ToString();
                cobro.Estado = dr["Estado"].ToString();
                cobro.Observaciones = dr["Observaciones"].ToString();
                if (tabla.Columns.Contains("IdLogin") && dr["IdLogin"] != DBNull.Value)
                    cobro.Idlogin = int.Parse(dr["IdLogin"].ToString());

                ls.Add(cobro);
            }

            return ls;
        }
        public DataTable Consultar(BE.cls10_Cobro cobro, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdCobro", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdCobroCombinado", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                cobro.Idcobro = int.Parse(dr["IdCobro"].ToString());
                cobro.Idfactura = int.Parse(dr["IdFactura"].ToString());
                cobro.Fechacobro = DateTime.Parse(dr["FechaCobro"].ToString());
                cobro.Importe = decimal.Parse(dr["Importe"].ToString());
                cobro.Formapago = dr["FormaPago"].ToString();
                cobro.Estado = dr["Estado"].ToString();
                cobro.Observaciones = dr["Observaciones"].ToString();
                cobro.Combo ="(ID: " + cobro.Idcobro + ") " +dr["Nombre"].ToString();
            }
            return tabla;
        }
        public List<BE.cls10_Cobro> Listar2()
        {
            List<BE.cls10_Cobro> ls = new List<BE.cls10_Cobro>();
            DataTable tabla = acc.Leer("Obtener_10_IdCobroCombinado2", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls10_Cobro cobro = new BE.cls10_Cobro();
                cobro.Idcobro = int.Parse(dr["IdCobro"].ToString());
                cobro.Idfactura = int.Parse(dr["IdFactura"].ToString());
                cobro.TipoFactura = dr["TipoFactura"].ToString();
                cobro.IdPedido = int.Parse(dr["IdPedido"].ToString());
                cobro.IdCliente= int.Parse(dr["IdCliente"].ToString());
                cobro.CondicionIVA = dr["CondicionIVA"].ToString();
                cobro.DireccionFiscal = dr["DireccionFiscal"].ToString();
                if (dr["FechaEmision"] != DBNull.Value)
                cobro.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]);
                if (dr["FechaVencimiento"] != DBNull.Value)
                cobro.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                cobro.Subtotal = decimal.Parse(dr["Subtotal"].ToString());
                cobro.Descuento = decimal.Parse(dr["Descuento"].ToString());
                cobro.IVA = decimal.Parse(dr["IVA"].ToString());
                cobro.Total = decimal.Parse(dr["Total"].ToString());
                cobro.Formapago = dr["FormaPago"].ToString();
                cobro.Estado = dr["Estado"].ToString();
                cobro.CAE = dr["CAE"].ToString();
                if (dr["FechaVencimientoCAE"] != DBNull.Value)
                cobro.FechaVencimientoCAE = Convert.ToDateTime(dr["FechaVencimientoCAE"]);
                cobro.Observaciones = dr["Observaciones"].ToString();
                cobro.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                cobro.Apellido= clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                cobro.Fechacobro = DateTime.Parse(dr["FechaCobro"].ToString());
                cobro.Importe = decimal.Parse(dr["Importe"].ToString());
                cobro.Combo = "N° " + cobro.Idcobro + " - " + cobro.Nombre + " " + cobro.Apellido + " - $" + cobro.Importe;
                ls.Add(cobro);
            }
            return ls;
        }
    }
}
