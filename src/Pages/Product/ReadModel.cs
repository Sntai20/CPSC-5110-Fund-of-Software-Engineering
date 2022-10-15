using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class ReadModel : PageModel
    {
        // Data Middletier
        public JsonFileArticleService ProductService { get; }

        // Default Constructor
        public ReadModel(JsonFileArticleService productService)
        {
            ProductService = productService;
        }

        // Data to show
        public ProductModel Product;

        // REST Get Request
        public void OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}
