using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapPedidoReaprovisionamiento
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls16_PedidoReaprovisionamiento pedido)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[15];
            parametro[0] = new SqlParameter("@IdPedidoReaprovisionamiento", pedido.Idpedidoreaprovisionamiento);
            parametro[1] = new SqlParameter("@IdProveedor", pedido.Idproveedor);
            parametro[2] = new SqlParameter("@IdPresupuestoProveedor", pedido.IdPresupuestoProveedor);
            parametro[3] = new SqlParameter("@FechaPedido", pedido.Fechapedido);
            parametro[4] = new SqlParameter("@FechaEntregaEstimada", (object)pedido.Fechaentregaestimada ?? DBNull.Value);
            parametro[5] = new SqlParameter("@FechaEntregaReal", (object)pedido.Fechaentregareal ?? DBNull.Value);
            parametro[6] = new SqlParameter("@Cantidad", pedido.Cantidad);
            parametro[7] = new SqlParameter("@Precio", pedido.Precio);
            parametro[8] = new SqlParameter("@Total", pedido.Total);
            parametro[9] = new SqlParameter("@Subtotal", pedido.Subtotal);
            parametro[10] = new SqlParameter("@IVA", pedido.IVA);
            parametro[11] = new SqlParameter("@Estado", pedido.Estado);
            parametro[12] = new SqlParameter("@Prioridad", pedido.Prioridad);
            parametro[13] = new SqlParameter("@Observaciones", pedido.Observaciones);
            parametro[14] = new SqlParameter("@IdLogin", pedido.Idlogin);
            fa = acc.Escribir("AgregarPedidoReaprovisionamiento", parametro);
            return fa;
        }
        public int ActualizarEstado(int idPedido, string estado)
        {
            SqlParameter[] parametro = new SqlParameter[2];
            parametro[0] = new SqlParameter("@IdPedidoReaprovisionamiento", idPedido);
            parametro[1] = new SqlParameter("@Estado", estado);
            return acc.Escribir("ActualizarEstadoPedidoReaprovisionamiento", parametro);
        }
        public int Editar(BE.cls16_PedidoReaprovisionamiento pedido)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[15];
            parametro[0] = new SqlParameter("@IdPedidoReaprovisionamiento", pedido.Idpedidoreaprovisionamiento);
            parametro[1] = new SqlParameter("@IdProveedor", pedido.Idproveedor);
            parametro[2] = new SqlParameter("@IdPresupuestoProveedor", pedido.IdPresupuestoProveedor);
            parametro[3] = new SqlParameter("@FechaPedido", pedido.Fechapedido);
            parametro[4] = new SqlParameter("@FechaEntregaEstimada", (object)pedido.Fechaentregaestimada ?? DBNull.Value);
            parametro[5] = new SqlParameter("@FechaEntregaReal", (object)pedido.Fechaentregareal ?? DBNull.Value);
            parametro[6] = new SqlParameter("@Cantidad", pedido.Cantidad);
            parametro[7] = new SqlParameter("@Precio", pedido.Precio);
            parametro[8] = new SqlParameter("@Total", pedido.Total);
            parametro[9] = new SqlParameter("@Subtotal", pedido.Subtotal);
            parametro[10] = new SqlParameter("@IVA", pedido.IVA);
            parametro[11] = new SqlParameter("@Estado", pedido.Estado);
            parametro[12] = new SqlParameter("@Prioridad", pedido.Prioridad);
            parametro[13] = new SqlParameter("@Observaciones", pedido.Observaciones);
            parametro[14] = new SqlParameter("@IdLogin", pedido.Idlogin);
            fa = acc.Escribir("EditarPedidoReaprovisionamiento", parametro);
            return fa;
        }
        public int Eliminar(BE.cls16_PedidoReaprovisionamiento pedido)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPedidoReaprovisionamiento", pedido.Idpedidoreaprovisionamiento);
            fa = acc.Escribir("EliminarPedidoReaprovisionamiento", parametro);
            return fa;
        }
        public int MaxId(BE.cls16_PedidoReaprovisionamiento pedido)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdPedidoReaprovisionamiento", null);
            foreach (DataRow dr in tabla.Rows)
            {
                pedido.Idpedidoreaprovisionamiento = int.Parse(dr["IdPedidoReaprovisionamiento"].ToString());
            }
            return ls = pedido.Idpedidoreaprovisionamiento;               
        }
        public List<BE.cls16_PedidoReaprovisionamiento> Listar2()
        {
            List<BE.cls16_PedidoReaprovisionamiento> ls = new List<BE.cls16_PedidoReaprovisionamiento>();
            DataTable tabla = acc.Leer("Obtener_16_IdPedidoReaprovisionamientoCombinado", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls16_PedidoReaprovisionamiento pedido = new BE.cls16_PedidoReaprovisionamiento();
                pedido.Idpedidoreaprovisionamiento = int.Parse(dr["IdPedidoReaprovisionamiento"].ToString());
                pedido.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                if (dr.Table.Columns.Contains("IdPresupuestoProveedor") && dr["IdPresupuestoProveedor"] != DBNull.Value)
                    pedido.IdPresupuestoProveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
                pedido.Nombreproveedor = dr["NombreEmpresa"].ToString();
                pedido.Fechapedido = DateTime.Parse(dr["FechaPedido"].ToString());
                if (dr["FechaEntregaEstimada"] != DBNull.Value)
                pedido.Fechaentregaestimada = DateTime.Parse(dr["FechaEntregaEstimada"].ToString());
                if (dr["FechaEntregaReal"] != DBNull.Value)
                pedido.Fechaentregareal = DateTime.Parse(dr["FechaEntregaReal"].ToString());
                pedido.Cantidad = int.Parse(dr["Cantidad"].ToString());
                pedido.Precio = int.Parse(dr["Precio"].ToString());
                pedido.Total = int.Parse(dr["Total"].ToString());
                pedido.Subtotal = int.Parse(dr["Subtotal"].ToString());
                pedido.IVA = int.Parse(dr["IVA"].ToString());
                pedido.Estado = dr["Estado"].ToString();        
                pedido.Prioridad = dr["Prioridad"].ToString();
                pedido.Observaciones = dr["Observaciones"].ToString();
                pedido.Idlogin = int.Parse(dr["IdLogin"].ToString());
                pedido.Producto = dr.Table.Columns.Contains("Producto") ? dr["Producto"].ToString() : "";
                if (dr.Table.Columns.Contains("IdStock") && dr["IdStock"] != DBNull.Value)
                    pedido.Idstock = int.Parse(dr["IdStock"].ToString());
                pedido.Combo = "N° " + pedido.Idpedidoreaprovisionamiento + " - " + pedido.Nombreproveedor + (pedido.Producto == "" ? "" : " - " + pedido.Producto) + " x " + pedido.Cantidad;
                ls.Add(pedido);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls16_PedidoReaprovisionamiento pedido, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdPedidoReaprovisionamiento", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdPedidoReaprovisionamientoCombo", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                pedido.Idpedidoreaprovisionamiento = int.Parse(dr["IdPedidoReaprovisionamiento"].ToString());
                pedido.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                if (dr.Table.Columns.Contains("IdPresupuestoProveedor") && dr["IdPresupuestoProveedor"] != DBNull.Value)
                    pedido.IdPresupuestoProveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
                pedido.Nombreproveedor = dr["NombreEmpresa"].ToString();
                pedido.Fechapedido = DateTime.Parse(dr["FechaPedido"].ToString());
                if (dr["FechaEntregaEstimada"] != DBNull.Value)
                    pedido.Fechaentregaestimada = DateTime.Parse(dr["FechaEntregaEstimada"].ToString());
                if (dr["FechaEntregaReal"] != DBNull.Value)
                    pedido.Fechaentregareal = DateTime.Parse(dr["FechaEntregaReal"].ToString());
                pedido.Cantidad = int.Parse(dr["Cantidad"].ToString());
                pedido.Precio = int.Parse(dr["Precio"].ToString());
                pedido.Total = int.Parse(dr["Total"].ToString());
                pedido.Subtotal = int.Parse(dr["Subtotal"].ToString());
                pedido.IVA = int.Parse(dr["IVA"].ToString());
                pedido.Estado = dr["Estado"].ToString();
                pedido.Prioridad = dr["Prioridad"].ToString();
                pedido.Observaciones = dr["Observaciones"].ToString();
                pedido.Idlogin = int.Parse(dr["IdLogin"].ToString());
            }
            return tabla;
        }
        public List<BE.cls16_PedidoReaprovisionamiento> Listar()
        {
            List<BE.cls16_PedidoReaprovisionamiento> ls = new List<BE.cls16_PedidoReaprovisionamiento>();
            DataTable tabla = acc.Leer("ListarPedidoReaprovisionamiento", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls16_PedidoReaprovisionamiento pedido = new BE.cls16_PedidoReaprovisionamiento();
                pedido.Idpedidoreaprovisionamiento = int.Parse(dr["IdPedidoReaprovisionamiento"].ToString());
                pedido.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                if (dr.Table.Columns.Contains("IdPresupuestoProveedor") && dr["IdPresupuestoProveedor"] != DBNull.Value)
                    pedido.IdPresupuestoProveedor = int.Parse(dr["IdPresupuestoProveedor"].ToString());
                pedido.Fechapedido = DateTime.Parse(dr["FechaPedido"].ToString());
                if (dr["FechaEntregaEstimada"] != DBNull.Value)
                    pedido.Fechaentregaestimada = DateTime.Parse(dr["FechaEntregaEstimada"].ToString());
                if (dr["FechaEntregaReal"] != DBNull.Value)
                    pedido.Fechaentregareal = DateTime.Parse(dr["FechaEntregaReal"].ToString());
                pedido.Cantidad = int.Parse(dr["Cantidad"].ToString());
                pedido.Precio = int.Parse(dr["Precio"].ToString());
                pedido.Total = int.Parse(dr["Total"].ToString());
                pedido.Subtotal = int.Parse(dr["Subtotal"].ToString());
                pedido.IVA = int.Parse(dr["IVA"].ToString());
                pedido.Estado = dr["Estado"].ToString();
                pedido.Prioridad = dr["Prioridad"].ToString();
                pedido.Observaciones = dr["Observaciones"].ToString();
                pedido.Idlogin = int.Parse(dr["IdLogin"].ToString());
                ls.Add(pedido);
            }
            return ls;
        }
    }
}

