using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_Practica02_.Data.Implementations;
using proyecto_Practica02_.Data.Interfaces;
using proyecto_Practica02_.Models;
using proyecto_Practica02_.Services;

namespace proyecto_Practica02_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase 
    {
        //private static readonly List<Article> lstArticles = new List<Article>();

        //private readonly IAplication _articleRepository;
        private IProductionService productionService;

        public ArticlesController(IAplication articleRepository)
        {
            productionService = new ProductionService();
        }

        //public IActionResult Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        public IActionResult Add([FromBody] Article article)
        {
            try
            {
                if (article == null)
                {                    
                    return BadRequest("Algo salió mal :(");                    
                }
                if(productionService.AddArticle(article))
                {
                    return Ok($"{article.Name} Guardado Correctamente");
                }
                else
                {
                    return StatusCode(500,"Hubo un imprevisto");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        //[Route("items")]
        public IActionResult GetAll()
        {
            return Ok(productionService.GetAllArticle());
        }


        //public IActionResult Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IActionResult Update(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
