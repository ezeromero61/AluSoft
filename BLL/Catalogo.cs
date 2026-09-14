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
    public class Catalogo
    {
         mapCatalogo mapper = new mapCatalogo();
        public int Agregar(BE.cls12_Catalogo catalogo)
        {
            int fa;
            fa = mapper.Agregar(catalogo);
            return fa;
        }
        public int Editar(BE.cls12_Catalogo catalogo)
        {
            int fa;
            fa = mapper.Editar(catalogo);
            return fa;
        }
        public int Eliminar(BE.cls12_Catalogo catalogo)
        {
            int fa;
            fa = mapper.Eliminar(catalogo);
            return fa;
        }
        public int Max(BE.cls12_Catalogo catalogo)
        {
            int fa;
            fa = mapper.MaxId(catalogo);
            return fa;
        }
        public List<BE.cls12_Catalogo> ListarCatalogo()
        {
            List<BE.cls12_Catalogo> catalogo = mapper.Listar();
            return catalogo;
        }
        public List<BE.cls12_Catalogo> Listar2()
        {
            List<BE.cls12_Catalogo> catalogo = mapper.Listar2();
            return catalogo;
        }
        public DataTable Consultar(BE.cls12_Catalogo inventario, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(inventario, id);
            return tabla;
        }
    }
}
