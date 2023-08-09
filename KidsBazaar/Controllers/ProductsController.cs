using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data.Contexts;
using KidsBazaar.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<IReadOnlyList<ProductsToReturnDTO>>> GetAllProducts([FromQuery]ProductSpecParams productSpec)
        {
            var spec = new ProductsWithCategorySpecification(productSpec);
            var products = await productRepository.ListAsync(spec);
            var productsDTO = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductsToReturnDTO>>(products);

            return Ok(productsDTO);
        }

        [HttpGet]
        [Route("/categories")]
        public async Task<ActionResult<IReadOnlyList<Categories>>> GetAllCategories()
        {
            var categories = await categoryRepository.ListAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("/categories/{id}")]
        public async Task<ActionResult<Categories>> GetCategoryById(int id)
        {
            var spec = new CategoryByIdSpecification(id);
            var category = await categoryRepository.GetByIdAsync(spec);
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithCategorySpecification(id);
            var product = await productRepository.GetByIdAsync(spec);

            return Ok(mapper.Map<ProductsToReturnDTO>(product));
     
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductsForCreatingDTO productsForCreating)
        {
            var productEntity = mapper.Map<Product>(productsForCreating);
            var spec = new CategoryByIdSpecification(productsForCreating.CategoriesId);
            var category = await categoryRepository.GetByIdAsync(spec);
            await productRepository.AddNewAsync(productEntity);

            //category.Products.Add(productEntity);

            await categoryRepository.SaveChangesAsync();

            return Ok();
        }

    }
}
