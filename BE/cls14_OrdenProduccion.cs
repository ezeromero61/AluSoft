using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls14_OrdenProduccion
    {
        // Identificación
        private int idordenproduccion;
        public int Idordenproduccion
        {
            get { return idordenproduccion; }
            set { idordenproduccion = value; }
        }      
        // Fechas
        private DateTime fechaorden;
        public DateTime Fechaorden
        {
            get { return fechaorden; }
            set { fechaorden = value; }
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
            set { idlogin = value; }
        }
    }
}
