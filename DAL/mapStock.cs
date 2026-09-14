using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapStock
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls02_Stock stock)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[5];

            parametro[0] = new SqlParameter("@IdStock", stock.Idstock);
            parametro[1] = new SqlParameter("@IdInventario", stock.Idinventario);
            parametro[2] = new SqlParameter("@CantidadActual", stock.Cantidad_actual);
            parametro[3] = new SqlParameter("@CantidadMinima", stock.Cantidad_minima);
            parametro[4] = new SqlParameter("@CantidadMaxima", stock.Cantidad_maxima);

            fa = acc.Escribir("AgregarStock", parametro);

            return fa;
        }
        public int Editar(BE.cls02_Stock stock)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[5];

            parametro[0] = new SqlParameter("@IdStock", stock.Idstock);
            parametro[1] = new SqlParameter("@IdInventario", stock.Idinventario);
            parametro[2] = new SqlParameter("@CantidadActual", stock.Cantidad_actual);
            parametro[3] = new SqlParameter("@CantidadMinima", stock.Cantidad_minima);
            parametro[4] = new SqlParameter("@CantidadMaxima", stock.Cantidad_maxima);

            fa = acc.Escribir("EditarStock", parametro);

            return fa;
        }
        public int Eliminar(BE.cls02_Stock stock)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdStock", stock.Idstock);

            fa = acc.Escribir("EliminarStock", parametro);

            return fa;
        }
        public int MaxId(BE.cls02_Stock stock)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdStock", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                stock.Idstock = int.Parse(dr["IdStock"].ToString());
                //ls=(inventario.Idinventario);
            }


            return ls = stock.Idstock;
        }
        public List<BE.cls02_Stock> Listar()
        {
            List<BE.cls02_Stock> ls = new List<BE.cls02_Stock>();

            DataTable tabla = acc.Leer("ListarStock", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls02_Stock stock = new BE.cls02_Stock();

                stock.Idstock = int.Parse(dr["IdStock"].ToString());
                stock.Idinventario = int.Parse(dr["IdInventario"].ToString());
                stock.Cantidad_actual = int.Parse(dr["CantidadActual"].ToString());
                stock.Cantidad_minima = int.Parse(dr["CantidadMinima"].ToString());
                stock.Cantidad_maxima = int.Parse(dr["CantidadMaxima"].ToString());

                ls.Add(stock);
            }

            return ls;
        }
        public List<BE.cls02_Stock> Listar2()
        {
            List<BE.cls02_Stock> ls = new List<BE.cls02_Stock>();
            DataTable tabla = acc.Leer("Obtener_02_StockInventario", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls02_Stock stock = new BE.cls02_Stock();
                stock.Idstock = int.Parse(dr["IdStock"].ToString());
                stock.Idinventario = int.Parse(dr["IdInventario"].ToString());
                stock.Nombre= (dr["CantidadActual"].ToString());
                stock.Descripcion = (dr["CantidadActual"].ToString());
                stock.Tipo = (dr["Tipo"].ToString());
                stock.Alto = int.Parse(dr["Alto"].ToString());
                stock.Largo = int.Parse(dr["Largo"].ToString());
                stock.Ancho = int.Parse(dr["Ancho"].ToString());
                stock.Material = (dr["Material"].ToString());
                stock.Color = (dr["Color"].ToString());
                stock.Cantidad_actual = int.Parse(dr["CantidadActual"].ToString());
                stock.Cantidad_minima = int.Parse(dr["CantidadMinima"].ToString());
                stock.Cantidad_maxima = int.Parse(dr["CantidadMaxima"].ToString());
                ls.Add(stock);
            }
            return ls;
        }
        
        public DataTable Consultar(BE.cls02_Stock stock, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdStock", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdStockIdInventario", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                stock.Idstock = int.Parse(dr["IdStock"].ToString());
                stock.Idinventario = int.Parse(dr["IdInventario"].ToString());
                stock.Nombre = dr["Nombre"].ToString();
                stock.Descripcion = dr["Descripcion"].ToString();
                stock.Tipo = dr["Tipo"].ToString();
                stock.Alto = int.Parse(dr["Alto"].ToString());
                stock.Largo = int.Parse(dr["Largo"].ToString());
                stock.Ancho = int.Parse(dr["Ancho"].ToString());
                stock.Material = dr["Material"].ToString();
                stock.Color = dr["Color"].ToString();
                stock.Cantidad_actual = int.Parse(dr["CantidadActual"].ToString());
                stock.Cantidad_minima = int.Parse(dr["CantidadMinima"].ToString());
                stock.Cantidad_maxima = int.Parse(dr["CantidadMaxima"].ToString());
            }
            return tabla;
        }
    }
}

