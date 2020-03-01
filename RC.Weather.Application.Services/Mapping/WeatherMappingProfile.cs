using AutoMapper;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Domain.Models;

namespace RC.Weather.Application.Services.Mapping
{
	public class WeatherMappingProfile : Profile
	{
		public WeatherMappingProfile()
		{
			CreateMap<DomainWeatherModel, ApplicationWeatherModel>()
				.ForMember(app => app.CityName, o => o.MapFrom(domain => domain.CityName))
				.ForMember(app => app.IsFavorite, o => o.MapFrom(domain => domain.IsFavorite))
				.ForMember(app => app.Temperature, o => o.MapFrom(domain => domain.Temperature))
				.ForMember(app => app.WeatherText, o => o.MapFrom(domain => domain.WeatherText));
		}
	}
}
