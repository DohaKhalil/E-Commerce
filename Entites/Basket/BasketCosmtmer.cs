using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites.Basket
{
    public class BasketCosmtmer
    {
        public string? Id { get; set; }
        public int? DeliveryMethod {  get; set; } 
        public decimal ShippingPrice { get; set; }
        public List<BasketItem>? basketItems { get; set; } = new List<BasketItem>();
    }
}
