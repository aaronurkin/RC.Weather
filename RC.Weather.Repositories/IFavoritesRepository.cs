using RC.Weather.Repositories.Models;
using System.Collections.Generic;

namespace RC.Weather.Repositories
{
	public interface IFavoritesRepository
	{
		FavoriteCityDbModel Create(FavoriteCityDbModel favorite);

		FavoriteCityDbModel GetSingle(string cityCode);

		List<FavoriteCityDbModel> GetList();

		void Delete(string cityCode);
	}
}
