using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using energy_providr.Data;
using System.IO;

namespace energy_providr.Data
{
    public class DbcontextFactory : IDesignTimeDbContextFactory<dtabaseContext>
    {
        public dtabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<dtabaseContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string is missing in appsettings.json.");
            }

            optionsBuilder.UseMySQL(connectionString);

            return new dtabaseContext(optionsBuilder.Options);
        }
    }
}
