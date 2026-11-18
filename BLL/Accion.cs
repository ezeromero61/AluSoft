using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Accion
    {
        mapAccion mapper = new mapAccion();

        public int Agregar(BE.cls28_Accion accion)
        {
            return mapper.Agregar(accion);
        }

        public int Editar(BE.cls28_Accion accion)
        {
            return mapper.Editar(accion);
        }

        public int Eliminar(BE.cls28_Accion accion)
        {
            return mapper.Eliminar(accion);
        }

        public int Max(BE.cls28_Accion accion)
        {
            return mapper.MaxId(accion);
        }

        public List<BE.cls28_Accion> ListarAccion()
        {
            return mapper.Listar();
        }

        public DataTable Consultar(BE.cls28_Accion accion, int id)
        {
            return mapper.Consultar(accion, id);
        }
    }
}
