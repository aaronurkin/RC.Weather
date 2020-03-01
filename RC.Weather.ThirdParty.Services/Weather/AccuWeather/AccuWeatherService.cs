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
	public class AccuWeatherService : IWeatherService
	{
		private const string AccuWeatherSettingsApiKey = "ApiKey";
		private const string AccuWeatherQueryParameterSearch = "q";
		private const string AccuWeatherQueryParameterApiKey = "apikey";
		private const string AccuWeatherSettingsPropertyName = "AccuWeather";
		private const string AccuWeatherSettingsSearchCityEndpoint = "SearchCityEndpoint";
		private const string AccuWeatherSettingsCityWeatherEndpoint = "CityWeatherEndpoint";

		private readonly IModelMapper mapper;
		private readonly IConfiguration configuration;
		private readonly IWeatherApiClient weatherApiClient;

		public AccuWeatherService(
			IModelMapper mapper,
			IConfiguration configuration,
			IWeatherApiClient weatherApiClient)
		{
			this.mapper = mapper;
			this.configuration = configuration;
			this.weatherApiClient = weatherApiClient;
		}

		public async Task<ThirdPartyWeatherApiResponse> GetCityWeatherAsync(object cityCode)
		{
			var endpoint = $"{this.configuration[$"{AccuWeatherSettingsPropertyName}:{AccuWeatherSettingsCityWeatherEndpoint}"]}/{cityCode}?{AccuWeatherQueryParameterApiKey}={this.configuration[$"{AccuWeatherSettingsPropertyName}:{AccuWeatherSettingsApiKey}"]}";
			var data = await this.weatherApiClient.GetAsync<AccuWeatherWeatherApiResponseData[]>(endpoint);
			var weather = this.mapper.Map<ThirdPartyWeatherApiResponse>(data.FirstOrDefault());

			return weather;
		}

		public async Task<List<ThirdPartyCityApiResponse>> SearchCityAsync(string term)
		{
			var endpoint = $"{this.configuration[$"{AccuWeatherSettingsPropertyName}:{AccuWeatherSettingsSearchCityEndpoint}"]}?{AccuWeatherSettingsApiKey}={this.configuration[$"{AccuWeatherSettingsPropertyName}:{AccuWeatherSettingsApiKey}"]}&{AccuWeatherQueryParameterSearch}={term}";
			var cities = await this.weatherApiClient.GetAsync<AccuWeatherCityApiResponseData[]>(endpoint);
			var result = cities.Select(this.mapper.Map<ThirdPartyCityApiResponse>).ToList();

			return result;
		}
	}
}
