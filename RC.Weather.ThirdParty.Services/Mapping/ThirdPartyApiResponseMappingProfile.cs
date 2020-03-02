using AutoMapper;
using RC.Weather.ThirdParty.Models;
using RC.Weather.ThirdParty.Models.AccuWeather;

namespace RC.Weather.ThirdParty.Services.Mapping
{
	public class ThirdPartyApiResponseMappingProfile : Profile
	{
		public ThirdPartyApiResponseMappingProfile()
		{
			CreateMap<AccuWeatherWeatherApiResponseData, ThirdPartyWeatherApiResponse>()
				.ForMember(target => target.Text, o => o.MapFrom(source => source.WeatherText))
				.ForMember(target => target.Temperature, o => o.MapFrom(source => source.Temperature.Metric.Value));

			CreateMap<AccuWeatherCityApiResponseData, ThirdPartyCityApiResponse>()
				.ForMember(target => target.CityCode, o => o.MapFrom(source => source.Key))
				.ForMember(target => target.CityName, o => o.MapFrom(source => source.LocalizedName));
		}
	}
}
