using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls35_Bitacora
    {
        private string nombreAccion;

        public string NombreAccion
        {
            get { return nombreAccion; }
            set { nombreAccion = value; }
        }
        private string nombreTabla;

        public string NombreTabla
        {
            get { return nombreTabla; }
            set { nombreTabla = value; }
        }
        private string usuraio;

        public string Usuraio
        {
            get { return usuraio; }
            set { usuraio = value; }
        }


        #region Atributos
        public int idbitacora;
        public int idlogin;
        public int idtabla;
        public int idaccion;
        public DateTime fecha;
        public DateTime hora;
        public int digitoverificador;
        #endregion
        #region Propiedades
        public int IdBitacora
        {
            get => idbitacora;
            set { idbitacora = value; }
        }
        public int IdLogin
        {
            get => idlogin;
            set { idlogin = value; }
        }
        public int IdTabla
        {
            get => idtabla;
            set { idtabla = value; }
        }
        public int IdAccion
        {
            get => idaccion;
            set { idaccion = value; }
        }
        public DateTime Fecha
        {
            get => fecha;
            set { fecha = value; }
        }
        public DateTime Hora
        {
            get => hora;
            set { hora = value; }
        }
        public int DigitoVerificador
        {
            get => digitoverificador;
            set { digitoverificador = value; }
        }
        #endregion
    }
}
