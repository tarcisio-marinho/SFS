using Application.Boundaries.UploadFile;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UploadFileInteractor : IUploadFileUseCase
    {
        private readonly IValidator<UploadFileInput> validator;
        private readonly IUploadFileOutputPorts UploadFileOutputPorts;

        public UploadFileInteractor(IValidator<UploadFileInput> validator,
            IUploadFileOutputPorts UploadFileOutputPorts)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.UploadFileOutputPorts = UploadFileOutputPorts ?? throw new ArgumentNullException(nameof(UploadFileOutputPorts));
        }

        public async Task ExecuteAsync(UploadFileInput input)
        {
            var validationResult = await validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                await UploadFileOutputPorts.PublishValidationErrorsAsync(input, validationResult.Errors.Select(e => e.ErrorMessage));
                return;
            }
            // TODO: implement application logic
            await UploadFileOutputPorts.PublishSuccessResultAsync(input);
        }
    }
}
