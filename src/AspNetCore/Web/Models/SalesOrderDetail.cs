using System.Text.Json.Serialization;

namespace Aspnet.FrontEnd.UI.Models;

public class SalesOrderDetail
{
    [JsonPropertyName("salesOrderID")]
    public int SalesOrderID { get; set; } = 0;

    [JsonPropertyName("salesOrderDetailID")]
    public int SalesOrderDetailID { get; set; } = 0;

    [JsonPropertyName("productID")]
    public int ProductID { get; set; } = 0;

    [JsonPropertyName("productName")]
    public string ProductName { get; set; } = string.Empty;

    [JsonPropertyName("categoryName")]
    public string CategoryName { get; set; } = string.Empty;

    [JsonPropertyName("orderQty")]
    public Int16 OrderQty { get; set; } = 0;

    [JsonPropertyName("unitPrice")]
    public decimal UnitPrice { get; set; } = 0;

    [JsonPropertyName("unitPriceDiscount")]
    public decimal UnitPriceDiscount { get; set; } = 0;

    [JsonPropertyName("lineTotal")]
    public decimal LineTotal { get; set; } = 0;
}