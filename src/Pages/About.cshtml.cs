namespace ContosoCrafts.WebSite.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

/// <summary>
/// About Page will return team information.
/// </summary>
/// <remarks>
/// Default Constructor
/// </remarks>
/// <param name="logger">Takes an ILogger.</param>
public class AboutModel(ILogger<AboutModel> logger) : PageModel
{
    // message logging interface
    private readonly ILogger<AboutModel> logger = logger;

    /// <summary>
    /// REST Get request
    /// </summary> 
    public void OnGet()
    {
    }
}
