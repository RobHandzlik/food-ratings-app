using System.Collections.Generic;

namespace FoodRatings.Api.Models
{
    public class AuthorityJsonDto
    {
        public ICollection<AuthorityDto> Authorities { get; set; }
    }
}
