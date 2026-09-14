using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class RemitoProveedor
    {
        mapRemitoProveedor mapper = new mapRemitoProveedor();
        public int Agregar(BE.cls23_RemitoProveedor prov)
        {
            int fa;
            fa = mapper.Agregar(prov);
            return fa;
        }
        public int Editar(BE.cls23_RemitoProveedor prov)
        {
            int fa;
            fa = mapper.Editar(prov);
            return fa;
        }
        public int Eliminar(BE.cls23_RemitoProveedor prov)
        {
            int fa;
            fa = mapper.Eliminar(prov);
            return fa;
        }
        public int Max(BE.cls23_RemitoProveedor prov)
        {
            int fa;
            fa = mapper.MaxId(prov);
            return fa;
        }
        public List<BE.cls23_RemitoProveedor> ListarCatalogo()
        {
            List<BE.cls23_RemitoProveedor> prov = mapper.Listar();
            return prov;
        }
    }
}
