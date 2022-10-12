using FluentValidation;
using Fluent.Validation.API.Models;

namespace Fluent.Validation.API.Validations;

public class UsersValidation : AbstractValidator<User>
{
    public UsersValidation()
    {
        RuleFor(x => x.UserName)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("fieldCantBeEmpty")
            .MinimumLength(5)
                .WithMessage("shortField")
            .MaximumLength(50)
                .WithMessage("longField");

        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("fieldCantBeEmpty")
            .EmailAddress()
                .WithMessage("invalidMail");

        RuleFor(x => x.ConfirmEmail)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("fieldCantBeEmpty")
            .EmailAddress()
                .WithMessage("invalidMail")
            .When(w => !w.Email.Equals(w.ConfirmEmail))
                .WithMessage("mailsDontMatch");

        RuleFor(x => x.Age)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("fieldCantBeEmpty")
            .LessThanOrEqualTo(0)
                .WithMessage("ageCantBeZero")
            .GreaterThan(100)
                .WithMessage("youLie");

        RuleFor(x => x.Phones)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("listCantBeEmpty")
            .Must((User model, List<string> value, ValidationContext<User> context) =>
            {
                if (value.Any(a => string.IsNullOrEmpty(a)))
                    context.AddFailure("somePhonesAreEmpty");

                return true;
            });
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("fieldCantBeEmpty")
            .EmailAddress()
                .WithMessage("invalidMail");

        RuleFor(x => x.ConfirmEmail)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("fieldCantBeEmpty")
            .EmailAddress()
                .WithMessage("invalidMail")
            .When(w => !w.Email.Equals(w.ConfirmEmail))
                .WithMessage("mailsDontMatch");

        RuleFor(x => x.Age)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("fieldCantBeEmpty")
            .LessThanOrEqualTo(0)
                .WithMessage("ageCantBeZero")
            .GreaterThan(100)
                .WithMessage("youLie");

        RuleFor(x => x.Phones)
            .Cascade(CascadeMode.Continue)
            .NotNull()
                .WithMessage("requiredField")
            .NotEmpty()
                .WithMessage("listCantBeEmpty")
            .Must((User model, List<string> value, ValidationContext<User> context) =>
            {
                if (value.Any(a => string.IsNullOrEmpty(a)))
                    context.AddFailure("somePhonesAreEmpty");

                return true;
            });
    }
}
