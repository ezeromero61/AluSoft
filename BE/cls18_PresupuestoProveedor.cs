using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls18_PresupuestoProveedor
    {
        private int idpresupuestoproveedor;

        public int Idpresupuestoproveedor
        {
            get { return idpresupuestoproveedor; }
            set { idpresupuestoproveedor = value; }
        }

        private int idproveedor;

        public int Idproveedor
        {
            get { return idproveedor; }
            set { idproveedor = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private int idstock;

        public int Idstock
        {
            get { return idstock; }
            set { idstock = value; }
        }

        private DateTime fechapresupuesto;

        public DateTime Fechapresupuesto
        {
            get { return fechapresupuesto; }
            set { fechapresupuesto = value; }
        }
        private DateTime fechavalidez;

        public DateTime Fechavalidez
        {
            get { return fechavalidez; }
            set { fechavalidez = value; }
        }
        private int idlogin;

        public int Idlogin
        {
            get { return idlogin; }
            set { idlogin = value; }
        }
        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }
        private int subtotal;

        public int Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        private int iva;

        public int Iva
        {
            get { return iva; }
            set { iva = value; }
        }
        private string combo;

        public string Combo
        {
            get { return combo; }
            set { combo = value; }
        }


    }
}
