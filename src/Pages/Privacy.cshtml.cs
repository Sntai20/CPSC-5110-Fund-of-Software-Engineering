namespace ContosoCrafts.WebSite.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

/// <summary>
/// Privacy page.
/// </summary>
/// <remarks>
/// Default constructor for the Privacy page.
/// </remarks>
/// <param name="logger">Takes a ILogger.</param>
public class PrivacyModel(ILogger<PrivacyModel> logger) : PageModel
{
    private readonly ILogger<PrivacyModel> _logger = logger;

    /// <summary>
    /// REST Get request
    /// </summary> 
    public void OnGet()
    {
    }
}
