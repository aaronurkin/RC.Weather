using Newtonsoft.Json;
using RC.Weather.ThirdParty.Services.ApiClients;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RC.Weather.ThirdParty.Services.Weather.AccuWeather
{
    public class AccuWeatherApiClientMock : IWeatherApiClient
    {
        private const string ENDPOINT_START_WEATHER = "currentconditions";
        private const string ENDPOINT_START_CITY_SEARCH = "locations";
        private const string RAW_CONTENT_WEATHER = @"[{""LocalObservationDateTime"":""2020-02-26T07:11:00+02:00"",""EpochTime"":1582693860,""WeatherText"":""Clouds and sun"",""WeatherIcon"":4,""HasPrecipitation"":false,""PrecipitationType"":null,""IsDayTime"":true,""Temperature"":{""Metric"":{""Value"":13.6,""Unit"":""C"",""UnitType"":17},""Imperial"":{""Value"":56.0,""Unit"":""F"",""UnitType"":18}},""MobileLink"":""http://m.accuweather.com/en/il/tel-aviv/215854/current-weather/215854?lang=en-us"",""Link"":""http://www.accuweather.com/en/il/tel-aviv/215854/current-weather/215854?lang=en-us""}]";
        private const string RAW_CONTENT_CITIES_SEARCH = @"[{""Version"":1,""Key"":""215854"",""Type"":""City"",""Rank"":31,""LocalizedName"":""Tel Aviv"",""Country"":{""ID"":""IL"",""LocalizedName"":""Israel""},""AdministrativeArea"":{""ID"":""TA"",""LocalizedName"":""Tel Aviv""}},{""Version"":1,""Key"":""3431644"",""Type"":""City"",""Rank"":45,""LocalizedName"":""Telanaipura"",""Country"":{""ID"":""ID"",""LocalizedName"":""Indonesia""},""AdministrativeArea"":{""ID"":""JA"",""LocalizedName"":""Jambi""}},{""Version"":1,""Key"":""300558"",""Type"":""City"",""Rank"":45,""LocalizedName"":""Telok Blangah New Town"",""Country"":{""ID"":""SG"",""LocalizedName"":""Singapore""},""AdministrativeArea"":{""ID"":""05"",""LocalizedName"":""South West""}},{""Version"":1,""Key"":""325876"",""Type"":""City"",""Rank"":51,""LocalizedName"":""Telford"",""Country"":{""ID"":""GB"",""LocalizedName"":""United Kingdom""},""AdministrativeArea"":{""ID"":""TFW"",""LocalizedName"":""Telford and Wrekin""}},{""Version"":1,""Key"":""169072"",""Type"":""City"",""Rank"":51,""LocalizedName"":""Telavi"",""Country"":{""ID"":""GE"",""LocalizedName"":""Georgia""},""AdministrativeArea"":{""ID"":""KA"",""LocalizedName"":""Kakheti""}},{""Version"":1,""Key"":""230611"",""Type"":""City"",""Rank"":51,""LocalizedName"":""Telsiai"",""Country"":{""ID"":""LT"",""LocalizedName"":""Lithuania""},""AdministrativeArea"":{""ID"":""TE"",""LocalizedName"":""Tel%u0161iai""}},{""Version"":1,""Key"":""2723742"",""Type"":""City"",""Rank"":55,""LocalizedName"":""Telgrafo"",""Country"":{""ID"":""BR"",""LocalizedName"":""Brazil""},""AdministrativeArea"":{""ID"":""PA"",""LocalizedName"":""Par""}},{""Version"":1,""Key"":""186933"",""Type"":""City"",""Rank"":55,""LocalizedName"":""Tela"",""Country"":{""ID"":""HN"",""LocalizedName"":""Honduras""},""AdministrativeArea"":{""ID"":""AT"",""LocalizedName"":""Atlntida""}},{""Version"":1,""Key"":""3453754"",""Type"":""City"",""Rank"":55,""LocalizedName"":""Telaga Asih"",""Country"":{""ID"":""ID"",""LocalizedName"":""Indonesia""},""AdministrativeArea"":{""ID"":""JB"",""LocalizedName"":""West Java""}},{""Version"":1,""Key"":""3453755"",""Type"":""City"",""Rank"":55,""LocalizedName"":""Telagamurni"",""Country"":{""ID"":""ID"",""LocalizedName"":""Indonesia""},""AdministrativeArea"":{""ID"":""JB"",""LocalizedName"":""West Java""}}]";

        private readonly HttpClient client;

        public AccuWeatherApiClientMock(HttpClient client)
        {
            client = null;
        }

        public Task<TResponseContent> GetAsync<TResponseContent>(string endpoint) where TResponseContent : class
        {
            var rawContent = endpoint.StartsWith(ENDPOINT_START_WEATHER)
                ? RAW_CONTENT_WEATHER
                : endpoint.StartsWith(ENDPOINT_START_CITY_SEARCH)
                    ? RAW_CONTENT_CITIES_SEARCH
                    : throw new System.Exception("Wrong AccuWeather endpoint");

            var responseContent = JsonConvert.DeserializeObject<TResponseContent>(rawContent);

            return Task.FromResult(responseContent);
        }
    }
}