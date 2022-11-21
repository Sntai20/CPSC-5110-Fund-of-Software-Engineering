namespace ContosoCrafts.WebSite.Pages.Article
{
    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// Create Page
    /// </summary>
    public class CreateModel : PageModel
    {

        // Data middle tier
        public JsonFileArticleService ArticleService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="articleService">The service responsible for interacting with the data store.</param>
        public CreateModel(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        // The data to show
        public ArticleModel Article;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <returns>Redirect the web page to the Update page populated with the data so the user can fill in the fields.</returns>
        public IActionResult OnGet()
        {
            this.Article = ArticleService.CreateArticle();

            return RedirectToPage("./Update", new { this.Article.Id });
        }
    }
}
