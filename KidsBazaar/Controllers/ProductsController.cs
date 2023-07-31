using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using KidsBazaar.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KidsBazaar.Controllers
{

    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<Product> productRepository;
        private readonly IGenericRepository<Categories> categoryRepository;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<Categories> categoryRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductsToReturnDTO>>> GetAllProducts()
        {
            var spec = new ProductsWithCategorySpecification();
            var products = await productRepository.ListAllAsync(spec);
            var productsDTO = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductsToReturnDTO>>(products);

            return Ok(productsDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductsForCreatingDTO productsForCreating)
        {
            var productEntity = mapper.Map<Product>(productsForCreating);
            var category = await categoryRepository.GetCategoryByIdAsync(productsForCreating.CategoriesId);

            category.Products.Add(productEntity);

            await categoryRepository.SaveChangesAsync();

            return Ok();
        }

    }
}
