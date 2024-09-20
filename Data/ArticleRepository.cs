using Microsoft.AspNetCore.Mvc;
using proyecto_Practica02_.Data.Interfaces;
using proyecto_Practica02_.Models;
using proyecto_Practica02_.Utils;
using System.Data;
using System.Data.SqlClient;

namespace proyecto_Practica02_.Data.Implementations
{
    public class ArticleRepository : IAplication
    {
        private static readonly List<Article> lstArticles = new List<Article>();

        public void Add(Article article)
        {
            lstArticles.Add(article);
        }

        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Article> GetAll()
        //{
        //    return lstArticles.Where(a => !a.IsActive);
        //}

        public List<Article> GetComponents()
        {
            DataTable table = DataHelper.GetInstance().Consult("OBTENER_ARTICULOS");
            List<Article> list = new List<Article>();

            foreach (DataRow row in table.Rows)
            {
                int id = Convert.ToInt32(row["id_articulo"]);
                string name = Convert.ToString(row["nombre"]);
                double price = Convert.ToDouble(row["precio_unitario"]);                
                string description = Convert.ToString(row["descripcion"]);
                Article article = new Article(name, id, price, description);
                list.Add(article);
            }
            return list;
        }

        public bool PostComponents(Article article)
        {
           try
            { 
                SqlConnection connection = DataHelper.GetInstance().GetConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand("AGREGAR_ARTICULOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", article.Name);
                cmd.Parameters.AddWithValue("precio", article.Price);
                cmd.Parameters.AddWithValue("@descripcion", article.Description);
                cmd.ExecuteNonQuery();
                connection.Close();

                return true; 
            }
            catch { return false; }
        }

        public bool DeleteComponents(int id)
        {
            try
            {
                var parameters = new List<ParameterSQL>()
                {
                    new ParameterSQL("@id", id)
                };

                int rowsAffected = DataHelper.GetInstance().ExcuteSPDML("ELIMINAR_PRODUCTO", parameters);

                return rowsAffected == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error eliminando el artículo: {ex.Message}");

                return false;
            }
        }

        public Article? GetByIdComponents(int id)
        {
            Article? oArticle = null;
            var helper = DataHelper.GetInstance();

            var parameters = new List<ParameterSQL>
            {
                new ParameterSQL("@id", id),
            };

            var table = helper.ExecuteSpQuery("BUSCAR_ARTICULO", parameters);
            if(table.Rows.Count > 0) 
            {
                DataRow row = table.Rows[0];
                oArticle = new Article() {
                    Id = Convert.ToInt32(row["id_articulo"].ToString()),
                    Name = row["nombre"].ToString(),
                    Price = Convert.ToDouble(row["precio_unitario"].ToString()),
                    Description = row["descripcion"].ToString()
                };
            }
            
            return oArticle;
        }

    }
}
