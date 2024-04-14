namespace ContosoCrafts.WebSite.Pages;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

/// <summary>
/// Privacy page.
/// </summary>
public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
   
    /// <summary>
    /// Default constructor for the Privacy page.
    /// </summary>
    /// <param name="logger">Takes a ILogger.</param>
    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }
    
    /// <summary>
    /// REST Get request
    /// </summary> 
    public void OnGet()
    {
    }
}
