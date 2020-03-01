namespace RC.Weather.Presentation.Models.Responses
{
	public class PresentationWeatherResponse
	{
		public string CityName { get; set; }

		public double Temperature { get; set; }

		public string Text { get; set; }

		public bool IsFavorite { get; set; }
	}
}
