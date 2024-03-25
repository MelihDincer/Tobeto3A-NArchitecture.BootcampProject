using FluentValidation;

namespace Application.Features.ApplicationStates.Commands.Create;

public class CreateApplicationStateCommandValidator : AbstractValidator<CreateApplicationStateCommand>
{
    public CreateApplicationStateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}