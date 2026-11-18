using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls12_Catalogo:cls01_Inventario
    {
        private int idcatalogo;

        public int Idcatalogo
        {
            get { return idcatalogo; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idcatalogo = value; }
        }

        private int idlistaprecio;

        public int Idlistaprecio
        {
            get { return idlistaprecio; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idlistaprecio = value; }
        }

        private int preciounitario;

        public int Preciounitario
        {
            get { return preciounitario; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                preciounitario = value; }
        }
        private string disponibilidad;

        public string Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "El valor no puede ser negativo.");
                }
                cantidad = value; }
        }
    }
}
