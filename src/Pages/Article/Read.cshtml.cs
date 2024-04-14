namespace ContosoCrafts.WebSite.Pages.Article;

using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

/// <summary>
/// Provide a detailed view of the Article
/// </summary>
/// <remarks>
/// The default constructor.
/// </remarks>
/// <param name="articleService">The service responsible for interacting with the data store.</param>
public class ReadModel(JsonFileArticleService articleService) : PageModel
{
    // Data middle tier
    public JsonFileArticleService ArticleService { get; } = articleService;

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
