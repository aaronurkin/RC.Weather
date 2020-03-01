using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.Common.Mapper;

namespace RC.Weather.Common.IoC
{
	public static class CommonServiceCollectionExtensions
	{
		public static IServiceCollection AddCommonServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper();
			AutoMapper.Mapper.Configuration.AssertConfigurationIsValid();

			services.AddScoped<IModelMapper, ModelMapper>();
			return services;
		}
	}
}
