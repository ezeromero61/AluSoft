using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class cls05_Login
    {
        #region Atributos
        public int idlogin;
        public int idrol;
        public string usuario;
        public string contraseña;
        public int digitoverificador;
        #endregion
        #region Propiedades
        public int IdLogin
        {
            get => idlogin;
            set { idlogin = value; }
        }
        public int IdRol
        {
            get => idrol;
            set { idrol = value; }
        }
        public string Usuario
        {
            get => usuario;
            set { usuario = value; }
        }
        public string Contraseña
        {
            get => contraseña;
            set { contraseña = value; }
        }
        public int DigitoVerificador
        {
            get => digitoverificador;
            set { digitoverificador = value; }
        }

        #endregion
    }
}
