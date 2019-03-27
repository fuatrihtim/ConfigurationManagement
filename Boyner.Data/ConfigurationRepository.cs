using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Boyner.Core;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Boyner.Data
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ConfigurationContext _context = null;

        public ConfigurationRepository(IOptions<Settings> settings)
        {
            _context = new ConfigurationContext(settings);
        }

        public async Task AddConfiguration(Configuration configuration)
        {
            try
            {
                await _context.Configurations.InsertOneAsync(configuration);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Configuration>> GetAllConfigurations()
        {
            try
            {
                return await _context.Configurations.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Configuration> GetConfiguration(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);

                return await _context.Configurations
                                .Find(configuration => configuration.Id == id || configuration.InternalId == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveConfiguration(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Configurations.DeleteOneAsync(Builders<Configuration>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateConfiguration(Configuration configuration)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Configurations.ReplaceOneAsync(n => n.Id.Equals(configuration.Id), configuration, new UpdateOptions { IsUpsert = true });

                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task<IEnumerable<Configuration>> GetConfigurationsByServiceName(string serviceName)
        {
            try
            {
                return await _context.Configurations.Find(x=>x.ApplicationName == serviceName && x.IsActive).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
