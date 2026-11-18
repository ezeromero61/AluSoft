using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapRol
    {
        clsAcceso acc = new clsAcceso();

        public int Agregar(BE.cls25_Rol rol)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdRol", rol.IdRol);
            parametro[1] = new SqlParameter("@Nombre", rol.Nombre);

            return acc.Escribir("AgregarRol", parametro);
        }

        public int Editar(BE.cls25_Rol rol)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdRol", rol.IdRol);
            parametro[1] = new SqlParameter("@Nombre", rol.Nombre);

            return acc.Escribir("EditarRol", parametro);
        }

        public int Eliminar(BE.cls25_Rol rol)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdRol", rol.IdRol);

            return acc.Escribir("EliminarRol", parametro);
        }

        public int MaxId()
        {
            int idRol = 0;
            DataTable tabla = acc.Leer("MAXIdRol", null);

            if (tabla != null && tabla.Rows.Count > 0 &&
                tabla.Rows[0]["IdRol"] != DBNull.Value)
            {
                idRol = Convert.ToInt32(tabla.Rows[0]["IdRol"]);
            }

            return idRol;
        }

        public List<BE.cls25_Rol> Listar()
        {
            List<BE.cls25_Rol> lista = new List<BE.cls25_Rol>();
            DataTable tabla = acc.Leer("ListarRol", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls25_Rol rol = new BE.cls25_Rol();

                rol.IdRol = Convert.ToInt32(dr["IdRol"]);
                rol.Nombre = dr["Nombre"].ToString();

                lista.Add(rol);
            }

            return lista;
        }

        public DataTable Consultar(BE.cls25_Rol rol, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdRol", id);

            DataTable tabla = acc.LeerConParametro(
                "BusquedaConIdRol",
                parametro);

            foreach (DataRow dr in tabla.Rows)
            {
                rol.IdRol = Convert.ToInt32(dr["IdRol"]);
                rol.Nombre = dr["Nombre"].ToString();
            }

            return tabla;
        }
    }
}
