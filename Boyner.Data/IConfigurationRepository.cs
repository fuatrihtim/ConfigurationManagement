using Boyner.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boyner.Data
{
    public interface IConfigurationRepository
    {
        Task<IEnumerable<Configuration>> GetAllConfigurations();

        Task<Configuration> GetConfiguration(string id);

        Task AddConfiguration(Configuration configuration);

        Task<bool> UpdateConfiguration(Configuration configuration);

        Task<bool> RemoveConfiguration(string id);

        Task<IEnumerable<Configuration>> GetConfigurationsByServiceName(string serviceName);
    }
}
