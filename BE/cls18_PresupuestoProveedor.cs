using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls18_PresupuestoProveedor
    {
        private int idpresupuestoproveedor;

        public int Idpresupuestoproveedor
        {
            get { return idpresupuestoproveedor; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idpresupuestoproveedor = value; }
        }
        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        private int idproveedor;

        public int Idproveedor
        {
            get { return idproveedor; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idproveedor = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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

        private DateTime fechapresupuesto;

        public DateTime Fechapresupuesto
        {
            get { return fechapresupuesto; }
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechapresupuesto = value; }
        }
        private DateTime fechavalidez;

        public DateTime Fechavalidez
        {
            get { return fechavalidez; }
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechavalidez = value; }
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
        private int total;

        public int Total
        {
            get { return total; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                total = value; }
        }
        private int subtotal;

        public int Subtotal
        {
            get { return subtotal; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                subtotal = value; }
        }
        private int iva;

        public int Iva
        {
            get { return iva; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                iva = value; }
        }
        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }

    }
}
