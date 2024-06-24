

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Data.Repository;

public static  class RegisterDataRepository 
{
      public static IServiceCollection AddRepositoryService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<Data.Repository.Abstract.IRpUser, Data.Repository.RpUser>();
        services.AddScoped<Data.Repository.Abstract.IRpPortfolio, Data.Repository.RpPortfolio>();
        services.AddScoped<Data.Repository.Abstract.IRpShareOwner, Data.Repository.RpShareOwner>();
        services.AddScoped<Data.Repository.Abstract.IRpTransaction, Data.Repository.RpTransaction>();
        services.AddScoped<Data.Repository.Abstract.IRpSharePriceDetail, Data.Repository.RpSharePriceDetail>();
        return services;
    }
}