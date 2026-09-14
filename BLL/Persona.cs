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
    public class Persona
    {
        mapPersona mapper = new mapPersona();
        public int Agregar(BE.cls00_Persona persona)
        {
            int fa;
            fa = mapper.Agregar(persona);
            return fa;
        }
        public int Editar(BE.cls00_Persona persona)
        {
            int fa;
            fa = mapper.Editar(persona);
            return fa;
        }
        public int Eliminar(BE.cls00_Persona persona)
        {
            int fa;
            fa = mapper.Eliminar(persona);
            return fa;
        }
        public int Max(BE.cls00_Persona catalogo)
        {
            int fa;
            fa = mapper.MaxId(catalogo);
            return fa;
        }
        public List<BE.cls00_Persona> ListarCatalogo()
        {
            List<BE.cls00_Persona> persona = mapper.Listar();
            return persona;
        }
        public List<BE.cls00_Persona> ListarCatalogo2()
        {
            List<BE.cls00_Persona> persona = mapper.Listar2();
            return persona;
        }
        public DataTable Consultar(BE.cls00_Persona stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.Consultar(stock, id);
            return tabla;
        }
    }
}
