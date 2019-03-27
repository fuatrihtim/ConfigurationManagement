using Boyner.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boyner.Data
{
    public class ConfigurationContext
    {
        private readonly IMongoDatabase _database = null;

        public ConfigurationContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Configuration> Configurations
        {
            get
            {
                return _database.GetCollection<Configuration>("Configuration");
            }
        }
    }
}
