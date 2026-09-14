using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Minimo
    {
        mapMinimo mapper = new mapMinimo();
        public int Agregar(BE.cls20_Minimo minimo)
        {
            int fa;
            fa = mapper.Agregar(minimo);
            return fa;
        }
        public int Editar(BE.cls20_Minimo minimo)
        {
            int fa;
            fa = mapper.Editar(minimo);
            return fa;
        }
        public int Eliminar(BE.cls20_Minimo minimo)
        {
            int fa;
            fa = mapper.Eliminar(minimo);
            return fa;
        }
        public int Max(BE.cls20_Minimo minimo)
        {
            int fa;
            fa = mapper.MaxId(minimo);
            return fa;
        }
        public List<BE.cls20_Minimo> ListarCatalogo()
        {
            List<BE.cls20_Minimo> minimo = mapper.Listar();
            return minimo;
        }
    }
}
