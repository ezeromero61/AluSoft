using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls22_Reportes
    {
        private int idreporte;

        public int Idreporte
        {
            get { return idreporte; }
            set { idreporte = value; }
        }
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
        }
        private int idventa;

        public int Idventa
        {
            get { return idventa; }
            set { idventa = value; }
        }
        private int idcompras;

        public int Idcompras
        {
            get { return idcompras; }
            set { idcompras = value; }
        }
        private int idproduccion;

        public int Idproduccion
        {
            get { return idproduccion; }
            set { idproduccion = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }
}
