using AutoMapper;
using E_Commerce.Core.Entites;
using E_Commerce.Core.Entites.DataTransferObject;
using E_Commerce.Core.Entites.Spicfication;
using E_Commerce.Core.InterFace.Repostroy;
using E_Commerce.Repostry.Spicfication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.InterFacees
{
    public class ProductServises : IProductServises
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServises(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagnatedResultDTO<ProductTrnsfrtDTO>> GetAllAsync(ProductSpificationPramter spificationPramter)
        {
            var spec = new ProductSpisfication(spificationPramter);
            var product = await _unitOfWork.Repostroy<Producte, int>().GetAllwithSpicAsync(spec);
            var count = await _unitOfWork.Repostroy<Producte, int>().GeTCountOFpage(spec);
            var MappedResult = _mapper.Map<IReadOnlyList<ProductTrnsfrtDTO>>(product);
            return new PagnatedResultDTO<ProductTrnsfrtDTO>()
            {
                Data = MappedResult,
                pageIndex = spificationPramter.pageIndex,
                pageSize = spificationPramter.pageSize,
                TotalCount = count

            };
        }

        public async Task<IEnumerable<BrandTransferDTO>> GetBrandAsync()
        {
            var barnd = await _unitOfWork.Repostroy<ProducteBrand , int>().GetAllAsync();
            return _mapper.Map<IEnumerable<BrandTransferDTO>>(barnd);
        }

        public async Task<ProductTrnsfrtDTO> GetProducte(int id)
        {
            var sepc = new ProductSpisfication(id);
            var GetById = await _unitOfWork.Repostroy<Producte,int>().GetwithidSpicAsync(sepc);
            return _mapper.Map<ProductTrnsfrtDTO>(GetById);

        }

        public async Task<IEnumerable<TypeTransferDTO>> GetTypeAcync()
        {
            var Type = await _unitOfWork.Repostroy<ProducteType, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<TypeTransferDTO>>(Type);
        }
    }
}
