using RC.Weather.Common.Mapper;
using RC.Weather.ThirdParty.Models;
using RC.Weather.ThirdParty.Models.AccuWeather;
using RC.Weather.ThirdParty.Services.ApiClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.Weather.ThirdParty.Services.Weather.AccuWeather
{
	public class AccuWeatherServiceMock : IWeatherService
	{
		private readonly IModelMapper mapper;
		private readonly IWeatherApiClient weatherApiClient;

		public AccuWeatherServiceMock(
			IModelMapper mapper,
			IWeatherApiClient weatherApiClient)
		{
			this.mapper = mapper;
			this.weatherApiClient = weatherApiClient;
		}

		public async Task<ThirdPartyWeatherApiResponse> GetCityWeatherAsync(object cityCode)
		{
			var raw = @"%5B%7B%22LocalObservationDateTime%22%3A%222020-02-26T07%3A11%3A00+02%3A00%22%2C%22EpochTime%22%3A1582693860%2C%22WeatherText%22%3A%22Clouds%20and%20sun%22%2C%22WeatherIcon%22%3A4%2C%22HasPrecipitation%22%3Afalse%2C%22PrecipitationType%22%3Anull%2C%22IsDayTime%22%3Atrue%2C%22Temperature%22%3A%7B%22Metric%22%3A%7B%22Value%22%3A13.6%2C%22Unit%22%3A%22C%22%2C%22UnitType%22%3A17%7D%2C%22Imperial%22%3A%7B%22Value%22%3A56.0%2C%22Unit%22%3A%22F%22%2C%22UnitType%22%3A18%7D%7D%2C%22MobileLink%22%3A%22http%3A//m.accuweather.com/en/il/tel-aviv/215854/current-weather/215854%3Flang%3Den-us%22%2C%22Link%22%3A%22http%3A//www.accuweather.com/en/il/tel-aviv/215854/current-weather/215854%3Flang%3Den-us%22%7D%5D";
			var data = await this.weatherApiClient.GetAsync<AccuWeatherWeatherApiResponseData[]>(raw);
			var weather = this.mapper.Map<ThirdPartyWeatherApiResponse>(data.FirstOrDefault());

			return weather;
		}

		public async Task<List<ThirdPartyCityApiResponse>> SearchCityAsync(string term)
		{
			var raw = @"%5B%7B%22Version%22%3A1%2C%22Key%22%3A%22215854%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A31%2C%22LocalizedName%22%3A%22Tel%20Aviv%22%2C%22Country%22%3A%7B%22ID%22%3A%22IL%22%2C%22LocalizedName%22%3A%22Israel%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22TA%22%2C%22LocalizedName%22%3A%22Tel%20Aviv%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%223431644%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A45%2C%22LocalizedName%22%3A%22Telanaipura%22%2C%22Country%22%3A%7B%22ID%22%3A%22ID%22%2C%22LocalizedName%22%3A%22Indonesia%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22JA%22%2C%22LocalizedName%22%3A%22Jambi%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%22300558%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A45%2C%22LocalizedName%22%3A%22Telok%20Blangah%20New%20Town%22%2C%22Country%22%3A%7B%22ID%22%3A%22SG%22%2C%22LocalizedName%22%3A%22Singapore%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%2205%22%2C%22LocalizedName%22%3A%22South%20West%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%22325876%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A51%2C%22LocalizedName%22%3A%22Telford%22%2C%22Country%22%3A%7B%22ID%22%3A%22GB%22%2C%22LocalizedName%22%3A%22United%20Kingdom%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22TFW%22%2C%22LocalizedName%22%3A%22Telford%20and%20Wrekin%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%22169072%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A51%2C%22LocalizedName%22%3A%22Telavi%22%2C%22Country%22%3A%7B%22ID%22%3A%22GE%22%2C%22LocalizedName%22%3A%22Georgia%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22KA%22%2C%22LocalizedName%22%3A%22Kakheti%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%22230611%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A51%2C%22LocalizedName%22%3A%22Telsiai%22%2C%22Country%22%3A%7B%22ID%22%3A%22LT%22%2C%22LocalizedName%22%3A%22Lithuania%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22TE%22%2C%22LocalizedName%22%3A%22Tel%u0161iai%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%222723742%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A55%2C%22LocalizedName%22%3A%22Tel%E9grafo%22%2C%22Country%22%3A%7B%22ID%22%3A%22BR%22%2C%22LocalizedName%22%3A%22Brazil%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22PA%22%2C%22LocalizedName%22%3A%22Par%E1%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%22186933%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A55%2C%22LocalizedName%22%3A%22Tela%22%2C%22Country%22%3A%7B%22ID%22%3A%22HN%22%2C%22LocalizedName%22%3A%22Honduras%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22AT%22%2C%22LocalizedName%22%3A%22Atl%E1ntida%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%223453754%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A55%2C%22LocalizedName%22%3A%22Telaga%20Asih%22%2C%22Country%22%3A%7B%22ID%22%3A%22ID%22%2C%22LocalizedName%22%3A%22Indonesia%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22JB%22%2C%22LocalizedName%22%3A%22West%20Java%22%7D%7D%2C%7B%22Version%22%3A1%2C%22Key%22%3A%223453755%22%2C%22Type%22%3A%22City%22%2C%22Rank%22%3A55%2C%22LocalizedName%22%3A%22Telagamurni%22%2C%22Country%22%3A%7B%22ID%22%3A%22ID%22%2C%22LocalizedName%22%3A%22Indonesia%22%7D%2C%22AdministrativeArea%22%3A%7B%22ID%22%3A%22JB%22%2C%22LocalizedName%22%3A%22West%20Java%22%7D%7D%5D";
			var cities = await this.weatherApiClient.GetAsync<AccuWeatherCityApiResponseData[]>(raw);
			var result = cities.Select(this.mapper.Map<ThirdPartyCityApiResponse>).ToList();

			return result;
		}
	}
}
