using Autofac;
using Domain.Segurancas;
using Domain.Usuarios;

namespace Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<SegurancaService>().As<ISegurancaService>().InstancePerLifetimeScope();
            builder.RegisterType<UsuarioService>().As<IUsuarioService>().InstancePerLifetimeScope();
        }
    }
}