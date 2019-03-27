using Boyner.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boyner.Service
{
    public interface IConfigurationService
    {
        Task<IEnumerable<Configuration>> GetAllConfigurations();

        Task<Configuration> GetConfigurationById(string id);

        void InsertConfiguration(Configuration configuration);

        void UpdateConfiguration(Configuration configuration);

        void DeleteConfiguration(string id);

        Task<IEnumerable<Configuration>> GetConfigurationsByServiceName(string serviceName);
    }
}
