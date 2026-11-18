using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Tabla
    {
        mapTabla mapper = new mapTabla();

        public int Agregar(BE.cls29_Tabla tabla)
        {
            return mapper.Agregar(tabla);
        }

        public int Editar(BE.cls29_Tabla tabla)
        {
            return mapper.Editar(tabla);
        }

        public int Eliminar(BE.cls29_Tabla tabla)
        {
            return mapper.Eliminar(tabla);
        }

        public int Max(BE.cls29_Tabla tabla)
        {
            return mapper.MaxId(tabla);
        }

        public List<BE.cls29_Tabla> ListarTabla()
        {
            return mapper.Listar();
        }

        public DataTable Consultar(BE.cls29_Tabla tabla, int id)
        {
            return mapper.Consultar(tabla, id);
        }
    }
}
