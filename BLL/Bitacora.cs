using DAL;
using System;
using System.Collections.Generic;
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
        //public List<BE.cls35_Bitacora> ListarId()
        //{
        //    List<BE.cls35_Bitacora> inventario = mapper.ListarId();
        //    return inventario;
        //}
        //public List<BE.cls35_Bitacora> ListarConId(int id)
        //{
        //    List<BE.cls35_Bitacora> inventario = mapper.ListarConID(id);
        //    return inventario;
        //}
    }
}
