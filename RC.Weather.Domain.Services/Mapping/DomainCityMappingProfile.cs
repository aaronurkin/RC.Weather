using AutoMapper;
using RC.Weather.Domain.Models;
using RC.Weather.Repositories.Models;
using RC.Weather.ThirdParty.Models;

namespace RC.Weather.Domain.Services.Mapping
{
	public class DomainCityMappingProfile : Profile
	{
		public DomainCityMappingProfile()
		{
			CreateMap<ThirdPartyCityApiResponse, DomainCityModel>()
				.ForMember(cityModel => cityModel.Code, o => o.MapFrom(thirdParty => thirdParty.CityCode))
				.ForMember(cityModel => cityModel.Name, o => o.MapFrom(thirdParty => thirdParty.CityName));
		}
	}
}
