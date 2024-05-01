using E_Commerce.Core.Entites;
using E_Commerce.Core.Entites.Spicfication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repostry.Spicfication
{
    public class ProductCountSpec : BaseSpicfication<Producte>
    {
        public ProductCountSpec(ProductSpificationPramter productSpificationPramter) :base (P => 
                      (!productSpificationPramter.TypeId.HasValue || P.Id == productSpificationPramter.TypeId.Value) &&
                      (!productSpificationPramter.BrandId.HasValue || P.Id == productSpificationPramter.BrandId.Value)&&
                      (string.IsNullOrWhiteSpace(productSpificationPramter.Search) || P.Name.ToLower().Contains(productSpificationPramter.Search)))

        
        {
        }
    }
}
