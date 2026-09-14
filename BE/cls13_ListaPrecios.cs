using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls13_ListaPrecios:cls12_Catalogo
    {
		private int idlista;

		public int Idlista
		{
			get { return idlista; }
			set { idlista = value; }
		}
		private int idcatalogo;

		//public int Idcatalogo
		//{
		//	get { return idcatalogo; }
		//	set { idcatalogo = value; }
		//}
		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}
		private int precio;

		public int Precio
		{
			get { return precio; }
			set { precio = value; }
		}

	}
}
