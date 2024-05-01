using E_Commerce.Core.Entites.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites.DataTransferObject
{
    public class BasketDTO
    {
        public string? Id { get; set; }
        public int? DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItemDTO>? basketItems { get; set; } = new List<BasketItemDTO>();
    }
}
