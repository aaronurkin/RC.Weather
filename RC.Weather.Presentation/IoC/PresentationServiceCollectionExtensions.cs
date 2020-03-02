using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.Application.Services.IoC;

namespace RC.Weather.Presentation.IoC
{
	public static class PresentationServiceCollectionExtensions
	{
		public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddApplicationServices(configuration);
			services.AddScoped<IPresentationCityService, PresentationCityService>();
			services.AddScoped<IPresentationWeatherService, PresentationWeatherService>();
			services.AddScoped<IPresentationFavoriteService, PresentationFavoriteService>();

			return services;
		}
	}
}
