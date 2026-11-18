using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapAccion
    {
        clsAcceso acc = new clsAcceso();

        public int Agregar(BE.cls28_Accion accion)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdAccion", accion.IdAccion);
            parametro[1] = new SqlParameter("@Nombre", accion.Nombre);

            return acc.Escribir("AgregarAccion", parametro);
        }

        public int Editar(BE.cls28_Accion accion)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdAccion", accion.IdAccion);
            parametro[1] = new SqlParameter("@Nombre", accion.Nombre);

            return acc.Escribir("EditarAccion", parametro);
        }

        public int Eliminar(BE.cls28_Accion accion)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdAccion", accion.IdAccion);

            return acc.Escribir("EliminarAccion", parametro);
        }

        public int MaxId(BE.cls28_Accion accion)
        {
            int id = 0;
            DataTable tabla = acc.Leer("MAXIdAccion", null);

            if (tabla != null && tabla.Rows.Count > 0 &&
                tabla.Rows[0]["IdAccion"] != DBNull.Value)
            {
                id = Convert.ToInt32(tabla.Rows[0]["IdAccion"]);
                accion.IdAccion = id;
            }

            return id;
        }

        public List<BE.cls28_Accion> Listar()
        {
            List<BE.cls28_Accion> lista = new List<BE.cls28_Accion>();
            DataTable tabla = acc.Leer("Obtener_28_IdAccion", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls28_Accion accion = new BE.cls28_Accion();
                accion.IdAccion = Convert.ToInt32(dr["IdAccion"]);
                accion.Nombre = dr["Nombre"].ToString();

                lista.Add(accion);
            }

            return lista;
        }

        public DataTable Consultar(BE.cls28_Accion accion, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdAccion", id);

            DataTable tabla = acc.LeerConParametro(
                "BusquedaConIdAccion",
                parametro);

            foreach (DataRow dr in tabla.Rows)
            {
                accion.IdAccion = Convert.ToInt32(dr["IdAccion"]);
                accion.Nombre = dr["Nombre"].ToString();
            }

            return tabla;
        }
    }
}
