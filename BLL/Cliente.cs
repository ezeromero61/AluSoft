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
    public class Cliente
    {
        mapCliente mapper = new mapCliente();
        public int Agregar(BE.cls03_Cliente cliente)
        {
            int fa;
            fa = mapper.Agregar(cliente);
            return fa;
        }
        public int Editar(BE.cls03_Cliente cliente)
        {
            int fa;
            fa = mapper.Editar(cliente);
            return fa;
        }
        public int Eliminar(BE.cls03_Cliente cliente)
        {
            int fa;
            fa = mapper.Eliminar(cliente);
            return fa;
        }
        public int Max(BE.cls03_Cliente cliente)
        {
            int fa;
            fa = mapper.MaxId(cliente);
            return fa;
        }
        public List<BE.cls03_Cliente> ListarCatalogo()
        {
            List<BE.cls03_Cliente> cliente = mapper.Listar();
            return cliente;
        }
        public List<string> ListarIdNombreApellido()
        {
            List<string> cliente = mapper.ListarIdNombreApellido();
            return cliente;
        }
        public List<cls00_Persona> ListarIdPersonaNombreApellido()
        {
            List<cls00_Persona> cliente = mapper.ListarIdPersonaNombreApellido();
            return cliente;
        }       
        public DataTable ConsultarIdUsuario(BE.cls03_Cliente stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.ConsultarIdUsuario(stock, id);
            return tabla;
        }
        public DataTable ConsultarIdPersonaIdCliente(BE.cls03_Cliente stock, int id)
        {
            DataTable tabla = new DataTable();
            tabla = mapper.ConsultarIdPersonaIdCliente(stock, id);
            return tabla;
        }
    }
}
