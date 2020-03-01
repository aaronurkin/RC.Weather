namespace RC.Weather.Application.Models.Weather
{
    public class ApplicationWeatherModel
    {
        public string CityName { get; set; }

        public double Temperature { get; set; }

        public string WeatherText { get; set; }

        public bool IsFavorite { get; set; }
	}
}
