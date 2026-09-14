using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Reportes
    {
        mapReportes mapper = new mapReportes();
        public int Agregar(BE.cls22_Reportes reporte)
        {
            int fa;
            fa = mapper.Agregar(reporte);
            return fa;
        }
        public int Editar(BE.cls22_Reportes reporte)
        {
            int fa;
            fa = mapper.Editar(reporte);
            return fa;
        }
        public int Eliminar(BE.cls22_Reportes reporte)
        {
            int fa;
            fa = mapper.Eliminar(reporte);
            return fa;
        }
        public int Max(BE.cls22_Reportes reporte)
        {
            int fa;
            fa = mapper.MaxId(reporte);
            return fa;
        }
        public List<BE.cls22_Reportes> ListarCatalogo()
        {
            List<BE.cls22_Reportes> reporte = mapper.Listar();
            return reporte;
        }
    }
}
