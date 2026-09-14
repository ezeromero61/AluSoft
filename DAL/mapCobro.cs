using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapCobro
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls10_Cobro cobro)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[9];

            parametro[0] = new SqlParameter("@IdCobro", cobro.Idcobro);
            parametro[1] = new SqlParameter("@NumeroCobro", cobro.Numerocobro);
            parametro[2] = new SqlParameter("@IdFactura", cobro.Idfactura);
            parametro[3] = new SqlParameter("@IdCliente", cobro.Idcliente);
            parametro[4] = new SqlParameter("@FechaCobro", cobro.Fechacobro);
            parametro[5] = new SqlParameter("@Importe", cobro.Importe);
            parametro[6] = new SqlParameter("@FormaPago", cobro.Formapago);
            parametro[7] = new SqlParameter("@Estado", cobro.Estado);
            parametro[8] = new SqlParameter("@Observaciones", cobro.Observaciones);

            fa = acc.Escribir("AgregarCobro", parametro);
            return fa;
        }

        public int Editar(BE.cls10_Cobro cobro)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[10];

            parametro[0] = new SqlParameter("@IdCobro", cobro.Idcobro);
            parametro[1] = new SqlParameter("@NumeroCobro", cobro.Numerocobro);
            parametro[2] = new SqlParameter("@IdFactura", cobro.Idfactura);
            parametro[3] = new SqlParameter("@IdCliente", cobro.Idcliente);
            parametro[4] = new SqlParameter("@FechaCobro", cobro.Fechacobro);
            parametro[5] = new SqlParameter("@Importe", cobro.Importe);
            parametro[6] = new SqlParameter("@FormaPago", cobro.Formapago);
            parametro[7] = new SqlParameter("@Estado", cobro.Estado);
            parametro[8] = new SqlParameter("@Observaciones", cobro.Observaciones);
            parametro[9] = new SqlParameter("@IdLogin", cobro.Idlogin);

            fa = acc.Escribir("EditarCobro", parametro);
            return fa;
        }

        public int Eliminar(BE.cls10_Cobro cobro)
        {
            int fa = 0;
            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdCobro", cobro.Idcobro);

            fa = acc.Escribir("EliminarCobro", parametro);
            return fa;
        }

        public int MaxId(BE.cls10_Cobro cobro)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdCobro", null);

            foreach (DataRow dr in tabla.Rows)
            {
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                cobro.Idcobro = int.Parse(dr["IdCobro"].ToString());
                //ls=(inventario.Idinventario);
            }

            return ls = cobro.Idcobro;
        }

        public List<BE.cls10_Cobro> Listar()
        {
            List<BE.cls10_Cobro> ls = new List<BE.cls10_Cobro>();

            DataTable tabla = acc.Leer("ListarCobro", null);

            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls10_Cobro cobro = new BE.cls10_Cobro();

                cobro.Idcobro = int.Parse(dr["IdCobro"].ToString());
                cobro.Numerocobro = dr["NumeroCobro"].ToString();
                cobro.Idfactura = int.Parse(dr["IdFactura"].ToString());
                cobro.Idcliente = int.Parse(dr["IdCliente"].ToString());
                if (dr["FechaCobro"] != DBNull.Value)
                    cobro.Fechacobro = Convert.ToDateTime(dr["FechaCobro"]);
                cobro.Importe = decimal.Parse(dr["Importe"].ToString());
                cobro.Formapago = dr["FormaPago"].ToString();
                cobro.Estado = dr["Estado"].ToString();
                cobro.Observaciones = dr["Observaciones"].ToString();
                cobro.Idlogin = int.Parse(dr["IdLogin"].ToString());

                ls.Add(cobro);
            }

            return ls;
        }
    }
}
