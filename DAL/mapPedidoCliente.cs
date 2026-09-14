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

            SqlParameter[] parametro = new SqlParameter[8];

            parametro[0] = new SqlParameter("@IdPedido", pedido.IdPedido);
            parametro[1] = new SqlParameter("@IdPresupuesto", pedido.Idpresupuesto);
            parametro[2] = new SqlParameter("@FechaPedido", pedido.Fechapedido);
            parametro[3] = new SqlParameter("@FechaEntregaEstimada", pedido.Fechaentregaestimada);
            parametro[4] = new SqlParameter("@FechaEntregaReal", pedido.Fechaentregareal);
            parametro[5] = new SqlParameter("@Estado", pedido.Estado);
            parametro[6] = new SqlParameter("@Observaciones", pedido.Observaciones);
            parametro[7] = new SqlParameter("@IdLogin", pedido.Idlogin);

            fa = acc.Escribir("AgregarPedidoCliente", parametro);

            return fa;
        }

        public int Editar(BE.cls08_PedidoCliente pedido)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[8];

            parametro[0] = new SqlParameter("@IdPedido", pedido.IdPedido);
            parametro[1] = new SqlParameter("@IdPresupuesto", pedido.Idpresupuesto);
            parametro[2] = new SqlParameter("@FechaPedido", pedido.Fechapedido);
            parametro[3] = new SqlParameter("@FechaEntregaEstimada", pedido.Fechaentregaestimada);
            parametro[4] = new SqlParameter("@FechaEntregaReal", pedido.Fechaentregareal);
            parametro[5] = new SqlParameter("@Estado", pedido.Estado);
            parametro[6] = new SqlParameter("@Observaciones", pedido.Observaciones);
            parametro[7] = new SqlParameter("@IdLogin", pedido.Idlogin);

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
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                pedido.IdPedido = int.Parse(dr["IdPedido"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = pedido.IdPedido
                ;
        }
        public List<BE.cls08_PedidoCliente> Listar()
        {
            List<BE.cls08_PedidoCliente> ls = new List<BE.cls08_PedidoCliente>();

            DataTable tabla = acc.Leer("ListarPedidoCliente", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls08_PedidoCliente pedido = new BE.cls08_PedidoCliente();

                pedido.IdPedido = int.Parse(dr["IdPedido"].ToString());
                pedido.Idpresupuesto = int.Parse(dr["IdPresupuesto"].ToString());
                pedido.Fechapedido = DateTime.Parse(dr["FechaPedido"].ToString());
                pedido.Fechaentregaestimada = DateTime.Parse(dr["FechaEntregaEstimada"].ToString());

                if (dr["FechaEntregaReal"] != DBNull.Value)
                    pedido.Fechaentregareal = DateTime.Parse(dr["FechaEntregaReal"].ToString());

                pedido.Estado = dr["Estado"].ToString();
                pedido.Observaciones = dr["Observaciones"].ToString();
                pedido.Idlogin = int.Parse(dr["IdLogin"].ToString());

                ls.Add(pedido);
            }

            return ls;
        }
    }
}

