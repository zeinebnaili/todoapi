using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TodoApi.Data;
using System.IO;

namespace TodoApi.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();

            // Charger la configuration depuis appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Configurer le DbContext avec la chaîne de connexion
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new TodoContext(optionsBuilder.Options);
        }
    }
}
