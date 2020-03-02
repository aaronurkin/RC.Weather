using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.Domain.Services.IoC;

namespace RC.Weather.Application.Services.IoC
{
	public static class ApplicationServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDomainServices(configuration);
			services.AddScoped<IApplicationWeatherService, ApplicationWeatherService>();

			return services;
		}
	}
}
