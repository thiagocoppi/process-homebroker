using System.Net.Http;
using System.Threading.Tasks;

namespace Domain.HttpServices
{
    public interface IHttpService
    {
        Task<TResponse> GetResultAsync<TResponse>(HttpClient httpClient, string url);
    }
}