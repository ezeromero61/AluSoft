using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls20_Minimo:cls02_Stock
    {
        private int idminimo;

        public int Idminimo
        {
            get { return idminimo; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idminimo = value; }
        }
        private int idstock;

        public int Idstock
        {
            get { return idstock; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idstock = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fecha = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El valor no puede ser negativo.");
                }
                cantidad = value; }
        }
        private int digitoverificador;

        public int DigitoVerificador
        {
            get { return digitoverificador; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                digitoverificador = value; }
        }

    }
}
