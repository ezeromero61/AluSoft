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
        private int idrol;

        public int IdRol
        {
            get { return idrol; }
            set { idrol = value; }
        }
        private string nombrerol;

        public string NombreRol
        {
            get { return nombrerol; }
            set { nombrerol = value; }
        }
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
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
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idbitacora = value; }
        }
        public int IdLogin
        {
            get => idlogin;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idlogin = value; }
        }
        public int IdTabla
        {
            get => idtabla;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idtabla = value; }
        }
        public int IdAccion
        {
            get => idaccion;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idaccion = value; }
        }
        public DateTime Fecha
        {
            get => fecha;
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fecha = value; }
        }
        public DateTime Hora
        {
            get => hora;
            set
            {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); hora = value; }
        }
        public int DigitoVerificador
        {
            get => digitoverificador;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                digitoverificador = value; }
        }
        #endregion
    }
}
