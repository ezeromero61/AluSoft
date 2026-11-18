using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapTabla
    {
        clsAcceso acc = new clsAcceso();

        public int Agregar(BE.cls29_Tabla tabla)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdTabla", tabla.IdTabla);
            parametro[1] = new SqlParameter("@Nombre", tabla.Nombre);

            return acc.Escribir("AgregarTabla", parametro);
        }

        public int Editar(BE.cls29_Tabla tabla)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdTabla", tabla.IdTabla);
            parametro[1] = new SqlParameter("@Nombre", tabla.Nombre);

            return acc.Escribir("EditarTabla", parametro);
        }

        public int Eliminar(BE.cls29_Tabla tabla)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdTabla", tabla.IdTabla);

            return acc.Escribir("EliminarTabla", parametro);
        }

        public int MaxId(BE.cls29_Tabla tabla)
        {
            int id = 0;
            DataTable resultado = acc.Leer("MAXIdTabla", null);

            if (resultado != null &&
                resultado.Rows.Count > 0 &&
                resultado.Rows[0]["IdTabla"] != DBNull.Value)
            {
                id = Convert.ToInt32(resultado.Rows[0]["IdTabla"]);
                tabla.IdTabla = id;
            }

            return id;
        }

        public List<BE.cls29_Tabla> Listar()
        {
            List<BE.cls29_Tabla> lista = new List<BE.cls29_Tabla>();
            DataTable resultado = acc.Leer("Obtener_29_IdTabla", null);

            foreach (DataRow dr in resultado.Rows)
            {
                BE.cls29_Tabla tabla = new BE.cls29_Tabla();
                tabla.IdTabla = Convert.ToInt32(dr["IdTabla"]);
                tabla.Nombre = dr["Nombre"].ToString();

                lista.Add(tabla);
            }

            return lista;
        }

        public DataTable Consultar(BE.cls29_Tabla tabla, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdTabla", id);

            DataTable resultado = acc.LeerConParametro(
                "BusquedaConIdTabla",
                parametro);

            foreach (DataRow dr in resultado.Rows)
            {
                tabla.IdTabla = Convert.ToInt32(dr["IdTabla"]);
                tabla.Nombre = dr["Nombre"].ToString();
            }

            return resultado;
        }
    }
}
