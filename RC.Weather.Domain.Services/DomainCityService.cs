using RC.Weather.Common.Mapper;
using RC.Weather.Domain.Models;
using RC.Weather.ThirdParty.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.Weather.Domain.Services
{
	public class DomainCityService : IDomainCityService
	{
		private readonly IModelMapper mapper;
		private readonly IThirdPartyCityService cityService;

		public DomainCityService(
			IModelMapper mapper,
			IThirdPartyCityService cityService)
		{
			this.mapper = mapper;
			this.cityService = cityService;
		}

		public async Task<List<DomainCityModel>> SearchCityAsync(string term)
		{
			var cities = await this.cityService.SearchAsync(term);
			var model = cities.Select(this.mapper.Map<DomainCityModel>).ToList();

			return model;
		}
	}
}
