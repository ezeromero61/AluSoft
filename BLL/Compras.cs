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
    public class Compras
    {

            mapCompras mapper = new mapCompras();
            public int Agregar(BE.cls17_Compras cliente)
            {
                int fa;
                fa = mapper.Agregar(cliente);
                return fa;
            }
            public int Editar(BE.cls17_Compras cliente)
            {
                int fa;
                fa = mapper.Editar(cliente);
                return fa;
            }
            public int Eliminar(BE.cls17_Compras cliente)
            {
                int fa;
                fa = mapper.Eliminar(cliente);
                return fa;
            }
            public int Max(BE.cls17_Compras cliente)
            {
                int fa;
                fa = mapper.MaxId(cliente);
                return fa;
            }
            public List<BE.cls17_Compras> ListarCatalogo()
            {
                List<BE.cls17_Compras> cliente = mapper.Listar();
                return cliente;
            }
        public List<BE.cls17_Compras> ListarCatalogo2()
        {
            List<BE.cls17_Compras> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls17_Compras stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }  
}
