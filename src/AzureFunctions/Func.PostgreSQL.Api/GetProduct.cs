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
    public class GetProduct
    {
        private readonly AdventureWorksContext _context;

        public GetProduct(AdventureWorksContext context)
        {
            _context = context;
        }

        [FunctionName("GetProduct")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Product/{id:int}")] HttpRequest req, int id,
            ILogger log)
        {
            log.LogInformation("GetProduct processed a request.");

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

            log.LogInformation($"{products.Count} products found.");

            string jsonStr = JsonSerializer.Serialize(products);

            return new OkObjectResult(jsonStr);
        }
    }
}
