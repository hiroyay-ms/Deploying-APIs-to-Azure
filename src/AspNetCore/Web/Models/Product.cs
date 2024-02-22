using System.Text.Json.Serialization;

namespace Aspnet.FrontEnd.UI.Models;

public class Product
{
    [JsonPropertyName("productID")]
    public int ProductID { get; set; } = 0;

    [JsonPropertyName("productName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("productNumber")]
    public string? ProductNumber { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("standardCost")]
    public decimal StandardCost { get; set; } = 0;

    [JsonPropertyName("listPrice")]
    public decimal ListPrice { get; set; } = 0;

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("weight")]
    public decimal? Weight { get; set; } = 0;

    [JsonPropertyName("productCategoryID")]
    public int ProductCategoryID { get; set; } = 0;

    [JsonPropertyName("categoryName")]
    public string? CategoryName { get; set; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("sellStartDate")]
    public DateTime SellStartDate { get; set; } = DateTime.MinValue;

    [JsonPropertyName("sellEndDate")]
    public DateTime? SellEndDate { get; set; }

    [JsonPropertyName("thumbnailPhotoFileName")]
    public string? ThumbnailPhotoFileName { get; set; }
}