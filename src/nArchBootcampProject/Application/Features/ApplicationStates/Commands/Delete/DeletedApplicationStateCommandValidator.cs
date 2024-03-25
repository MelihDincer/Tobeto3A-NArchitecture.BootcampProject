using FluentValidation;

namespace Application.Features.ApplicationStates.Commands.Delete;

public class DeleteApplicationStateCommandValidator : AbstractValidator<DeleteApplicationStateCommand>
{
    public DeleteApplicationStateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}