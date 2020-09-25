using realpage.Application.Interfaces;
using realpage.Domain.Core.Interfaces.Services;
using realpage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realpage.Application.Services
{
    public class ProductAppService : BaseAppService<Products>, IProductsAppService
    {
        private readonly IProductsService ProductsService;

        public ProductAppService(IProductsService productsService) : base(productsService)
        {
            this.ProductsService = productsService;
        }
     }
}
