using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls02_Stock:cls01_Inventario
    {
		private int idstock;

		public int Idstock
		{
			get { return idstock; }
			set { idstock = value; }
		}
		private int cantidad_minima;

		public int Cantidad_minima
        {
			get { return cantidad_minima; }
			set { cantidad_minima = value; }
		}
		private int cantidad_maxima;

		public int Cantidad_maxima
        {
			get { return cantidad_maxima; }
			set { cantidad_maxima = value; }
		}
		private int cantidad_actual;

		public int Cantidad_actual
		{
			get { return cantidad_actual; }
			set { cantidad_actual = value; }
		}

	}
}
