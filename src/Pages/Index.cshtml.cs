namespace ContosoCrafts.WebSite.Pages;

using System.Collections.Generic;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

/// <summary>
/// Index Page will return all the data to show the user.
/// </summary>
/// <remarks>
/// Constructor
/// </remarks>
public class IndexModel(ILogger<IndexModel> logger, JsonFileArticleService articleService) : PageModel
{

    // message logging interface
    private readonly ILogger<IndexModel> logger = logger;

    /// <summary>
    /// Store the service responsible for interacting with the data store.
    /// </summary>
    public JsonFileArticleService ArticleService { get; } = articleService;

    /// <summary>
    /// Collection of the Data.
    /// </summary>
    public IEnumerable<ArticleModel> Articles { get; private set; }
    
    /// <summary>
    /// REST OnGet
    /// Return all the data
    /// </summary>
    public void OnGet()
    {
        Articles = ArticleService.GetAllData();
    }
}
