using AutoMapper;
using E_Commerce.Core.Entites.Basket;
using E_Commerce.Core.Entites.DataTransferObject;
using E_Commerce.Core.InterFace.Repostroy;
using E_Commerce.Core.InterFace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service
{
    public class BasketServer : IBasketService
    {
        private readonly IBasketRepostry _basketRepostry;
        private readonly IMapper _mapper;

        public BasketServer(IBasketRepostry basketRepostry , IMapper mapper)
        {
            _basketRepostry = basketRepostry;
            _mapper = mapper;
            
        }

        public async Task<bool> DeleteBasketletAsync(string id) => await _basketRepostry.DeletCostmetBasket(id);
      
        public async Task<BasketDTO?> GetBasketAsync(string id)
        {
            var basket = await _basketRepostry.GetBasketCosmtmerAsync(id);
            return basket is null ? null : _mapper.Map<BasketDTO?>(basket);

        }

        public async Task<BasketDTO?> UpdateBasketAsync(BasketDTO basket)
        {
            var contmerBasket = _mapper.Map<BasketCosmtmer>(basket);
            var UpdateBasket = await _basketRepostry.UpdateBasketCosmtmerAsync(contmerBasket);
            return UpdateBasket is null ? null : _mapper.Map<BasketDTO>(contmerBasket);
        }
    }
}
