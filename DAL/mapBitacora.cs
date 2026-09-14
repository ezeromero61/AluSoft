using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public   class mapBitacora
    {
        clsAcceso acc = new clsAcceso();

        public int Agregar(BE.cls35_Bitacora bita)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[6];
            parametro[0] = new SqlParameter("@IdBitacora", bita.idbitacora);
            parametro[1] = new SqlParameter("@Fecha", bita.fecha);
            parametro[2] = new SqlParameter("@Hora", bita.hora);
            parametro[3] = new SqlParameter("@IdAccion", bita.idaccion);
            parametro[4] = new SqlParameter("@IdTabla", bita.idtabla);
            parametro[5] = new SqlParameter("@IdLogin", bita.idlogin);
            fa = acc.Escribir("AgregarBitacora", parametro);
            return fa;
        }
        public int Editar(BE.cls35_Bitacora bita)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[6];
            parametro[0] = new SqlParameter("@IdBitacora", bita.idbitacora);
            parametro[1] = new SqlParameter("@Fecha", bita.fecha);
            parametro[2] = new SqlParameter("@Hora", bita.hora);
            parametro[3] = new SqlParameter("@IdAccion", bita.idaccion);
            parametro[4] = new SqlParameter("@IdTabla", bita.idtabla);
            parametro[5] = new SqlParameter("@IdLogin", bita.idlogin);
            fa = acc.Escribir("EditarBitacora", parametro);
            return fa;
        }
        public int Eliminar(BE.cls35_Bitacora bita)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdBitacora", bita.idbitacora);
            fa = acc.Escribir("EliminarBitacora", parametro);
            return fa;
        }
        public int MaxId(BE.cls35_Bitacora bita)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdBitacora", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = bita.idbitacora;
        }
        //Obtener_35_ListadoBitacora
        public List<BE.cls35_Bitacora> Listar()
        {
            List<BE.cls35_Bitacora> ls = new List<BE.cls35_Bitacora>();
            DataTable tabla = acc.Leer("ListarBitacora", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls35_Bitacora bita = new BE.cls35_Bitacora();
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                if (dr["Fecha"] != DBNull.Value)
                    bita.fecha = Convert.ToDateTime(dr["Fecha"]);
                //bita.fecha = DateTime.Parse(dr["Fecha"]);
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
                //bita.hora = DateTime.Parse(dr["Hora"].ToString());
                bita.idaccion = int.Parse(dr["IdAccion"].ToString());
                bita.idtabla = int.Parse(dr["IdTabla"].ToString());
                bita.idlogin = int.Parse(dr["IdLogin"].ToString());
                ls.Add(bita);
            }
            return ls;
        }
        public List<BE.cls35_Bitacora> ListarCompleto()
        {
            List<BE.cls35_Bitacora> ls = new List<BE.cls35_Bitacora>();
            DataTable tabla = acc.Leer("Obtener_35_ListadoBitacora", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls35_Bitacora bita = new BE.cls35_Bitacora();
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                if (dr["Fecha"] != DBNull.Value)
                    bita.fecha = Convert.ToDateTime(dr["Fecha"]);
                //bita.fecha = DateTime.Parse(dr["Fecha"]);
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
                //bita.hora = DateTime.Parse(dr["Hora"].ToString());
                bita.idaccion = int.Parse(dr["IdAccion"].ToString());
                bita.NombreAccion = (dr["NombreAccion"].ToString());
                bita.idtabla = int.Parse(dr["IdTabla"].ToString());
                bita.NombreTabla = (dr["NombreTabla"].ToString());
                bita.idlogin = int.Parse(dr["IdLogin"].ToString());
                //bita.Usuraio = (dr["Usuraio"].ToString());
                ls.Add(bita);
            }
            return  ls;
        }
    }
}
