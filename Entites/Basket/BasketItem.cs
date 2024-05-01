using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites.Basket
{
    public class BasketItem
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string PicUrl { get; set; }
        public string TypName { get; set; }
        public string BrandName { get; set; }


    }
}
