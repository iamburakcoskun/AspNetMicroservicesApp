using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Identity.API/"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

            DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new();

            var connectionString = config["ConnectionStrings:IdentityConnectionString"];
            // dbContextOptionsBuilder.UseSqlServer("Server=.; Database=PttMain; Trusted_Connection= true");
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            return (AppDbContext)Activator.CreateInstance(typeof(AppDbContext), dbContextOptionsBuilder.Options);
        }
    }
}
