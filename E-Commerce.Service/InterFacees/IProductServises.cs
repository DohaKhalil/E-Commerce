using E_Commerce.Core.Entites.DataTransferObject;
using E_Commerce.Core.Entites.Spicfication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.InterFacees
{
    public interface IProductServises
    {
        Task<PagnatedResultDTO<ProductTrnsfrtDTO>> GetAllAsync(ProductSpificationPramter spificationPramter);
        Task<ProductTrnsfrtDTO> GetProducte(int id);
        Task<IEnumerable<BrandTransferDTO>> GetBrandAsync();
        Task<IEnumerable<TypeTransferDTO>> GetTypeAcync();

    }
}
