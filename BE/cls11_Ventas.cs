using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls11_Ventas
    {
        // Identificación
        private int idventa;
        public int Idventa
        {
            get { return idventa; }
            set { idventa = value; }
        }

        private string numeroventa;
        public string Numeroventa
        {
            get { return numeroventa; }
            set { numeroventa = value; }
        }

        // Relaciones
        private int idpedido;
        public int Idpedido
        {
            get { return idpedido; }
            set { idpedido = value; }
        }

        private int idfactura;
        public int Fdfactura
        {
            get { return idfactura; }
            set { idfactura = value; }
        }

        private int idcliente;
        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }
        private int idcobro;
        public int Idcobro
        {
            get { return idcobro; }
            set { idcobro = value; }
        }
        // Fechas clave
        private DateTime fechaventa;
        public DateTime Fechaventa
        {
            get { return fechaventa; }
            set { fechaventa = value; }
        }

        private DateTime? fechaentrega;
        public DateTime? Fechaentrega
        {
            get { return fechaentrega; }
            set { fechaentrega = value; }
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

        private decimal impuestos;
        public decimal Impuestos
        {
            get { return impuestos; }
            set { impuestos = value; }
        }

        private decimal total;
        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }

        // Pagos (clave para reportes)
        private decimal totalcobrado;
        public decimal Totalcobrado
        {
            get { return totalcobrado; }
            set { totalcobrado = value; }
        }

        private decimal saldopendiente;
        public decimal Saldopendiente
        {
            get { return saldopendiente; }
            set { saldopendiente = value; }
        }

        // Estado de la venta
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        // Ej: Pendiente, EnProceso, Finalizada, Cancelada
       
        // Observaciones
        private string observaciones;
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        // Usuario / vendedor
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
        }
    }
}
