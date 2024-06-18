using SuperTrader.Core.Results;
using SuperTraderService.User.DTOs;

namespace SuperTraderService.User.Abstract
{
    public interface IServiceUser
    {
        Task<IResult> Login(UserLoginDTOs user);
    }
}
