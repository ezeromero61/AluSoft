using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapRemitoProveedor
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls23_RemitoProveedor remito)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[5];
            parametro[0] = new SqlParameter("@IdRemitoProveedor", remito.Idremitoproveedor);
            parametro[1] = new SqlParameter("@IdPresupuestoProveedor", remito.Idpresupuestoproveedor);
            parametro[2]= new SqlParameter("@Fecha", remito.Fecha);
            parametro[3] = new SqlParameter("@Estado", remito.Estado);
            parametro[4] = new SqlParameter("@Observaciones", remito.Observaciones);
            fa = acc.Escribir("AgregarRemitoProveedor", parametro);
            return fa;
        }

        public int Editar(BE.cls23_RemitoProveedor remito)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[5];
            parametro[0] = new SqlParameter("@IdRemitoProveedor", remito.Idremitoproveedor);
            parametro[1] = new SqlParameter("@IdPresupuestoProveedor", remito.Idpresupuestoproveedor);
            parametro[2] = new SqlParameter("@Fecha", remito.Fecha);
            parametro[3] = new SqlParameter("@Estado", remito.Estado);
            parametro[4] = new SqlParameter("@Observaciones", remito.Observaciones);
            fa = acc.Escribir("EditarRemitoProveedor", parametro);
            return fa;
        }

        public int Eliminar(BE.cls23_RemitoProveedor remito)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdRemitoProveedor", remito.Idremitoproveedor);

            fa = acc.Escribir("EliminarRemitoProveedor", parametro);

            return fa;
        }
        public int MaxId(BE.cls23_RemitoProveedor remito)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdRemitoProveedor", null);
            foreach (DataRow dr in tabla.Rows)
            {
                remito.Idremitoproveedor = int.Parse(dr["IdRemitoProveedor"].ToString());
            }
            return ls = remito.Idremitoproveedor;
        }
        public List<BE.cls23_RemitoProveedor> Listar()
        {
            List<BE.cls23_RemitoProveedor> ls = new List<BE.cls23_RemitoProveedor>();

            DataTable tabla = acc.Leer("ListarRemitoProveedor", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls23_RemitoProveedor remito = new BE.cls23_RemitoProveedor();

                remito.Idremitoproveedor = int.Parse(dr["IdRemitoProveedor"].ToString());
                remito.Idpresupuestoproveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
                remito.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                remito.Estado = (dr["Estado"].ToString());
                remito.Observaciones = (dr["Observaciones"].ToString());
                ls.Add(remito);
            }

            return ls;
        }
        public DataTable Consultar(BE.cls23_RemitoProveedor remito,int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdRemitoProveedor",id);

            DataTable tabla = acc.LeerConParametro("BusquedaConIdRemitoProveedorCombinado", parametro);

            if (tabla.Rows.Count > 0)
            {
                CargarEntidad(remito, tabla.Rows[0]);
            }

            return tabla;
        }
        public List<BE.cls23_RemitoProveedor> Listar2()
        {
            List<BE.cls23_RemitoProveedor> ls = new List<BE.cls23_RemitoProveedor>();

            DataTable tabla = acc.Leer("Obtener_23_IdRemitoProveedorCombinado", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls23_RemitoProveedor remito = new BE.cls23_RemitoProveedor();

                remito.Idremitoproveedor = int.Parse(dr["IdRemitoProveedor"].ToString());
                remito.Idpresupuestoproveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
                remito.Nombre=(dr["NombreEmpresa"].ToString());
                remito.Fecha = Convert.ToDateTime(dr["Fecha"]);
                remito.Estado = dr["Estado"].ToString();
                remito.Observaciones = dr["Observaciones"] == DBNull.Value ? string.Empty : dr["Observaciones"].ToString();
                remito.Combo= "Nº" + remito.Idremitoproveedor + "-" + remito.Nombre+"-"+remito.Estado;
                ls.Add(remito);
            }

            return ls;
        }
        
        private void CargarEntidad(BE.cls23_RemitoProveedor remito,DataRow dr)
        {
            remito.Idremitoproveedor =Convert.ToInt32(dr["IdRemitoProveedor"]);

            remito.Idpresupuestoproveedor = Convert.ToInt32(dr["IdPresupuestoProveedor"]);

            remito.Fecha = Convert.ToDateTime(dr["Fecha"]);

            remito.Estado =dr["Estado"].ToString();

            remito.Observaciones = dr["Observaciones"] == DBNull.Value ? string.Empty : dr["Observaciones"].ToString();
        }
    }
}

