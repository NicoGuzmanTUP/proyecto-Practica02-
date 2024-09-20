using System.Data;
using System.Data.SqlClient;

namespace proyecto_Practica02_.Utils
{
    public class DataHelper
    {
        public static DataHelper? _instance=null;
        private SqlConnection connection;

        public DataHelper()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-Q6GKN7O\SQLEXPRESS;Initial Catalog=Facturacion;Integrated Security=True");
        }

        public static DataHelper GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataHelper();
            }

            return _instance;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public DataTable Consult(string sp, List<SqlParameter>? parameters = null)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;

            if(parameters != null)
            {
                foreach(var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                }
            }

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            
            return dt;
        }

        public DataTable ExecuteSpQuery(string sp, List<ParameterSQL> parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                var cmd = new SqlCommand(sp, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if(parameters != null)
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                dataTable.Load(cmd.ExecuteReader());
                connection.Close();
            }
            catch (SqlException)
            {
                dataTable = null;
            }

            return dataTable;

        }

        public int ExcuteSPDML(string sp, List<ParameterSQL>? parameters)
        {
            int row=0;
            try
            {
                connection.Open();
                var cmd = new SqlCommand(sp, connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if(parameters != null)
                {
                    foreach(var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Name, param.Value);
                    }
                }
                row = cmd.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                //row = 0;
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return row;
        }
    }
}
