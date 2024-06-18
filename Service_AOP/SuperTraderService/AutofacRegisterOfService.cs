using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using SuperTrader.Core.AOF;
using SuperTrader.Core.Security.JWT;
using SuperTraderService.Portfolio;
using SuperTraderService.Portfolio.Abstract;
using SuperTraderService.Share;
using SuperTraderService.Share.Abstract;
using SuperTraderService.Share.Rules;
using SuperTraderService.Share.Rules.Abstract;
using SuperTraderService.Transaction;
using SuperTraderService.Transaction.Abstract;
using SuperTraderService.User;
using SuperTraderService.User.Abstract;

namespace SuperTraderService
{
    public class AutofacRegisterOfService : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ShareRule>().As<IShareRule>();

            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            builder.RegisterType<ServiceShare>().As<IServiceShare>();
            builder.RegisterType<ServiceTransaction>().As<IServiceTransaction>();
            builder.RegisterType<ServicePortfolio>().As<IServicePortfolio>();
            
            builder.RegisterType<JwtProvider>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();



        }
    }
}
