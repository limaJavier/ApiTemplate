using FluentValidation;

namespace ApiTemplate.Application.Features.Items.Queries.GetItems;

public class GetItemsQueryValidator : AbstractValidator<GetItemsQuery>
{
    public GetItemsQueryValidator()
    {
        RuleFor(x => x.Count).GreaterThan(0);
        RuleFor(x => x.Count).LessThanOrEqualTo(10);
    }
}