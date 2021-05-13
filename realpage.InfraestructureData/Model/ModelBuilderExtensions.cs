using Microsoft.EntityFrameworkCore;
using realpage.Domain.Entities;

namespace realpage.InfraestructureData.Model
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder model)
        {

            //model.Entity<Products>().HasData(
            //       new Products { ProductName = "Producto 1", UnitsInStock = 2, UnitPrice = (decimal?)3.5 },
            //       new Products { ProductName = "Producto 2", UnitsInStock = 1, UnitPrice = (decimal?)5.5 },
            //       new Products { ProductName = "Producto 3", UnitsInStock = 50, UnitPrice = (decimal?)6.5 },
            //       new Products { ProductName = "Producto 4", UnitsInStock = 1, UnitPrice = (decimal?)32.5 });

        }
    }
}
