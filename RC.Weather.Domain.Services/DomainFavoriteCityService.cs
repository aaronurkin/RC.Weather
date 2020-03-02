using RC.Weather.Common.Mapper;
using RC.Weather.Domain.Models;
using RC.Weather.Repositories;
using RC.Weather.Repositories.Models;
using System.Collections.Generic;
using System.Linq;

namespace RC.Weather.Domain.Services
{
	public class DomainFavoriteCityService : IDomainFavoriteCityService
	{
		private readonly IModelMapper mapper;
		private readonly IDatabaseUnit database;

		public DomainFavoriteCityService(
			IModelMapper mapper,
			IDatabaseUnit database)
		{
			this.mapper = mapper;
			this.database = database;
		}

		public List<DomainCityModel> GetList()
		{
			var favorites = this.database.Favorites.GetList();
			var result = favorites.Select(this.mapper.Map<DomainCityModel>).ToList();

			return result;
		}

		public void Create(DomainCityModel model)
		{
			var favorite = this.mapper.Map<FavoriteCityDbModel>(model);
			this.database.Favorites.Create(favorite);
		}

		public void Delete(object cityCode)
		{
			this.database.Favorites.Delete($"{cityCode}");
		}
	}
}
