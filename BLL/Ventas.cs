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
    public class Ventas
    {
        mapVentas mapper = new mapVentas();
        public int Agregar(BE.cls06_Venta ven)
        {
            int fa;
            fa = mapper.Agregar(ven);
            return fa;
        }
        public int Editar(BE.cls06_Venta venta)
        {
            int fa;
            fa = mapper.Editar(venta);
            return fa;
        }
        public int Eliminar(BE.cls06_Venta venta)
        {
            int fa;
            fa = mapper.Eliminar(venta);
            return fa;
        }
        public int Max(BE.cls06_Venta venta)
        {
            int fa;
            fa = mapper.MaxId(venta);
            return fa;
        }
        public List<BE.cls06_Venta> ListarCatalogo()
        {
            List<BE.cls06_Venta> venta = mapper.Listar();
            return venta;
        }
        public List<BE.cls06_Venta> ListarCatalogo2()
        {
            List<BE.cls06_Venta> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls06_Venta stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
