using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using static Boyner.Domain.Test.ConfigurationTests;
using Moq;
using Boyner.Data;
using Boyner.Core;
using System.Threading.Tasks;
using FluentAssertions;

namespace Boyner.Service.Test
{
    public class ConfigurationServiceTests
    {
        [Theory, AutoMoqData]
        public void GetAll_Configurations_Should_Success([Frozen]Mock<IConfigurationRepository> repository, List<Configuration> configurations, ConfigurationService service)
        {
            GetAllConfigurations(repository, configurations, service).Wait();
        }

        private async Task GetAllConfigurations([Frozen]Mock<IConfigurationRepository> repository, List<Configuration> configurations, ConfigurationService service)
        {
            repository.Setup(x => x.GetAllConfigurations()).Returns(Task.FromResult<IEnumerable<Configuration>>(null));

            var actual = await service.GetAllConfigurations();

            Assert.NotNull(actual);
            actual.Should().NotBeNull();
        }
    }
}
