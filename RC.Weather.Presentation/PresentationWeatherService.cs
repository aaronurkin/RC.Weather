using Microsoft.Extensions.Logging;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Application.Services;
using RC.Weather.Common.Mapper;
using RC.Weather.Presentation.Models;
using RC.Weather.Presentation.Models.Requests;
using RC.Weather.Presentation.Models.Responses;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RC.Weather.Presentation
{
	public class PresentationWeatherService : IPresentationWeatherService
	{
		private readonly ILogger logger;
		private readonly IModelMapper mapper;
		private readonly IApplicationWeatherService weatherService;

		public PresentationWeatherService(
			IModelMapper mapper,
			IApplicationWeatherService weatherService,
			ILogger<PresentationWeatherService> logger)
		{
			this.logger = logger;
			this.mapper = mapper;
			this.weatherService = weatherService;
		}

		public async Task<ApiResponse<PresentationWeatherResponse>> GetWeatherAsync(PresentationWeatherRequest requestDto)
		{
			ApiResponse<PresentationWeatherResponse> response;

			try
			{
				var filter = this.mapper.Map<ApplicationWeatherRequest>(requestDto);
				var result = await this.weatherService.GetWeatherAsync(filter);
				var data = this.mapper.Map<PresentationWeatherResponse>(result.Data);

				response = new ApiResponse<PresentationWeatherResponse>(data);
			}
			catch (Exception exception)
			{
				this.logger.LogError(exception, "Get weather failed");
				response = new ApiResponse<PresentationWeatherResponse>(HttpStatusCode.InternalServerError);
			}

			return response;
		}
	}
}
