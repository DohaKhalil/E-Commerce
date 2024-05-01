using E_Commerce.Core.Entites;
using E_Commerce.Core.Entites.Spicfication;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repostry.Spicfication
{
    public class ProductSpisfication : BaseSpicfication<Producte>
    {
        public ProductSpisfication(ProductSpificationPramter productSpificationPramter) :
            base(P => (!productSpificationPramter.TypeId.HasValue || P.Id == productSpificationPramter.TypeId.Value) &&
                      (!productSpificationPramter.BrandId.HasValue || P.Id == productSpificationPramter.BrandId.Value) &&
            (string.IsNullOrWhiteSpace(productSpificationPramter.Search) || P.Name.ToLower().Contains(productSpificationPramter.Search)))
           
        {
            ExpritionInclude.Add(p => p.producteBrand);
            ExpritionInclude.Add(p => p.ProducteType);
            ApplyPagnation(productSpificationPramter.pageSize, productSpificationPramter.pageIndex);

            if (productSpificationPramter.sort is not null)
            {
                switch (productSpificationPramter.sort)
                {
                    case ProductStoringSpicfication.NameAsc:
                        OrdreBy = x => x.Name;
                        break;
                    case ProductStoringSpicfication.NameDesc:
                        OrdreBy = x => x.Name;
                        break;
                    case ProductStoringSpicfication.PriceAsc:
                        OrdreBy = x => x.Price; 
                        break;
                    case ProductStoringSpicfication.PriceDes:
                        OrdreBy = x => x.Price;
                        break;
                    default:
                        OrdreBy = x => x.Name;
                        break;        
                }

            }
            else
            {
                OrdreBy = x => x.Name;
            }

        }
        public ProductSpisfication(int id) 
            : base(P => P.Id == id)
        {

            ExpritionInclude.Add(p => p.producteBrand);
            ExpritionInclude.Add(p => p.ProducteType);
        }
    }
}
