using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class mapProveedor
    {
        clsAcceso acc = new clsAcceso();
        public int Agregar(BE.cls04_Proveedor proveedor)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[4];

            parametro[0] = new SqlParameter("@IdProveedor", proveedor.Idproveedor);
            parametro[1] = new SqlParameter("@IdPersona", proveedor.Idpersona);
            parametro[2] = new SqlParameter("@NombreEmpresa", proveedor.Nombre_empresa);
            parametro[3] = new SqlParameter("@DigitoVerificador",
                proveedor.DigitoVerificador > 0 ? proveedor.DigitoVerificador : 1);

            fa = acc.Escribir("AgregarProveedor", parametro);

            return fa;
        }

        public int Editar(BE.cls04_Proveedor proveedor)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[4];

            parametro[0] = new SqlParameter("@IdProveedor", proveedor.Idproveedor);
            parametro[1] = new SqlParameter("@IdPersona", proveedor.Idpersona);
            parametro[2] = new SqlParameter("@NombreEmpresa", proveedor.Nombre_empresa);
            parametro[3] = new SqlParameter("@DigitoVerificador",
                proveedor.DigitoVerificador > 0 ? proveedor.DigitoVerificador : 1);

            fa = acc.Escribir("EditarProveedor", parametro);

            return fa;
        }

        public int Eliminar(BE.cls04_Proveedor proveedor)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[1];

            parametro[0] = new SqlParameter("@IdProveedor", proveedor.Idproveedor);

            fa = acc.Escribir("EliminarProveedor", parametro);

            return fa;
        }
        public int MaxId(BE.cls04_Proveedor proveedor)
        {
            int ls = 0;
            DataTable tabla = acc.Leer("MAXIdProveedor", null);
            foreach (DataRow dr in tabla.Rows)
            {
                proveedor.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
            }
            return ls = proveedor.Idproveedor;
        }
        public List<BE.cls04_Proveedor> Listar()
        {
            List<BE.cls04_Proveedor> ls = new List<BE.cls04_Proveedor>();
            DataTable tabla = acc.Leer("ListarProveedor", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls04_Proveedor proveedor = new BE.cls04_Proveedor();
                proveedor.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                proveedor.Idpersona = int.Parse(dr["IdPersona"].ToString());
                proveedor.Nombre_empresa = dr["NombreEmpresa"].ToString();
                proveedor.DigitoVerificador= int.Parse(dr["DigitoVerificador"].ToString());
                ls.Add(proveedor);
            }
            return ls;
        }
        public DataTable Consultar(BE.cls04_Proveedor proveedor, int id)
        {
            SqlParameter[] parametro = new SqlParameter[1];
            parametro[0] = new SqlParameter("@IdProveedor", id);
            DataTable tabla = acc.LeerConParametro("BusquedaConIdProveedor", parametro);
            foreach (DataRow dr in tabla.Rows)
            {
                proveedor.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                proveedor.Idpersona = int.Parse(dr["IdPersona"].ToString());
                proveedor.Nombre_empresa = dr["NombreEmpresa"].ToString();
                proveedor.DigitoVerificador = int.Parse(dr["DigitoVerificador"].ToString());
            }
            return tabla;
        }
        public List<BE.cls04_Proveedor> Listar2()
        {
            List<BE.cls04_Proveedor> ls = new List<BE.cls04_Proveedor>();
            DataTable tabla = acc.Leer("Obtener_04_pROVEEDOR", null);
            foreach (DataRow dr in tabla.Rows)
            {
                BE.cls04_Proveedor proveedor = new BE.cls04_Proveedor();
                proveedor.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                proveedor.Idpersona = int.Parse(dr["IdPersona"].ToString());
                proveedor.Nombre_empresa = dr["NombreEmpresa"].ToString();
                proveedor.DigitoVerificador = int.Parse(dr["DigitoVerificador"].ToString());
                proveedor.Combo = proveedor.Nombre_empresa;
                ls.Add(proveedor);
            }
            return ls;
        }
    }
}

