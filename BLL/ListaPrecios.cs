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
    public class ListaPrecios
    {
        mapListaPrecios mapper = new mapListaPrecios();
        public int Agregar(BE.cls13_ListaPrecios lista)
        {
            int fa;
            fa = mapper.Agregar(lista);
            return fa;
        }
        public int Editar(BE.cls13_ListaPrecios lista)
        {
            int fa;
            fa = mapper.Editar(lista);
            return fa;
        }
        public int Eliminar(BE.cls13_ListaPrecios lista)
        {
            int fa;
            fa = mapper.Eliminar(lista);
            return fa;
        }
        public int Max(BE.cls13_ListaPrecios lista)
        {
            int fa;
            fa = mapper.MaxId(lista);
            return fa;
        }
        public List<BE.cls13_ListaPrecios> ListarCatalogo()
        {
            List<BE.cls13_ListaPrecios> lista = mapper.Listar();
            return lista;
        }
        public DataTable Consultar(BE.cls13_ListaPrecios stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
        public List<BE.cls13_ListaPrecios> ListarCatalogo2()
        {
            List<BE.cls13_ListaPrecios> lista = mapper.Listar2();
            return lista;
        }
    }
}
