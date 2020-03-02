using RC.Weather.Presentation.Models;
using RC.Weather.Presentation.Models.Requests;
using RC.Weather.Presentation.Models.Responses;
using System.Collections.Generic;

namespace RC.Weather.Presentation
{
	public interface IPresentationFavoriteService
	{
		ApiResponse<List<PresentationCityResponse>> Get();
		ApiResponse Create(PresentationAddFavoriteRequest favorite);
		ApiResponse Delete(object cityCode);
	}
}
