using System.Collections.Generic;

namespace RC.Weather.ThirdParty.Models.AccuWeather
{
    public class AccuWeatherApiResponse
    {
        public string RequestVerb { get; set; }

        public string HttpVersion { get; set; }

        public string RequestContent { get; set; }

        public string ResponseContent { get; set; }

        public string ResponseStatusCode { get; set; }

        public string ResponseReasonPhrase { get; set; }

        public IDictionary<string, string> RequestHeaders { get; set; }

        public IDictionary<string, string> ResponseHeaders { get; set; }
    }
}
