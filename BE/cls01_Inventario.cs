using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls01_Inventario
    {
		private int idinventario;

		public int Idinventario
        {
			get { return idinventario; }
			set { idinventario = value; }
		}
		private int idstock;

		public int Idstock
        {
			get { return idstock; }
			set { idstock = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}
		private string descripcion;

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; }
		}
		private string tipo;

		private int alto;

		public int Alto
        {
			get { return alto; }
			set { alto = value; }
		}
		private int largo;

		public int Largo
		{
			get { return largo; }
			set { largo = value; }
		}
		private int ancho;

		public int Ancho
		{
			get { return ancho; }
			set { ancho = value; }
		}

		public string Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}
        // Material
        private string material;
        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        // Ej: Aluminio, PVC

        // Color
        private string color;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
		private string combo;

		public string Combo
		{
			get { return combo; }
			set { combo = value; }
		}

	}
}
