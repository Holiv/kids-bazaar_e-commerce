using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KidsBazaar.Controllers
{

    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<Product> productRepository;

        public ProductsController(IGenericRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<Product> GetAllClothes()
        {
            var products = productRepository.GetProductTest();

            return Ok(products);
        }
    }
}
