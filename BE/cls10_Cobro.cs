using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls10_Cobro:cls09_Factura
    {
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

        private string numeroCobro;
        public string Numerocobro
        {
            get { return numeroCobro; }
            set { numeroCobro = value; }
        }

        private int idfactura;
        public int Idfactura
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

        private DateTime fechacobro;
        public DateTime Fechacobro
        {
            get { return fechacobro; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechacobro = value; }
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

        private string formapago;
        public string Formapago
        {
            get { return formapago; }
            set { formapago = value; }
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
        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }

    }
}
