using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Stock
    {
        mapStock mapper = new mapStock();
        public int Agregar(BE.cls02_Stock stock)
        {
            int fa;
            fa = mapper.Agregar(stock);
            return fa;
        }
        public int Editar(BE.cls02_Stock stock)
        {
            int fa;
            fa = mapper.Editar(stock);
            return fa;
        }
        public int Eliminar(BE.cls02_Stock stock)
        {
            int fa;
            fa = mapper.Eliminar(stock);
            return fa;
        }
        public DataTable Consultar(BE.cls02_Stock stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
        public int Max(BE.cls02_Stock stock)
        {
            int fa;
            fa = mapper.MaxId(stock);
            return fa;
        }
        public List<BE.cls02_Stock> ListarCatalogo()
        {
            List<BE.cls02_Stock> stock = mapper.Listar();
            return stock;
        }
        public List<BE.cls02_Stock> ListarCatalogo2()
        {
            List<BE.cls02_Stock> stock = mapper.Listar2();
            return stock;
        }
    }
}
