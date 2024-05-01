using E_Commerce.Core.Entites;
using E_Commerce.Core.InterFace.Repostroy;
using E_Commerce.Repostry.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repostry.Repostry
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly Hashtable _repostrise;

        public UnitOfWork(DataContext context)
        {
           _context = context;
           _repostrise = new Hashtable();
        }
        public async Task<int> CompleteAsync()=> await _context.SaveChangesAsync();
       

        public async ValueTask DisposeAsync()=>await _context.DisposeAsync();
       

        public IGenaricRepostroy<TEntity, Tkey> Repostroy<TEntity, Tkey>() where TEntity : BaseEntites<Tkey> // create Object from Ginaric use HashTable to return 2 Object ;
        {
            var TypeName = typeof(TEntity).Name; // first object is TypeName
            if (_repostrise.ContainsKey(TypeName)) return (_repostrise[TypeName] as GenaricRepostroy<TEntity, Tkey>); // secound Object The TEntity;
            var repo = new GenaricRepostroy<TEntity , Tkey>(_context);
            _repostrise.Add(TypeName, repo);// Add to HashTable
            return repo;
        }
    }
}
