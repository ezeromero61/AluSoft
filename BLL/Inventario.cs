using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Inventario
    {
        mapInventario mapper = new mapInventario();
        public int Agregar(BE.cls01_Inventario inventario)
        {
            int fa;
            fa = mapper.Agregar(inventario);
            return fa;
        }
        public DataTable Consultar(BE.cls01_Inventario inventario, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(inventario, id);
            return tabla;
        }

        public int Editar(BE.cls01_Inventario inventario)
        {
            int fa;
            fa = mapper.Editar(inventario);
            return fa;
        }
        public int Eliminar(BE.cls01_Inventario inventario)
        {
            int fa;
            fa = mapper.Eliminar(inventario);
            return fa;
        }
        public int Max(BE.cls01_Inventario inventario)
        {
            int fa;
            fa = mapper.MaxId(inventario);
            return fa;
        }
        public List<BE.cls01_Inventario> ListarCatalogo()
        {
            List<BE.cls01_Inventario> inventario = mapper.Listar();
            return inventario;
        }
        public List<BE.cls01_Inventario> ListarCatalogo2()
        {
            List<BE.cls01_Inventario> inventario = mapper.Listar2();
            return inventario;
        }
        public List<BE.cls01_Inventario> ListarId()
        {
            List<BE.cls01_Inventario> inventario = mapper.ListarId();
            return inventario;
        }
    }
}
