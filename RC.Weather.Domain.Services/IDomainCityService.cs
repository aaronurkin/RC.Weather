using RC.Weather.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.Weather.Domain.Services
{
	public interface IDomainCityService
	{
		Task<List<DomainCityModel>> SearchCityAsync(string term);
	}
}
