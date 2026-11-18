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
    public class OrdenProduccion
    {
        mapOrdenProduccion mapper = new mapOrdenProduccion();
        public int Agregar(BE.cls14_OrdenProduccion orden)
        {
            int fa;
            fa = mapper.Agregar(orden);
            return fa;
        }
        public int Editar(BE.cls14_OrdenProduccion orden)
        {
            int fa;
            fa = mapper.Editar(orden);
            return fa;
        }
        public int UsarStock(int idOrden, int idStock)
        {
            return mapper.UsarStock(idOrden, idStock);
        }
        public int Eliminar(BE.cls14_OrdenProduccion orden)
        {
            int fa;
            fa = mapper.Eliminar(orden);
            return fa;
        }
        public int Max(BE.cls14_OrdenProduccion orden)
        {
            int fa;
            fa = mapper.MaxId(orden);
            return fa;
        }
        public List<BE.cls14_OrdenProduccion> ListarCatalogo()
        {
            List<BE.cls14_OrdenProduccion> orden = mapper.Listar();
            return orden;
        }
        public List<BE.cls14_OrdenProduccion> ListarCatalogo2()
        {
            List<BE.cls14_OrdenProduccion> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls14_OrdenProduccion stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
