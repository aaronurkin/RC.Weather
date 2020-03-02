using RC.Weather.Presentation.Models;
using RC.Weather.Presentation.Models.Requests;
using RC.Weather.Presentation.Models.Responses;
using System.Threading.Tasks;

namespace RC.Weather.Presentation
{
	public interface IPresentationWeatherService
	{
		Task<ApiResponse<PresentationWeatherResponse>> GetWeatherAsync(PresentationWeatherRequest requestDto);
	}
}
