using AlphaVantage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;

namespace Process_Homebroker.HttpClients
{
    public static class HttpClientFactoryBuilder
    {
        public static void ConfigureHttpClientAlphaVantage(this IServiceCollection services)
        {
            var baseUrl = Startup.Configuration.GetValue<string>("AlphaVantage:BaseRequest");
            var timeout = Startup.Configuration.GetValue<int>("AlphaVantage:TimeoutRequest");

            services
                .AddHttpClient<AcaoService>(client =>
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Add("Content", "Request");
                    client.Timeout = TimeSpan.FromSeconds(timeout);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                    new HttpClientHandler
                    {
                        SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls
                    })
                .AddHttpMessageHandler<HttpClientDelegatingHandler>();
        }
    }
}