using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Ventas
    {
        mapVentas mapper = new mapVentas();
        public int Agregar(BE.cls11_Ventas ven)
        {
            int fa;
            fa = mapper.Agregar(ven);
            return fa;
        }
        public int Editar(BE.cls11_Ventas venta)
        {
            int fa;
            fa = mapper.Editar(venta);
            return fa;
        }
        public int Eliminar(BE.cls11_Ventas venta)
        {
            int fa;
            fa = mapper.Eliminar(venta);
            return fa;
        }
        public int Max(BE.cls11_Ventas venta)
        {
            int fa;
            fa = mapper.MaxId(venta);
            return fa;
        }
        public List<BE.cls11_Ventas> ListarCatalogo()
        {
            List<BE.cls11_Ventas> venta = mapper.Listar();
            return venta;
        }
    }
}
