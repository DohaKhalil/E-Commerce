using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.InterFace.Service
{
    public interface ISpecification<T>
    {
        //Creatiria Of Where
        public Expression<Func<T, bool>> Criteria { get; }
        //Include
        public List<Expression<Func<T, object>>> ExpritionInclude { get; }

        public Expression<Func<T, object>> OrdreBy { get; }
        public Expression<Func<T, object>> OrdreByDesc { get; }
        public int Take { get; }
        public int Skip { get; }
        public bool IsPaginted { get; }

    }
}
