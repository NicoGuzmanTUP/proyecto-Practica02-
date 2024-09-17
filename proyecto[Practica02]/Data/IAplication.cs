using Microsoft.AspNetCore.Mvc;
using proyecto_Practica02_.Models;

namespace proyecto_Practica02_.Data.Interfaces
{
    public interface IAplication
    {
        IActionResult Get();

        List<Article> GetComponents();

        bool PostComponents(Article article);
        //IEnumerable<Article> GetAll();
        //IActionResult Get(int id);
        void Add(Article article);
        //IActionResult Update(int id);
        //IActionResult Delete(int id);
    }
}
