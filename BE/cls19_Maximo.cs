using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls19_Maximo:cls02_Stock
    {
        private int idmaximo;

        public int Idmaximo
        {
            get { return idmaximo; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idmaximo = value; }
        }
        private int idstock;

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
