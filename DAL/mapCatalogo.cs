
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapCatalogo
    {
        clsAcceso acc = new clsAcceso();

        public int Agregar(BE.cls12_Catalogo catalogo)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[5];
            parametro[0] = new SqlParameter("@IdCatalogo", catalogo.Idcatalogo);
            parametro[1] = new SqlParameter("@IdInventario", catalogo.Idinventario);
            parametro[2] = new SqlParameter("@PrecioUnitario", catalogo.Preciounitario);
            parametro[3] = new SqlParameter("@Disponibilidad", catalogo.Disponibilidad);
            parametro[4] = new SqlParameter("@Cantidad", catalogo.Cantidad);
            fa = acc.Escribir("AgregarCatalogo", parametro);
            return fa;
        }
        public int Editar(BE.cls12_Catalogo catalogo)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[5];
            parametro[0] = new SqlParameter("@IdCatalogo", catalogo.Idcatalogo);
            parametro[1] = new SqlParameter("@IdInventario", catalogo.Idinventario);
            parametro[2] = new SqlParameter("@PrecioUnitario", catalogo.Preciounitario);
            parametro[3] = new SqlParameter("@Disponibilidad", catalogo.Disponibilidad);
            parametro[4] = new SqlParameter("@Cantidad", catalogo.Cantidad);
            fa = acc.Escribir("EditarCatalogo", parametro);
            return fa;
        }
        public int Eliminar(BE.cls12_Catalogo catalogo)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdCatalogo", catalogo.Idcatalogo);
            fa = acc.Escribir("EliminarAlumno", parametro);
            return fa;
        }
        public int MaxId(BE.cls12_Catalogo catalogo)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdCatalogo", null);
            foreach (DataRow dr in tabla.Rows)
            {
                catalogo.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
            }
            return ls = catalogo.Idcatalogo;
        }
        public List<BE.cls12_Catalogo> Listar()
        {
            List<BE.cls12_Catalogo> ls = new List<BE.cls12_Catalogo>();
            DataTable tabla = acc.Leer("Obtener_12_CatalogoInventario", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls12_Catalogo catalogo = new BE.cls12_Catalogo();
                catalogo.Idcatalogo= int.Parse(dr["IdCatalogo"].ToString());
                catalogo.Idinventario= int.Parse(dr["IdInventario"].ToString());
                catalogo.Nombre = (dr["Nombre"].ToString());
                catalogo.Preciounitario= int.Parse(dr["PrecioUnitario"].ToString());
                catalogo.Disponibilidad= (dr["Disponibilidad"].ToString());
                catalogo.Cantidad= int.Parse(dr["Cantidad"].ToString());              
                catalogo.Combo = "(ID: " + catalogo.Idcatalogo + ") " + catalogo.Nombre;
                ls.Add(catalogo);
            }
            return ls;
        }
        public List<BE.cls12_Catalogo> Listar2()
        {
            List<BE.cls12_Catalogo> ls = new List<BE.cls12_Catalogo>();
            DataTable tabla = acc.Leer("Obtener_12_CompletoCatalogoInventario", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls12_Catalogo catalogo = new BE.cls12_Catalogo();
                catalogo.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                catalogo.Idinventario = int.Parse(dr["IdInventario"].ToString());
                catalogo.Nombre = (dr["Nombre"].ToString());
                catalogo.Descripcion = dr["Descripcion"].ToString();
                catalogo.Tipo = dr["Tipo"].ToString();
                catalogo.Alto = int.Parse(dr["Alto"].ToString());
                catalogo.Largo = int.Parse(dr["Largo"].ToString());
                catalogo.Ancho = int.Parse(dr["Ancho"].ToString());
                catalogo.Material = dr["Material"].ToString();
                catalogo.Color = dr["Color"].ToString();
                catalogo.Preciounitario = int.Parse(dr["PrecioUnitario"].ToString());
                catalogo.Disponibilidad = (dr["Disponibilidad"].ToString());
                catalogo.Cantidad = int.Parse(dr["Cantidad"].ToString());
                catalogo.Combo = "(ID: " + catalogo.Idcatalogo + ") " + catalogo.Nombre;
                ls.Add(catalogo);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls12_Catalogo catalogo, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdCatalogo", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdCatalogo", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                catalogo.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                catalogo.Idinventario = int.Parse(dr["IdInventario"].ToString());
                //catalogo.Nombre = (dr["Nombre"].ToString());
                catalogo.Preciounitario = int.Parse(dr["PrecioUnitario"].ToString());
                catalogo.Disponibilidad = (dr["Disponibilidad"].ToString());
                catalogo.Cantidad = int.Parse(dr["Cantidad"].ToString());
                //catalogo.Combo = "(ID: " + catalogo.Idcatalogo + ") " + catalogo.Nombre;
            }
            return tabla;
        }
    }
}
