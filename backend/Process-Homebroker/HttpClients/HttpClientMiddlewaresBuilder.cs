using Microsoft.Extensions.DependencyInjection;

namespace Process_Homebroker.HttpClients
{
    public static class HttpClientMiddlewaresBuilder
    {
        public static void ConfigureHttpClientMiddlewares(this IServiceCollection services)
        {
            services.AddTransient<HttpClientDelegatingHandler>();
        }
    }
}