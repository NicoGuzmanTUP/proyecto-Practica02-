using proyecto_Practica02_.Models;

namespace proyecto_Practica02_.Services
{
    public interface IProductionService
    {
        List<Article> GetAllArticle();

        bool AddArticle(Article article);
    }
}
