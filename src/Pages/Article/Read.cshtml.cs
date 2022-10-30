using System.Linq;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.Article
{
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileArticleService ArticleService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="articleService"></param>
        public ReadModel(JsonFileArticleService articleService)
        {
            ArticleService = articleService;
        }

        // The data to show
        public ArticleModel Article;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Article = ArticleService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}
