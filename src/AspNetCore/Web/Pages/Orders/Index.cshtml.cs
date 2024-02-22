using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Aspnet.FrontEnd.UI.Models;

namespace Aspnet.FrontEnd.UI.Pages.Orders;

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

    public List<SalesOrder> Orders { get; set; } = default!;

    public async Task OnGetAsync()
    {
        string jsonString = string.Empty;

        string actionName = "Order";

        _logger.LogInformation($"Calling API: {actionName}");

        var httpClient = _httpClientFactory.CreateClient("API");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, actionName);

        var response = await httpClient.SendAsync(httpRequestMessage);

        if (response.IsSuccessStatusCode)
        {
            jsonString = await response.Content.ReadAsStringAsync();
            Orders = JsonSerializer.Deserialize<List<SalesOrder>>(jsonString);

            _logger.LogInformation($"{Orders.Count} orders found.");
        }
        else
        {
            _logger.LogError($"Error calling API: {response.StatusCode}");
        }
    }
}