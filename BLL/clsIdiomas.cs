using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class clsIdiomas
    {
        public static List<string> CambiarIdiomas(int numerodeidioma)
        {
            List<string> lenguajes = new List<string>();
            if (numerodeidioma == 1)
            {
                lenguajes.Add("Español");
                lenguajes.Add("English");
            }
            else if (numerodeidioma == 2)
            {
                lenguajes.Add("English");
                lenguajes.Add("Español");
            }
            else if (numerodeidioma == 3)
            {
                lenguajes.Add("English");
                lenguajes.Add("Español");
            }
            else if (numerodeidioma == 4)
            {
                lenguajes.Add("English");
                lenguajes.Add("Español");
            }
            else
            {
                lenguajes.Add("Español");
                lenguajes.Add("English");
            }
            return lenguajes;
        }
    }
}
