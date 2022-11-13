namespace ContosoCrafts.WebSite.Pages
{
    using System.Collections.Generic;
    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Index Page will return all the data to show the user.
    /// </summary>
    public class IndexModel : PageModel
    {
        // message logging interface
        private readonly ILogger<IndexModel> logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public IndexModel(ILogger<IndexModel> logger, JsonFileArticleService articleService)
        {
            this.logger = logger;
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
