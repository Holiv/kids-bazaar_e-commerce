using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext context;

        public GenericRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task AddNewAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<Categories> GetCategoryByIdAsync(int id)
        {
            return await context.Set<Categories>()
                .Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Product GetProductTest()
        {
            var product = new Product();
            product.Title = "Product Test";
            return product;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var products = await context.Set<T>().ToListAsync();
            return products;
        }
        public async Task<IReadOnlyList<Product>> ListAllProductsAsync()
        {
            var products = await context.Set<Product>()
                .Include(products => products.Categories).ToListAsync();
            return products;
        }

        public async Task<Categories> GetCategories(int id)
        {
            return await context.Set<Categories>().Include(category => category.Products)
                .Where(category => category.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            var hasChanges = context.ChangeTracker.HasChanges();
            int updates = await context.SaveChangesAsync();
            return (hasChanges);
        }
    }
}
