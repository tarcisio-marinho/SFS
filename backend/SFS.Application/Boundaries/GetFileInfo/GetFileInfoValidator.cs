using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SFS.Application.Boundaries.GetFileInfo
{
    public class GetFileInfoValidator : AbstractValidator<string>
    {
        public GetFileInfoValidator()
        {
            RuleFor(i => i)
                .NotEmpty()
                .NotNull()
                .WithMessage($"Identifier missing")
                .Length(12)
                .WithMessage($"Identifier must be a size 12")
                .Matches("[0-9A-F]{12}")
                .WithMessage("Identifier with wrong format");
        }
    }
}
