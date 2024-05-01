using E_Commerce.Core.Entites;
using E_Commerce.Core.InterFace.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repostry.Spicfication
{
    public class SpicficationEvaluter<TEntity , TKey> where TEntity : BaseEntites<TKey>
    {
        public static IQueryable<TEntity> BulidQuery (IQueryable<TEntity> inputquery , ISpecification<TEntity> specification)
        {
            var quiry = inputquery;
            if (specification.Criteria is not null)
            {
                quiry = quiry.Where(specification.Criteria);
            }

            if (specification.OrdreBy is not null)
            {
                quiry = quiry.OrderBy(specification.OrdreBy);
            }
            if (specification.OrdreByDesc is not null)
            {
                quiry = quiry.OrderBy(specification.OrdreByDesc);
            }
            if (specification.IsPaginted)
            {
                quiry = quiry.Skip(specification.Skip).Take(specification.Take);
            }

            if (specification.ExpritionInclude.Any())
            {
                quiry = specification.ExpritionInclude.Aggregate(quiry, (crruntQuery, exprition) => crruntQuery.Include(exprition));
            }
            return quiry;

        }
    }
}
