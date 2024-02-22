using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Aspnet.FrontEnd.UI.Models;

namespace Aspnet.FrontEnd.UI.Pages.Orders;

public class SalesOrderDetailModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    public SalesOrderDetailModel(ILogger<IndexModel> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    public List<SalesOrderDetail> OrderDetails { get; set; } = default!;

    [BindProperty(SupportsGet = true)]
    public string? Id { get; set; }

    public async Task OnGetAsync()
    {
        string jsonString = string.Empty;

        if (string.IsNullOrEmpty(Id))
        {
            _logger.LogInformation("Missing sales order ID.");
            return;
        }

        string actionName = $"Order/{Id}";

        _logger.LogInformation($"Calling API: {actionName}");

        var httpClient = _httpClientFactory.CreateClient("API");
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, actionName);

        var response = await httpClient.SendAsync(httpRequestMessage);

        if (response.IsSuccessStatusCode)
        {
            jsonString = await response.Content.ReadAsStringAsync();
            OrderDetails = JsonSerializer.Deserialize<List<SalesOrderDetail>>(jsonString);

            _logger.LogInformation($"{OrderDetails.Count} order details found.");
        }
        else
        {
            _logger.LogError($"Error calling API: {response.StatusCode}");
        }
    }
}