using System.Text.Json.Serialization;

namespace Aspnet.FrontEnd.UI.Models;

public class ProductCategory
{
    [JsonPropertyName("productCategoryID")]
    public int ProductCategoryID { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("subCategory")]
    public string? SubCategory { get; set; }

    [JsonPropertyName("productCount")]
    public int ProductCount { get; set; }
}