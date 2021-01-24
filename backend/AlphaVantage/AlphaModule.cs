using Autofac;
using Domain.Acoes;

namespace AlphaVantage
{
    public class AlphaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AcaoService>().As<IAcaoService>().InstancePerLifetimeScope();
        }
    }
}