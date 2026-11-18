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
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
            }

            return ls = bita.idbitacora;
        }
        public DataTable ConsultarConFecha(BE.cls35_Bitacora bita, DateTime id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@Fecha", id);
            DataTable tabla = acc.LeerConParametro("BusquedaBitacoraConFecha", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                if (dr["Fecha"] != DBNull.Value)
                    bita.fecha = Convert.ToDateTime(dr["Fecha"]);
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
                bita.idaccion = int.Parse(dr["IdAccion"].ToString());
                bita.NombreAccion = (dr["NombreAccion"].ToString());
                bita.idtabla = int.Parse(dr["IdTabla"].ToString());
                bita.NombreTabla = (dr["NombreTabla"].ToString());
                bita.idlogin = int.Parse(dr["IdLogin"].ToString());
                bita.IdRol = int.Parse(dr["IdRol"].ToString());
                bita.NombreRol = dr["NombreRol"].ToString();
                bita.Usuario = clsCifrado.DesencriptarString(dr["Usuario"].ToString());
            }
            return tabla;
        }
        public DataTable ConsultarConAccion(BE.cls35_Bitacora bita, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdAccion", id);
            DataTable tabla = acc.LeerConParametro("BusquedaBitacoraConIdAccion", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                if (dr["Fecha"] != DBNull.Value)
                    bita.fecha = Convert.ToDateTime(dr["Fecha"]);
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
                bita.idaccion = int.Parse(dr["IdAccion"].ToString());
                bita.NombreAccion = (dr["NombreAccion"].ToString());
                bita.idtabla = int.Parse(dr["IdTabla"].ToString());
                bita.NombreTabla = (dr["NombreTabla"].ToString());
                bita.idlogin = int.Parse(dr["IdLogin"].ToString());
                bita.IdRol = int.Parse(dr["IdRol"].ToString());
                bita.NombreRol = dr["NombreRol"].ToString();
                bita.Usuario = clsCifrado.DesencriptarString(dr["Usuario"].ToString());
            }
            return tabla;
        }
        public DataTable ConsultarConRol(BE.cls35_Bitacora bita, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdRol", id);
            DataTable tabla = acc.LeerConParametro("BusquedaBitacoraConRol", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                if (dr["Fecha"] != DBNull.Value)
                    bita.fecha = Convert.ToDateTime(dr["Fecha"]);
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
                bita.idaccion = int.Parse(dr["IdAccion"].ToString());
                bita.NombreAccion = (dr["NombreAccion"].ToString());
                bita.idtabla = int.Parse(dr["IdTabla"].ToString());
                bita.NombreTabla = (dr["NombreTabla"].ToString());
                bita.idlogin = int.Parse(dr["IdLogin"].ToString());
                bita.IdRol = int.Parse(dr["IdRol"].ToString());
                bita.NombreRol = dr["NombreRol"].ToString();
                bita.Usuario = clsCifrado.DesencriptarString(dr["Usuario"].ToString());
            }
            return tabla;
        }
        public DataTable ConsultarConTabla(BE.cls35_Bitacora bita, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdTabla", id);
            DataTable tabla = acc.LeerConParametro("BusquedaBitacoraConTabla", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                if (dr["Fecha"] != DBNull.Value)
                    bita.fecha = Convert.ToDateTime(dr["Fecha"]);
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
                bita.idaccion = int.Parse(dr["IdAccion"].ToString());
                bita.NombreAccion = (dr["NombreAccion"].ToString());
                bita.idtabla = int.Parse(dr["IdTabla"].ToString());
                bita.NombreTabla = (dr["NombreTabla"].ToString());
                bita.idlogin = int.Parse(dr["IdLogin"].ToString());
                bita.IdRol = int.Parse(dr["IdRol"].ToString());
                bita.NombreRol = dr["NombreRol"].ToString();
                bita.Usuario = clsCifrado.DesencriptarString(dr["Usuario"].ToString());
            }
            return tabla;
        }
        public DataTable ConsultarConUsuario(BE.cls35_Bitacora bita, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdLogin", id);
            DataTable tabla = acc.LeerConParametro("BusquedaBitacoraConUsuario", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                if (dr["Fecha"] != DBNull.Value)
                    bita.fecha = Convert.ToDateTime(dr["Fecha"]);
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
                bita.idaccion = int.Parse(dr["IdAccion"].ToString());
                bita.NombreAccion = (dr["NombreAccion"].ToString());
                bita.idtabla = int.Parse(dr["IdTabla"].ToString());
                bita.NombreTabla = (dr["NombreTabla"].ToString());
                bita.idlogin = int.Parse(dr["IdLogin"].ToString());
                bita.IdRol = int.Parse(dr["IdRol"].ToString());
                bita.NombreRol = dr["NombreRol"].ToString();
                bita.Usuario = clsCifrado.DesencriptarString(dr["Usuario"].ToString());
            }
            return tabla;
        }
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
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
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
            DataTable tabla = acc.Leer("Obtener_35_ListadoBitacoraCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls35_Bitacora bita = new BE.cls35_Bitacora();
                bita.idbitacora = int.Parse(dr["IdBitacora"].ToString());
                if (dr["Fecha"] != DBNull.Value)
                    bita.fecha = Convert.ToDateTime(dr["Fecha"]);
                if (dr["Hora"] != DBNull.Value)
                    bita.hora = Convert.ToDateTime(dr["Hora"]);
                bita.idaccion = int.Parse(dr["IdAccion"].ToString());
                bita.NombreAccion = (dr["NombreAccion"].ToString());
                bita.idtabla = int.Parse(dr["IdTabla"].ToString());
                bita.NombreTabla = (dr["NombreTabla"].ToString());
                bita.idlogin = int.Parse(dr["IdLogin"].ToString());
                bita.IdRol = int.Parse(dr["IdRol"].ToString());
                bita.NombreRol = dr["NombreRol"].ToString();
                bita.Usuario = clsCifrado.DesencriptarString(dr["Usuario"].ToString());              
                ls.Add(bita);
            }
            return  ls;
        }
    }
}
