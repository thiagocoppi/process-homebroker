using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Process_Homebroker.HttpClients
{
    public class HttpClientDelegatingHandler : DelegatingHandler
    {
        private readonly Stopwatch _stopWatch;
        private readonly ILogger<HttpClientDelegatingHandler> _logger;

        public HttpClientDelegatingHandler(ILogger<HttpClientDelegatingHandler> logger)
        {
            _stopWatch = new Stopwatch();
            _logger = logger;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando a requisção a URL {0}",
                   request.RequestUri?.ToString());
            _stopWatch.Start();

            var response = base.SendAsync(request, cancellationToken);
            
            _stopWatch.Stop();
            _logger.LogInformation("Finalizando a requisção a URL {0} | Tempo total de execução foi de {1} milisegundos", 
                request.RequestUri?.ToString(), _stopWatch.ElapsedMilliseconds);

            return response;


        }
    }
}