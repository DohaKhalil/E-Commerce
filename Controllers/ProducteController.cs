using E_Commerce.APIError;
using E_Commerce.Core.Entites.DataTransferObject;
using E_Commerce.Core.Entites.Spicfication;
using E_Commerce.Helper;
using E_Commerce.Service.InterFacees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProducteController : ControllerBase
    {
        private readonly IProductServises _productServises;

        public ProducteController(IProductServises productServises)
        {
            _productServises = productServises;
        }

        [HttpGet]
        [Cash(60)]
        public async Task<ActionResult<IEnumerable<ProductTrnsfrtDTO>>> GetAllAsync([FromQuery]ProductSpificationPramter spificationPramter) =>
        Ok(await _productServises.GetAllAsync(spificationPramter));


        [HttpGet("id")]
        public async Task<ActionResult<ProductTrnsfrtDTO>> GetProduct(int id)
        {
            try
            {
                var Producte = await _productServises.GetProducte(id);
                return Producte == null ? NotFound(new ApiResponse(404, $"the producte with id {id} Not Found")) : Ok(Producte);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("brand")]
        public async Task<ActionResult<IEnumerable<ProductTrnsfrtDTO>>> GetBrand() => Ok(await _productServises.GetBrandAsync());

        [HttpGet("type")]
        public async Task<ActionResult<IEnumerable<ProductTrnsfrtDTO>>> GetType() => Ok(await _productServises.GetTypeAcync());
    }
}
