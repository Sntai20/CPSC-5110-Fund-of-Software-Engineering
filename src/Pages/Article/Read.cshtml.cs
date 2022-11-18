namespace ContosoCrafts.WebSite.Pages.Article
{
    using System.Linq;
    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ReadModel : PageModel
    {
        // Data middle tier
        public JsonFileArticleService ArticleService { get; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="articleService">The service responsible for interacting with the data store.</param>
        public ReadModel(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        // The data to show
        public ArticleModel Article;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id">The article id as a string.</param>
        public IActionResult OnGet(string id)
        {
            this.Article = ArticleService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if (Article == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
