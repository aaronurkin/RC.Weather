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
	public class AccuWeatherCityService : IThirdPartyCityService
	{
		private readonly IModelMapper mapper;
		private readonly IConfiguration configuration;
		private readonly string endpointCitySearchFormat;
		private readonly IWeatherApiClient weatherApiClient;

		public AccuWeatherCityService(
			IModelMapper mapper,
			IConfiguration configuration,
			IWeatherApiClient weatherApiClient)
		{
			this.mapper = mapper;
			this.configuration = configuration;
			this.weatherApiClient = weatherApiClient;
			this.endpointCitySearchFormat = this.configuration["AccuWeather:SearchCityEndpointFormat"];
		}

		public async Task<List<ThirdPartyCityApiResponse>> SearchAsync(string term)
		{
			var endpoint = string.Format(this.endpointCitySearchFormat, this.configuration["AccuWeather:ApiKey"], term);
			var cities = await this.weatherApiClient.GetAsync<AccuWeatherCityApiResponseData[]>(endpoint);
			var result = cities.Select(this.mapper.Map<ThirdPartyCityApiResponse>).ToList();

			return result;
		}
	}
}
