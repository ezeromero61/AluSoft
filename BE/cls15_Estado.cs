using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls15_Estado
    {
        private int idestado;

        public int Idestado
        {
            get { return idestado; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idestado = value; }
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
        private DateTime fechaorden;

        public DateTime Fechaorden
        {
            get { return fechaorden; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaorden = value; }
        }

        private DateTime fechainicioproduccion;

        public DateTime Fechainicioproduccion
        {
            get { return fechainicioproduccion; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechainicioproduccion = value; }
        }

        private DateTime fechafinproduccion;

        public DateTime Fechafinproduccion
        {
            get { return fechafinproduccion; }
            set {
                // Vacía (MinValue) = todavía sin fecha: se guarda NULL.
                if (value == DateTime.MinValue) { fechafinproduccion = value; return; }
                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechafinproduccion = value; }
        }

        private DateTime fechaentrega;

        public DateTime Fechaentrega
        {
            get { return fechaentrega; }
            set
            {
                // Vacía (MinValue) = todavía sin fecha: se guarda NULL.
                if (value == DateTime.MinValue) { fechaentrega = value; return; }
                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaentrega = value; }
        }

        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
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
