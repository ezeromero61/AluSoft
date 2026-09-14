using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls12_Catalogo:cls01_Inventario
    {
        private int idcatalogo;

        public int Idcatalogo
        {
            get { return idcatalogo; }
            set { idcatalogo = value; }
        }

        private int idlistaprecio;

        public int Idlistaprecio
        {
            get { return idlistaprecio; }
            set { idlistaprecio = value; }
        }

        private int preciounitario;

        public int Preciounitario
        {
            get { return preciounitario; }
            set { preciounitario = value; }
        }
        private string disponibilidad;

        public string Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        //private string combo;

        //public string Combo
        //{
        //    get { return combo; }
        //    set { combo = value; }
        //}

    }
}
