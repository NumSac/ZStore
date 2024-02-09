using FluentValidation;

namespace ZStore.Application.Api.Cart.Queries.GetShoppingCart
{
    public class GetShoppingCartQueryValidator : AbstractValidator<GetShoppingCartQuery>
    {
        public GetShoppingCartQueryValidator() 
        { 
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("A cart uid must be provided");

            RuleFor(x => x.PageNumber)
                 .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
