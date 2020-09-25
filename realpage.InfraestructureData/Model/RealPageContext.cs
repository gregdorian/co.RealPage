using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using realpage.Domain.Entities;
using System;
using System.IO;

namespace realpage.InfraestructureData.Model
{
    public partial class RealPageContext : IdentityDbContext<RpUsers>
    {


        public RealPageContext()
        {
        }

        public RealPageContext(DbContextOptions<RealPageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                //Directory.GetCurrentDirectory() 
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("RealPageConn"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
