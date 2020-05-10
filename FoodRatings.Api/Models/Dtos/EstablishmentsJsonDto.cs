using System.Collections.Generic;

namespace FoodRatings.Api.Models
{
    public class EstablishmentsJsonDto
    {
        public ICollection<EstablishmentDto> Establishments { get; set; }
    }
}
