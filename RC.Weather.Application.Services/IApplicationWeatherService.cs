using RC.Weather.Application.Models;
using RC.Weather.Application.Models.Weather;
using System.Threading.Tasks;

namespace RC.Weather.Application.Services
{
	public interface IApplicationWeatherService
	{
		Task<ApplicationServiceResult<ApplicationWeatherModel>> GetWeatherAsync(ApplicationWeatherRequest filter);
	}
}
