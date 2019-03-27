using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boyner.Core
{
    public class Configuration
    {
        [BsonId]
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
