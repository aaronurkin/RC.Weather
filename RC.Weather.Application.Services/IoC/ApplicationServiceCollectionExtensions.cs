﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.Domain.Services.IoC;

namespace RC.Weather.Application.Services.IoC
{
	public static class ApplicationServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDomainServices(configuration);
			services.AddScoped<IApplicationCityService, ApplicationCityService>();
			services.AddScoped<IApplicationWeatherService, ApplicationWeatherService>();
			services.AddScoped<IApplicationFavoriteService, ApplicationFavoriteService>();

			return services;
		}
	}
}
