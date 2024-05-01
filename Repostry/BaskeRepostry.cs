using E_Commerce.Core.Entites.Basket;
using E_Commerce.Core.InterFace.Repostroy;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repostry.Repostry
{
    public class BaskeRepostry : IBasketRepostry
    {
        private readonly IDatabase _database;
        public BaskeRepostry(IConnectionMultiplexer connection)
        {
            _database =connection.GetDatabase();
        }
        public async Task<bool> DeletCostmetBasket(string id) => await _database.KeyDeleteAsync(id);
     

        public async Task<BasketCosmtmer?> GetBasketCosmtmerAsync(string id)
        {
            var Basket = await _database.StringGetAsync(id);
            return Basket.IsNullOrEmpty? null :JsonSerializer.Deserialize<BasketCosmtmer>(Basket);  
        }

        public async Task<BasketCosmtmer?> UpdateBasketCosmtmerAsync(BasketCosmtmer basket)
        {
            var SerializerBasket = JsonSerializer.Serialize(basket);
           var Result = await _database.StringSetAsync(basket.Id, SerializerBasket, TimeSpan.FromDays(7));
            return  Result ? await GetBasketCosmtmerAsync(basket.Id) : null;

        }
    }
}
