using System.Net;

namespace RC.Weather.Presentation.Models
{
	public class ApiResponse<TData>
	{
		public ApiResponse(TData data)
			: this(data, HttpStatusCode.OK)
		{
		}

		public ApiResponse(HttpStatusCode httpStatusCode)
			: this(default(TData), HttpStatusCode.OK)
		{
		}

		public ApiResponse(TData data, HttpStatusCode httpStatusCode)
		{
			this.Data = data;
			this.HttpStatusCode = httpStatusCode;
		}

		public TData Data { get; }

		public HttpStatusCode HttpStatusCode { get; }
	}
}
