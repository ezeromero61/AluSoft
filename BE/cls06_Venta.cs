using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls06_Venta
    {
		private int idventa;

		public int Idventa
		{
			get { return idventa; }
			set { idventa = value; }
		}
		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}
		private int total;

		public int Total
		{
			get { return total; }
			set { total = value; }
		}

	}
}
