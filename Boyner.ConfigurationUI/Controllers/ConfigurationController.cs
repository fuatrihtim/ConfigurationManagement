using Boyner.ConfigurationUI.Models;
using Boyner.Core;
using Boyner.RabbitMQ;
using Boyner.Service;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.ConfigurationUI.Controllers
{
    public class ConfigurationController : Controller
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public async Task<IActionResult> Index(string nameSearchString, string applicationNameSearchString)
        {
            IEnumerable<Configuration> configurations = await _configurationService.GetAllConfigurations();

            List<ConfigurationModel> configurationsModel = configurations.Select(x => x.ToModel()).ToList();

            if (!string.IsNullOrEmpty(nameSearchString) || !string.IsNullOrEmpty(applicationNameSearchString))
                configurationsModel = configurationsModel.Where(x => x.Name == nameSearchString || x.ApplicationName == applicationNameSearchString).ToList();

            return View(configurationsModel);

            //var client = new RestClient("http://localhost:5000");
            //var request = new RestRequest("api/configuration/", Method.GET);

            ////IRestResponse response = client.Execute(request);

            //var response = client.Execute<ConfigurationModel>(request);
            //var content = response.Content;

            //var configurations = JsonConvert.DeserializeObject<List<ConfigurationModel>>(content);

            //configurationModels.AddRange(configurations);

            //return View(configurationModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ConfigurationModel model)
        {
            Configuration configuration = model.ToEntity();
            _configurationService.InsertConfiguration(configuration);

            if (model.IsActive)
            {
                var message = new ServiceMessageModel()
                {
                    Key = model.ApplicationName,
                    Value = model.Value
                };

                Publisher publisher = new Publisher(message.Key, message.Value);
            }

            return RedirectToAction("Index", "Configuration");
        }

        public async Task<IActionResult> Update(string InternalId)
        {
            Configuration configuration = await _configurationService.GetConfigurationById(InternalId);

            ConfigurationModel model = configuration.ToModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(string InternalId, ConfigurationModel model)
        {
            model.InternalId = new ObjectId(InternalId);
            Configuration configuration = model.ToEntity();
            _configurationService.UpdateConfiguration(configuration);

            if (model.IsActive)
            {
                var message = new ServiceMessageModel()
                {
                    Key = model.ApplicationName,
                    Value = model.Value
                };

                Publisher publisher = new Publisher(message.Key, message.Value);
            }

            return RedirectToAction("Index", "Configuration");
        }

        [HttpPost]
        public bool Delete(int id)
        {
            return false;
        }
    }
}
