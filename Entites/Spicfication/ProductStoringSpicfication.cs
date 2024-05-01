using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entites.Spicfication
{
    [JsonConverter(typeof(JsonStringEnumConverter))]    
    public enum ProductStoringSpicfication
    {
        NameAsc , NameDesc , PriceAsc , PriceDes
    }
}
