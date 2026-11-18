using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapInventario
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls01_Inventario inventario)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[9];

            parametro[0] = new SqlParameter("@IdInventario", inventario.Idinventario);
            parametro[1] = new SqlParameter("@Nombre", inventario.Nombre);
            parametro[2] = new SqlParameter("@Descripcion", inventario.Descripcion);
            parametro[3] = new SqlParameter("@Tipo", inventario.Tipo);
            parametro[4] = new SqlParameter("@Alto", inventario.Alto);
            parametro[5] = new SqlParameter("@Largo", inventario.Largo);
            parametro[6] = new SqlParameter("@Ancho", inventario.Ancho);
            parametro[7] = new SqlParameter("@Material", inventario.Material);
            parametro[8] = new SqlParameter("@Color", inventario.Color);

            fa = acc.Escribir("AgregarInventario", parametro);
            return fa;
        }
        public int Editar(BE.cls01_Inventario inventario)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[9];

            parametro[0] = new SqlParameter("@IdInventario", inventario.Idinventario);
            parametro[1] = new SqlParameter("@Nombre", inventario.Nombre);
            parametro[2] = new SqlParameter("@Descripcion", inventario.Descripcion);
            parametro[3] = new SqlParameter("@Tipo", inventario.Tipo);
            parametro[4] = new SqlParameter("@Alto", inventario.Alto);
            parametro[5] = new SqlParameter("@Largo", inventario.Largo);
            parametro[6] = new SqlParameter("@Ancho", inventario.Ancho);
            parametro[7] = new SqlParameter("@Material", inventario.Material);
            parametro[8] = new SqlParameter("@Color", inventario.Color);

            fa = acc.Escribir("EditarInventario", parametro);
            return fa;
        }
        public int Eliminar(BE.cls01_Inventario inventario)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdInventario", inventario.Idinventario);
            fa = acc.Escribir("EliminarInventario", parametro);
            return fa;
        }
        public DataTable Consultar(BE.cls01_Inventario inventario,int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdInventario", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdInventario", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                inventario.Idinventario = int.Parse(dr["IdInventario"].ToString());
                inventario.Nombre = dr["Nombre"].ToString();
                inventario.Descripcion = dr["Descripcion"].ToString();
                inventario.Tipo = dr["Tipo"].ToString();
                inventario.Alto = int.Parse(dr["Alto"].ToString());
                inventario.Largo = int.Parse(dr["Largo"].ToString());
                inventario.Ancho = int.Parse(dr["Ancho"].ToString());
                inventario.Material = dr["Material"].ToString();
                inventario.Color = dr["Color"].ToString();
            }
            return tabla;
        }
        public List<BE.cls01_Inventario> Listar()
        {
            List<BE.cls01_Inventario> ls = new List<BE.cls01_Inventario>();
            DataTable tabla = acc.Leer("ListarInventario", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                inventario.Idinventario = int.Parse(dr["IdInventario"].ToString());
                inventario.Nombre = dr["Nombre"].ToString();
                inventario.Descripcion = dr["Descripcion"].ToString();
                inventario.Tipo = dr["Tipo"].ToString();
                inventario.Alto = int.Parse(dr["Alto"].ToString());
                inventario.Largo = int.Parse(dr["Largo"].ToString());
                inventario.Ancho = int.Parse(dr["Ancho"].ToString());
                inventario.Material = dr["Material"].ToString();
                inventario.Color = dr["Color"].ToString();
                ls.Add(inventario);
            }
            return ls;
        }
        public List<BE.cls01_Inventario> Listar2()
        {
            List<BE.cls01_Inventario> ls = new List<BE.cls01_Inventario>();
            DataTable tabla = acc.Leer("Obtener_01_InventarioCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                inventario.Idinventario = int.Parse(dr["IdInventario"].ToString());
                inventario.Nombre = dr["Nombre"].ToString();
                inventario.Descripcion = dr["Descripcion"].ToString();
                inventario.Tipo = dr["Tipo"].ToString();
                inventario.Alto = int.Parse(dr["Alto"].ToString());
                inventario.Largo = int.Parse(dr["Largo"].ToString());
                inventario.Ancho = int.Parse(dr["Ancho"].ToString());
                inventario.Material = dr["Material"].ToString();
                inventario.Color = dr["Color"].ToString();
                inventario.Combo = inventario.Nombre;
                ls.Add(inventario);   
            }
            return ls;
        }
        public List<BE.cls01_Inventario> ListarId()
        {
            List<BE.cls01_Inventario> ls = new List<BE.cls01_Inventario>();

            DataTable tabla = acc.Leer("ListarInventario", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls01_Inventario inventario = new BE.cls01_Inventario();

                inventario.Idinventario = int.Parse(dr["IdInventario"].ToString());
                ls.Add(inventario);
            }

            return ls;
        }
        public int MaxId(BE.cls01_Inventario inventario)
        {
            int ls=0;
            DataTable tabla = acc.Leer("MAXInventario", null);

            foreach (DataRow dr in tabla.Rows)
            {
                inventario.Idinventario = int.Parse(dr["IdInventario"].ToString());
            }

            return ls=inventario.Idinventario;
        }
    }
}
