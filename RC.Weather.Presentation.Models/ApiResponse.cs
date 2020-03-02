using System.Net;

namespace RC.Weather.Presentation.Models
{
	public class ApiResponse
	{
		public ApiResponse(HttpStatusCode httpStatusCode)
		{
			this.HttpStatusCode = httpStatusCode;
		}

		public HttpStatusCode HttpStatusCode { get; }
	}

	public class ApiResponse<TData> : ApiResponse
	{
		public ApiResponse(TData data)
			: this(data, HttpStatusCode.OK)
		{
		}

		public ApiResponse(HttpStatusCode httpStatusCode)
			: base(httpStatusCode)
		{
		}

		public ApiResponse(TData data, HttpStatusCode httpStatusCode)
			: base(httpStatusCode)
		{
			this.Data = data;
		}

		public TData Data { get; }
	}
}
