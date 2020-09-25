using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using realpage.Application.Interfaces;
using realpage.Application.Services;
using realpage.Domain.Entities;

namespace realpage.Testing
{
    [TestClass]
    public class AppLayerTesting
    {

        private readonly IProductsAppService ProductFactory;

        public AppLayerTesting(IProductsAppService productFactory)
        {
            ProductFactory = productFactory;
        }

        public bool Mock { get; private set; }

        [TestMethod]
        public void savingMethods ()
        {

            
            var prod = new Products()
            {
                ProductName = "Coke",
                UnitsInStock = 2,
                UnitPrice = (decimal?)3.5
            };
            Assert.IsNotNull(prod);
            //Mock = new Mock<ProductFactory.Add(prod)>();
            ProductFactory.Add(prod);


        }
    }
}
