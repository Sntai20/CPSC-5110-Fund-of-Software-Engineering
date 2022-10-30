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
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        // The data to show
        public ArticleModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet()
        {
            Product = ArticleService.CreateData();

            // Redirect the webpage to the Update page populated with the data so the user can fill in the fields
            return RedirectToPage("./Update", new { Product.Id });
        }
    }
}
