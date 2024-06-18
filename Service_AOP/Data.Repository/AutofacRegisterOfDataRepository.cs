using Autofac;

namespace Data.Repository;

public class AutofacRegisterOfDataRepository : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Data.Repository.RpUser>().As<Data.Repository.Abstract.IRpUser>();
        builder.RegisterType<Data.Repository.RpShare>().As<Data.Repository.Abstract.IRpShare>();
        builder.RegisterType<Data.Repository.RpPortfolio>().As<Data.Repository.Abstract.IRpPortfolio>();
        builder.RegisterType<Data.Repository.RpShareOwner>().As<Data.Repository.Abstract.IRpShareOwner>();
        builder.RegisterType<Data.Repository.RpTransaction>().As<Data.Repository.Abstract.IRpTransaction>();
        builder.RegisterType<Data.Repository.RpSharePriceDetail>().As<Data.Repository.Abstract.IRpSharePriceDetail>();

    }
}