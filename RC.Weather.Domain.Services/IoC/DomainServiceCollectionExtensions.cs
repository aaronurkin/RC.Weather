using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.ThirdParty.Services.IoC;

namespace RC.Weather.Domain.Services.IoC
{
	public static class DomainServiceCollectionExtensions
	{
		public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddThirdPartyServices(configuration);
			services.AddScoped<IWeatherDomainService, WeatherDomainService>();
			return services;
		}
	}
}
