using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Proveedor
    {
        mapProveedor mapper = new mapProveedor();
        public int Agregar(BE.cls04_Proveedor prov)
        {
            int fa;
            fa = mapper.Agregar(prov);
            return fa;
        }
        public int Editar(BE.cls04_Proveedor prov)
        {
            int fa;
            fa = mapper.Editar(prov);
            return fa;
        }
        public int Eliminar(BE.cls04_Proveedor prov)
        {
            int fa;
            fa = mapper.Eliminar(prov);
            return fa;
        }
        public int Max(BE.cls04_Proveedor prov)
        {
            int fa;
            fa = mapper.MaxId(prov);
            return fa;
        }
        public List<BE.cls04_Proveedor> ListarCatalogo()
        {
            List<BE.cls04_Proveedor> prov = mapper.Listar();
            return prov;
        }
    }
}
