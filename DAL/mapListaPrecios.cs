using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapListaPrecios
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls13_ListaPrecios lista)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[4];

            parametro[0] = new SqlParameter("@IdLista", lista.Idlista);
            parametro[1] = new SqlParameter("@IdCatalogo", lista.Idcatalogo);
            parametro[2] = new SqlParameter("@Fecha", lista.Fecha);
            parametro[3] = new SqlParameter("@Precio", lista.Precio);

            fa = acc.Escribir("AgregarListaPrecios", parametro);
            return fa;
        }
        public int Editar(BE.cls13_ListaPrecios lista)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[4];

            parametro[0] = new SqlParameter("@IdLista", lista.Idlista);
            parametro[1] = new SqlParameter("@IdCatalogo", lista.Idcatalogo);
            parametro[2] = new SqlParameter("@Fecha", lista.Fecha);
            parametro[3] = new SqlParameter("@Precio", lista.Precio);

            fa = acc.Escribir("EditarListaPrecios", parametro);
            return fa;
        }
        public int Eliminar(BE.cls13_ListaPrecios lista)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdLista", lista.Idlista);

            fa = acc.Escribir("EliminarListaPrecios", parametro);
            return fa;
        }
        public int MaxId(BE.cls13_ListaPrecios lista)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdLista", null);

            foreach (DataRow dr in tabla.Rows)
            {
                lista.Idlista = int.Parse(dr["IdLista"].ToString());
            }

            return ls = lista.Idlista;
        }
        public List<BE.cls13_ListaPrecios> Listar()
        {
            List<BE.cls13_ListaPrecios> ls = new List<BE.cls13_ListaPrecios>();
            DataTable tabla = acc.Leer("ListarListaPrecios", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls13_ListaPrecios lista = new BE.cls13_ListaPrecios();
                lista.Idlista = int.Parse(dr["IdLista"].ToString());
                lista.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                lista.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                lista.Precio = int.Parse(dr["Precio"].ToString());
                ls.Add(lista);
            }
            return ls;
        }
        public List<BE.cls13_ListaPrecios> Listar2()
        {
            List<BE.cls13_ListaPrecios> ls = new List<BE.cls13_ListaPrecios>();
            DataTable tabla = acc.Leer("Obtener_13_IdListaPrecioCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls13_ListaPrecios lista = new BE.cls13_ListaPrecios();
                lista.Idlista = int.Parse(dr["IdLista"].ToString());
                lista.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                lista.Nombre = dr["Nombre"].ToString();
                lista.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                lista.Precio = int.Parse(dr["Precio"].ToString());
                lista.Cantidad = int.Parse(dr["Cantidad"].ToString());
                lista.Combo = "Nº" + lista.Idlista+"-"+lista.Nombre+"-$"+lista.Precio;
                ls.Add(lista);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls13_ListaPrecios lista, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdLista", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdListaPreciosCombo", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                lista.Idlista = int.Parse(dr["IdLista"].ToString());
                lista.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                lista.Nombre = dr["Nombre"].ToString();
                lista.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                lista.Precio = int.Parse(dr["Precio"].ToString());
            }
            return tabla;
        }
    }

}

