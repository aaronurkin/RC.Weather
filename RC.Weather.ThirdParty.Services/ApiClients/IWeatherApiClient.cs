using System.Threading.Tasks;

namespace RC.Weather.ThirdParty.Services.ApiClients
{
	public interface IWeatherApiClient
	{
		Task<TResponseContent> GetAsync<TResponseContent>(string endpoint) where TResponseContent : class;
	}
}
