namespace RC.Weather.Application.Models
{
	public class ApplicationServiceResult<TData>
	{
		public ApplicationServiceResult(TData data)
		{
			this.Data = data;
		}

		public TData Data { get; set; }
	}
}
