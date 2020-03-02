using RC.Weather.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.Weather.Domain.Services
{
	public interface IDomainWeatherService
	{
		Task<List<DomainCityModel>> SearchCityAsync(string term);
		Task<DomainWeatherModel> GetCityWeatherAsync(object cityCode);
	}
}
