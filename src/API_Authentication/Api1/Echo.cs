using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api1
{
    public static class Echo
    {
        [FunctionName("Echo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.HttpContext.User.Identity.Name ?? "unkonwn";

            string responseMessage = $"Hello, {name}! This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
