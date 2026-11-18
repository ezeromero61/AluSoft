using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls16_PedidoReaprovisionamiento
    {
        private int idpedidoreaprovisionamiento;
        public int Idpedidoreaprovisionamiento
        {
            get { return idpedidoreaprovisionamiento; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idpedidoreaprovisionamiento = value; }
        }

        private int idproveedor;
        public int Idproveedor
        {
            get { return idproveedor; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idproveedor = value; }
        }
        private int idpresupuestoproveedor;

        public int IdPresupuestoProveedor
        {
            get { return idpresupuestoproveedor; }
            set { idpresupuestoproveedor = value; }
        }

        private string nombreproveedor;
        public string Nombreproveedor
        {
            get { return nombreproveedor; }
            set { nombreproveedor = value; }
        }

        private DateTime fechapedido;
        public DateTime Fechapedido
        {
            get { return fechapedido; }
            set
            {
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
            set
            {
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
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fechaentregareal = value; }
        }

        private int catidad;

        public int Cantidad
        {
            get { return catidad; }
            set { catidad = value; }
        }
        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private int iva;

        public int IVA
        {
            get { return iva; }
            set { iva = value; }
        }
        private int subtotal;

        public int Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string prioridad;
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
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
        private int digitoverificador;

        public int DigitoVerificador
        {
            get { return digitoverificador; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                digitoverificador = value; }
        }
        private string combo;

        public string Producto { get; set; }
        public int Idstock { get; set; }
        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }

    }
}
