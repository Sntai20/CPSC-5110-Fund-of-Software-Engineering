namespace ContosoCrafts.WebSite.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// About Page will return team information.
    /// </summary>
    public class AboutModel : PageModel
    {
        // message logging interface
        private readonly ILogger<AboutModel> logger;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="logger">Takes an ILogger.</param>
        public AboutModel(ILogger<AboutModel> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// REST Get request
        /// </summary> 
        public void OnGet()
        {
        }
    }
}
