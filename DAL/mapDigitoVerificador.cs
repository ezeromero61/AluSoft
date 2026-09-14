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
        //public bool VerificadorDigitoVerificador(object parametro)
        //{
            //ConsultarBitacora(IdBitacora);
            //int verificador2 = clsCifrado.DesencriptartInt(digitoverificador.ToString());
            //int verificador1 = ContadorDigitoVerificador(IdBitacora);
            //if (verificador1 == verificador2)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        //}
    }
}
