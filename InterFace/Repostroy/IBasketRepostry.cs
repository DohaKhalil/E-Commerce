using E_Commerce.Core.Entites.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.InterFace.Repostroy
{
    public interface IBasketRepostry
    {
        Task<BasketCosmtmer?> GetBasketCosmtmerAsync(string id);
        Task<BasketCosmtmer?> UpdateBasketCosmtmerAsync(BasketCosmtmer basket);
        Task<bool> DeletCostmetBasket(string id);
    }
}
