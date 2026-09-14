using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DigitoVerificador
    {
        mapDigitoVerificador mapper = new mapDigitoVerificador();
        public int CrearDigitoVerificador(object parametro)
        {
            int fa;
            fa = mapper.CrearDigitoVerificador(parametro);
            return fa;
        }
    }
}
