using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.ConfigurationUI.Models
{
    public class ConfigurationModel
    {
        //[JsonIgnore]
        //[BsonId]        
        public ObjectId InternalId { get; set; }

        public string Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }

        public string ApplicationName { get; set; }
    }
}
