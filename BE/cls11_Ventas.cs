using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls11_Ventas
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

        private string numeroventa;
        public string Numeroventa
        {
            get { return numeroventa; }
            set { numeroventa = value; }
        }

        private int idpedido;
        public int Idpedido
        {
            get { return idpedido; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idpedido = value; }
        }

        private int idfactura;
        public int Fdfactura
        {
            get { return idfactura; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idfactura = value; }
        }

        private int idcliente;
        public int Idcliente
        {
            get { return idcliente; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idcliente = value; }
        }
        private int idcobro;
        public int Idcobro
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
        private DateTime fechaventa;
        public DateTime Fechaventa
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
        public DateTime Fechaentrega
        {
            get { return fechaentrega; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaentrega = value; }
        }

        private decimal subtotal;
        public decimal Subtotal
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

        private decimal descuento;
        public decimal Descuento
        {
            get { return descuento; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El valor no puede ser negativo.");
                }
                descuento = value; }
        }

        private decimal impuestos;
        public decimal Impuestos
        {
            get { return impuestos; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El valor no puede ser negativo.");
                }
                impuestos = value; }
        }

        private decimal total;
        public decimal Total
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

        private decimal totalcobrado;
        public decimal Totalcobrado
        {
            get { return totalcobrado; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El valor no puede ser negativo.");
                }
                totalcobrado = value; }
        }

        private decimal saldopendiente;
        public decimal Saldopendiente
        {
            get { return saldopendiente; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El valor no puede ser negativo.");
                }
                saldopendiente = value; }
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
    }
}
