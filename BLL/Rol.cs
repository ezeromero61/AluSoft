using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Rol
    {
        mapRol mapper = new mapRol();

        public int Agregar(BE.cls25_Rol rol)
        {
            return mapper.Agregar(rol);
        }

        public int Editar(BE.cls25_Rol rol)
        {
            return mapper.Editar(rol);
        }

        public int Eliminar(BE.cls25_Rol rol)
        {
            return mapper.Eliminar(rol);
        }

        public int Max()
        {
            return mapper.MaxId();
        }

        public List<BE.cls25_Rol> ListarRol()
        {
            return mapper.Listar();
        }

        public DataTable Consultar(BE.cls25_Rol rol, int id)
        {
            return mapper.Consultar(rol, id);
        }
    }
}
