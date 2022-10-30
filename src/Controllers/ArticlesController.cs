namespace ContosoCrafts.WebSite.Controllers
{
    using System.Collections.Generic;

    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.AspNetCore.Mvc;

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
            _ = ArticleService.AddRating(request.ArticleId, request.Rating);

            return Ok();
        }

        public class RatingRequest
        {
            public string ArticleId { get; set; }
            public int Rating { get; set; }
        }
    }
}