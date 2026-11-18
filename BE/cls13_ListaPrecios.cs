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
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idlista = value; }
		}
		private int idcatalogo;

		private DateTime fecha;

		public DateTime Fecha
		{
			get { return fecha; }
			set {
                if (value == DateTime.MinValue)
                    throw new ArgumentException("La fecha es obligatoria.");

                if (value.Year < 1753)
                    throw new ArgumentException(
                        "La fecha ingresada no es válida."); fecha = value; }
		}
		private int precio;

		public int Precio
		{
			get { return precio; }
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                precio = value; }
		}

	}
}
