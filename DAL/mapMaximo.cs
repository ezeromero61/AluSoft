using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapMaximo
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls19_Maximo maximo)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[4];

            parametro[0] = new SqlParameter("@IdMaximo", maximo.Idmaximo);
            parametro[1] = new SqlParameter("@IdStock", maximo.Idstock);
            parametro[2] = new SqlParameter("@Fecha", maximo.Fecha);
            parametro[3] = new SqlParameter("@Cantidad", maximo.Cantidad);

            fa = acc.Escribir("AgregarMaximo", parametro);

            return fa;
        }

        public int Editar(BE.cls19_Maximo maximo)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[4];

            parametro[0] = new SqlParameter("@IdMaximo", maximo.Idmaximo);
            parametro[1] = new SqlParameter("@IdStock", maximo.Idstock);
            parametro[2] = new SqlParameter("@Fecha", maximo.Fecha);
            parametro[3] = new SqlParameter("@Cantidad", maximo.Cantidad);

            fa = acc.Escribir("EditarMaximo", parametro);

            return fa;
        }

        public int Eliminar(BE.cls19_Maximo maximo)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdMaximo", maximo.Idmaximo);

            fa = acc.Escribir("EliminarMaximo", parametro);

            return fa;
        }

        public int MaxId(BE.cls19_Maximo maximo)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdMaximo", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                maximo.Idmaximo = int.Parse(dr["IdMaximo"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = maximo.Idmaximo
                ;
        }

        public List<BE.cls19_Maximo> Listar()
        {
            List<BE.cls19_Maximo> ls = new List<BE.cls19_Maximo>();
            DataTable tabla = acc.Leer("Obtener_02_MaximoStockInventario", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls19_Maximo maximo = new BE.cls19_Maximo();
                maximo.Idmaximo = int.Parse(dr["IdMaximo"].ToString());
                maximo.Idstock = int.Parse(dr["IdStock"].ToString());
                maximo.Nombre = (dr["Nombre"].ToString());
                maximo.Fecha = DateTime.Parse(dr["Fecha"].ToString());
                maximo.Cantidad = int.Parse(dr["Cantidad"].ToString());
                maximo.DigitoVerificador = int.Parse(dr["DigitoVerificador"].ToString());
                ls.Add(maximo);
            }
            return ls;
        }
    }
}

