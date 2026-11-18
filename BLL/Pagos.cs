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
    public class Pagos
    {
        mapPagos mapper = new mapPagos();
        public int Agregar(BE.cls24_Pagos pago)
        {
            int fa;
            fa = mapper.Agregar(pago);
            return fa;
        }
        public int Editar(BE.cls24_Pagos pago)
        {
            int fa;
            fa = mapper.Editar(pago);
            return fa;
        }
        public int Eliminar(BE.cls24_Pagos pago)
        {
            int fa;
            fa = mapper.Eliminar(pago);
            return fa;
        }
        public int Max(BE.cls24_Pagos pago)
        {
            int fa;
            fa = mapper.MaxId(pago);
            return fa;
        }
        public List<BE.cls24_Pagos> ListarCatalogo()
        {
            List<BE.cls24_Pagos> pago = mapper.Listar();
            return pago;
        }
        public List<BE.cls24_Pagos> ListarCatalogo2()
        {
            List<BE.cls24_Pagos> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls24_Pagos stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
