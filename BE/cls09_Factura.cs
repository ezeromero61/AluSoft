using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls09_Factura
    {
        private int idfactura;
        public int Idfactura
        {
            get { return idfactura; }
            set
            {
                idfactura = value; }
        }

        private string numerofactura;
        public string NumeroFactura
        {
            get { return numerofactura; }
            set
            { numerofactura = value; }
        }

        private string tipofactura;
        public string TipoFactura
        {
            get { return tipofactura; }
            set { tipofactura = value; }
        }

        private int idpedido;
        public int IdPedido
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
        private int idinventario;

        public int Idinventario
        {
            get { return idinventario; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idinventario = value; }
        }
        private string nombreinventario;

        public string Nombreinventario
        {
            get { return nombreinventario; }
            set { nombreinventario = value; }
        }

        private int idcliente;
        public int IdCliente
        {
            get { return idcliente; }
            set
            {
                if (value <= 0)
                {
                }
                idcliente = value; }
        }

        private string nombrecliente;
        public string NombreCliente
        {
            get { return nombrecliente; }
            set { nombrecliente = value; }
        }
        private string apellidocliente;

        public string Apellidocliente
        {
            get { return apellidocliente; }
            set { apellidocliente = value; }
        }

        private int documento;
        public int Documento
        {
            get { return documento; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                documento = value; }
        }

        private double cuit;
        public double CUIT
        {
            get { return cuit; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                cuit = value; }
        }

        private string condicionIVA;
        public string CondicionIVA
        {
            get { return condicionIVA; }
            set { condicionIVA = value; }
        }

        private string direccionfiscal;
        public string DireccionFiscal
        {
            get { return direccionfiscal; }
            set { direccionfiscal = value; }
        }

        private DateTime fechaemision;
        public DateTime FechaEmision
        {
            get { return fechaemision; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaemision = value; }
        }

        private DateTime fechavencimiento;
        public DateTime FechaVencimiento
        {
            get { return fechavencimiento; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechavencimiento = value; }
        }

        private decimal subtotal;
        public decimal Subtotal
        {
            get { return subtotal; }
            set
            {
                if (value < 0)
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
                        "El número debe ser mayor a 0.");
                }
                descuento = value; }
        }

        private decimal iva;
        public decimal IVA
        {
            get { return iva; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                iva = value; }
        }

        private decimal total;
        public decimal Total
        {
            get { return total; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                total = value; }
        }

        private string formapago;
        public string Formapago
        {
            get { return formapago; }
            set { formapago = value; }
        }

        private bool pagada;
        public bool Pagada
        {
            get { return pagada; }
            set { pagada = value; }
        }

        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string cae;
        public string CAE
        {
            get { return cae; }
            set { cae = value; }
        }

        private DateTime? fechavencimientoCAE;
        public DateTime? FechaVencimientoCAE
        {
            get { return fechavencimientoCAE; }
            set { fechavencimientoCAE = value; }
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

    }
}
