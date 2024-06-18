using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperTraderService.User.Abstract;
using SuperTraderService.User.DTOs;
using IResult = SuperTrader.Core.Results.IResult;

namespace SuperTrader.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private   IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }
        [HttpPost(Name = "Login")]
        public async  Task<IResult> Login(UserLoginDTOs data)
        {
            var tkn = await _serviceUser.Login(data);
            return tkn;
        }
    }
}
