using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Article
{
    /// <summary>
    /// Manage the Delete of the data for a single record.
    /// </summary>
    public class DeleteModel : PageModel
    {
        // Data middle tier
        public JsonFileArticleService ArticleService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="articleService">The service responsible for interacting with the data store.</param>
        public DeleteModel(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        // The data to show, bind to it for the post.
        [BindProperty]
        public ArticleModel Article { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id">The article Id as a string.</param>
        public void OnGet(string id)
        {
            Article = ArticleService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Article
        /// Call the data layer to Delete that data
        /// Then return to the index page
        /// </summary>
        /// <returns>An IActionResult.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ArticleService.DeleteData(Article.Id);

            return RedirectToPage("./Index");
        }
    }
}
