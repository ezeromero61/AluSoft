using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Factura
    {
        mapFactura mapper = new mapFactura();
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
    }
}
