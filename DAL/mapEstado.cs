using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapEstado
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls15_Estado estado)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[8];

            parametro[0] = new SqlParameter("@IdEstado", estado.Idestado);
            parametro[1] = new SqlParameter("@IdOrdenProduccion", estado.Idordenproduccion);
            parametro[2] = new SqlParameter("@FechaOrden", estado.Fechaorden);
            parametro[3] = new SqlParameter("@FechaInicioProduccion", estado.Fechainicioproduccion);
            parametro[4] = new SqlParameter("@FechaFinProduccion", estado.Fechafinproduccion);
            parametro[5] = new SqlParameter("@FechaEntrega", estado.Fechaentrega);
            parametro[6] = new SqlParameter("@Estado", estado.Estado);
            parametro[7] = new SqlParameter("@Observaciones", estado.Observaciones);

            fa = acc.Escribir("AgregarEstadoProduccion", parametro);
            return fa;
        }

        public int Editar(BE.cls15_Estado estado)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[9];

            parametro[0] = new SqlParameter("@IdEstado", estado.Idestado);
            parametro[1] = new SqlParameter("@IdOrdenProduccion", estado.Idordenproduccion);
            parametro[2] = new SqlParameter("@FechaOrden", estado.Fechaorden);
            parametro[3] = new SqlParameter("@FechaInicioProduccion", estado.Fechainicioproduccion);
            parametro[4] = new SqlParameter("@FechaFinProduccion", estado.Fechafinproduccion);
            parametro[5] = new SqlParameter("@FechaEntrega", estado.Fechaentrega);
            parametro[6] = new SqlParameter("@Estado", estado.Estado);
            parametro[7] = new SqlParameter("@Observaciones", estado.Observaciones);
            parametro[8] = new SqlParameter("@IdLogin", estado.Idlogin);

            fa = acc.Escribir("EditarEstadoProduccion", parametro);
            return fa;
        }

        public int Eliminar(BE.cls15_Estado estado)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdEstado", estado.Idestado);

            fa = acc.Escribir("EliminarEstadoProduccion", parametro);
            return fa;
        }

        public int MaxId(BE.cls15_Estado estado)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdEstado", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                estado.Idestado = int.Parse(dr["IdEstado"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = estado.Idestado;
        }

        public List<BE.cls15_Estado> Listar()
        {
            List<BE.cls15_Estado> ls = new List<BE.cls15_Estado>();

            DataTable tabla = acc.Leer("ListarEstadoProduccion", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls15_Estado estado = new BE.cls15_Estado();
                estado.Idestado = int.Parse(dr["IdEstado"].ToString());
                estado.Idordenproduccion = int.Parse(dr["IdOrdenProduccion"].ToString());
                estado.Fechaorden = Convert.ToDateTime(dr["FechaOrden"]);
                if (dr["FechaInicioProduccion"] != DBNull.Value)
                    estado.Fechainicioproduccion = Convert.ToDateTime(dr["FechaInicioProduccion"]);
                if (dr["FechaFinProduccion"] != DBNull.Value)
                    estado.Fechafinproduccion = Convert.ToDateTime(dr["FechaFinProduccion"]);
                if (dr["FechaEntrega"] != DBNull.Value)
                    estado.Fechaentrega = Convert.ToDateTime(dr["FechaEntrega"]);
                estado.Estado = dr["Estado"].ToString();
                estado.Observaciones = dr["Observaciones"].ToString();
                estado.Idlogin = int.Parse(dr["IdLogin"].ToString());
                ls.Add(estado);
            }

            return ls;
        }
    }
}
