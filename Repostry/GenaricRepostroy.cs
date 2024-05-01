using E_Commerce.Core.Entites;
using E_Commerce.Core.InterFace.Repostroy;
using E_Commerce.Core.InterFace.Service;
using E_Commerce.Repostry.Data;
using E_Commerce.Repostry.Spicfication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repostry.Repostry
{
    public class GenaricRepostroy<TEntity, Tkey> : IGenaricRepostroy<TEntity, Tkey> where TEntity : BaseEntites<Tkey>
    {
        private readonly DataContext _dataContext;

        public GenaricRepostroy(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task AddAsync(TEntity entity)=> await _dataContext.Set<TEntity>().AddAsync(entity);

        public void DeleteAsync(TEntity entity)
        {
            _dataContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()=> await _dataContext.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllwithSpicAsync(ISpecification<TEntity> specification)
        {
            return await Applyspecfication(specification).ToListAsync();
        }

    

        public async Task<TEntity> GetAsync(Tkey id) => await _dataContext.Set<TEntity>().FindAsync(id);

        public async Task<int> GeTCountOFpage(ISpecification<TEntity> specification)
        {
            return await Applyspecfication(specification).CountAsync();
        }



        public Task<TEntity> GetwithidSpicAsync(ISpecification<TEntity> specification)
        {
             return Applyspecfication(specification).FirstOrDefaultAsync();

        }

  

        public void UpdateAsync(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
        }

        private IQueryable<TEntity> Applyspecfication(ISpecification<TEntity> specification) => SpicficationEvaluter<TEntity, Tkey>.BulidQuery(_dataContext.Set<TEntity>(), specification);
    }
}
