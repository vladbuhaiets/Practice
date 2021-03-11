using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Airport.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath
                  (Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var connectionString = configuration
                ["ConnectionStrings:DefaultConnection"];
            optionsBuilder.UseSqlServer(configuration
                ["ConnectionStrings:DefaultConnection"]);

        }
        public DbSet<Airplanes> Airplanes { get; set; }
    }
}
