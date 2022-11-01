namespace ContosoCrafts.WebSite.Pages.Article
{
    using System.Collections.Generic;

    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// Index Page will return all the data to show the user.
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="articleService">The service responsible for interacting with the data store.</param>
        public IndexModel(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        /// <summary>
        /// Store the service responsible for interacting with the data store.
        /// </summary>
        public JsonFileArticleService ArticleService { get; }

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
}
