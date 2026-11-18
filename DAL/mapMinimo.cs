using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapMinimo
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls20_Minimo minimo)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[4];
            parametro[0] = new SqlParameter("@IdMinimo", minimo.Idminimo);
            parametro[1] = new SqlParameter("@IdStock", minimo.Idstock);
            parametro[2] = new SqlParameter("@Fecha", minimo.Fecha);
            parametro[3] = new SqlParameter("@Cantidad", minimo.Cantidad);
            fa = acc.Escribir("AgregarMinimo", parametro);
            return fa;
        }

        public int Editar(BE.cls20_Minimo minimo)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[4];
            parametro[0] = new SqlParameter("@IdMinimo", minimo.Idminimo);
            parametro[1] = new SqlParameter("@IdStock", minimo.Idstock);
            parametro[2] = new SqlParameter("@Fecha", minimo.Fecha);
            parametro[3] = new SqlParameter("@Cantidad", minimo.Cantidad);
            fa = acc.Escribir("EditarMinimo", parametro);
            return fa;
        }

        public int Eliminar(BE.cls20_Minimo minimo)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdMinimo", minimo.Idminimo);
            fa = acc.Escribir("EliminarMinimo", parametro);
            return fa;
        }
        public int MaxId(BE.cls20_Minimo minimo)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdMinimo", null);

            foreach (DataRow dr in tabla.Rows)
            {
                minimo.Idminimo = int.Parse(dr["IdMinimo"].ToString());
            }

            return ls = minimo.Idminimo
                ;
        }
        public List<BE.cls20_Minimo> Listar()
        {
            List<BE.cls20_Minimo> ls = new List<BE.cls20_Minimo>();
            DataTable tabla = acc.Leer("Obtener_02_MinimoStockInventario", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls20_Minimo minimo = new BE.cls20_Minimo();
                minimo.Idminimo = int.Parse(dr["IdMinimo"].ToString());
                minimo.Idstock = int.Parse(dr["IdStock"].ToString());
                minimo.Nombre = (dr["Nombre"].ToString());
                minimo.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                minimo.Cantidad = int.Parse(dr["Cantidad"].ToString());
                minimo.DigitoVerificador = int.Parse(dr["DigitoVerificador"].ToString());
                ls.Add(minimo);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls20_Minimo minimo, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdMinimo", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdMinimoCombinadoStockInventario", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                minimo.Idminimo = int.Parse(dr["IdMinimo"].ToString());
                minimo.Idstock = int.Parse(dr["IdStock"].ToString());
                minimo.Nombre = (dr["Nombre"].ToString());
                minimo.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                minimo.Cantidad = int.Parse(dr["Cantidad"].ToString());
                minimo.DigitoVerificador = int.Parse(dr["DigitoVerificador"].ToString());
            }
            return tabla;
        }
        public List<BE.cls20_Minimo> Listar2()
        {
            List<BE.cls20_Minimo> ls = new List<BE.cls20_Minimo>();
            DataTable tabla = acc.Leer("Obtener_20_StockInventario", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls20_Minimo minimo = new BE.cls20_Minimo();
                minimo.Idminimo = int.Parse(dr["IdMinimo"].ToString());
                minimo.Idstock = int.Parse(dr["IdStock"].ToString());
                minimo.Nombre = (dr["Nombre"].ToString());
                minimo.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                minimo.Cantidad = int.Parse(dr["Cantidad"].ToString());
                minimo.DigitoVerificador = int.Parse(dr["DigitoVerificador"].ToString());
                minimo.Combo = "(ID: " + minimo.Idminimo + ") " + minimo.Nombre;
                ls.Add(minimo);
            }
            return ls;
        }
    }
}

