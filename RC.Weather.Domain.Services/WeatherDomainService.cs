using RC.Weather.Common.Mapper;
using RC.Weather.Domain.Models;
using RC.Weather.ThirdParty.Services.Weather;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.Weather.Domain.Services
{
	public class WeatherDomainService : IWeatherDomainService
	{
		private readonly IModelMapper mapper;
		private readonly IWeatherService weatherService;

		public WeatherDomainService(
			IModelMapper mapper,
			IWeatherService weatherService)
		{
			this.mapper = mapper;
			this.weatherService = weatherService;
		}

		public async Task<List<DomainCityModel>> SearchCityAsync(string term)
		{
			var cities = await this.weatherService.SearchCityAsync(term);
			var model = cities.Select(this.mapper.Map<DomainCityModel>).ToList();

			return model;
		}

		public async Task<DomainWeatherModel> GetCityWeatherAsync(object cityCode)
		{
			var weather = await this.weatherService.GetCityWeatherAsync(cityCode);
			var model = this.mapper.Map<DomainWeatherModel>(weather);

			return model;
		}
	}
}
