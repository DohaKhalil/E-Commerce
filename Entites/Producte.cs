using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites
{
    public class Producte :BaseEntites<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
       
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public ProducteType ProducteType { get; set; }
        public int TypeId { get; set; }
        public ProducteBrand producteBrand { get; set; }
        public int BrandId { get; set; }



    }
}
