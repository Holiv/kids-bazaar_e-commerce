using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, bool>> OrderBy { get; private set; }

        public Expression<Func<T, bool>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginationEnabled { get; private set; }

        public void AddIncludes(Expression<Func<T, object>> expression)
        {
            Includes.Add(expression);
        }

        public void AddOrderBy(Expression<Func<T, bool>> expression)
        {
            OrderBy = expression;
        }

        public void AddOrderByDescending(Expression<Func<T, bool>> expression)
        {
            OrderByDescending = expression;
        }

        public void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPaginationEnabled = true;
        }
    }
}
