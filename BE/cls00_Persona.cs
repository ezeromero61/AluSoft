using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls00_Persona
    {		
		private int idpersona;

		public int Idpersona
		{
			get { return idpersona; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }

                idpersona = value;
            }
        }

		private int idlogin;

		public int Idlogin
        {
			get { return idlogin; }
			set {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El identificador de acceso no puede ser negativo.");
                }
                idlogin = value; }
		}
		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		private string apellido;

		public string Apellido
		{
			get { return apellido; }
			set { apellido = value; }
		}
		private DateTime fecha_nacimiento;

		public DateTime Fecha_nacimiento
		{
			get { return fecha_nacimiento; }
			set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fecha_nacimiento = value; }
		}

		private string genero;

		public string Genero
		{
			get { return genero; }
			set { genero = value; }
		}
		private string domicilio;

		public string Domicilio
		{
			get { return domicilio; }
			set { domicilio = value; }
		}
		private string correo;

		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}
		private double telefono;

		public double Telefono
		{
			get { return telefono; }
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                telefono = value; }
		}
		private double dni;

		public double Dni
		{
			get { return dni; }
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                dni = value; }
		}
		private string localidad;

		public string Localidad
		{
			get { return localidad; }
			set { localidad = value; }
		}
		private int idrol;

		public int Idrol
		{
			get { return idrol; }
			set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El identificador de rol no puede ser negativo.");
                }
                idrol = value; }
		}
		private DateTime fecha_alta;

		public DateTime Fecha_alta
        {
			get { return fecha_alta; }
			set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fecha_alta = value; }
		}
        private DateTime? fecha_baja;

        public DateTime? Fecha_baja
        {
            get { return fecha_baja; }
            set
            {
                if (value.HasValue && value.Value < new DateTime(1753, 1, 1))
                    throw new ArgumentException("La fecha ingresada no es válida.");

                fecha_baja = value;
            }
        }
        private double cuil;

		public double Cuil
		{
			get { return cuil; }
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                cuil = value; }
		}
		private int digitoverificador;

		public int DigitoVerificador
		{
			get { return digitoverificador; }
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                digitoverificador = value; }
		}
        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }
    }
}
