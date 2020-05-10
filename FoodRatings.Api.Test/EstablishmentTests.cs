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
    public class EstablishmentTests
    {
        private IOptions<ApplicationSettings> _config;
        private IFoodRatingProvider _foodRatingProvider;

        [Fact]
        public async Task GetEstablishmentById_ReturnsOk()
        {
            // Arrange
            GetConfigAndMockedObjects();

            // Act
            var establishmentDto = await _foodRatingProvider.GetEstablishmentById(75064);

            // Assert
            Assert.True(establishmentDto.LocalAuthorityBusinessID.Equals("17437", StringComparison.CurrentCultureIgnoreCase));
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
