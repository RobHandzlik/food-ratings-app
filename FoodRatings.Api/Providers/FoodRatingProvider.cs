using FoodRatings.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodRatings.Api.Providers
{
    public class FoodRatingProvider : IFoodRatingProvider
    {
        private readonly ApplicationSettings _appSettings;
        private readonly ILogger<FoodRatingProvider> _logger;

        public FoodRatingProvider(IOptions<ApplicationSettings> appSettings, ILogger<FoodRatingProvider> logger)
        {
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        /// <summary>
        /// Get all Authorities from Food Standard Agency api
        /// </summary>
        public async Task<ICollection<AuthorityDto>> GetAllAuthorities()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("x-api-version", _appSettings.FoodStandardsApi.Version);
                    var url = $"{_appSettings.FoodStandardsApi.BaseUri}/authorities/basic";

                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var jsonObject = JsonConvert.DeserializeObject<AuthorityJsonDto> (json);

                    return jsonObject.Authorities;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception in GetAllAuthorities: {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// Get Establishments for Authority by Id
        /// </summary>
        /// <param name="authorityId">Authority Id</param> 
        public async Task<ICollection<EstablishmentDto>> GetEstablishmentsForAuthorityId(int authorityId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("x-api-version", _appSettings.FoodStandardsApi.Version);
                    var url = $"{_appSettings.FoodStandardsApi.BaseUri}/establishments?name=&localAuthorityId={authorityId}";

                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var jsonObject = JsonConvert.DeserializeObject<EstablishmentsJsonDto>(json);

                    return jsonObject.Establishments;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception in GetEstablishmentsForAuthorityId: {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// Get Establishment by Id
        /// </summary>
        /// <param name="establishmentId">Authority Id</param> 
        public async Task<EstablishmentDto> GetEstablishmentById(int establishmentId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("x-api-version", _appSettings.FoodStandardsApi.Version);
                    var url = $"{_appSettings.FoodStandardsApi.BaseUri}/establishments/{establishmentId}";

                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    var establishmentDto = JsonConvert.DeserializeObject<EstablishmentDto>(json);

                    return establishmentDto;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Exception in GetEstablishmentById: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
