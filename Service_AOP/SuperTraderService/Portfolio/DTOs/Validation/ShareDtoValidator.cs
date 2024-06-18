using FluentValidation;
using SuperTraderService.Share.DTOs;

namespace SuperTraderService.Portfolio.DTOs.Validation
{
    public class SaleSharesDtoValidator : AbstractValidator<SaleSharesDto>
    {

        public SaleSharesDtoValidator()
        {
            RuleFor(o => o.ShareId).NotEmpty();
            RuleFor(o => o.Amount).NotEmpty();
        }
    }
}
