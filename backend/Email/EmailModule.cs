using Autofac;
using Domain.Emails;

namespace Email
{
    public class EmailModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<EmailService>().As<IEmailService>().InstancePerLifetimeScope();
        }
    }
}