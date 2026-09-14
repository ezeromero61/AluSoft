using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls10_Cobro
    {
        // Identificación
        private int idcobro;
        public int Idcobro
        {
            get { return idcobro; }
            set { idcobro = value; }
        }

        private string numeroCobro;
        public string Numerocobro
        {
            get { return numeroCobro; }
            set { numeroCobro = value; }
        }

        // Relación con factura
        private int idfactura;
        public int Idfactura
        {
            get { return idfactura; }
            set { idfactura = value; }
        }

        // Cliente (opcional pero útil para consultas)
        private int idcliente;
        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        // Fecha del cobro
        private DateTime? fechacobro;
        public DateTime? Fechacobro
        {
            get { return fechacobro; }
            set { fechacobro = value; }
        }

        // Importe
        private decimal importe;
        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        // Forma de pago
        private string formapago;
        public string Formapago
        {
            get { return formapago; }
            set { formapago = value; }
        }

        // Datos adicionales según forma de pago
        //private string numerocomprobante;
        //public string Numerocomprobante
        //{
        //    get { return numerocomprobante; }
        //    set { numerocomprobante = value; }
        //}

        //private string banco;
        //public string Banco
        //{
        //    get { return banco; }
        //    set { banco = value; }
        //}

        // Estado del cobro
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        // Ej: Confirmado, Pendiente, Rechazado

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
