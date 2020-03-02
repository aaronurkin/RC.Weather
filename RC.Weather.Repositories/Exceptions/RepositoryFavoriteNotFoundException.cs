using System;

namespace RC.Weather.Repositories.Exceptions
{
	public class RepositoryFavoriteNotFoundException : Exception
	{
		public RepositoryFavoriteNotFoundException(string cityCode)
			: this(cityCode, null)
		{
		}
		public RepositoryFavoriteNotFoundException(string cityCode, Exception innerException)
			: base($"Favorite with code {cityCode} was not found", innerException)
		{
		}
	}
}
