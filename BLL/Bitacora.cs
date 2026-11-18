using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bitacora
    {
        mapBitacora mapper = new mapBitacora();
        public int Agregar(BE.cls35_Bitacora inventario)
        {
            int fa;
            fa = mapper.Agregar(inventario);
            return fa;
        }
        public int Editar(BE.cls35_Bitacora inventario)
        {
            int fa;
            fa = mapper.Editar(inventario);
            return fa;
        }
        public int Eliminar(BE.cls35_Bitacora inventario)
        {
            int fa;
            fa = mapper.Eliminar(inventario);
            return fa;
        }
        public int Max(BE.cls35_Bitacora inventario)
        {
            int fa;
            fa = mapper.MaxId(inventario);
            return fa;
        }
        public List<BE.cls35_Bitacora> ListarCatalogo()
        {
            List<BE.cls35_Bitacora> inventario = mapper.Listar();
            return inventario;
        }
        public List<BE.cls35_Bitacora> ListarCompleto()
        {
            List<BE.cls35_Bitacora> inventario = mapper.ListarCompleto();
            return inventario;
        }
        public DataTable ConsultarConFecha(BE.cls35_Bitacora inventario, DateTime id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.ConsultarConFecha(inventario, id);
            return tabla;
        }
        public DataTable ConsultarConAccion(BE.cls35_Bitacora inventario, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.ConsultarConAccion(inventario, id);
            return tabla;
        }
        public DataTable ConsultarConRol(BE.cls35_Bitacora inventario, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.ConsultarConRol(inventario, id);
            return tabla;
        }
        public DataTable ConsultarConTabla(BE.cls35_Bitacora inventario, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.ConsultarConTabla(inventario, id);
            return tabla;
        }
        public DataTable ConsultarConUsuario(BE.cls35_Bitacora inventario, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.ConsultarConUsuario(inventario, id);
            return tabla;
        }
    }
}
