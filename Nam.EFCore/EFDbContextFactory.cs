using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nam.EFCore
{
    public class EFDbContextFactory : IDesignTimeDbContextFactory<EFDbContext>
    {
        public EFDbContextFactory()
        {

        }
        public EFDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false);

            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<EFDbContext>()
                .UseSqlServer(config.GetConnectionString("DevConnection"));

            return new EFDbContext(optionsBuilder.Options);

            //var optionBuilder = new DbContextOptionsBuilder<EFDbContext>();
            //optionBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=DbDemo;Trusted_Connection=True;MultipleActiveResultSets=True");
            //return new EFDbContext(optionBuilder.Options);
        }
    }
}
