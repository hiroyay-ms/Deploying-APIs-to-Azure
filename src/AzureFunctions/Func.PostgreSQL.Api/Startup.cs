using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Func.PostgreSQL.Api.Data;

[assembly: FunctionsStartup(typeof(Func.PostgreSQL.Api.Startup))]
namespace Func.PostgreSQL.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

            builder.Services.AddDbContext<AdventureWorksContext>(options => options.UseNpgsql(connectionString));
        }
    }
}