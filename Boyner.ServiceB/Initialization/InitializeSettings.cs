using Boyner.Core;
using Boyner.Service;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.ServiceB
{
    public class InitializeSettings : IInitializeSettings
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfigurationService _configurationService;

        public InitializeSettings(IMemoryCache memoryCache, IConfigurationService configurationService)
        {
            _memoryCache = memoryCache;
            _configurationService = configurationService;
        }

        public async Task<IEnumerable<Config>> Initialize()
        {
            const string cacheKey = "settingsKey";

            if (!_memoryCache.TryGetValue(cacheKey, out List<Config> response))
            {
                IEnumerable<Configuration> configurations = await _configurationService.GetConfigurationsByServiceName("ServiceA");

                response = new List<Config>();

                foreach (Configuration item in configurations)
                {
                    response.Add(new Config() { Key = item.Name, Value = item.Value });
                }

                var cacheExpirationOptions = new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddYears(1), Priority = CacheItemPriority.Normal };

                _memoryCache.Set(cacheKey, response, cacheExpirationOptions);
            }
            return response;
        }
    }
}
