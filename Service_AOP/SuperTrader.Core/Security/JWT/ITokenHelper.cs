using System.Collections.Generic;
using System.Security.Claims;

namespace SuperTrader.Core.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(string fullName, string email,int userId, int userType);
        ClaimsPrincipal ValidateToken(string token);
    }
}
