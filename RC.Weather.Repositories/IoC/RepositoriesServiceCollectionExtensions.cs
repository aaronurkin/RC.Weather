using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RC.Weather.Repositories.EntityFramework;

namespace RC.Weather.Repositories.IoC
{
	public static class RepositoriesServiceCollectionExtensions
	{
		private const string SETTINGS_PARAMETER_NAME_SQL_SERVER_CONNECTION_STRING = "ApplicationLocalDb";
		public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(SETTINGS_PARAMETER_NAME_SQL_SERVER_CONNECTION_STRING)));
			services.AddScoped<IFavoritesRepository, FavoritesEntityFrameworkRepository>();
			services.AddScoped<IConditionsRepository, ConditionsEntityFrameworkRepository>();
			services.AddScoped<IDatabaseUnit, DatabaseUnit>();
			return services;
		}
	}
}
