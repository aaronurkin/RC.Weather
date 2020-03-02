using RC.Weather.Application.Models;
using RC.Weather.Application.Models.Weather;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.Weather.Application.Services
{
	public interface IApplicationCityService
	{
		Task<ApplicationServiceResult<List<ApplicationCityModel>>> SearchCityAsync(ApplicationCitiesRequest request);
	}
}
