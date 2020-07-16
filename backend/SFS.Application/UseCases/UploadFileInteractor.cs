using Application.Boundaries.UploadFile;
using Domain;
using FluentValidation;
using SFS.Application.Services;
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
        private readonly IUploadFileOutputPorts uploadFileOutputPorts;
        private readonly IDataAccessor storageAccessor;
        private readonly IFileAccessor fileAccessor;
        private const string FilePath = "asdfsd";

        public UploadFileInteractor(IValidator<UploadFileInput> validator,
            IUploadFileOutputPorts uploadFileOutputPorts, 
            IDataAccessor storageAccessor, 
            IFileAccessor fileAccessor)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.uploadFileOutputPorts = uploadFileOutputPorts ?? throw new ArgumentNullException(nameof(uploadFileOutputPorts));
            this.storageAccessor = storageAccessor ?? throw new ArgumentNullException(nameof(storageAccessor));
            this.fileAccessor = fileAccessor ?? throw new ArgumentNullException(nameof(fileAccessor)); 
        }

        public async Task ExecuteAsync(UploadFileInput input)
        {
            var validationResult = await validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                await uploadFileOutputPorts.PublishValidationErrorsAsync(input, validationResult.Errors.Select(e => e.ErrorMessage));
                return;
            }

            // TODO: implement application logic
            // Store at the database -> filepath, identificator, StoredDate
            // Store file at the disk
            // Return
            var identificator = await this.GenerateIdentificator();

            var storedFile = new StoredFile(input.File.FileName, identificator, input.File);
            if(await fileAccessor.WriteFileToDiskAsync(storedFile))
            {
                await uploadFileOutputPorts.PublishSuccessResultAsync(input);
            }
            else
            {
                await uploadFileOutputPorts.PublishApplicationErrorAsync(new UploadFileOutput(false, null, null));
            }
        }

        private async Task<string> GenerateIdentificator()
        {
            var identificator = string.Empty;
            do
            {
                identificator = Guid.NewGuid().ToString().Split('-')[4].ToUpper();
            }
            while (await storageAccessor.CheckIfIdentificatorExists(identificator)); 
            
            return identificator;
        }
    }
}
