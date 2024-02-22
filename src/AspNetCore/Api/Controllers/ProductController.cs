using System;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aspnet.Backend.Api.Data;

namespace Aspnet.Backend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly AdventureWorksContext _context;

    public ProductController(ILogger<WeatherForecastController> logger, AdventureWorksContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [Route("Category")]
    public async Task<IActionResult> GetProductCategory()
    {
        _logger.LogInformation("GetProductCategory processed a request.");

        var query = from a in _context.ProductCategory 
                    join b in _context.ProductCategory on a.ProductCategoryID equals b.ParentProductCategoryID 
                    join p in _context.Product on b.ProductCategoryID equals p.ProductCategoryID 
                    group new { a, b, p } by new { b.ProductCategoryID, Category = a.Name, SubCategory = b.Name } into g 
                    orderby g.Key.ProductCategoryID  
                    select new 
                    {
                        ProductCategoryID = g.Key.ProductCategoryID, 
                        Category = g.Key.Category,
                        SubCategory = g.Key.SubCategory,
                        ProductCount = g.Count()
                    };

        var productCategories = await query.ToListAsync();

        _logger.LogInformation($"{productCategories.Count} product categories found.");

        return Ok(productCategories);
    }

    [HttpGet]
    [Route("Category/{category}")]
    public async Task<IActionResult> GetProductCategoryByName(string category)
    {
        _logger.LogInformation("GetProductCategoryByName processed a request.");

        var query = from a in _context.ProductCategory 
                    join b in _context.ProductCategory on a.ProductCategoryID equals b.ParentProductCategoryID 
                    join p in _context.Product on b.ProductCategoryID equals p.ProductCategoryID 
                    where a.Name == category
                    group new { a, b, p } by new { b.ProductCategoryID, Category = a.Name, SubCategory = b.Name } into g 
                    orderby g.Key.ProductCategoryID  
                    select new 
                    {
                        ProductCategoryID = g.Key.ProductCategoryID, 
                        Category = g.Key.Category,
                        SubCategory = g.Key.SubCategory,
                        ProductCount = g.Count()
                    };

        var productCategories = await query.ToListAsync();

        _logger.LogInformation($"{productCategories.Count} product categories found.");

        return Ok(productCategories);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        _logger.LogInformation("GetProductById processed a request.");

        var query = from p in _context.Product 
                    join pc in _context.ProductCategory on p.ProductCategoryID equals pc.ProductCategoryID 
                    join pm in _context.ProductModel on p.ProductModelID equals pm.ProductModelID 
                    join pmd in _context.ProductModelProductDescription on pm.ProductModelID equals pmd.ProductModelID 
                    join pd in _context.ProductDescription on pmd.ProductDescriptionID equals pd.ProductDescriptionID 
                    where pmd.Culture == "en" && pc.ProductCategoryID == id 
                    select new 
                    {
                        p.ProductID,
                        ProductName = p.Name,
                        p.ProductNumber,
                        p.Color,
                        p.StandardCost,
                        p.ListPrice,
                        p.Size,
                        p.Weight,
                        p.ProductCategoryID,
                        CategoryName = pc.Name,
                        ModelName = pm.Name,
                        Description = pd.Description,
                        p.SellStartDate,
                        p.SellEndDate,
                        p.ThumbnailPhotoFileName
                    };
        
        var products = await query.ToListAsync();

        _logger.LogInformation($"{products.Count} products found.");

        return Ok(products);
    }
}