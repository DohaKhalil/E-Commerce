using E_Commerce.Core.InterFace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repostry.Spicfication
{
    public class BaseSpicfication<T> : ISpecification<T>
    {
        public BaseSpicfication(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> ExpritionInclude { get; } = new();

        public Expression<Func<T, object>> OrdreBy  { get; protected set; }

        public Expression<Func<T, object>> OrdreByDesc { get; protected set; }

        public int Take { get; protected set; }

        public int Skip { get; protected set; }

        public bool IsPaginted { get; protected set; }

        protected void ApplyPagnation(int pageSize , int pageIndex)
        {
            IsPaginted = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;


        }
    }
}
