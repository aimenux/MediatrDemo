using FluentValidation;

namespace MediatrDemo.Application.UseCases.GetPersonById;

public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQuery>
{
    public GetPersonByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty.")
            .Must(IsValidGuid).WithMessage("{PropertyName} is not valid.");
    }

    private static bool IsValidGuid(string id)
    {
        return Guid.TryParse(id, out var guid) && guid != default;
    }
}
