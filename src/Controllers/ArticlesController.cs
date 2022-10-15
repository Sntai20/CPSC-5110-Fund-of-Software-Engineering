using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        public ArticlesController(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        public JsonFileArticleService ArticleService { get; }

        [HttpGet]
        public IEnumerable<ArticleModel> Get() 
        {
            return ArticleService.GetAllData();
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ArticleService.AddRating(request.ArticleId, request.Rating);
            
            return Ok();
        }

        public class RatingRequest
        {
            public string ArticleId { get; set; }
            public int Rating { get; set; }
        }
    }
}