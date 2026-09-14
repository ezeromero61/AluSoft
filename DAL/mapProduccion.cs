using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapProduccion
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls21_Produccion produccion)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[6];

            parametro[0] = new SqlParameter("@IdProduccion", produccion.Idproduccion);
            parametro[1] = new SqlParameter("@IdOrdenProduccion", produccion.Idordenproduccion);
            parametro[2] = new SqlParameter("@IdLogin", produccion.Idlogin);
            parametro[3] = new SqlParameter("@IdStock", produccion.Idstock);
            parametro[4] = new SqlParameter("@Fecha", produccion.Fecha);
            parametro[5] = new SqlParameter("@Estado", produccion.Estado);

            fa = acc.Escribir("AgregarProduccion", parametro);

            return fa;
        }

        public int Editar(BE.cls21_Produccion produccion)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[6];

            parametro[0] = new SqlParameter("@IdProduccion", produccion.Idproduccion);
            parametro[1] = new SqlParameter("@IdOrdenProduccion", produccion.Idordenproduccion);
            parametro[2] = new SqlParameter("@IdLogin", produccion.Idlogin);
            parametro[3] = new SqlParameter("@IdStock", produccion.Idstock);
            parametro[4] = new SqlParameter("@Fecha", produccion.Fecha);
            parametro[5] = new SqlParameter("@Estado", produccion.Estado);

            fa = acc.Escribir("EditarProduccion", parametro);

            return fa;
        }

        public int Eliminar(BE.cls21_Produccion produccion)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdProduccion", produccion.Idproduccion);

            fa = acc.Escribir("EliminarProduccion", parametro);

            return fa;
        }
        public int MaxId(BE.cls21_Produccion produccion)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdProduccion", null);
            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                produccion.Idproduccion = int.Parse(dr["IdProduccion"].ToString());
                //ls=(inventario.Idinventario);
            }
            return ls = produccion.Idproduccion;
        }
        public List<BE.cls21_Produccion> Listar()
        {
            List<BE.cls21_Produccion> ls = new List<BE.cls21_Produccion>();

            DataTable tabla = acc.Leer("ListarProduccion", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls21_Produccion produccion = new BE.cls21_Produccion();

                produccion.Idproduccion = int.Parse(dr["IdProduccion"].ToString());
                produccion.Idordenproduccion = int.Parse(dr["IdOrdenProduccion"].ToString());
                produccion.Idlogin = int.Parse(dr["IdLogin"].ToString());
                produccion.Idstock = int.Parse(dr["IdStock"].ToString());
                produccion.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                produccion.Estado = dr["Estado"].ToString();

                ls.Add(produccion);
            }

            return ls;
        }
    }
}

