using Domain.HttpServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class HttpService : IHttpService
    {
        public async Task<TResponse> GetResultAsync<TResponse>(HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(result);
        }
    }
}