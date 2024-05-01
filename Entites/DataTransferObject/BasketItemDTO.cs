using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites.DataTransferObject
{
    public class BasketItemDTO
    {
        [Required]
        public int? ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        [Range(1 , 99)]
        public int quantity { get; set; }
        [Required]
        public string PicUrl { get; set; }
        [Required]
        public string TypName { get; set; }
        [Required]
        public string BrandName { get; set; }
    }
}
