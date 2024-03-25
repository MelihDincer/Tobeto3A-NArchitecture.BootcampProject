using FluentValidation;

namespace Application.Features.BlackLists.Commands.Delete;

public class DeleteBlackListCommandValidator : AbstractValidator<DeleteBlackListCommand>
{
    public DeleteBlackListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}