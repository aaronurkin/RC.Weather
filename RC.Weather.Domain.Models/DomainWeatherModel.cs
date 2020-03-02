namespace RC.Weather.Domain.Models
{
	public class DomainWeatherModel
	{
		public string WeatherText { get; set; }

		public double Temperature { get; set; }

		public bool IsFavorite { get; set; }
	}
}
