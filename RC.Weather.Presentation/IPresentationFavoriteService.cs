using RC.Weather.Presentation.Models;
using System.Collections.Generic;

namespace RC.Weather.Presentation
{
	public interface IPresentationFavoriteService
	{
		ApiResponse<List<PresentationCityModel>> Get();
		ApiResponse Create(PresentationCityModel favorite);
		ApiResponse Delete(object cityCode);
	}
}
