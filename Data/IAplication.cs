using Microsoft.AspNetCore.Mvc;
using proyecto_Practica02_.Models;

namespace proyecto_Practica02_.Data.Interfaces
{
    public interface IAplication
    {
        List<Article> GetComponents();
        Article GetByIdComponents(int id);

        bool PostComponents(Article article);

        void Add(Article article);

        //bool DeleteComponents(Article article);        
        bool DeleteComponents(int id);
        
    }
}
