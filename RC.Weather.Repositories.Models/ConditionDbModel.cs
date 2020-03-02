namespace RC.Weather.Repositories.Models
{
	public class ConditionDbModel
	{
		public int Id { get; set; }

		public string CityCode { get; set; }

		public double Temperature { get; set; }

		public string WeatherText { get; set; }
	}
}
