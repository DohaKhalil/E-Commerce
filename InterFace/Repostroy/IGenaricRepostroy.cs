using E_Commerce.Core.Entites;
using E_Commerce.Core.InterFace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.InterFace.Repostroy
{
    public interface IGenaricRepostroy<TEntity ,Tkey> where TEntity : BaseEntites<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllwithSpicAsync(ISpecification<TEntity> specification);
        Task<int> GeTCountOFpage(ISpecification<TEntity> specification);

        Task<TEntity> GetAsync(Tkey id);
        Task<TEntity> GetwithidSpicAsync(ISpecification<TEntity> specification);

        Task AddAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
    }
}
