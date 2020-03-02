using RC.Weather.Application.Models;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Common.Mapper;
using RC.Weather.Domain.Services;
using System.Threading.Tasks;

namespace RC.Weather.Application.Services
{
	public class ApplicationWeatherService : IApplicationWeatherService
	{
		private readonly IModelMapper mapper;
		private readonly IDomainWeatherService weatherService;

		public ApplicationWeatherService(
			IModelMapper mapper,
			IDomainWeatherService weatherService)
		{
			this.mapper = mapper;
			this.weatherService = weatherService;
		}

		public async Task<ApplicationServiceResult<ApplicationWeatherModel>> GetWeatherAsync(ApplicationWeatherRequest filter)
		{
			var model = await this.weatherService.GetCityWeatherAsync(filter.CityCode);
			var dto = this.mapper.Map<ApplicationWeatherModel>(model);
			var result = new ApplicationServiceResult<ApplicationWeatherModel>(dto);

			return result;
		}
	}
}
