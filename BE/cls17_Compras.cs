using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls17_Compras
    {
        private int idcompras;

        public int Idcompras
        {
            get { return idcompras; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idcompras = value; }
        }
        private int idpago;

        public int Idpago
        {
            get { return idpago; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idpago = value; }
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
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                myVar = value; }
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
        public int IdProveedor { get; set; }
        public int IdPedidoReaprovisionamiento { get; set; }
        public string NombreEmpresa { get; set; }
        public decimal Pagado { get; set; }
        public decimal Saldo { get { return Total - Pagado; } }

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
