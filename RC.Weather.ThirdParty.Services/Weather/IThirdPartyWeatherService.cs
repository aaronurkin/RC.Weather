using RC.Weather.ThirdParty.Models;
using System.Threading.Tasks;

namespace RC.Weather.ThirdParty.Services.Weather
{
	public interface IThirdPartyWeatherService
	{
		Task<ThirdPartyWeatherApiResponse> GetAsync(object cityCode);
	}
}
