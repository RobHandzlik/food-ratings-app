using FoodRatings.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodRatings.Api.Providers
{
    public interface IFoodRatingProvider
    {
        Task<ICollection<AuthorityDto>> GetAllAuthorities();
        Task<ICollection<EstablishmentDto>> GetEstablishmentsForAuthorityId(int authorityId);
        Task<EstablishmentDto> GetEstablishmentById(int establishmentId);
    }    
}
