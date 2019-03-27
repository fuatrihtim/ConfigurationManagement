using Boyner.Core;
using Boyner.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boyner.Service
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public void DeleteConfiguration(string id)
        {
            _configurationRepository.RemoveConfiguration(id);
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurations()
        {
            return await _configurationRepository.GetAllConfigurations();
        }

        public async Task<Configuration> GetConfigurationById(string id)
        {
            return await _configurationRepository.GetConfiguration(id);
        }

        public void InsertConfiguration(Configuration configuration)
        {
            _configurationRepository.AddConfiguration(configuration);
        }

        public void UpdateConfiguration(Configuration configuration)
        {
            _configurationRepository.UpdateConfiguration(configuration);
        }

        public async Task<IEnumerable<Configuration>> GetConfigurationsByServiceName(string serviceName)
        {
            return await _configurationRepository.GetConfigurationsByServiceName(serviceName);
        }
    }
}
