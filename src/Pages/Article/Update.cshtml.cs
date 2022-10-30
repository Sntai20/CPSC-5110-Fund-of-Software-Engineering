namespace ContosoCrafts.WebSite.Pages.Article
{
    using System.Linq;

    using ContosoCrafts.WebSite.Models;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    /// <summary>
    /// Manage the Update of the data for a single record
    /// </summary>
    public class UpdateModel : PageModel
    {
        // Data middletier
        public JsonFileArticleService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileArticleService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ArticleModel Article { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Article = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _ = ProductService.UpdateData(Article);

            return RedirectToPage("./Index");
        }
    }
}