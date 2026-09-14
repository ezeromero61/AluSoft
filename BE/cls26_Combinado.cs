using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls26_Combinado
    {
        // =========================
        // DATOS DEL PRESUPUESTO
        // =========================

        private int idpresupuesto;

        public int Idpresupuesto
        {
            get { return idpresupuesto; }
            set { idpresupuesto = value; }
        }

        private int idcliente;

        public int Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
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
        private int idcataqlogo;

        public int IdCatalogo
        {
            get { return idcataqlogo; }
            set { idcataqlogo = value; }
        }
        private string producto;

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }
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
        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }

    }
}
