using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using realpage.Application.Interfaces;
using realpage.Domain.Entities;
using realpage.InfraestructureData.Model;

namespace realpage.Services.UI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductsAppService ProductFactory;

        private readonly ILogger<ProductsController> _logger;
        private readonly UserManager<RpUsers> userManager;

        public ProductsController(IProductsAppService productFactory, 
                                  ILogger<ProductsController> logger,
                                  UserManager<RpUsers> userManager)
        {
            this.ProductFactory = productFactory;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.userManager = userManager;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        [Authorize(Roles = "Administrator, RegularUser")]
        public IEnumerable<Products> GetAll()
        {
            if (User.Identity.IsAuthenticated)
            {

                var lstProducts = ProductFactory.GetAll();

                _logger.LogInformation($"Status Listed: ");

                return lstProducts;
            }
            else
               return null;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator, RegularUser")]
        public ActionResult<Products> Get(int id)
        {
            var product = ProductFactory.GetById(id);

            if (product == null)
            {
                _logger.LogError("No Data found");
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public void Post([FromBody] Products value)
        {
            if (value != null)
            {
                ProductFactory.Add(value);
                _logger.LogInformation("Data SAVED!!!");
            }
            else
            {
                _logger.LogError("No Data found");
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public void Put(int id, [FromBody] Products value)
        {
            var prod = ProductFactory.GetById(id);
            if (prod != null)
            {
                ProductFactory.Modify(value);
                _logger.LogInformation("Data Modified and SAVED!!!");
            }
            else
            {
                _logger.LogError("No Data found");
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public void Delete(int id)
        {
             ProductFactory.Delete(id);
            _logger.LogInformation("Data Deleted");
        }
    }
}
