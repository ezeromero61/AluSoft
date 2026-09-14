using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls07_PresupuestoCliente
    {
        // Identificación
        private int idpresupuesto;

        public int Idpresupuesto
        {
            get { return idpresupuesto; }
            set { idpresupuesto = value; }
        }
        // Cliente
        private int idcliente;

        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }
        // Fechas
        private DateTime fechacreacion;

        public DateTime FechaCreacion
        {
            get { return fechacreacion; }
            set { fechacreacion = value; }
        }
        private DateTime fechavalidez;

        public DateTime FechaValidez
        {
            get { return fechavalidez; }
            set { fechavalidez = value; }
        }
        // Estado del presupuesto
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        // Descripción general
        private int idcatalogo;

        public int Idcatalogo
        {
            get { return idcatalogo; }
            set { idcatalogo = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
        // Totales
        private int subtotal;

        public int Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        private int descuento;

        public int Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
        private int impuestos;

        public int Impuestos
        {
            get { return impuestos; }
            set { impuestos = value; }
        }
        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        // Condiciones comerciales
        private string formapago;

        public string FormaPago
        {
            get { return formapago; }
            set { formapago = value; }
        }
        private int plazoentregaDias;

        public int PlazoEntregaDias
        {
            get { return plazoentregaDias; }
            set { plazoentregaDias = value; }
        }
        // Usuario que lo creó
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
        }
    }
}
