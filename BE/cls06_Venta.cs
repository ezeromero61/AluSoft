using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls06_Venta:cls09_Factura
    {
		private int idventa;

		public int Idventa
		{
			get { return idventa; }
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idventa = value; }
		}
		private DateTime fechaventa;

		public DateTime FechaVenta
		{
			get { return fechaventa; }
			set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaventa = value; }
		}
		private DateTime fechaentrega;

		public DateTime FechaEntrega
		{
			get { return fechaentrega; }
			set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaentrega = value; }
		}
		private int totalcobrado;

		public int TotalCobrado
		{
			get { return totalcobrado; }
			set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                totalcobrado = value; }
		}
        private int idcobro;
        private int saldopendiente;

        public int SalfoPendiente
        {
            get { return saldopendiente; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                saldopendiente = value; }
        }

        public int IdCobro
        {
            get { return idcobro; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idcobro = value; }
        }
        private int impuestos;

        public int Impuestos
        {
            get { return impuestos; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                impuestos = value; }
        }

        private string numeroventa;

        public string NumeroVenta
        {
            get { return numeroventa; }
            set { numeroventa = value; }
        }

    }
}
