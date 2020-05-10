using System;
using System.Collections.Generic;
using System.Linq;
using FoodRatings.Api.Models;

namespace FoodRatings.Api.Helpers
{
    public static class AuthoritytHelper
    {
        public static double GetProcentageValue(IEnumerable<EstablishmentDto> dtos, int totalItems)
        {
            if (!dtos.Any()) return 0.0;
            return Math.Round((double)dtos.Count() / totalItems * 100, 2);
        }
    }
}
