using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Func.PostgreSQL.Api.Data;

namespace Func.PostgreSQL.Api
{
    public class GetProductCategory
    {
        private readonly AdventureWorksContext _context;

        public GetProductCategory(AdventureWorksContext context)
        {
            _context = context;
        }

        [FunctionName("GetProductCategory")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "ProductCategory/{category:alpha?}")] HttpRequest req, string category,
            ILogger log)
        {
            log.LogInformation("GetProductCategory processed a request.");

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

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(x => x.Category == category);
            }

            var productCategories = await query.ToListAsync();

            log.LogInformation($"{productCategories.Count} product categories found");

            var jsonString = JsonSerializer.Serialize(productCategories);

            return new OkObjectResult(jsonString);
        }
    }
}
