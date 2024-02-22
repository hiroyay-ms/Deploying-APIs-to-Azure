using System.Text.Json.Serialization;

namespace Aspnet.FrontEnd.UI.Models;

public class SalesOrder
{
    [JsonPropertyName("salesOrderID")]
    public int SalesOrderID { get; set; } = 0;

    [JsonPropertyName("shipDate")]
    public DateTime? ShipDate { get; set; } = null;

    [JsonPropertyName("salesOrderNumber")]
    public string SalesOrderNumber { get; set; } = string.Empty;

    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; } = null;

    [JsonPropertyName("customerID")]
    public int CustomerID { get; set; } = 0;

    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; } = string.Empty;

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; } = null;

    [JsonPropertyName("shipToAddressID")]
    public int? ShipToAddressID { get; set; } = null;

    [JsonPropertyName("shipMethod")]
    public string ShipMethod { get; set; } = string.Empty;

    [JsonPropertyName("addressLine1")]
    public string AddressLine1 { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("stateProvince")]
    public string StateProvince { get; set; } = string.Empty;

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; } = string.Empty;

    [JsonPropertyName("subTotal")]
    public decimal SubTotal { get; set; } = 0;

    [JsonPropertyName("taxAmt")]
    public decimal TaxAmt { get; set; } = 0;

    [JsonPropertyName("freight")]
    public decimal Freight { get; set; } = 0;

    [JsonPropertyName("totalDue")]
    public decimal TotalDue { get; set; } = 0;

}