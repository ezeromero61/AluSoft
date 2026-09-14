using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Cobro
    {
        mapCobro mapper = new mapCobro();
        public int Agregar(BE.cls10_Cobro cobro)
        {
            int fa;
            fa = mapper.Agregar(cobro);
            return fa;
        }
        public int Editar(BE.cls10_Cobro cobro)
        {
            int fa;
            fa = mapper.Editar(cobro);
            return fa;
        }
        public int Eliminar(BE.cls10_Cobro cobro)
        {
            int fa;
            fa = mapper.Eliminar(cobro);
            return fa;
        }
        public int Max(BE.cls10_Cobro cobro)
        {
            int fa;
            fa = mapper.MaxId(cobro);
            return fa;
        }
        public List<BE.cls10_Cobro> ListarCatalogo()
        {
            List<BE.cls10_Cobro> cobro = mapper.Listar();
            return cobro;
        }
    }
}
