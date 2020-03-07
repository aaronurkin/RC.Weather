using AutoMapper;
using RC.Weather.Application.Models.Weather;
using RC.Weather.Presentation.Models;

namespace RC.Weather.Presentation.Mapping
{
	public class PresentationCityMappingProfile : Profile
	{
		public PresentationCityMappingProfile()
		{
			CreateMap<ApplicationCityModel, PresentationCityModel>().ReverseMap();
		}
	}
}
