using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraderService.Share.DTOs.Validation
{
    public class ShareDtoValidator : AbstractValidator<ShareDto>
    {

        public ShareDtoValidator()
        {
            RuleFor(o => o.Code).NotEmpty();
            RuleFor(o => o.Code).Length(3);
            RuleFor(o => o.Code).Must((code )=> code.All(char.IsUpper) && code.All(char.IsLetter)).WithErrorCode("Share code must 3 letter and upper case");

            RuleFor(o => o.Name).NotEmpty().Length(0, 20);
            RuleFor(o => o.Quantity).NotEmpty().GreaterThan(0);

        }

        
    }
}
