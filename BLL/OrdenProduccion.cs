using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

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
    }
}
