using RC.Weather.Presentation.Models;
using RC.Weather.Presentation.Models.Requests;
using RC.Weather.Presentation.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.Weather.Presentation
{
	public interface IPresentationCityService
	{
		Task<ApiResponse<List<PresentationCityResponse>>> SearchCityAsync(PresentationCitiesListRequest requestDto);
	}
}
