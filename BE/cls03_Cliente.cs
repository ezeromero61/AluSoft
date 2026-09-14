using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls03_Cliente:cls00_Persona
    {
		private int idcliente;

		public int Idcliente
		{
			get { return idcliente; }
			set { idcliente = value; }
		}
		private string combo;

		public string Combo
		{
			get { return combo; }
			set { combo = value; }
		}

	}
}
