using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls08_PedidoCliente : cls07_PresupuestoCliente
    {
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

        private DateTime fechapedido;

        public DateTime Fechapedido
        {
            get { return fechapedido; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechapedido = value; }
        }
        private DateTime fechaentregaestimada;

        public DateTime Fechaentregaestimada
        {
            get { return fechaentregaestimada; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaentregaestimada = value; }
        }
        private DateTime fechaentregareal;

        public DateTime Fechaentregareal
        {
            get { return fechaentregareal; }
            set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaentregareal = value; }
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
        private string nombreproducto;

        public string NombreProducto
        {
            get { return nombreproducto; }
            set { nombreproducto = value; }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
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

    }
}
