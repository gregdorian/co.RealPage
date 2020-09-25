
using realpage.Domain.Entities;
using realpage.Domain.Core.Interfaces.Repositories;
using realpage.Domain.Core.Interfaces.Services;


namespace realpage.Domain.Core
{
    public class ProductsService : BaseService<Products>, IProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository) : base(productsRepository)
        {
            this.productsRepository = productsRepository;
        }
    }
}
