using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites.DataTransferObject
{
    public class PagnatedResultDTO<T>
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int TotalCount { get; set; }

        public IReadOnlyList<T> Data  { get; set; }



    }
}
