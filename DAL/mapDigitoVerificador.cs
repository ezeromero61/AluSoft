using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class mapDigitoVerificador
    {
        public int CrearDigitoVerificador(object parametro)
        {
            int cantidadCaracteres = 0;
            if (parametro == null)
            {
                cantidadCaracteres= 0;
                return cantidadCaracteres;
            }
            else
            {
                cantidadCaracteres= parametro.ToString().Length;
                return cantidadCaracteres;
            }        
        }
    }
}
