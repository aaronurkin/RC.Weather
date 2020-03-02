using AutoMapper;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Domain.Models;
using RC.Weather.Presentation.Models.Requests;

namespace RC.Weather.Presentation.Mapping
{
	public class PresentationFavoriteCityMappingProfile : Profile
	{
		public PresentationFavoriteCityMappingProfile()
		{
			CreateMap<PresentationAddFavoriteRequest, ApplicationCreateFavoriteRequest>().ReverseMap();

			CreateMap<ApplicationCreateFavoriteRequest, DomainCityModel>()
				.ForMember(d => d.Code, o => o.MapFrom(app => app.CityCode))
				.ForMember(d => d.Name, o => o.MapFrom(app => app.CityName));
		}
	}
}
