﻿using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        //Hi Mike
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileArticleService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public JsonFileArticleService ProductService { get; }
        public IEnumerable<ArticleModel> Articles { get; private set; }
  
        public void OnGet()
        {
            Articles = ProductService.GetAllData();
        }  
    }
}