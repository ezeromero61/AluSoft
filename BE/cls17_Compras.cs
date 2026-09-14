using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls17_Compras
    {
        private int idcompras;

        public int Idcompras
        {
            get { return idcompras; }
            set { idcompras = value; }
        }
        private int idpago;

        public int Idpago
        {
            get { return idpago; }
            set { idpago = value; }
        }

        private int idstock;

        public int Idstock
        {
            get { return idstock; }
            set { idstock = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        private int subtotal;

        public int Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

    }
}
