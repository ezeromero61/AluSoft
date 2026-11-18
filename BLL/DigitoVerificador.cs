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

        public static int CalcularLogin(string usuario, string contraseña, int idRol)
        {
            int suma = idRol;
            foreach (char c in ((usuario ?? "").Trim() + (contraseña ?? "").Trim()))
                suma += (int)c;
            return suma;
        }
    }
}
