using Microsoft.Extensions.DependencyInjection;

namespace SuperTrader.Core;

public interface ICoreModule
{
    void Load(IServiceCollection collection);
}