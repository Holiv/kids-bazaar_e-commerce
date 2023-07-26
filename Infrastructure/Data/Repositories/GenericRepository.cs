using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseProduct
    {
        private readonly StoreContext context;

        public GenericRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductTest()
        {
            var product = new Product();
            product.Title = "Product Test";
            return product;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var clothes = await context.Set<T>().ToListAsync();
            return clothes;
        }
    }
}
