using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.ThirdParty.Services.ApiClients;
using RC.Weather.ThirdParty.Services.Weather;
using RC.Weather.ThirdParty.Services.Weather.AccuWeather;

namespace RC.Weather.ThirdParty.Services.IoC
{
	public static class ThirdPartyServiceCollectionExtensions
	{
		public static IServiceCollection AddThirdPartyServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHttpClient<IWeatherApiClient, AccuWeatherApiClient>(client =>
			{
				client.BaseAddress = new System.Uri(configuration["AccuWeather:BaseUrl"]);
			});
			services.AddScoped<IWeatherService, AccuWeatherService>();

			return services;
		}
	}
}
