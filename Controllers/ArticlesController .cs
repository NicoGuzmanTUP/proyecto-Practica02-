using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_Practica02_.Data.Implementations;
using proyecto_Practica02_.Data.Interfaces;
using proyecto_Practica02_.Models;
using proyecto_Practica02_.Services;
using proyecto_Practica02_.Utils;
using System.Data.SqlClient;

namespace proyecto_Practica02_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase 
    {
        private IProductionService productionService;

        public ArticlesController(IAplication articleRepository)
        {
            productionService = new ProductionService();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Article article)
        {
            try
            {
                if (article == null)
                {
                    return BadRequest("Algo salió mal :(");
                }
                if (productionService.AddArticle(article))
                {
                    return Ok($"{article.Name} Guardado Correctamente");
                }
                else
                {
                    return StatusCode(500, "Hubo un imprevisto");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(productionService.GetAllArticle());
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                return Ok(productionService.GetById(id));
            }
            catch (SqlException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = productionService.DeleteArticle(id);
                if (isDeleted)
                {
                    return Ok($"El artículo con id {id} fue eliminado exitosamente.");
                }
                else
                {
                    return NotFound($"No se encontró el artículo con id {id}.");
                }
            }
            catch (SqlException ex)
            {
                return StatusCode(500, $"Error no conocido {ex.Message}");
            }
        }
    }
}
