using AutoMapper;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Domain.Models;
using RC.Weather.Presentation.Models;

namespace RC.Weather.Presentation.Mapping
{
	public class PresentationFavoriteCityMappingProfile : Profile
	{
		public PresentationFavoriteCityMappingProfile()
		{
			CreateMap<PresentationCityModel, ApplicationCreateFavoriteRequest>()
				.ForMember(app => app.CityCode, o => o.MapFrom(p => p.Code))
				.ForMember(app => app.CityName, o => o.MapFrom(p => p.Name));

			CreateMap<ApplicationCreateFavoriteRequest, DomainCityModel>()
				.ForMember(d => d.Code, o => o.MapFrom(app => app.CityCode))
				.ForMember(d => d.Name, o => o.MapFrom(app => app.CityName));
		}
	}
}
