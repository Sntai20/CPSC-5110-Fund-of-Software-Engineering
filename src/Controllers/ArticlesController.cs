namespace ContosoCrafts.WebSite.Controllers
{
    using System.Collections.Generic;
    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Article control class definition
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        /// <summary>
        /// Controller class for Articles
        /// </summary>
        /// <param name="articleService"></param>
        public ArticlesController(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        /// <summary>
        /// Retrieve ArticleServer property
        /// </summary>
        public JsonFileArticleService ArticleService { get; }

        /// <summary>
        /// Get all data from Json database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ArticleModel> Get()
        {
            return ArticleService.GetAllData();
        }

        /// <summary>
        /// Add requested rating to article. 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            _ = ArticleService.AddRating(request.ArticleId, request.Rating);

            return Ok();
        }

        /// <summary>
        /// Define a rating request class with article ID and rating. 
        /// </summary>
        public class RatingRequest
        {
            public string ArticleId { get; set; }
            public int Rating { get; set; }
        }
    }
}
