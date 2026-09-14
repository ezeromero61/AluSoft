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

            SqlParameter[] parametro = new SqlParameter[3];

            parametro[0] = new SqlParameter("@IdProveedor", proveedor.Idproveedor);
            parametro[1] = new SqlParameter("@IdPersona", proveedor.Idpersona);
            parametro[2] = new SqlParameter("@NombreEmpresa", proveedor.Nombre_empresa);

            fa = acc.Escribir("AgregarProveedor", parametro);

            return fa;
        }

        public int Editar(BE.cls04_Proveedor proveedor)
        {
            int fa = 0;

            SqlParameter[] parametro = new SqlParameter[3];

            parametro[0] = new SqlParameter("@IdProveedor", proveedor.Idproveedor);
            parametro[1] = new SqlParameter("@IdPersona", proveedor.Idpersona);
            parametro[2] = new SqlParameter("@NombreEmpresa", proveedor.Nombre_empresa);

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
                //BE.cls01_Inventario inventario = new BE.cls01_Inventario();
                proveedor.Idproveedor = int.Parse(dr["IdProveedor"].ToString());
                //ls=(inventario.Idinventario);
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
    }
}

