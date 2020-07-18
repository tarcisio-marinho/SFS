using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Boundaries.UploadFile
{
    public class UploadFileValidator : AbstractValidator<UploadFileInput>
    {
        public UploadFileValidator()
        {
            RuleFor(i => i.HashPassword)
                    .NotEmpty()
                    .WithMessage($"The {nameof(UploadFileInput.File)} field is required.")
                    .Length(64)
                    .WithMessage($"Hash password must be a size 64")
                    .Matches("[A-Fa-f0-9]{64}")
                    .WithMessage("Hash password must be a SHA256.");

            RuleFor(i => i.File.Length)
                .NotNull()
                .LessThanOrEqualTo(100 * 1024 * 1024)
                .WithMessage("File size is larger than 100MB");
        }
    }
}
