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

        public void Conectar()
        {
            cn.ConnectionString = @"Server=localhost\SQLEXPRESS;Database=AluSoft.bacpac;Integrated Security=true";
            
            //cn.ConnectionString = @"Data Source=.;Initial Catalog=Facultad;User ID=sa";
            cn.Open();
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
        public SqlDataReader LeerConDataReaderSinParametro(string StoredProcedure)
        {
            Conectar();
            SqlCommand comando = new SqlCommand();
            comando.Connection = cn;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = StoredProcedure;           
            // cierra automáticamente la conexión cuando se cierre el DataReader
            SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public SqlDataReader LeerConDataReader(string StoredProcedure, SqlParameter[] parametros)
        {
            Conectar();
            SqlCommand comando = new SqlCommand();
            comando.Connection = cn;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = StoredProcedure;
            // Agregar parámetros si existen
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros);               
            }
            // cierra automáticamente la conexión cuando se cierre el DataReader
            SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
    }
}
