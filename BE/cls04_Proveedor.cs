using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls04_Proveedor:cls00_Persona
    {
		private int idproveedor;

		public int Idproveedor
        {
			get { return idproveedor; }
			set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idproveedor = value; }
		}
		private string nombre_empresa;

		public string Nombre_empresa
        {
			get { return nombre_empresa; }
			set { nombre_empresa = value; }
		}

	}
}
