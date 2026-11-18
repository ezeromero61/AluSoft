using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class clsPaginas
    {
        private static Stack<int> pagina = new Stack<int>();

        public static void AgregarNumeroDePagina(int numerodepagina)
        {
            pagina.Push(numerodepagina);
        }

        public static int ObtenerPaginaActual()
        {
            return pagina.Peek();
        }
        public static int QuitarNumeroDePagina()
        {
            if (pagina.Count > 0)
            {
                return pagina.Pop();
            }
            else
            {
                throw new InvalidOperationException("La página está vacía.");
            }
        }
    }
}
