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
    public class Maximo
    {
        mapMaximo mapper = new mapMaximo();
        public int Agregar(BE.cls19_Maximo maximo)
        {
            int fa;
            fa = mapper.Agregar(maximo);
            return fa;
        }
        public int Editar(BE.cls19_Maximo maximo)
        {
            int fa;
            fa = mapper.Editar(maximo);
            return fa;
        }
        public int Eliminar(BE.cls19_Maximo maximo)
        {
            int fa;
            fa = mapper.Eliminar(maximo);
            return fa;
        }
        public int Max(BE.cls19_Maximo maximo)
        {
            int fa;
            fa = mapper.MaxId(maximo);
            return fa;
        }
        public List<BE.cls19_Maximo> ListarCatalogo()
        {
            List<BE.cls19_Maximo> maximo = mapper.Listar();
            return maximo;
        }
        public List<BE.cls19_Maximo> ListarCatalogo2()
        {
            List<BE.cls19_Maximo> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls19_Maximo stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
