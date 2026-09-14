using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls15_Estado
    {
        // Identificación
        private int idestado;

        public int Idestado
        {
            get { return idestado; }
            set { idestado = value; }
        }
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

        private DateTime? fechainicioproduccion;

        public DateTime? Fechainicioproduccion
        {
            get { return fechainicioproduccion; }
            set { fechainicioproduccion = value; }
        }

        private DateTime? fechafinproduccion;

        public DateTime? Fechafinproduccion
        {
            get { return fechafinproduccion; }
            set { fechafinproduccion = value; }
        }

        private DateTime? fechaentrega;

        public DateTime? Fechaentrega
        {
            get { return fechaentrega; }
            set { fechaentrega = value; }
        }

        // Estado de producción
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        // Ej: Pendiente, EnProduccion, Pausado, Terminado, Entregado

        // Prioridad
        //private string prioridad;

        //public string Prioridad
        //{
        //    get { return prioridad; }
        //    set { prioridad = value; }
        //}
        // Normal, Urgente

        // Detalles técnicos generales
        private string observaciones;

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        // Dirección de obra
        //private string direccionobra;

        //public string Direccionobra
        //{
        //    get { return direccionobra; }
        //    set { direccionobra = value; }
        //}

        // Responsable
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
        }

        // Indicadores de proceso
        //private bool listoparainstalar;

        //public bool Listoparainstalar
        //{
        //    get { return listoparainstalar; }
        //    set { listoparainstalar = value; }
        //}

        //private bool entregado;

        //public bool Entregado
        //{
        //    get { return entregado; }
        //    set { entregado = value; }
        //}
    }
}
