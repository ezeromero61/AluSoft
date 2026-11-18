using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapPedidoCliente
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls08_PedidoCliente pedido)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[7];
            parametro[0] = new SqlParameter("@IdPedido", pedido.IdPedido);
            parametro[1] = new SqlParameter("@IdPresupuesto", pedido.Idpresupuesto);
            parametro[2] = new SqlParameter("@FechaPedido", pedido.Fechapedido);
            parametro[3] = new SqlParameter("@FechaEntregaEstimada", pedido.Fechaentregaestimada);
            parametro[4] = new SqlParameter("@FechaEntregaReal", pedido.Fechaentregareal);
            parametro[5] = new SqlParameter("@Estado", pedido.Estado);
            parametro[6] = new SqlParameter("@Observaciones", pedido.Observaciones);
            fa = acc.Escribir("AgregarPedidoCliente", parametro);
            return fa;
        }
        public int Editar(BE.cls08_PedidoCliente pedido)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[7];
            parametro[0] = new SqlParameter("@IdPedido", pedido.IdPedido);
            parametro[1] = new SqlParameter("@IdPresupuesto", pedido.Idpresupuesto);
            parametro[2] = new SqlParameter("@FechaPedido", pedido.Fechapedido);
            parametro[3] = new SqlParameter("@FechaEntregaEstimada", pedido.Fechaentregaestimada);
            parametro[4] = new SqlParameter("@FechaEntregaReal", pedido.Fechaentregareal);
            parametro[5] = new SqlParameter("@Estado", pedido.Estado);
            parametro[6] = new SqlParameter("@Observaciones", pedido.Observaciones);
            fa = acc.Escribir("EditarPedidoCliente", parametro);
            
            return fa;
        }
        public int Eliminar(BE.cls08_PedidoCliente pedido)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdPedido", pedido.IdPedido);

            fa = acc.Escribir("EliminarPedidoCliente", parametro);

            return fa;
        }
        public int MaxId(BE.cls08_PedidoCliente pedido)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdPedido", null);
            foreach (DataRow dr in tabla.Rows)
            {
                pedido.IdPedido = int.Parse(dr["IdPedido"].ToString());
            }
            return ls = pedido.IdPedido;                
        }
        public List<BE.cls08_PedidoCliente> Listar()
        {
            List<BE.cls08_PedidoCliente> ls = new List<BE.cls08_PedidoCliente>();

            DataTable tabla = acc.Leer("ListarPedidoClientePresupuestoClienteCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls08_PedidoCliente pedido = new BE.cls08_PedidoCliente();
                pedido.IdPedido = int.Parse(dr["IdPedido"].ToString());
                pedido.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                pedido.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                pedido.Nombre = (dr["Nombre"].ToString());
                pedido.Cantidad= int.Parse(dr["Cantidad"].ToString());
                pedido.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                pedido.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                pedido.Estado = dr["Estado"].ToString();
                pedido.Subtotal = int.Parse(dr["Subtotal"].ToString());
                pedido.Descuento = int.Parse(dr["Descuento"].ToString());
                pedido.Impuestos = int.Parse(dr["Impuestos"].ToString());
                pedido.FormaPago = dr["FormaPago"].ToString();
                pedido.Total = int.Parse(dr["Total"].ToString());
                pedido.Fechapedido = DateTime.Parse(dr["FechaPedido"].ToString());
                pedido.Fechaentregaestimada = DateTime.Parse(dr["FechaEntregaEstimada"].ToString());
                pedido.Fechaentregareal = DateTime.Parse(dr["FechaEntregaReal"].ToString());
                pedido.Estado = (dr["Estado"].ToString());
                pedido.Observaciones = dr["Observaciones"].ToString();
                pedido.Combo = "N° " + pedido.IdPedido + " - " + pedido.Nombre + " x" + pedido.Cantidad;
                ls.Add(pedido);
            }

            return ls;
        }
        public DataTable Consultar(BE.cls08_PedidoCliente pedido, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPedido", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdPedidoCombinado", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                pedido.IdPedido = int.Parse(dr["IdPedido"].ToString());
                pedido.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                pedido.Idcatalogo = int.Parse(dr["IdCatalogo"].ToString());
                pedido.Idcliente = int.Parse(dr["IdCliente"].ToString());
                pedido.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                pedido.Apellido = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                pedido.NombreProducto = (dr["NombreProducto"].ToString());
                pedido.Direccion= clsCifrado.DesencriptarString(dr["Domicilio"].ToString());
                pedido.Cantidad = int.Parse(dr["Cantidad"].ToString());
                pedido.FechaCreacion = DateTime.Parse(dr["FechaCreacion"].ToString());
                pedido.FechaValidez = DateTime.Parse(dr["FechaValidez"].ToString());
                pedido.Estado = dr["EstadoPresupuesto"].ToString();
                pedido.Subtotal = int.Parse(dr["Subtotal"].ToString());
                pedido.Descuento = int.Parse(dr["Descuento"].ToString());
                pedido.Impuestos = int.Parse(dr["Impuestos"].ToString());
                pedido.FormaPago = dr["FormaPago"].ToString();
                pedido.Total = int.Parse(dr["Total"].ToString());
                pedido.Fechapedido = DateTime.Parse(dr["FechaPedido"].ToString());
                pedido.Fechaentregaestimada = DateTime.Parse(dr["FechaEntregaEstimada"].ToString());
                pedido.Fechaentregareal = DateTime.Parse(dr["FechaEntregaReal"].ToString());
                pedido.Estado = (dr["EstadoPedido"].ToString());
                pedido.Observaciones = dr["Observaciones"].ToString();
            }
            // La tabla se muestra en la grilla: se devuelven los datos descifrados.
            clsCifrado.DescifrarColumnas(tabla, "Nombre", "Apellido", "Domicilio");
            return tabla;
        }
        public List<BE.cls08_PedidoCliente> Listar2()
        {
            List<BE.cls08_PedidoCliente> ls = new List<BE.cls08_PedidoCliente>();
            DataTable tabla = acc.Leer("Obtener_08_IdPedidoClienteCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls08_PedidoCliente pedido = new BE.cls08_PedidoCliente();
                pedido.IdPedido = int.Parse(dr["IdPedido"].ToString());
                pedido.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                pedido.Nombre = clsCifrado.DesencriptarString(dr["Nombre"].ToString());
                pedido.Apellido = clsCifrado.DesencriptarString(dr["Apellido"].ToString());
                pedido.Fechapedido = DateTime.Parse(dr["FechaPedido"].ToString());
                pedido.Fechaentregaestimada = DateTime.Parse(dr["FechaEntregaEstimada"].ToString());
                pedido.Fechaentregareal = DateTime.Parse(dr["FechaEntregaReal"].ToString());
                pedido.Estado = (dr["Estado"].ToString());
                pedido.Observaciones = dr["Observaciones"].ToString();
                pedido.Combo = "N° " + pedido.IdPedido + " - " + pedido.Nombre + " " + pedido.Apellido;
                ls.Add(pedido);
            }
            return ls;
        }
    }
}

