using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls14_OrdenProduccion
    {
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
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                cantidad = value; }
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
        public int IdPedido { get; set; }

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
