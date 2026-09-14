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

            SqlParameter[] parametro = new SqlParameter[2];

            parametro[0] = new SqlParameter("@IdRemitoProveedor", remito.Idremitoproveedor);
            parametro[1] = new SqlParameter("@IdPresupuestoProveedor", remito.Idpresupuestoproveedor);

            fa = acc.Escribir("AgregarRemitoProveedor", parametro);

            return fa;
        }

        public int Editar(BE.cls23_RemitoProveedor remito)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[2];

            parametro[0] = new SqlParameter("@IdRemitoProveedor", remito.Idremitoproveedor);
            parametro[1] = new SqlParameter("@IdPresupuestoProveedor", remito.Idpresupuestoproveedor);

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
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                remito.Idremitoproveedor = int.Parse(dr["IdRemitoProveedor"].ToString());
                //ls=(inventario.Idinventario);
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

                ls.Add(remito);
            }

            return ls;
        }
    }
}
