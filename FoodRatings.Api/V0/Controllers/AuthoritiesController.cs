using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodRatings.Api.Providers;
using AutoMapper;
using FoodRatings.Api.Models;
using System.Collections.Generic;
using System.Linq;
using FoodRatings.Api.Helpers;

namespace FoodRatings.Api.V0.Controllers
{
    [Route("v{version:range(0,0)}/[controller]")]
    public class AuthoritiesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFoodRatingProvider _foodRatingProvider;

        public AuthoritiesController(IMapper mapper, IFoodRatingProvider foodRatingProvider)
        {
            _mapper = mapper;
            _foodRatingProvider = foodRatingProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authorityDtos = await _foodRatingProvider.GetAllAuthorities();
            var authorities = _mapper.Map<ICollection<Authority>>(authorityDtos);

            return Ok(authorities);
        }

        [HttpGet("{authorityId}/establishments")]
        public async Task<IActionResult> GetEstablishmentsForAuthorityId(int authorityId)
        {
            var establishmentDtos = await _foodRatingProvider.GetEstablishmentsForAuthorityId(authorityId);
            var establishments = _mapper.Map<ICollection<Establishment>>(establishmentDtos);

            return Ok(establishments);
        }

        [HttpGet("{authorityId}/results")]
        public async Task<IActionResult> GetEstablishmentsResultsForAuthoriyId(int authorityId)
        {
            var establishmentDtos = await _foodRatingProvider.GetEstablishmentsForAuthorityId(authorityId);
            var results = establishmentDtos.GroupBy(x => x.RatingValue).Select(e => new AuthorityResult
            {
                Score = e.Key,
                Procentage = AuthoritytHelper.GetProcentageValue(e, establishmentDtos.Count())
            });

            return Ok(results);
        }
    }
}
