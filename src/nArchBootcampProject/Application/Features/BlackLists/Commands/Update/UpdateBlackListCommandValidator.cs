using FluentValidation;

namespace Application.Features.BlackLists.Commands.Update;

public class UpdateBlackListCommandValidator : AbstractValidator<UpdateBlackListCommand>
{
    public UpdateBlackListCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ApplicantId).NotEmpty();
        RuleFor(c => c.Reason).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
    }
}