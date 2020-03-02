namespace RC.Weather.Repositories
{
	public interface IDatabaseUnit
	{
		IFavoritesRepository Favorites { get; }
		IConditionsRepository Conditions { get; }
	}

	public class DatabaseUnit : IDatabaseUnit
	{
		public DatabaseUnit(
			IFavoritesRepository favorites,
			IConditionsRepository conditions)
		{
			this.Favorites = favorites;
			this.Conditions = conditions;
		}

		public IFavoritesRepository Favorites { get; }

		public IConditionsRepository Conditions { get; }
	}
}
