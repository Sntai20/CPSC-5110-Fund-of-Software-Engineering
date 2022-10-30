using System.Collections.Generic;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Article
{
    /// <summary>
    /// Index Page will return all the data to show the user
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="articleService"></param>
        public IndexModel(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        // Data Service
        public JsonFileArticleService ArticleService { get; }

        // Collection of the Data
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
}