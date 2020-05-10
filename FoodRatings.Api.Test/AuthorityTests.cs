using AutoMapper;
using FoodRatings.Api.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FoodRatings.Api.Tests.Controllers
{
    public class AuthorityTests
    {
        private IOptions<ApplicationSettings> _config;
        private IFoodRatingProvider _foodRatingProvider;

        [Fact]
        public async Task GetAllAuthorities_CointainsAuthorityId_197()
        {
            // Arrange
            GetConfigAndMockedObjects();

            // Act
            var authorityDtos = await _foodRatingProvider.GetAllAuthorities();

            // Assert
            Assert.Single(authorityDtos, a => a.LocalAuthorityId == 197);
        }

        [Fact]
        public async Task GetEstablishmentsForAuthorityId_198_CointainsEstablishmentId_75064()
        {
            // Arrange
            GetConfigAndMockedObjects();

            // Act
            var establishmentDtos = await _foodRatingProvider.GetEstablishmentsForAuthorityId(198);

            // Assert
            Assert.Single(establishmentDtos,e => e.FHRSID.Equals("75064", StringComparison.CurrentCultureIgnoreCase));
        }

        private void GetConfigAndMockedObjects()
        {
            Mapper.Reset();
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            _config = Options.Create(config.Get<ApplicationSettings>());

            var loggerMock = Mock.Of<ILogger<FoodRatingProvider>>();
            _foodRatingProvider = new FoodRatingProvider(_config, loggerMock);
        }
    }
}
