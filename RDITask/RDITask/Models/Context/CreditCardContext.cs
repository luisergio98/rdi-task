using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RDITask.Models.Context
{
    public class CreditCardContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.Development.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("CreditCardDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }

        }

        public DbSet<CustomerModel> Costumer { get; set; }
        public DbSet<CreditCardModel> CreditCard { get; set; }
        public DbSet<TokenModel> Token { get; set; }
    }
}
