using RC.Weather.Application.Models;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Common.Mapper;
using RC.Weather.Domain.Models;
using RC.Weather.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace RC.Weather.Application.Services
{
	public class ApplicationFavoriteService : IApplicationFavoriteService
	{
		private readonly IModelMapper mapper;
		private readonly IDomainFavoriteCityService favoriteService;

		public ApplicationFavoriteService(
			IModelMapper mapper,
			IDomainFavoriteCityService favoriteService)
		{
			this.mapper = mapper;
			this.favoriteService = favoriteService;
		}

		public ApplicationServiceResult<List<ApplicationCityModel>> GetList()
		{
			var favorites = this.favoriteService.GetList();
			var data = favorites.Select(this.mapper.Map<ApplicationCityModel>).ToList();

			return new ApplicationServiceResult<List<ApplicationCityModel>>(data);
		}

		public ApplicationServiceResult Create(ApplicationCreateFavoriteRequest request)
		{
			var favorite = this.mapper.Map<DomainCityModel>(request);
			this.favoriteService.Create(favorite);
			return new ApplicationServiceResult(true);
		}

		public ApplicationServiceResult Delete(object cityCode)
		{
			this.favoriteService.Delete(cityCode);
			return new ApplicationServiceResult(true);
		}
	}
}
