using SuperTraderService.User.Abstract;
using SuperTrader.Core.Results;
using SuperTraderService.User.DTOs;
using Data.Repository.Abstract;
using Azure.Core;
using SuperTrader.Core.Security.JWT;
using SuperTrader.Core.Validation;
using SuperTraderService.User.Validation;

namespace SuperTraderService.User
{
    public class ServiceUser : IServiceUser
    {
        private   IRpUser _rpUser;
        private   ITokenHelper _tokenHelper;

        public ServiceUser(IRpUser rpUser,ITokenHelper tokenHelper)
        {
            _rpUser = rpUser;
            _tokenHelper = tokenHelper;
        }

        [ValidationAspect(typeof(UserLoginValidator), Priority = 1)]
        public async Task<IResult> Login(UserLoginDTOs user)
        {
            var usr = await _rpUser.GetAsync(f => f.Email == user.Email);
            if (usr is not null && usr.Pwd==user.Pwd)
            {

                // Comment the following line because i  ignore the password hashing and salting
                //if (SuperTrader.Core.Security.PasswordHashingHmacsha512.VerifyPassword(user.Pwd, itm.Result.Pwd))
                
                {
                    var token = _tokenHelper.CreateToken(usr.FullName, usr.Email, usr.Id, usr.UserType);
                    return new SuccessDataResult<SuperTrader.Core.Security.JWT.AccessToken>(token, "TokenCreated");
                }
            }
            // the error message  with code because of localization
            return new ErrorResult("UserNotFound");

        }
    }
}
