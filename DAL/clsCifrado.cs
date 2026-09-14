using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsCifrado
    {
        public static string EncriptarString(string plainText)
        {
            if (plainText is null)
            {
                return "";
            }
            else
            {
                char[] chars = plainText.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    char letter = chars[i];
                    if (letter >= 'a' && letter <= 'z')
                    {
                        letter = (char)(((letter - 'a' + 7) % 26) + 'a');
                    }
                    else if (letter >= 'A' && letter <= 'Z')
                    {
                        letter = (char)(((letter - 'A' + 7) % 26) + 'A');
                    }
                    chars[i] = letter;
                }
                return new string(chars);
            }

        }
        public static string DesencriptarString(string cipherText)
        {
            if (cipherText is null)
            {
                return "";
            }
            else
            {
                if (int.TryParse(cipherText, out int result))
                {
                    return result.ToString();
                }
                else
                {
                    char[] chars = cipherText.ToCharArray();
                    for (int i = 0; i < chars.Length; i++)
                    {
                        char letter = chars[i];
                        if (letter >= 'a' && letter <= 'z')
                        {
                            letter = (char)(((letter - 'a' + 19) % 26) + 'a');
                        }
                        else if (letter >= 'A' && letter <= 'Z')
                        {
                            letter = (char)(((letter - 'A' + 19) % 26) + 'A');
                        }
                        chars[i] = letter;
                    }
                    return new string(chars);
                }
            }
            //return EncriptarString(cipherText);   
        }
        public static int EncriptarInteger(int numero)
        {
            string parcial = null;
            int resultado = 0;
            string DeNumeroAString = numero.ToString();
            char[] chars = DeNumeroAString.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                int Unidad = Convert.ToInt32(chars[i]) - 48;
                int j = Convert.ToInt32(chars[0]) - 48;
                if (j == 7 && i == 0)
                {
                    parcial = "7";
                }
                else
                {
                    if (Unidad >= 7)
                    {
                        parcial = parcial + Convert.ToString((Unidad + 3) - 10);
                    }
                    else
                    {
                        parcial = parcial + Convert.ToString(Unidad + 3);
                    }
                }
            }
            return resultado = Convert.ToInt32(parcial);
        }
        public static int EncriptarInteger2(int numero)
        {
            string parcial = "";
            string DeNumeroAString = numero.ToString();
            char[] chars = DeNumeroAString.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                int Unidad = chars[i] - '0'; // Convierte char numérico a int
                int encriptado = (Unidad + 3) % 10; // Suma 3 y aplica módulo 10
                parcial += encriptado.ToString();
            }

            return int.Parse(parcial);
        }
        public static int DesencriptartInt(string numero)
        {
            string parcial = null;
            int resultado = 0;
            string DeNumeroAString = numero.ToString();
            char[] chars = DeNumeroAString.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                int Unidad = Convert.ToInt32(chars[i]) - 48;
                int j = Convert.ToInt32(chars[0]) - 48;
                if (j == 7 && i == 0)
                {
                    parcial = "7";
                }
                else
                {
                    if (Unidad < 3)
                    {
                        parcial = parcial + Convert.ToString((Unidad + 10) - 3);
                    }
                    else
                    {
                        parcial = parcial + Convert.ToString(Unidad - 3);
                    }
                }
            }
            return resultado = Convert.ToInt32(parcial);
        }
        public static int DesencriptarInt2(string numero)
        {
            string parcial = "";
            char[] chars = numero.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                int Unidad = chars[i] - '0'; // Convierte char numérico a int
                int desencriptado = (Unidad + 10 - 3) % 10; // Resta 3 usando módulo inverso
                parcial += desencriptado.ToString();
            }

            return int.Parse(parcial);
        }
        public static double EncriptarDouble(double numero)
        {
            string parcial = null;
            double resultado = 0;
            string DeNumeroAString = numero.ToString();
            char[] chars = DeNumeroAString.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                int Unidad = Convert.ToInt32(chars[i]) - 48;
                int j = Convert.ToInt32(chars[0]) - 48;
                if (j == 7 && i == 0)
                {
                    parcial = "7";
                }
                else
                {
                    if (Unidad >= 7)
                    {
                        parcial = parcial + Convert.ToString((Unidad + 3) - 10);
                    }
                    else
                    {
                        parcial = parcial + Convert.ToString(Unidad + 3);
                    }
                }
            }
            return resultado = Convert.ToInt64(parcial);
        }
        public static double DesencriptarDouble(string numero)
        {
            string parcial = null;
            double resultado = 0;
            string DeNumeroAString = numero.ToString();
            char[] chars = DeNumeroAString.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                int Unidad = Convert.ToInt32(chars[i]) - 48;
                int j = Convert.ToInt32(chars[0]) - 48;
                if (j == 7 && i == 0)
                {
                    parcial = "7";
                }
                else
                {
                    if (Unidad < 3)
                    {
                        parcial = parcial + Convert.ToString((Unidad + 10) - 3);
                    }
                    else
                    {
                        parcial = parcial + Convert.ToString(Unidad - 3);
                    }
                }
            }
            return resultado = Convert.ToInt64(parcial);
        }
    }
}
