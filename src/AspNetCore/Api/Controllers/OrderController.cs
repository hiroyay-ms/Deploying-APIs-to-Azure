using System;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aspnet.Backend.Api.Data;

namespace Aspnet.Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly AdventureWorksContext _context;

    public OrderController(ILogger<WeatherForecastController> logger, AdventureWorksContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrder()
    {
        _logger.LogInformation("GetOrders processed a request.");

        var query = from soh in _context.SalesOrderHeader 
                    join c in _context.Customer on soh.CustomerID equals c.CustomerID 
                    join a in _context.Address on soh.ShipToAddressID equals a.AddressID 
                    select new 
                    {
                        soh.SalesOrderID,
                        soh.ShipDate,
                        soh.SalesOrderNumber,
                        soh.AccountNumber,
                        soh.CustomerID,
                        CustomerName = c.FirstName + " " + c.LastName,
                        c.CompanyName, 
                        soh.ShipToAddressID,
                        soh.ShipMethod,
                        a.AddressLine1,
                        a.City,
                        a.StateProvince,
                        a.PostalCode,
                        soh.SubTotal,
                        soh.TaxAmt,
                        soh.Freight,
                        soh.TotalDue
                    };
        
        var orders = await query.ToListAsync();

        _logger.LogInformation($"{orders.Count} orders found.");

        return Ok(orders);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        _logger.LogInformation("GetOrderById processed a request.");

        var query = from sod in _context.SalesOrderDetail 
                    join p in _context.Product on sod.ProductID equals p.ProductID 
                    join pc in _context.ProductCategory on p.ProductCategoryID equals pc.ProductCategoryID 
                    where sod.SalesOrderID == id  
                    select new 
                    {
                        sod.SalesOrderID,
                        sod.SalesOrderDetailID,
                        sod.ProductID,
                        ProductName = p.Name,
                        CategoryName = pc.Name,
                        sod.OrderQty,
                        sod.UnitPrice,
                        sod.UnitPriceDiscount,
                        sod.LineTotal
                    };
        
        var orderlines = await query.ToListAsync();

        _logger.LogInformation($"{orderlines.Count} order lines found.");

        return Ok(orderlines);
    }
}