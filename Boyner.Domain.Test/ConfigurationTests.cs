using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Boyner.Core;
using MongoDB.Bson;
using System;
using Xunit;

namespace Boyner.Domain.Test
{
    public class ConfigurationTests
    {
        [Theory, AutoMoqData]
        public void Create_Configuration_Should_Exception_When_InternalId_Is_Null(ObjectId objectId)
        {
            Assert.Throws<Exception>(() => new Configuration() { InternalId = objectId });
        }

        [Theory, AutoMoqData]
        public void Create_Configuration_With_Empty_Values_Should_Success(Configuration configuration)
        {
            var config = new Configuration();

            Assert.True(config.Equals(configuration));
        }

        public class AutoMoqDataAttribute : AutoDataAttribute
        {
            public AutoMoqDataAttribute() : base(new Fixture().Customize(new AutoMoqCustomization()))
            {
            }
        }
    }
}
