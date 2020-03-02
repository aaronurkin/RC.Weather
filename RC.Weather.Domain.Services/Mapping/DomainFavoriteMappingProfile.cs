using AutoMapper;
using RC.Weather.Domain.Models;
using RC.Weather.Repositories.Models;

namespace RC.Weather.Domain.Services.Mapping
{
	public class DomainFavoriteMappingProfile : Profile
	{
		public DomainFavoriteMappingProfile()
		{
			CreateMap<DomainCityModel, FavoriteCityDbModel>()
				.ForMember(db => db.Id, o => o.Ignore())
				.ForMember(db => db.CityCode, o => o.MapFrom(domain => domain.Code))
				.ForMember(db => db.CityName, o => o.MapFrom(domain => domain.Name))
				.ReverseMap();
		}
	}
}
