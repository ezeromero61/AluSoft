using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls19_Maximo:cls02_Stock
    {
        private int idmaximo;

        public int Idmaximo
        {
            get { return idmaximo; }
            set { idmaximo = value; }
        }
        private int idstock;

        //public int Idstock
        //{
        //    get { return idstock; }
        //    set { idstock = value; }
        //}
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
