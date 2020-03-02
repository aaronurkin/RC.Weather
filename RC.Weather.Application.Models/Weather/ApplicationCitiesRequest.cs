namespace RC.Weather.Application.Models.Weather
{
	public class ApplicationCitiesRequest
	{
		public int Page { get; set; }

		public int PageSize { get; set; }

		public string Term { get; set; }
	}
}
