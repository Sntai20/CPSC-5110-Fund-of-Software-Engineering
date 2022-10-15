using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages.Article
{
    public class ReadModel : PageModel
    {
        // Data Middletier
        public JsonFileArticleService ArticleService { get; }

        // Default Constructor
        public ReadModel(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        // Data to show
        public ArticleModel Article;

        // REST Get Request
        public void OnGet(string id)
        {
            Article = ArticleService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}
