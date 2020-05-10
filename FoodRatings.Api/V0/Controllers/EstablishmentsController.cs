using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodRatings.Api.Providers;
using AutoMapper;
using FoodRatings.Api.Models;

namespace FoodRatings.Api.V0.Controllers
{
    [Route("v{version:range(0,0)}/[controller]")]
    public class EstablishmentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFoodRatingProvider _foodRatingProvider;

        public EstablishmentsController(IMapper mapper, IFoodRatingProvider foodRatingProvider)
        {
            _mapper = mapper;
            _foodRatingProvider = foodRatingProvider;
        }

        [HttpGet("{establishmentId}")]
        public async Task<IActionResult> GetEstablishmentById(int establishmentId)
        {
            var establishmentDto = await _foodRatingProvider.GetEstablishmentById(establishmentId);
            var establishment = _mapper.Map<Establishment>(establishmentDto);

            return Ok(establishment);
        }
    }
}
