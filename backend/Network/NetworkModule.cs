using Autofac;
using Domain.HttpServices;

namespace Network
{
    public class NetworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<HttpService>().As<IHttpService>().InstancePerLifetimeScope();
        }
    }
}