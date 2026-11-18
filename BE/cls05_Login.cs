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
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idlogin = value;
            }
        }
        public int IdRol
        {
            get => idrol;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                idrol = value;
            }
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
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "El número debe ser mayor a 0.");
                }
                digitoverificador = value;
            }
        }

        #endregion
    }
}
