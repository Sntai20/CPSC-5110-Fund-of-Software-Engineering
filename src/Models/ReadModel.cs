using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Models
{
    public class ReadModel : PageModel
    {
        // Data Middletier
        public JsonFileProductService ProductService { get; }

        // Default Constructor
        public ReadModel(JsonFileProductService productService)
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
