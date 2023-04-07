using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace web.Pages;

public class IndexModel : PageModel
{
    public string Value;
    private readonly IConfiguration _config;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(IConfiguration config, ILogger<IndexModel> logger)
    {
        _config = config;
        _logger = logger;
    }

    public void OnGet()
    {
        //_config.GetValue<string>("SecretValue");
        Value = _config.GetValue<string>("Custom:Value") ?? ""; // Custom__Value <-- 2 underscores
    }
}
