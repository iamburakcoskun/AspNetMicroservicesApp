using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ordering.Infrastructure.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Ordering.API/"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

            DbContextOptionsBuilder<OrderContext> dbContextOptionsBuilder = new();

            var connectionString = config["ConnectionStrings:OrderingConnectionString"];
            // dbContextOptionsBuilder.UseSqlServer("Server=.; Database=PttMain; Trusted_Connection= true");
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            return (OrderContext)Activator.CreateInstance(typeof(OrderContext), dbContextOptionsBuilder.Options);
        }
    }
}
