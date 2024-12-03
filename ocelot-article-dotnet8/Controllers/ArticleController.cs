using Microsoft.AspNetCore.Mvc;
using ocelot_article_dotnet8.Entity;
using ocelot_article_dotnet8.Repository.IRepository;

namespace ocelot_article_dotnet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController(IArticleRepository articleRepository) : Controller
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            var articles = articleRepository.GetAll();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var article = articleRepository.GetById(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }
            articleRepository.Add(article);
            return CreatedAtAction(nameof(GetById), new { id = article.Id }, article);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Article article)
        {
            if (article == null || article.Id != id)
            {
                return BadRequest();
            }

            var existingArticle = articleRepository.GetById(id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            articleRepository.Update(article);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var article = articleRepository.GetById(id);
            if (article == null)
            {
                return NotFound();
            }

            articleRepository.Delete(id);
            return NoContent();
        }
    }
}