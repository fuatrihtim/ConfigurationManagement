using Boyner.Core;
using Boyner.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boyner.ConfigurationManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationController(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Configuration>> Get()
        {
            return await _configurationRepository.GetAllConfigurations();

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Configuration> Get(string id)
        {
            return await _configurationRepository.GetConfiguration(id);

            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(Configuration configuration)
        {
            _configurationRepository.AddConfiguration(configuration);

            //add rabbitMQ
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Configuration configuration)
        {
            //_configurationRepository.UpdateConfiguration(id, configuration);

            //add rabbitMQ
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _configurationRepository.RemoveConfiguration(id);

            //add rabbitMQ
        }


        /*
         * Yazacağınız kütüphane en fazla üç adet parametre ile initialize olmalıdır. 
new ConfigurationReader(applicationName,connectionString,refreshTimerIntervalInMs);
ApplicationName: Üzerinde çalışacağı uygulamanın adı. 
ConnectionString: Storage bağlantı bilgileri.
RefreshTimerIntervalInMs : Ne kadar aralıklarla storage’ın kontrol edileceği bilgisi.
Diğer taraftan kütüphane’den dışarıya aşağıdaki imza ile bir method açılmalıdır.
T GetValue<T>(string key);
Örnek kullanım: _configurationReader.GetValue<string>("SiteName");	
Yukarıdaki gibi bir kullanım söz konusu olduğunda kütüphane sonuç olarak “boyner.com.tr” dönmelidir.
Ek olarak bir web ara yüzü ile storage’daki kayıtlar listelenmeli, güncellenebilmeli ve yeni kayıtlar eklenebilmelidir. Kayıtları client side olarak ismi ile filtrelenebilmelidir.
*/
    }
}
