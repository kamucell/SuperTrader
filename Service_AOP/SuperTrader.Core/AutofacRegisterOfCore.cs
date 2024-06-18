using System;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using SuperTrader.Core.Sender;
using SuperTrader.Core.Sender.SendEmail;
using SuperTrader.Core.Sender.SendSMS;

namespace SuperTrader.Core
{
    public class AutofacRegisterOfCore : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Email>().Named<ISend>(EnumSenderType.Email.ToString());
            builder.RegisterType<Sms>().Named<ISend>(EnumSenderType.SMS.ToString());

            builder.Register<Func<EnumSenderType, ISend>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return namedService =>
                {
                    return context.ResolveNamed<ISend>(namedService.ToString());
                };
            });

        }

    }
}
