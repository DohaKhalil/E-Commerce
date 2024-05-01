using E_Commerce.Core.Entites.DataTransferObject;

namespace E_Commerce.Core.InterFace.Service
{
    public interface IBasketService
    {
        Task<BasketDTO?> GetBasketAsync(string id);
        Task<BasketDTO?> UpdateBasketAsync(BasketDTO basket);
        Task<bool> DeleteBasketletAsync(string id);

    }
}
