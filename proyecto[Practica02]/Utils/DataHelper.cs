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
    }
}
