using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapPresupuestoCliente
    {
        clsAcceso acc = new clsAcceso();
        public int ActualizarEstado(int idPresupuesto, string estado)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdPresupuesto", idPresupuesto);
            parametro[1] = new SqlParameter("@Estado", estado);
            return acc.Escribir("ActualizarEstadoPresupuestoCliente", parametro);
        }

        public int Agregar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[16];
            parametro[0] = new SqlParameter("@IdPresupuesto", presupuesto.Idpresupuesto);
            parametro[1] = new SqlParameter("@IdCliente", presupuesto.Idcliente);
            parametro[2] = new SqlParameter("@IdCatalogo", presupuesto.Idcatalogo);
            parametro[3] = new SqlParameter("@Cantidad", presupuesto.Cantidad);
            parametro[4] = new SqlParameter("@FechaCreacion", presupuesto.FechaCreacion);
            parametro[5] = new SqlParameter("@FechaValidez", presupuesto.FechaValidez);
            parametro[6] = new SqlParameter("@Estado", presupuesto.Estado);
            parametro[7] = new SqlParameter("@Descripcion", presupuesto.Descripcion);
            parametro[8] = new SqlParameter("@Observaciones", presupuesto.Observaciones);
            parametro[9] = new SqlParameter("@Subtotal", presupuesto.Subtotal);
            parametro[10] = new SqlParameter("@Descuento", presupuesto.Descuento);
            parametro[11] = new SqlParameter("@Impuestos", presupuesto.Impuestos);
            parametro[12] = new SqlParameter("@Total", presupuesto.Total);
            parametro[13] = new SqlParameter("@FormaPago", presupuesto.FormaPago);
            parametro[14] = new SqlParameter("@PlazoEntregaDias", presupuesto.PlazoEntregaDias);
            parametro[15] = new SqlParameter("@DigitoVerificador", presupuesto.DigitoVerificador);
            fa = acc.Escribir("AgregarPresupuestoCliente", parametro);
            return fa;
        }
        public int Editar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[16];
            parametro[0] = new SqlParameter("@IdPresupuesto", presupuesto.Idpresupuesto);
            parametro[1] = new SqlParameter("@IdCliente", presupuesto.Idcliente);
            parametro[2] = new SqlParameter("@IdCatalogo", presupuesto.Idcatalogo);
            parametro[3] = new SqlParameter("@Cantidad", presupuesto.Cantidad);
            parametro[4] = new SqlParameter("@FechaCreacion", presupuesto.FechaCreacion);
            parametro[5] = new SqlParameter("@FechaValidez", presupuesto.FechaValidez);
            parametro[6] = new SqlParameter("@Estado", presupuesto.Estado);
            parametro[7] = new SqlParameter("@Descripcion", presupuesto.Descripcion);
            parametro[8] = new SqlParameter("@Observaciones", presupuesto.Observaciones);
            parametro[9] = new SqlParameter("@Subtotal", presupuesto.Subtotal);
            parametro[10] = new SqlParameter("@Descuento", presupuesto.Descuento);
            parametro[11] = new SqlParameter("@Impuestos", presupuesto.Impuestos);
            parametro[12] = new SqlParameter("@Total", presupuesto.Total);
            parametro[13] = new SqlParameter("@FormaPago", presupuesto.FormaPago);
            parametro[14] = new SqlParameter("@PlazoEntregaDias", presupuesto.PlazoEntregaDias);
            parametro[15] = new SqlParameter("@DigitoVerificador", presupuesto.DigitoVerificador);
            fa = acc.Escribir("EditarPresupuestoCliente", parametro);
            return fa;
        }
        public int Eliminar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPresupuesto", presupuesto.Idpresupuesto);
            fa = acc.Escribir("EliminarPresupuestoCliente", parametro);
            return fa;
        }
        public int MaxId(BE.cls07_PresupuestoCliente presupuesto)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdPresupuesto", null);
            foreach (DataRow dr in tabla.Rows)
            {
                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
            }
            return ls = presupuesto.Idpresupuesto;
        }
        public List<BE.cls26_Combinado> Listar2()
        {
            List<BE.cls26_Combinado> ls = new List<BE.cls26_Combinado>();

            DataTable tabla = acc.Leer("Obtener_07_IdPresupuestoClienteCombinado", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls26_Combinado presupuesto = new BE.cls26_Combinado();

                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                presupuesto.Idcliente = int.Parse(dr["IdCliente"].ToString());
                presupuesto.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                presupuesto.Apellido =clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                presupuesto.IdCatalogo = int.Parse(dr["IdCatalogo"].ToString());
                presupuesto.Cantidad= int.Parse(dr["Cantidad"].ToString());
                presupuesto.Precio = int.Parse(dr["PrecioUnitario"].ToString());
                presupuesto.Producto = dr["NombreInventario"].ToString();
                presupuesto.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                presupuesto.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Estado = dr["Estado"].ToString();
                presupuesto.Descripcion = dr["Descripcion"].ToString();
                presupuesto.Observaciones = dr["Observaciones"].ToString();
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Descuento = int.Parse(dr["Descuento"].ToString());
                presupuesto.Impuestos = int.Parse(dr["Impuestos"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.FormaPago = dr["FormaPago"].ToString();
                presupuesto.PlazoEntregaDias = int.Parse(dr["PlazoEntregaDias"].ToString());
                presupuesto.Combo = "N° " + presupuesto.Idpresupuesto + " - " + presupuesto.Nombre + " " + presupuesto.Apellido + " - " + presupuesto.Producto;
                ls.Add(presupuesto);
            }

            return ls;
        }
        public List<BE.cls07_PresupuestoCliente> Listar()
        {
            List<BE.cls07_PresupuestoCliente> ls = new List<BE.cls07_PresupuestoCliente>();

            DataTable tabla = acc.Leer("ListarPresupuestoCliente", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls07_PresupuestoCliente presupuesto = new BE.cls07_PresupuestoCliente();

                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                presupuesto.Idcliente = int.Parse(dr["IdCliente"].ToString());
                presupuesto.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                presupuesto.Cantidad = int.Parse(dr["Cantidad"].ToString());
                presupuesto.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                presupuesto.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Estado = dr["Estado"].ToString();
                presupuesto.Descripcion = dr["Descripcion"].ToString();
                presupuesto.Observaciones = dr["Observaciones"].ToString();
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Descuento = int.Parse(dr["Descuento"].ToString());
                presupuesto.Impuestos = int.Parse(dr["Impuestos"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.FormaPago = dr["FormaPago"].ToString();
                presupuesto.PlazoEntregaDias = int.Parse(dr["PlazoEntregaDias"].ToString());

                ls.Add(presupuesto);
            }

            return ls;
        }
        public DataTable Consultar(BE.cls07_PresupuestoCliente presupuesto, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPresupuesto", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdPresupuestoCliente", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                presupuesto.Idcliente = int.Parse(dr["IdCliente"].ToString());
                presupuesto.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                presupuesto.Cantidad = int.Parse(dr["Cantidad"].ToString());
                presupuesto.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                presupuesto.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Estado = dr["Estado"].ToString();
                presupuesto.Descripcion = dr["Descripcion"].ToString();
                presupuesto.Observaciones = dr["Observaciones"].ToString();
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Descuento = int.Parse(dr["Descuento"].ToString());
                presupuesto.Impuestos = int.Parse(dr["Impuestos"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.FormaPago = dr["FormaPago"].ToString();
                presupuesto.PlazoEntregaDias = int.Parse(dr["PlazoEntregaDias"].ToString());
            }
            return tabla;
        }
        public DataTable Consultar2(BE.cls26_Combinado presupuesto, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPresupuesto", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdPresupuestoClienteCombinado", parametro);
            clsCifrado.DescifrarColumnas(tabla, "Nombre", "Apellido");
            foreach (DataRow dr in tabla.Rows)
            {
                presupuesto.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                presupuesto.Idcliente = int.Parse(dr["IdCliente"].ToString());
                presupuesto.Nombre = dr["Nombre"].ToString();
                presupuesto.Apellido = dr["Apellido"].ToString();
                presupuesto.IdCatalogo = int.Parse(dr["IdCatalogo"].ToString());
                presupuesto.Cantidad = int.Parse(dr["Cantidad"].ToString());
                presupuesto.Precio = int.Parse(dr["PrecioUnitario"].ToString());
                presupuesto.Producto = dr["NombreInventario"].ToString();
                presupuesto.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                presupuesto.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                presupuesto.Estado = dr["Estado"].ToString();
                presupuesto.Descripcion = dr["Descripcion"].ToString();
                presupuesto.Observaciones = dr["Observaciones"].ToString();
                presupuesto.Subtotal = int.Parse(dr["Subtotal"].ToString());
                presupuesto.Descuento = int.Parse(dr["Descuento"].ToString());
                presupuesto.Impuestos = int.Parse(dr["Impuestos"].ToString());
                presupuesto.Total = int.Parse(dr["Total"].ToString());
                presupuesto.FormaPago = dr["FormaPago"].ToString();
                presupuesto.PlazoEntregaDias = int.Parse(dr["PlazoEntregaDias"].ToString());
                presupuesto.Combo = presupuesto.Idpresupuesto + " " + presupuesto.Nombre + " " + presupuesto.Apellido;

            }
            return tabla;
        }
    }
}

