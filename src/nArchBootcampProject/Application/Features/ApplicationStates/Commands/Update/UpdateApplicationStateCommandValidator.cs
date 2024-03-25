using FluentValidation;

namespace Application.Features.ApplicationStates.Commands.Update;

public class UpdateApplicationStateCommandValidator : AbstractValidator<UpdateApplicationStateCommand>
{
    public UpdateApplicationStateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}