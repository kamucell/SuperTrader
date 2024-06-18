using System.Threading.Tasks;
using SuperTrader.Core.Results;

namespace SuperTrader.Core.Event
{
    public interface IEvent
    {
        Task<IResult> Execute();
    }
}
