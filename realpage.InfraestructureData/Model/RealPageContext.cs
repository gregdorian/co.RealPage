using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using realpage.Domain.Entities;
using System;
using System.IO;

namespace realpage.InfraestructureData.Model
{
    public partial class RealPageContext : DbContext
    {

        public RealPageContext()
        {

        }

        public RealPageContext(DbContextOptions<RealPageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //**** Solo para Realizarel Primer Initial-Migration  ****
            if (!optionsBuilder.IsConfigured)
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder()
                //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                //    .AddJsonFile("appsettings.json")
                //    .Build();
                //Directory.GetCurrentDirectory() configuration.GetConnectionString("RealPageConn")
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=realpageDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           base.OnModelCreating(builder);
           builder.Seed();
        }

    }
}
