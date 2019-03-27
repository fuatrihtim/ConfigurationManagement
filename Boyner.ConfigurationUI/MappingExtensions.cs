using Boyner.ConfigurationUI.Models;
using Boyner.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.ConfigurationUI
{
    public static class MappingExtensions
    {
        public static ConfigurationModel ToModel(this Configuration entity)
        {
            if (entity == null)
                return null;

            var model = new ConfigurationModel
            {
                InternalId = entity.InternalId,
                Id = entity.Id,
                Guid = entity.Guid,
                Name = entity.Name,
                Type = entity.Type,
                Value = entity.Value,
                IsActive = entity.IsActive,
                ApplicationName = entity.ApplicationName
            };

            return model;
        }

        public static Configuration ToEntity(this ConfigurationModel model)
        {
            if (model == null)
                return null;

            var entity = new Configuration
            {
                InternalId = model.InternalId,
                Id = model.Id,
                Guid = model.Guid,
                Name = model.Name,
                Type = model.Type,
                Value = model.Value,
                IsActive = model.IsActive,
                ApplicationName = model.ApplicationName
            };

            return entity;
        }
    }
}
