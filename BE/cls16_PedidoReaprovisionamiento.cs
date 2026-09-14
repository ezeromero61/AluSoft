using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls16_PedidoReaprovisionamiento
    {
        // Identificación
        private int idpedidoreaprovisionamiento;
        public int Idpedidoreaprovisionamiento
        {
            get { return idpedidoreaprovisionamiento; }
            set { idpedidoreaprovisionamiento = value; }
        }

        //private string numeropedido;
        //public string Numeropedido
        //{
        //    get { return numeropedido; }
        //    set { numeropedido = value; }
        //}

        // Proveedor
        private int idproveedor;
        public int Idproveedor
        {
            get { return idproveedor; }
            set { idproveedor = value; }
        }

        private string nombreproveedor;
        public string Nombreproveedor
        {
            get { return nombreproveedor; }
            set { nombreproveedor = value; }
        }

        //// Relación (opcional) con orden de producción
        //private int? idordenproduccion;
        //public int? Idordenproduccion
        //{
        //    get { return idordenproduccion; }
        //    set { idordenproduccion = value; }
        //}

        // Fechas
        private DateTime fechapedido;
        public DateTime Fechapedido
        {
            get { return fechapedido; }
            set { fechapedido = value; }
        }

        private DateTime? fechaentregaestimada;
        public DateTime? Fechaentregaestimada
        {
            get { return fechaentregaestimada; }
            set { fechaentregaestimada = value; }
        }

        private DateTime? fechaentregareal;
        public DateTime? Fechaentregareal
        {
            get { return fechaentregareal; }
            set { fechaentregareal = value; }
        }

        // Estado del pedido
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        // Ej: Pendiente, Enviado, Recibido, Cancelado

        // Prioridad
        private string prioridad;
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        //// Importes
        //private decimal subtotal;
        //public decimal Subtotal
        //{
        //    get { return subtotal; }
        //    set { subtotal = value; }
        //}

        //private decimal impuestos;
        //public decimal Impuestos
        //{
        //    get { return impuestos; }
        //    set { impuestos = value; }
        //}

        //private decimal total;
        //public decimal Total
        //{
        //    get { return total; }
        //    set { total = value; }
        //}

        // Observaciones
        private string observaciones;
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        // Usuario responsable
        private int idlogin;
        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
        }
        private int digitoverificador;

        public int DigitoVerificador
        {
            get { return digitoverificador; }
            set { digitoverificador = value; }
        }
        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }

    }
}
