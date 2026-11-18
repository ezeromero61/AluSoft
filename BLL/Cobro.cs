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
    public class Cobro
    {
        mapCobro mapper = new mapCobro();
        public int Agregar(BE.cls10_Cobro cobro)
        {
            int fa;
            fa = mapper.Agregar(cobro);
            return fa;
        }
        public int Editar(BE.cls10_Cobro cobro)
        {
            int fa;
            fa = mapper.Editar(cobro);
            return fa;
        }
        public int Eliminar(BE.cls10_Cobro cobro)
        {
            int fa;
            fa = mapper.Eliminar(cobro);
            return fa;
        }
        public int Max(BE.cls10_Cobro cobro)
        {
            int fa;
            fa = mapper.MaxId(cobro);
            return fa;
        }
        public List<BE.cls10_Cobro> ListarCatalogo()
        {
            List<BE.cls10_Cobro> cobro = mapper.Listar();
            return cobro;
        }
        public List<BE.cls10_Cobro> ListarCatalogo2()
        {
            List<BE.cls10_Cobro> stock = mapper.Listar2();
            return stock;
        }
        public DataTable Consultar(BE.cls10_Cobro stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
