using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Aspnet.FrontEnd.UI.Models;

namespace Aspnet.FrontEnd.UI.Pages.Products;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public List<ProductCategory> ProductCategories { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? Category { get; set; }

    public async Task OnGetAsync()
    {
        string jsonString = string.Empty;

        string actionName = string.IsNullOrEmpty(Category) ? "Product/Category" : $"Product/Category/{Category}";

        _logger.LogInformation($"Calling API: {actionName}");

        var httpClient = _httpClientFactory.CreateClient("API");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, actionName);

        var response = await httpClient.SendAsync(httpRequestMessage);

        if (response.IsSuccessStatusCode)
        {
            jsonString = await response.Content.ReadAsStringAsync();
            ProductCategories = JsonSerializer.Deserialize<List<ProductCategory>>(jsonString);

            _logger.LogInformation($"{ProductCategories.Count} product categories found.");
        }
        else
        {
            _logger.LogError($"Error calling API: {response.StatusCode}");
        }
    }
}