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
        // Cantidad que entró al stock con un remito (ajusta por diferencia si se edita).
        public int IngresarStockRemito(int idRemito, int idPresupuesto, int idStock, int cantidad)
        {
            SqlParameter[] parametro = new SqlParameter[4];
            parametro[0] = new SqlParameter("@IdRemitoProveedor", idRemito);
            parametro[1] = new SqlParameter("@IdPresupuestoProveedor", idPresupuesto);
            parametro[2] = new SqlParameter("@IdStock", idStock);
            parametro[3] = new SqlParameter("@Cantidad", cantidad);
            return acc.Escribir("IngresarStockRemito", parametro);
        }
        public DataTable ListarIngresosRemito()
        {
            return acc.Leer("ListarMovimientoStockRemito", null);
        }
        // Script 13: descuenta del stock lo que usa un pedido (queda como movimiento negativo de la orden).
        public int DescontarStockPedido(int idOrden, int idStock, int cantidad)
        {
            SqlParameter[] parametro = new SqlParameter[3];
            parametro[0] = new SqlParameter("@IdOrdenProduccion", idOrden);
            parametro[1] = new SqlParameter("@IdStock", idStock);
            parametro[2] = new SqlParameter("@Cantidad", cantidad);
            return acc.Escribir("DescontarStockPedido", parametro);
        }
        // Script 13: devuelve al stock lo que había descontado un pedido que se elimina.
        public int DevolverStockPedido(int idPedido)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPedido", idPedido);
            return acc.Escribir("DevolverStockPedido", parametro);
        }
        public int SumarStock(int idStock, int cantidad)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdStock", idStock);
            parametro[1] = new SqlParameter("@Cantidad", cantidad);
            return acc.Escribir("SumarStock", parametro);
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
                stock.Idstock = int.Parse(dr["IdStock"].ToString());
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
                stock.Cantidad_actual = (dr["CantidadActual"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadActual"]));
                stock.Cantidad_minima = (dr["CantidadMinima"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadMinima"]));
                stock.Cantidad_maxima = (dr["CantidadMaxima"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadMaxima"]));

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
                stock.Nombre= (dr["Nombre"].ToString());
                stock.Descripcion = (dr["Descripcion"].ToString());
                stock.Tipo = (dr["Tipo"].ToString());
                stock.Alto = int.Parse(dr["Alto"].ToString());
                stock.Largo = int.Parse(dr["Largo"].ToString());
                stock.Ancho = int.Parse(dr["Ancho"].ToString());
                stock.Material = (dr["Material"].ToString());
                stock.Color = (dr["Color"].ToString());
                stock.Cantidad_actual = (dr["CantidadActual"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadActual"]));
                stock.Cantidad_minima = (dr["CantidadMinima"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadMinima"]));
                stock.Cantidad_maxima = (dr["CantidadMaxima"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadMaxima"]));
                stock.Combo =stock.Nombre;
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
                stock.Cantidad_actual = (dr["CantidadActual"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadActual"]));
                stock.Cantidad_minima = (dr["CantidadMinima"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadMinima"]));
                stock.Cantidad_maxima = (dr["CantidadMaxima"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CantidadMaxima"]));
            }
            return tabla;
        }
    }
}

