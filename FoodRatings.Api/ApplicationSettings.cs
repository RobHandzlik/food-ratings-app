using System;

namespace FoodRatings.Api
{
    public class ApplicationSettings
    {
        public UriBase FoodStandardsApi { get; set; }
    }

    public class UriBase
    {
        public string BaseUri { get; set; }
        public string Version { get; set; }
    }
}
