using Microsoft.Extensions.Logging;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Application.Services;
using RC.Weather.Common.Mapper;
using RC.Weather.Presentation.Models;
using RC.Weather.Presentation.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RC.Weather.Presentation
{
	public class PresentationCityService : IPresentationCityService
	{
		private readonly ILogger logger;
		private readonly IModelMapper mapper;
		private readonly IApplicationCityService cityService;

		public PresentationCityService(
			IModelMapper mapper,
			IApplicationCityService cityService,
			ILogger<PresentationCityService> logger)
		{
			this.logger = logger;
			this.mapper = mapper;
			this.cityService = cityService;
		}

		public async Task<ApiResponse<List<PresentationCityModel>>> SearchCityAsync(PresentationCitiesListRequest requestDto)
		{
			ApiResponse<List<PresentationCityModel>> response;

			try
			{
				var appRequest = this.mapper.Map<ApplicationCitiesRequest>(requestDto);
				var result = await this.cityService.SearchCityAsync(appRequest);
				var data = result.Data?.Select(this.mapper.Map<PresentationCityModel>).ToList();

				response = new ApiResponse<List<PresentationCityModel>>(data);
			}
			catch (Exception exception)
			{
				this.logger.LogError(exception, "Search city failed");
				response = new ApiResponse<List<PresentationCityModel>>(HttpStatusCode.InternalServerError);
			}

			return response;
		}
	}
}
