using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites.Spicfication
{
    public class ProductSpificationPramter
    {
        private int MAXpageSize { get; set; } = 10;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductStoringSpicfication? sort { get; set; }
        public int pageIndex { get; set; } = 1;

        private int _pageSize = 5;
        public int pageSize
        {
            get => _pageSize;
            set { _pageSize = value > MAXpageSize ? MAXpageSize : value; }
        }

        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
