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
    public class Factura
    {
        mapFactura mapper = new mapFactura();
        public int ActualizarEstado(int idFactura, string estado)
        {
            return mapper.ActualizarEstado(idFactura, estado);
        }

        public int Agregar(BE.cls09_Factura factura)
        {
            int fa;
            fa = mapper.Agregar(factura);
            return fa;
        }
        public int Editar(BE.cls09_Factura factura)
        {
            int fa;
            fa = mapper.Editar(factura);
            return fa;
        }
        public int Eliminar(BE.cls09_Factura factura)
        {
            int fa;
            fa = mapper.Eliminar(factura);
            return fa;
        }
        public int Max(BE.cls09_Factura factura)
        {
            int fa;
            fa = mapper.MaxId(factura);
            return fa;
        }
        public List<BE.cls09_Factura> ListarCatalogo()
        {
            List<BE.cls09_Factura> factura = mapper.Listar();
            return factura;
        }
        public List<BE.cls09_Factura> ListarCatalogo2()
        {
            List<BE.cls09_Factura> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls09_Factura stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
