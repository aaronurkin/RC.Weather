using RC.Weather.ThirdParty.Services.ApiClients;
using System.Net.Http;
using System.Threading.Tasks;

namespace RC.Weather.ThirdParty.Services.Weather.AccuWeather
{
    public class AccuWeatherApiClient : IWeatherApiClient
    {
        private readonly HttpClient client;

        public AccuWeatherApiClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<TResponseContent> GetAsync<TResponseContent>(string endpoint) where TResponseContent : class
        {
            var response = (await this.client.GetAsync(endpoint)).EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsAsync<TResponseContent>();

            return content;
        }
    }
}