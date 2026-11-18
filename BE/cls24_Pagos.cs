using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls24_Pagos
    {
        private int idPago;

        public int IdPago
        {
            get { return idPago; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idPago = value; }
        }

        private int idProveedor;

        public int IdProveedor
        {
            get { return idProveedor; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idProveedor = value; }
        }

        private int idCompras;

        public int IdCompras
        {
            get { return idCompras; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idCompras = value; }
        }

        private DateTime fechaPago;

        public DateTime FechaPago
        {
            get { return fechaPago; }
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaPago = value; }
        }

        private decimal importe;

        public decimal Importe
        {
            get { return importe; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                importe = value; }
        }

        private string formaPago;

        public string FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }

        private string numeroComprobante;

        public string NumeroComprobante
        {
            get { return numeroComprobante; }
            set { numeroComprobante = value; }
        }

        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        private bool anulado;

        public bool Anulado
        {
            get { return anulado; }
            set { anulado = value; }
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
        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

    }
}
