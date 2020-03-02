using Microsoft.Extensions.Configuration;
using RC.Weather.Common.Mapper;
using RC.Weather.ThirdParty.Models;
using RC.Weather.ThirdParty.Models.AccuWeather;
using RC.Weather.ThirdParty.Services.ApiClients;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.Weather.ThirdParty.Services.Weather.AccuWeather
{
	public class AccuWeatherWeatherService : IThirdPartyWeatherService
	{
		private readonly IModelMapper mapper;
		private readonly IConfiguration configuration;
		private readonly string endpointCityWeatherFormat;
		private readonly IWeatherApiClient weatherApiClient;

		public AccuWeatherWeatherService(
			IModelMapper mapper,
			IConfiguration configuration,
			IWeatherApiClient weatherApiClient)
		{
			this.mapper = mapper;
			this.configuration = configuration;
			this.weatherApiClient = weatherApiClient;
			this.endpointCityWeatherFormat = this.configuration["AccuWeather:CityWeatherEndpointFormat"];
		}

		public async Task<ThirdPartyWeatherApiResponse> GetAsync(object cityCode)
		{
			var endpoint = string.Format(this.endpointCityWeatherFormat, cityCode, this.configuration["AccuWeather:ApiKey"]);
			var data = await this.weatherApiClient.GetAsync<AccuWeatherWeatherApiResponseData[]>(endpoint);
			var weather = this.mapper.Map<ThirdPartyWeatherApiResponse>(data.FirstOrDefault());

			return weather;
		}
	}
}
