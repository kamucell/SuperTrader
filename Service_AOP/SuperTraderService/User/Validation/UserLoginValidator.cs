using FluentValidation;
using SuperTraderService.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraderService.User.Validation
{
    public class UserLoginValidator : AbstractValidator<UserLoginDTOs>
    {
        public UserLoginValidator()
        {
            RuleFor(o => o.Email).NotEmpty();
            RuleFor(o => o.Email).EmailAddress();
            RuleFor(o => o.Pwd).Length(1, 50);
        }
    }
}
