using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls08_PedidoCliente
    {
        // Identificación
        private int idpedido;

        public int IdPedido
        {
            get { return idpedido; }
            set { idpedido = value; }
        }
        // Relación con presupuesto (MUY IMPORTANTE)
        private int idpresupuesto;

        public int Idpresupuesto
        {
            get { return idpresupuesto; }
            set { idpresupuesto = value; }
        }
        // Cliente


        // Fechas
        private DateTime fechapedido;

        public DateTime Fechapedido
        {
            get { return fechapedido; }
            set { fechapedido = value; }
        }
        private DateTime fechaentregaestimada;

        public DateTime Fechaentregaestimada
        {
            get { return fechaentregaestimada; }
            set { fechaentregaestimada = value; }
        }
        private DateTime fechaentregareal;

        public DateTime Fechaentregareal
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
        // Observaciones
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        // Usuario que lo registró
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
        }
    }
}
