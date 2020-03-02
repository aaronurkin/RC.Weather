using RC.Weather.Domain.Models;
using System.Collections.Generic;

namespace RC.Weather.Domain.Services
{
	public interface IDomainFavoriteCityService
	{
		List<DomainCityModel> GetList();
		void Create(DomainCityModel model);
		void Delete(object cityCode);
	}
}
