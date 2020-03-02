using RC.Weather.Repositories.Models;

namespace RC.Weather.Repositories
{
	public interface IFavoritesRepository
	{
		FavoriteCityDbModel Create(FavoriteCityDbModel favorite);

		FavoriteCityDbModel GetSingle(string cityCode);

		void Delete(string cityCode);
	}
}
