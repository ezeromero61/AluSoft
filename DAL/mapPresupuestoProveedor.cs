using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapPresupuestoProveedor
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls18_PresupuestoProveedor presupuesto)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[11];
            parametro[0] = new SqlParameter("@IdPresupuestoProveedor", presupuesto.Idpresupuestoproveedor);
            parametro[1] = new SqlParameter("@IdProveedor", presupuesto.Idproveedor);
            parametro[2] = new SqlParameter("@IdStock", presupuesto.Idstock);
            parametro[3] = new SqlParameter("@Precio", presupuesto.Precio);
            parametro[4] = new SqlParameter("@Cantidad", presupuesto.Cantidad);
            parametro[5] = new SqlParameter("@FechaPresupuesto", presupuesto.Fechapresupuesto);
            parametro[6] = new SqlParameter("@FechaValidez", presupuesto.Fechavalidez);
            parametro[7] = new SqlParameter("@IdLogin", presupuesto.Idlogin);
            parametro[8] = new SqlParameter("@Subtotal", presupuesto.Subtotal);
            parametro[9] = new SqlParameter("@IVA", presupuesto.Iva);
            parametro[10] = new SqlParameter("@Total", presupuesto.Total);
            fa = acc.Escribir("AgregarPresupuestoProveedor", parametro);
            return fa;
        }
        public int Editar(BE.cls18_PresupuestoProveedor presupuesto)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[11];
            parametro[0] = new SqlParameter("@IdPresupuestoProveedor", presupuesto.Idpresupuestoproveedor);
            parametro[1] = new SqlParameter("@IdProveedor", presupuesto.Idproveedor);
            parametro[2] = new SqlParameter("@IdStock", presupuesto.Idstock);
            parametro[3] = new SqlParameter("@Precio", presupuesto.Precio);
            parametro[4] = new SqlParameter("@Cantidad", presupuesto.Cantidad);
            parametro[5] = new SqlParameter("@FechaPresupuesto", presupuesto.Fechapresupuesto);
            parametro[6] = new SqlParameter("@FechaValidez", presupuesto.Fechavalidez);
            parametro[7] = new SqlParameter("@IdLogin", presupuesto.Idlogin);
            parametro[8] = new SqlParameter("@Subtotal", presupuesto.Subtotal);
            parametro[9] = new SqlParameter("@IVA", presupuesto.Iva);
            parametro[10] = new SqlParameter("@Total", presupuesto.Total);
            fa = acc.Escribir("EditarPresupuestoProveedor", parametro);
            return fa;
        }
        public int Eliminar(BE.cls18_PresupuestoProveedor presupuesto)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdPresupuestoProveedor", presupuesto.Idpresupuestoproveedor);

            fa = acc.Escribir("EliminarPresupuestoProveedor", parametro);

            return fa;
        }
        public int MaxId(BE.cls18_PresupuestoProveedor catalogo)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdPresupuestoProveedor", null);

            foreach (DataRow dr in tabla.Rows)
            {
                catalogo.Idpresupuestoproveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
            }

            return ls = catalogo.Idpresupuestoproveedor;
        }
        public List<BE.cls18_PresupuestoProveedor> Listar()
        {
            List<BE.cls18_PresupuestoProveedor> ls = new List<BE.cls18_PresupuestoProveedor>();

            DataTable tabla = acc.Leer("ListarPresupuestoProveedor", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls18_PresupuestoProveedor presupuesto = new BE.cls18_PresupuestoProveedor();

                presupuesto.Idpresupuestoproveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
                presupuesto.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                presupuesto.Idstock = int.Parse(dr["IdStock"].ToString());
                presupuesto.Fechapresupuesto = DateTime.Parse(dr["FechaPresupuesto"].ToString());
                presupuesto.Fechavalidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Idlogin = int.Parse(dr["IdLogin"].ToString());
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Iva = int.Parse(dr["IVA"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());

                ls.Add(presupuesto);
            }

            return ls;
        }
        public List<BE.cls18_PresupuestoProveedor> Listar2()
        {
            List<BE.cls18_PresupuestoProveedor> ls = new List<BE.cls18_PresupuestoProveedor>();
            DataTable tabla = acc.Leer("Obtener_18_IdPresupuestoProveedorCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls18_PresupuestoProveedor presupuesto = new BE.cls18_PresupuestoProveedor();
                presupuesto.Idpresupuestoproveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
                presupuesto.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                presupuesto.Nombre = (dr["Nombre"].ToString());
                presupuesto.Idstock = int.Parse(dr["IdStock"].ToString());
                presupuesto.Precio = int.Parse(dr["Precio"].ToString());
                presupuesto.Cantidad = int.Parse(dr["Cantidad"].ToString());
                presupuesto.Fechapresupuesto = DateTime.Parse(dr["FechaPresupuesto"].ToString());
                presupuesto.Fechavalidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Idlogin = int.Parse(dr["IdLogin"].ToString());
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Iva = int.Parse(dr["IVA"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.Combo = "N° " + presupuesto.Idpresupuestoproveedor + " - " + dr["NombreEmpresa"] + " - " + presupuesto.Nombre + " x " + presupuesto.Cantidad;
                ls.Add(presupuesto);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls18_PresupuestoProveedor presupuesto, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPresupuestoProveedor", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdPresupuestoProveedor", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                presupuesto.Idpresupuestoproveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
                presupuesto.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                presupuesto.Idstock = int.Parse(dr["IdStock"].ToString());
                if (dr["Precio"] != DBNull.Value) presupuesto.Precio = int.Parse(dr["Precio"].ToString());
                if (dr["Cantidad"] != DBNull.Value) presupuesto.Cantidad = int.Parse(dr["Cantidad"].ToString());
                presupuesto.Fechapresupuesto = DateTime.Parse(dr["FechaPresupuesto"].ToString());
                presupuesto.Fechavalidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Idlogin = int.Parse(dr["IdLogin"].ToString());
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Iva = int.Parse(dr["IVA"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
            }
            return tabla;
        }
    }
}

