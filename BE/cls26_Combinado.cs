using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls26_Combinado
    {

        private int idpresupuesto;

        public int Idpresupuesto
        {
            get { return idpresupuesto; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idpresupuesto = value; }
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
                        "El Inúmero debe ser mayor a 0.");
                }
                idcliente = value; }
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
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idcataqlogo = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
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
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechacreacion = value; }
        }
        private DateTime fechavalidez;

        public DateTime FechaValidez
        {
            get { return fechavalidez; }
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechavalidez = value; }
        }
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
        private int subtotal;

        public int Subtotal
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
        private int descuento;

        public int Descuento
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
        private int total;

        public int Total
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

        public string FormaPago
        {
            get { return formapago; }
            set { formapago = value; }
        }
        private int plazoentregaDias;

        public int PlazoEntregaDias
        {
            get { return plazoentregaDias; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                plazoentregaDias = value; }
        }
      
        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }
        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

    }
}
