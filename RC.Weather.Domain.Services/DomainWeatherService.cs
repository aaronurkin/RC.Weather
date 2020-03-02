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
	public class DomainWeatherService : IDomainWeatherService
	{
		private readonly IModelMapper mapper;
		private readonly IDatabaseUnit database;
		private readonly IThirdPartyWeatherService weatherService;

		public DomainWeatherService(
			IModelMapper mapper,
			IDatabaseUnit database,
			IThirdPartyWeatherService weatherService)
		{
			this.mapper = mapper;
			this.database = database;
			this.weatherService = weatherService;
		}

		public async Task<DomainWeatherModel> GetCityWeatherAsync(object cityCode)
		{
			DomainWeatherModel model;
			var code = $"{cityCode}";

			var condition = this.database.Conditions.GetSingle(code);

			if (condition == null)
			{
				var weather = await this.weatherService.GetAsync(cityCode);

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
