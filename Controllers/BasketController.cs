using E_Commerce.APIError;
using E_Commerce.Core.Entites.DataTransferObject;
using E_Commerce.Core.InterFace.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<BasketDTO>> Get(string id)
        {
            var basket = await _basketService.GetBasketAsync(id);
            return basket is null? NotFound(new ApiResponse(404)) : Ok(basket);

        }

        [HttpPost]

        public async Task<ActionResult<BasketDTO>> UpdateBasket(BasketDTO basket)
        {
            var basketResult = await _basketService.UpdateBasketAsync(basket);
            return basket is null ? NotFound(new ApiResponse(404)) : Ok(basketResult);
        }


        [HttpDelete]

        public async Task<ActionResult<BasketDTO>> DeleteBaskets(string id)
        
         =>Ok(await _basketService.DeleteBasketletAsync(id));
        


    }
}
