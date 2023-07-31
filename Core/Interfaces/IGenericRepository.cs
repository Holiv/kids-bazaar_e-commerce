using Core.Entities;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> spec);
        Task<T> GetByIdAsync(int id);
        Task<Categories> GetCategoryByIdAsync(int id);
        Task AddNewAsync(T entity);
        Task<Categories> GetCategories(int id);
        Task<IReadOnlyList<Product>> ListAllProductsAsync();
        Product GetProductTest();
        Task<bool> SaveChangesAsync();
    }
}
