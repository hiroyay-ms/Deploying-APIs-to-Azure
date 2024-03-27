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
    public class GetSalesOrderDetail
    {
        private readonly AdventureWorksContext _context;

        public GetSalesOrderDetail(AdventureWorksContext context)
        {
            _context = context;
        }

        [FunctionName("GetSalesOrderDetail")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Order/{id:int}")] HttpRequest req, int id,
            ILogger log)
        {
            log.LogInformation("GetSalesOrderDetail function processed a request.");

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

            log.LogInformation($"{orderlines.Count} sales order lines found.");

            string jsonString = JsonSerializer.Serialize(orderlines);

            return new OkObjectResult(jsonString);
        }
    }
}
