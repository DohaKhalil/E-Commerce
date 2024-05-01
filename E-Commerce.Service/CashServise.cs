using E_Commerce.Core.InterFace;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Service
{
    public class CashServise : ICashService
    {
        private readonly IDatabase _database;

        public CashServise(IConnectionMultiplexer connectionMultiplexer)
        {
            _database = connectionMultiplexer.GetDatabase();
        }
        public async Task<string?> GetCashResponseAsync(string key)
        {
            var respons = await _database.StringGetAsync(key);
            return respons.IsNullOrEmpty ? null : respons.ToString();
        }

        public async Task SetCashResponseAsync(string Key, object response, TimeSpan time)
        {
            var serializedResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            await _database.StringSetAsync(Key, serializedResponse, time);
        }
    }
}
