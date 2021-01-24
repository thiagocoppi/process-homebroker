using Autofac;
using Domain.Lancamentos;
using Domain.Ordens;
using Domain.Saldos;
using Domain.Usuarios;
using Infraestrutura.Context;
using Infraestrutura.EntityStore;
using Infraestrutura.QueryStore.Saldos;

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
            builder.RegisterType<SaldoStore>().As<ISaldoStore>().InstancePerLifetimeScope();
            builder.RegisterType<SaldoQueryStore>().As<ISaldoQueryStore>().InstancePerLifetimeScope();
            builder.RegisterType<LancamentoStore>().As<ILancamentoStore>().InstancePerLifetimeScope();
        }
    }
}