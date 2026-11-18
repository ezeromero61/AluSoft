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
    public class PresupuestoProveedor
    {
        mapPresupuestoProveedor mapper = new mapPresupuestoProveedor();
        public int Agregar(BE.cls18_PresupuestoProveedor presupuesto)
        {
            int fa;
            fa = mapper.Agregar(presupuesto);
            return fa;
        }
        public int Editar(BE.cls18_PresupuestoProveedor presupuesto)
        {
            int fa;
            fa = mapper.Editar(presupuesto);
            return fa;
        }
        public int Eliminar(BE.cls18_PresupuestoProveedor presupuesto)
        {
            int fa;
            fa = mapper.Eliminar(presupuesto);
            return fa;
        }
        public int Max(BE.cls18_PresupuestoProveedor presupuesto)
        {
            int fa;
            fa = mapper.MaxId(presupuesto);
            return fa;
        }
        public List<BE.cls18_PresupuestoProveedor> ListarCatalogo()
        {
            List<BE.cls18_PresupuestoProveedor> presupuesto = mapper.Listar();
            return presupuesto;
        }
        public List<BE.cls18_PresupuestoProveedor> ListarCatalogo2()
        {
            List<BE.cls18_PresupuestoProveedor> presupuesto = mapper.Listar2();
            return presupuesto;
        }
        public DataTable Consultar(BE.cls18_PresupuestoProveedor stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
