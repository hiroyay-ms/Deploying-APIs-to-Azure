using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Aspnet.FrontEnd.UI.Models;

namespace Aspnet.FrontEnd.UI.Pages.Products;

public class CatalogModel : PageModel
{
    private readonly ILogger<CatalogModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public CatalogModel(ILogger<CatalogModel> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public List<Product> Products { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? Id { get; set; }

    public async Task OnGetAsync()
    {
        string jsonString = string.Empty;

        if (string.IsNullOrEmpty(Id))
        {
            _logger.LogInformation("Missing product category ID.");
            return;
        }

        string actionName = $"Product/{Id}";

        _logger.LogInformation($"Calling API: {actionName}");

        var httpClient = _httpClientFactory.CreateClient("API");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, actionName);
        
        var response = await httpClient.SendAsync(httpRequestMessage);

        if (response.IsSuccessStatusCode)
        {
            jsonString = await response.Content.ReadAsStringAsync();
            Products = JsonSerializer.Deserialize<List<Product>>(jsonString);

            _logger.LogInformation($"{Products.Count} products found.");
        }
        else
        {
            _logger.LogError($"Error calling API: {response.StatusCode}");
        }
    }
}