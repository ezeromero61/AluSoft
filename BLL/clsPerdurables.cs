using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsPerdurables
    {
            public static int numerodeidioma;
            public static int NumeroIdioma
            {
                get; set;
            }
            public static int Id_Login
            { get; set; }

            public static int selector_en_informes
            { get; set; }

            public static string StringIdiomaSeleccionado(int NumeroIdioma)
            {
                string salida = null;
                clsPerdurables numerodeidioma = new clsPerdurables();
                if (NumeroIdioma == 1)
                {
                    salida = "Spanish";
                }
                else if (NumeroIdioma == 2)
                {
                    salida = "English";
                }
                else if (NumeroIdioma == 3)
                {
                    salida = "French";
                }
                else if (NumeroIdioma == 4)
                {
                    salida = "Português";
                }
                return salida;
            }
            public static int IdiomaSeleccionado(string idioma)
            {
                if (idioma == "Spanish")
                {
                    clsPerdurables.numerodeidioma = 1;
                }
                else if (idioma == "English")
                {
                    clsPerdurables.numerodeidioma = 2;
                }
                else if (idioma == "French")
                {
                    clsPerdurables.numerodeidioma = 3;
                }
                else if (idioma == "Português")
                {
                    clsPerdurables.numerodeidioma = 4;
                }
                else
                {
                    clsPerdurables.numerodeidioma = 1;
                }
                return clsPerdurables.numerodeidioma;
            }
            public static DateTime ConvertirFormatoFecha(string fechaString, string formatoEntrada, string formatoSalida)
            {
                // Convertir la cadena de fecha al formato deseado
                try
                {
                    DateTime fecha = DateTime.ParseExact(fechaString, formatoEntrada, System.Globalization.CultureInfo.InvariantCulture);
                    return fecha;
                }
                catch (FormatException)
                {
                    throw new FormatException("Formato de fecha incorrecto.");
                }
            }       
    }
}
