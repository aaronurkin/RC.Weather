using Newtonsoft.Json;
using RC.Weather.ThirdParty.Models.AccuWeather;
using RC.Weather.ThirdParty.Services.ApiClients;
using System.Net;
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
            var data = await response.Content.ReadAsAsync<AccuWeatherApiResponse>();
            var content = WebUtility.UrlDecode(data.ResponseContent);
            var responseContent = JsonConvert.DeserializeObject<TResponseContent>(content);

            return responseContent;
        }
    }
}