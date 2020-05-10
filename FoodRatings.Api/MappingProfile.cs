using AutoMapper;
using FoodRatings.Api.Models;

namespace FoodRatings.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorityDto, Authority>();
            CreateMap<EstablishmentDto, Establishment>();
        }
    }
}
