using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFS.Application.Boundaries.DownloadFile
{
    public class DownloadFileValidator : AbstractValidator<DownloadFileInput>
    {
        public DownloadFileValidator()
        {
            RuleFor(input => input.HashPassword)
                .NotEmpty()
                .NotNull()
                .WithMessage($"The HashPassword missing")
                .Length(64)
                .WithMessage($"Hash password must be a size 64")
                .Matches("[A-Fa-f0-9]{64}")
                .WithMessage("Hash password must be a SHA256.");

            RuleFor(i => i.Identificator)
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
