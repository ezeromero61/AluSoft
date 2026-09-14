using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class PedidoCliente
    {
        mapPedidoCliente mapper = new mapPedidoCliente();
        public int Agregar(BE.cls08_PedidoCliente pedido)
        {
            int fa;
            fa = mapper.Agregar(pedido);
            return fa;
        }
        public int Editar(BE.cls08_PedidoCliente pedido)
        {
            int fa;
            fa = mapper.Editar(pedido);
            return fa;
        }
        public int Eliminar(BE.cls08_PedidoCliente pedido)
        {
            int fa;
            fa = mapper.Eliminar(pedido);
            return fa;
        }
        public int Max(BE.cls08_PedidoCliente pedido)
        {
            int fa;
            fa = mapper.MaxId(pedido);
            return fa;
        }
        public List<BE.cls08_PedidoCliente> ListarCatalogo()
        {
            List<BE.cls08_PedidoCliente> pedido = mapper.Listar();
            return pedido;
        }
    }
}
