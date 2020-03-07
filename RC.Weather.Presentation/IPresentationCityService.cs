using RC.Weather.Presentation.Models;
using RC.Weather.Presentation.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RC.Weather.Presentation
{
	public interface IPresentationCityService
	{
		Task<ApiResponse<List<PresentationCityModel>>> SearchCityAsync(PresentationCitiesListRequest requestDto);
	}
}
