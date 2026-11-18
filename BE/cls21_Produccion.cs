using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls21_Produccion
    {
        private int idproduccion;

        public int Idproduccion
        {
            get { return idproduccion; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idproduccion = value; }
        }
        private int idordenproduccion;

        public int Idordenproduccion
        {
            get { return idordenproduccion; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idordenproduccion = value; }
        }
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idlogin = value; }
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
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}
