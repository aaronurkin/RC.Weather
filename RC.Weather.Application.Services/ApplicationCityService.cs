using RC.Weather.Application.Models;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Common.Mapper;
using RC.Weather.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.Weather.Application.Services
{
	public class ApplicationCityService : IApplicationCityService
	{
		private readonly IModelMapper mapper;
		private readonly IDomainCityService cityService;

		public ApplicationCityService(
			IModelMapper mapper,
			IDomainCityService cityService)
		{
			this.mapper = mapper;
			this.cityService = cityService;
		}

		public async Task<ApplicationServiceResult<List<ApplicationCityModel>>> SearchCityAsync(ApplicationCitiesRequest request)
		{
			var domainModel = await this.cityService.SearchCityAsync(request.Term);
			var cities = domainModel.Select(this.mapper.Map<ApplicationCityModel>).ToList();
			var result = new ApplicationServiceResult<List<ApplicationCityModel>>(cities);

			return result;
		}
	}
}
