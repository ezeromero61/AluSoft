using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls09_Factura
    {
        // Identificación
        private int idfactura;
        public int Idfactura
        {
            get { return idfactura; }
            set { idfactura = value; }
        }

        private string numerofactura;
        public string NumeroFactura
        {
            get { return numerofactura; }
            set { numerofactura = value; }
        }

        private string tipofactura;
        public string TipoFactura
        {
            get { return tipofactura; }
            set { tipofactura = value; }
        }

        // Relaciones
        private int idpedido;
        public int IdPedido
        {
            get { return idpedido; }
            set { idpedido = value; }
        }

        private int idcliente;
        public int IdCliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        // Datos cliente
        private string nombrecliente;
        public string NombreCliente
        {
            get { return nombrecliente; }
            set { nombrecliente = value; }
        }

        private string documento;
        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        private string cuit;
        public string CUIT
        {
            get { return cuit; }
            set { cuit = value; }
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

        // Fechas
        private DateTime? fechaemision;
        public DateTime? FechaEmision
        {
            get { return fechaemision; }
            set { fechaemision = value; }
        }

        private DateTime? fechavencimiento;
        public DateTime? FechaVencimiento
        {
            get { return fechavencimiento; }
            set { fechavencimiento = value; }
        }

        // Importes
        private decimal subtotal;
        public decimal Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        private decimal descuento;
        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        private decimal iva;
        public decimal IVA
        {
            get { return iva; }
            set { iva = value; }
        }

        private decimal total;
        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        // Pago
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

        // Estado
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        // AFIP
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

        // Observaciones
        private string observaciones;
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        // Usuario
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
        }
    }
}
