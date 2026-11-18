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
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idstock = value; }
		}
		private int cantidad_minima;

		public int Cantidad_minima
        {
			get { return cantidad_minima; }
			set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El valor no puede ser negativo.");
                }
                cantidad_minima = value; }
		}
		private int cantidad_maxima;

		public int Cantidad_maxima
        {
			get { return cantidad_maxima; }
			set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El valor no puede ser negativo.");
                }
                cantidad_maxima = value; }
		}
		private int cantidad_actual;

		public int Cantidad_actual
		{
			get { return cantidad_actual; }
			set
            {
                // El stock puede quedar en 0 (producto agotado); solo no puede ser negativo.
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El stock no puede ser negativo.");
                }
                cantidad_actual = value; }
		}

	}
}
