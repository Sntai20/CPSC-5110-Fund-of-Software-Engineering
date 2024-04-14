namespace ContosoCrafts.WebSite.Controllers;

using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Article control class definition
/// </summary>
/// <remarks>
/// Controller class for Articles
/// </remarks>
/// <param name="articleService"></param>
[ApiController]
[Route("[controller]")]
public class ArticlesController(JsonFileArticleService articleService) : ControllerBase
{
    /// <summary>
    /// Retrieve ArticleServer property.
    /// Data middle tier.
    /// </summary>
    public JsonFileArticleService ArticleService { get; } = articleService;

    /// <summary>
    /// Get all data from Json database
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ArticleModel> Get()
    {
        return ArticleService.GetAllData();
    }
}
