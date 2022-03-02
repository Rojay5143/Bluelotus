

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;



namespace B_lotus.Models
{
    public class DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            optionsBuilder.UseMySql(configuration
                ["ConnectionStrings:DefaultConnection"], new MySqlServerVersion(new Version(8, 0, 11)),
                options => options.EnableRetryOnFailure()
                
                );
        }

        //Need to register your models here
       
        public DbSet<User> Users { get; set; }
 
        
        public DbSet<Company> Companys { get; set; }
       

        
        
       
    }
}
