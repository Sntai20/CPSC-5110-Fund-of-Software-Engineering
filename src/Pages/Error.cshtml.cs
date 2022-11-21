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
        /// <summary>
        /// Check if request id is null or empty
        /// </summary>
        // Boolean check to see if RequestID contains valid value
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Error logger item
        private readonly ILogger<ErrorModel> _logger;
        /// <summary>
        /// Default contructor for ErrorModel
        /// </summary>
        /// <param name="logger">logger dependecy for ErrorModel</param>
        // Log an error
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
