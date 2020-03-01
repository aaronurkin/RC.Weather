using AutoMapper;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Presentation.Models.Responses;

namespace RC.Weather.Presentation.Mapping
{
	public class WeatherMappingProfile : Profile
	{
		public WeatherMappingProfile()
		{
			CreateMap<ApplicationWeatherModel, PresentationWeatherResponse>()
				.ForMember(response => response.Text, o => o.MapFrom(app => app.WeatherText));
		}
	}
}
