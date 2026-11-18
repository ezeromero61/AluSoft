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
    public class Produccion
    {
        mapProduccion mapper = new mapProduccion();
        public int Agregar(BE.cls21_Produccion produccion)
        {
            int fa;
            fa = mapper.Agregar(produccion);
            return fa;
        }
        public int Editar(BE.cls21_Produccion produccion)
        {
            int fa;
            fa = mapper.Editar(produccion);
            return fa;
        }
        public int Eliminar(BE.cls21_Produccion produccion)
        {
            int fa;
            fa = mapper.Eliminar(produccion);
            return fa;
        }
        public int Max(BE.cls21_Produccion produccion)
        {
            int fa;
            fa = mapper.MaxId(produccion);
            return fa;
        }
        public List<BE.cls21_Produccion> ListarCatalogo()
        {
            List<BE.cls21_Produccion> produccion = mapper.Listar();
            return produccion;
        }
        public List<BE.cls21_Produccion> ListarCatalogo2()
        {
            List<BE.cls21_Produccion> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls21_Produccion stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
