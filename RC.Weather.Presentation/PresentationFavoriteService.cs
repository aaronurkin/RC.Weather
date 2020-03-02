using Microsoft.Extensions.Logging;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Application.Services;
using RC.Weather.Common.Mapper;
using RC.Weather.Presentation.Models;
using RC.Weather.Presentation.Models.Requests;
using RC.Weather.Presentation.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RC.Weather.Presentation
{
	public class PresentationFavoriteService : IPresentationFavoriteService
	{
		private readonly ILogger logger;
		private readonly IModelMapper mapper;
		private readonly IApplicationFavoriteService favoriteService;

		public PresentationFavoriteService(
			IModelMapper mapper,
			IApplicationFavoriteService favoriteService,
			ILogger<PresentationFavoriteService> logger)
		{
			this.logger = logger;
			this.mapper = mapper;
			this.favoriteService = favoriteService;
		}

		public ApiResponse Create(PresentationAddFavoriteRequest request)
		{
			ApiResponse response;

			try
			{
				var favorite = this.mapper.Map<ApplicationCreateFavoriteRequest>(request);
				this.favoriteService.Create(favorite);
				response = new ApiResponse(HttpStatusCode.OK);
			}
			catch (Exception exception)
			{
				this.logger.LogError(exception, $"Failed creating {request.CityName} (with code: {request.CityCode}) favorite cities");
				response = new ApiResponse(HttpStatusCode.InternalServerError);
			}

			return response;
		}

		public ApiResponse Delete(object cityCode)
		{
			ApiResponse response;

			try
			{
				this.favoriteService.Delete(cityCode);
				response = new ApiResponse(HttpStatusCode.OK);
			}
			catch (Exception exception)
			{
				this.logger.LogError(exception, $"Failed deleting favorite city with {cityCode}");
				response = new ApiResponse(HttpStatusCode.InternalServerError);
			}

			return response;
		}

		public ApiResponse<List<PresentationCityResponse>> Get()
		{
			ApiResponse<List<PresentationCityResponse>> response;

			try
			{
				var favorites = this.favoriteService.GetList();
				var result = favorites.Data.Select(this.mapper.Map<PresentationCityResponse>).ToList();
				response = new ApiResponse<List<PresentationCityResponse>>(result, HttpStatusCode.OK);
			}
			catch (Exception exception)
			{
				this.logger.LogError(exception, "Failed retrieving favorite cities");
				response = new ApiResponse<List<PresentationCityResponse>>(HttpStatusCode.InternalServerError);
			}

			return response;
		}
	}
}
