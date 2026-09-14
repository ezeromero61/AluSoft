using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls00_Persona
    {
		private string combo;

		public string Combo
		{
			get { return combo; }
			set { combo = value; }
		}

		private int idpersona;

		public int Idpersona
		{
			get { return idpersona; }
			set { idpersona = value; }
		}

		private int idlogin;

		public int Idlogin
        {
			get { return idlogin; }
			set { idlogin = value; }
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
			set { fecha_nacimiento = value; }
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
		private int telefono;

		public int Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}
		private int dni;

		public int Dni
		{
			get { return dni; }
			set { dni = value; }
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
			set { idrol = value; }
		}
		private DateTime fecha_alta;

		public DateTime Fecha_alta
        {
			get { return fecha_alta; }
			set { fecha_alta = value; }
		}
		private DateTime fecha_baja;

		public DateTime Fecha_baja
		{
			get { return fecha_baja; }
			set { fecha_baja = value; }
		}
		private double cuil;

		public double Cuil
		{
			get { return cuil; }
			set { cuil = value; }
		}
		private int digitoverificador;

		public int DigitoVerificador
		{
			get { return digitoverificador; }
			set { digitoverificador = value; }
		}

	}
}
