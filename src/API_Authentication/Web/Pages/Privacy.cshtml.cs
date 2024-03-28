using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

[Authorize]
public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        if (!this.HttpContext.Request.Headers.ContainsKey("X-MS-TOKEN-AAD-ACCESS-TOKEN"))
        {
            ViewData["Message"] = "Access token not found";
        }
    }
}

