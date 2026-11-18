using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class mapPresupuestoDetalle
    {
        clsAcceso acc = new clsAcceso();

        public int Agregar(BE.cls36_PresupuestoDetalle d)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@IdPresupuesto", d.IdPresupuesto);
            p[1] = new SqlParameter("@IdCatalogo", d.IdCatalogo);
            p[2] = new SqlParameter("@Cantidad", d.Cantidad);
            p[3] = new SqlParameter("@PrecioUnitario", d.PrecioUnitario);
            return acc.Escribir("AgregarPresupuestoClienteDetalle", p);
        }

        public int EliminarDePresupuesto(int idPresupuesto)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@IdPresupuesto", idPresupuesto);
            return acc.Escribir("EliminarDetallePresupuestoCliente", p);
        }

        public List<BE.cls36_PresupuestoDetalle> Listar(int idPresupuesto)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@IdPresupuesto", idPresupuesto);
            DataTable tabla = acc.LeerConParametro("ListarDetallePresupuestoCliente", p);
            List<BE.cls36_PresupuestoDetalle> ls = new List<BE.cls36_PresupuestoDetalle>();
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls36_PresupuestoDetalle d = new BE.cls36_PresupuestoDetalle();
                d.IdDetalle = Convert.ToInt32(dr["IdDetalle"]);
                d.IdPresupuesto = Convert.ToInt32(dr["IdPresupuesto"]);
                d.IdCatalogo = Convert.ToInt32(dr["IdCatalogo"]);
                d.Producto = dr["Producto"].ToString();
                d.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                d.PrecioUnitario = Convert.ToInt32(dr["PrecioUnitario"]);
                d.IdStock = dr["IdStock"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdStock"]);
                ls.Add(d);
            }
            return ls;
        }
    }
}
