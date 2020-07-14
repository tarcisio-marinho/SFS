using Application.Boundaries.UploadFile;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UploadFileInteractor : IUploadFileUseCase
    {
        private readonly IValidator<UploadFileInput> validator;
        private readonly IUploadFileOutputPorts UploadFileOutputPorts;
        private const string FilePath = "asdfsd";

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
            // Generate new identificator
            // Check if identificator is unique
            // Store at the database -> filepath, identificator, StoredDate
            // Store file at the disk
            // Return
            var identificator = this.GenerateIdentificator();
            
            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await input.File.CopyToAsync(stream);
            }

            await UploadFileOutputPorts.PublishSuccessResultAsync(input);
        }

        private string GenerateIdentificator()
        {
            var identificator = string.Empty;
            do
            {

                identificator = Guid.NewGuid().ToString().Split('-')[4].ToUpper();
            }
            while (this.CheckIfIdentificatorExists(identificator)); 
            
            return identificator;
        }

        private bool CheckIfIdentificatorExists(string identificator)
        {
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
