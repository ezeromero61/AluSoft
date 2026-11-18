using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class clsValidacionesPerdurables
    {
        public static DateTime FechaObligatoria(DateTime fecha,string campo)
        {
            if (fecha == DateTime.MinValue)
                throw new ArgumentException(
                    $"El campo {campo} es obligatorio.");
            if (fecha.Year < 1753)
                throw new ArgumentException(
                    $"El campo {campo} contiene una fecha inválida.");
            return fecha;
        }

        public static DateTime FechaNoFutura(DateTime fecha,string campo)
        {
            FechaObligatoria(fecha, campo);
            if (fecha.Date > DateTime.Today)
                throw new ArgumentException(
                    $"El campo {campo} no puede contener una fecha futura.");
            return fecha;
        }

        // [NUEVO] Fecha de nacimiento: no puede ser futura ni de hoy, y la persona tiene que tener
        // entre 18 y 120 años (clientes, proveedores y empleados son mayores de edad).
        public static DateTime FechaNacimiento(DateTime fecha, string campo)
        {
            FechaNoFutura(fecha, campo);
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - fecha.Year;
            if (fecha.Date > hoy.AddYears(-edad)) edad--;
            if (edad < 18)
                throw new ArgumentException($"El campo {campo} no es válido: la persona tiene que ser mayor de 18 años.");
            if (edad > 120)
                throw new ArgumentException($"El campo {campo} no es válido.");
            return fecha;
        }

        public static DateTime FechaPosterior( DateTime fecha, DateTime fechaReferencia, string campo)
        {
            FechaObligatoria(fecha, campo);
            if (fecha.Date < fechaReferencia.Date)
                throw new ArgumentException(
                    $"El campo {campo} no puede ser anterior a {fechaReferencia:d}.");
            return fecha;
        }
        public static double SoloNumerosDouble(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException(
                    $"El campo {campo} no puede estar vacío.");
            }

            if (!double.TryParse(valor, out double numero))
            {
                throw new ArgumentException(
                    $"El campo {campo} solo puede contener números.");
            }

            return numero;
        }
        public static long NumeroLargo(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"El campo {campo} no puede estar vacío.");
            long numero;
            if (!long.TryParse(valor.Trim(), out numero) || numero < 0)
                throw new ArgumentException($"El campo {campo} solo puede contener números.");
            return numero;
        }
        public static int SoloNumeros(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException(
                    $"El campo {campo} no puede estar vacío.");
            }

            if (!int.TryParse(valor, out int numero))
            {
                throw new ArgumentException(
                    $"El campo {campo} solo puede contener números.");
            }

            return numero;
        }
    }
}
