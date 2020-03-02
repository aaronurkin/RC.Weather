using Microsoft.EntityFrameworkCore;
using RC.Weather.Repositories.Exceptions;
using RC.Weather.Repositories.Models;
using System.Linq;

namespace RC.Weather.Repositories.EntityFramework
{
	public class FavoritesEntityFrameworkRepository : IFavoritesRepository
	{
		private readonly ApplicationDbContext dbContext;

		public FavoritesEntityFrameworkRepository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public FavoriteCityDbModel Create(FavoriteCityDbModel favorite)
		{
			var created = this.dbContext.Favorites.Add(favorite);
			this.dbContext.SaveChanges();
			return created.Entity;
		}

		public void Delete(string cityCode)
		{

			var favorite = this.dbContext.Favorites.FirstOrDefault(f => f.CityCode == cityCode);

			if (favorite == null)
			{
				throw new RepositoryFavoriteNotFoundException(cityCode);
			}

			this.dbContext.Favorites.Remove(favorite);
			this.dbContext.SaveChanges();
		}

		public FavoriteCityDbModel GetSingle(string cityCode)
		{
			var favorite = this.dbContext.Favorites.AsNoTracking().FirstOrDefault(f => f.CityCode == cityCode);
			return favorite;
		}
	}
}
