namespace ContosoCrafts.WebSite.Pages
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
   
    /// <summary>
    /// Error page.
    /// </summary>
    public class ErrorModel : PageModel
    {
        // The data to show, bind to it for the post.
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// REST Get request
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
