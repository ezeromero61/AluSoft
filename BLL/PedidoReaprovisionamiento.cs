using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PedidoReaprovisionamiento
    {
        mapPedidoReaprovisionamiento mapper = new mapPedidoReaprovisionamiento();
        public int ActualizarEstado(int idPedido, string estado)
        {
            return mapper.ActualizarEstado(idPedido, estado);
        }
        public int Agregar(BE.cls16_PedidoReaprovisionamiento pedidio)
        {
            int fa;
            fa = mapper.Agregar(pedidio);
            return fa;
        }
        public int Editar(BE.cls16_PedidoReaprovisionamiento pedidio)
        {
            int fa;
            fa = mapper.Editar(pedidio);
            return fa;
        }
        public int Eliminar(BE.cls16_PedidoReaprovisionamiento pedidio)
        {
            int fa;
            fa = mapper.Eliminar(pedidio);
            return fa;
        }
        public int Max(BE.cls16_PedidoReaprovisionamiento pedidio)
        {
            int fa;
            fa = mapper.MaxId(pedidio);
            return fa;
        }
        public List<BE.cls16_PedidoReaprovisionamiento> ListarCatalogo()
        {
            List<BE.cls16_PedidoReaprovisionamiento> pedidio = mapper.Listar();
            return pedidio;
        }
        public List<BE.cls16_PedidoReaprovisionamiento> ListarCatalogo2()
        {
            List<BE.cls16_PedidoReaprovisionamiento> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls16_PedidoReaprovisionamiento stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
