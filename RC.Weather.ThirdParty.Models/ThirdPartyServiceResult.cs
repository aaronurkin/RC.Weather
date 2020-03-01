namespace RC.Weather.ThirdParty.Models
{
	public class ThirdPartyServiceResult<TData> where TData : class
	{
		public TData Data { get; set; }
	}
}
