using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.ThirdParty.Services.ApiClients;
using RC.Weather.ThirdParty.Services.Weather;
using RC.Weather.ThirdParty.Services.Weather.AccuWeather;
using System.Linq;

namespace RC.Weather.ThirdParty.Services.IoC
{
	public static class ThirdPartyServiceCollectionExtensions
	{
		public static IServiceCollection AddThirdPartyServices(this IServiceCollection services, IConfiguration configuration)
		{
			var assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("RC."));
			services.AddHttpClient<IWeatherApiClient, AccuWeatherApiClientMock>(client =>
			{
				client.BaseAddress = new System.Uri(configuration["AccuWeather:BaseUrl"]);
			});
			services.AddScoped<IWeatherService, AccuWeatherServiceMock>();

			return services;
		}
	}
}
