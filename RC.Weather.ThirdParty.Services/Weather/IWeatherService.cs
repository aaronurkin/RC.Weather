using RC.Weather.ThirdParty.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.Weather.ThirdParty.Services.Weather
{
	public interface IWeatherService
	{
		Task<List<ThirdPartyCityApiResponse>> SearchCityAsync(string term);
		Task<ThirdPartyWeatherApiResponse> GetCityWeatherAsync(object cityCode);
	}
}
