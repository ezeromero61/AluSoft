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
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idcliente = value; }
		}
        //public string NombreCompleto
        //{
        //    get { return (Nombre + " " + Apellido).Trim(); }
        //}
    }
}
