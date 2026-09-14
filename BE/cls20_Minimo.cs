using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls20_Minimo:cls02_Stock
    {
        private int idminimo;

        public int Idminimo
        {
            get { return idminimo; }
            set { idminimo = value; }
        }
        private int idstock;

        public int Idstock
        {
            get { return idstock; }
            set { idstock = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private int digitoverificador;

        public int DigitoVerificador
        {
            get { return digitoverificador; }
            set { digitoverificador = value; }
        }

    }
}
