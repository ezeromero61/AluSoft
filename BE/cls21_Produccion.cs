using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls21_Produccion
    {
        private int idproduccion;

        public int Idproduccion
        {
            get { return idproduccion; }
            set { idproduccion = value; }
        }
        private int idordenproduccion;

        public int Idordenproduccion
        {
            get { return idordenproduccion; }
            set { idordenproduccion = value; }
        }
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
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
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }


    }
}
