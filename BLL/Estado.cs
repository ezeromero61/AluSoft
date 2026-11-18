using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Estado
    {
        mapEstado mapper = new mapEstado();
        public int Agregar(BE.cls15_Estado estado)
        {
            int fa;
            fa = mapper.Agregar(estado);
            return fa;
        }
        public int Editar(BE.cls15_Estado estado)
        {
            int fa;
            fa = mapper.Editar(estado);
            return fa;
        }
        public int Eliminar(BE.cls15_Estado estado)
        {
            int fa;
            fa = mapper.Eliminar(estado);
            return fa;
        }
        public int Max(BE.cls15_Estado estado)
        {
            int fa;
            fa = mapper.MaxId(estado);
            return fa;
        }
        public List<BE.cls15_Estado> ListarCatalogo()
        {
            List<BE.cls15_Estado> estado = mapper.Listar();
            return estado;
        }
        public List<BE.cls15_Estado> ListarCatalogo2()
        {
            List<BE.cls15_Estado> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls15_Estado stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
