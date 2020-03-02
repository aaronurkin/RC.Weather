namespace RC.Weather.Application.Models
{
	public class ApplicationServiceResult
	{
		public ApplicationServiceResult(bool succeeded)
		{
			this.Succeeded = succeeded;
		}

		public bool Succeeded { get; }
	}

	public class ApplicationServiceResult<TData> : ApplicationServiceResult
	{
		public ApplicationServiceResult(TData data)
			: this(data, true)
		{
		}

		public ApplicationServiceResult(TData data, bool succeeded)
			: base(succeeded)
		{
			this.Data = data;
		}

		public TData Data { get; }
	}
}
