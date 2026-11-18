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
    public class PresupuestroCliente
    {
        mapPresupuestoCliente mapper = new mapPresupuestoCliente();
        public int ActualizarEstado(int idPresupuesto, string estado)
        {
            return mapper.ActualizarEstado(idPresupuesto, estado);
        }

        public int Agregar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa;
            fa = mapper.Agregar(presupuesto);
            return fa;
        }
        public int Editar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa;
            fa = mapper.Editar(presupuesto);
            return fa;
        }
        public int Eliminar(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa;
            fa = mapper.Eliminar(presupuesto);
            return fa;
        }
        public int Max(BE.cls07_PresupuestoCliente presupuesto)
        {
            int fa;
            fa = mapper.MaxId(presupuesto);
            return fa;
        }
        public List<BE.cls07_PresupuestoCliente> ListarCatalogo()
        {
            List<BE.cls07_PresupuestoCliente> presupuesto = mapper.Listar();
            return presupuesto;
        }
        public DataTable Consultar(BE.cls07_PresupuestoCliente stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
        public DataTable Consultar2(BE.cls26_Combinado stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar2(stock, id);
            return tabla;
        }
        public List<BE.cls26_Combinado> ListarCatalogo2()
        {
            List<BE.cls26_Combinado> stock = mapper.Listar2();
            return stock;
        }
    }
}
