using E_Commerce.Core.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.InterFace.Repostroy
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenaricRepostroy<TEntity, Tkey> Repostroy<TEntity, Tkey>() where TEntity : BaseEntites<Tkey>; // to create object from Repostoy
        Task<int> CompleteAsync();// Save Changg();
    }
}
