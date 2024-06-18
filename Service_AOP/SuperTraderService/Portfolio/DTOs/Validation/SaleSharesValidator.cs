using FluentValidation;
using SuperTraderService.Share.DTOs;

namespace SuperTraderService.Portfolio.DTOs.Validation
{
    public class SaleSharesValidator : AbstractValidator<SaleSharesDto>
    {

        public SaleSharesValidator()
        {
            RuleFor(o => o.ShareId).NotEmpty();
            RuleFor(o => o.Amount).NotEmpty();
        }
    }
}
