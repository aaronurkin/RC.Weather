using AutoMapper;
using RC.Weather.Domain.Models;
using RC.Weather.ThirdParty.Models;

namespace RC.Weather.Domain.Services.Mapping
{
	public class WeatherMappingProfile : Profile
	{
		public WeatherMappingProfile()
		{
			CreateMap<ThirdPartyWeatherApiResponse, DomainWeatherModel>()
				.ForMember(weatherModel => weatherModel.IsFavorite, o => o.Ignore())
				.ForMember(weatherModel => weatherModel.WeatherText, o => o.MapFrom(thirdParty => thirdParty.Text))
				.ForMember(weatherModel => weatherModel.Temperature, o => o.MapFrom(thirdParty => thirdParty.Temperature));
		}
	}
}
