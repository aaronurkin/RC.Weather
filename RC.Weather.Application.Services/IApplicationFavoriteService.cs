using RC.Weather.Application.Models;
using RC.Weather.Application.Models.Weather;
using System.Collections.Generic;

namespace RC.Weather.Application.Services
{
	public interface IApplicationFavoriteService
	{
		ApplicationServiceResult<List<ApplicationCityModel>> GetList();
		ApplicationServiceResult Create(ApplicationCreateFavoriteRequest request);
		ApplicationServiceResult Delete(object cityCode);
	}
}
