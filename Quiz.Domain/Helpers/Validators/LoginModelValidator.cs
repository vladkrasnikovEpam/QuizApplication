using FluentValidation;
using Quiz.Domain.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Domain.Helpers.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
