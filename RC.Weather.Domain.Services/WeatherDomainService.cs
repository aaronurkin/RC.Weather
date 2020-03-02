using RC.Weather.Common.Mapper;
using RC.Weather.Domain.Models;
using RC.Weather.Repositories;
using RC.Weather.Repositories.Models;
using RC.Weather.ThirdParty.Services.Weather;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.Weather.Domain.Services
{
	public class WeatherDomainService : IWeatherDomainService
	{
		private readonly IModelMapper mapper;
		private readonly IDatabaseUnit database;
		private readonly IWeatherService weatherService;

		public WeatherDomainService(
			IModelMapper mapper,
			IDatabaseUnit database,
			IWeatherService weatherService)
		{
			this.mapper = mapper;
			this.database = database;
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
			DomainWeatherModel model;
			var code = $"{cityCode}";

			var condition = this.database.Conditions.GetSingle(code);

			if (condition == null)
			{
				var weather = await this.weatherService.GetCityWeatherAsync(cityCode);

				condition = this.mapper.Map<ConditionDbModel>(weather);
				condition.CityCode = code;

				this.database.Conditions.Create(condition);
			}

			var favorite = this.database.Favorites.GetSingle(code);

			model = this.mapper.Map<DomainWeatherModel>(condition);
			model.IsFavorite = favorite != null;

			return model;
		}
	}
}
