using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsAcceso
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public const string BaseDeDatos = "AluSoft_entrega";
        static readonly string[] cadenas = {
            @"Data Source=localhost\SQLEXPRESS06;Initial Catalog=" + BaseDeDatos + ";Integrated Security=True;TrustServerCertificate=True;Connect Timeout=5;",
            @"Data Source=.;Initial Catalog=" + BaseDeDatos + ";Integrated Security=True;TrustServerCertificate=True;Connect Timeout=5;",
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=" + BaseDeDatos + ";Integrated Security=True;TrustServerCertificate=True;Connect Timeout=5;"
        };
        static string cadenaQueFunciona;

        public static string CadenaConexion
        {
            get
            {
                if (cadenaQueFunciona != null) return cadenaQueFunciona;
                foreach (string cadena in cadenas)
                {
                    try
                    {
                        using (SqlConnection prueba = new SqlConnection(cadena))
                        {
                            prueba.Open();
                            cadenaQueFunciona = cadena;
                            return cadena;
                        }
                    }
                    catch (SqlException) { }
                }
                return cadenas[0];
            }
        }

        public void Conectar()
        {
            try
            {
                if (cn.State != ConnectionState.Closed)
                    cn.Close();
                cn.ConnectionString = CadenaConexion;
                cn.Open();
            }
            catch (SqlException ex)
            {
                cadenaQueFunciona = null;
                throw new InvalidOperationException(
                    "No se pudo conectar con la base " + BaseDeDatos + " en ninguna de las instancias configuradas.", ex);
            }
        }

        public void Desconectar()
        {
            cn.Close();
            cn.Dispose();
        }

        public int Escribir(string sp, SqlParameter[] parametro)
        {
            int fa = 0;
            Conectar();
            cmd.Parameters.Clear();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (parametro != null)
            {
                cmd.Parameters.AddRange(parametro);
                fa = cmd.ExecuteNonQuery();
            }
            else
            {
                fa = cmd.ExecuteNonQuery();
            }
            cmd.Parameters.Clear();
            Desconectar();
            return fa;
        }

        public DataTable Leer(string sp, SqlParameter[] parametro)
        {
            Desconectar();
            cmd.Parameters.Clear();
            DataTable dt = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            Conectar();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (parametro != null)
            {
                cmd.ExecuteReader();
            }
            adaptador.SelectCommand = cmd;
            adaptador.Fill(dt);
            Desconectar();
            return dt;
        }
        public DataTable LeerConParametro(string sp, SqlParameter[] parametro)
        {
            Desconectar();
            cmd.Parameters.Clear();
            DataTable dt = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();
            Conectar();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            if (parametro != null)
            {
                cmd.Parameters.AddRange(parametro);
            }
            adaptador.SelectCommand = cmd;
            adaptador.Fill(dt);
            Desconectar();
            return dt;
        }
        public SqlDataReader LeerConDataReader(string StoredProcedure, SqlParameter[] parametros)
        {
            Conectar();
            SqlCommand comando = new SqlCommand();
            comando.Connection = cn;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = StoredProcedure;
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros);               
            }
            SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
    }
}
