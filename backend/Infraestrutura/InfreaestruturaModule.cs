using Autofac;
using Domain.Ordens;
using Domain.Usuarios;
using Infraestrutura.Context;
using Infraestrutura.EntityStore;

namespace Infraestrutura
{
    public sealed class InfreaestruturaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ProcessContext>().As<IProcessContext>().SingleInstance();
            builder.RegisterType<UsuarioStore>().As<IUsuarioStore>().InstancePerLifetimeScope();
            builder.RegisterType<OrdemStore>().As<IOrdemStore>().InstancePerLifetimeScope();
        }
    }
}