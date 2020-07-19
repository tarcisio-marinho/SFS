using Application.Boundaries.UploadFile;
using Domain;
using FluentValidation;
using SFS.Application.Boundaries;
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
        private readonly IDataAccessor dataAccessor;
        private readonly IFileAccessor fileAccessor;
        private const string _applicationErrorMessage = "Try again later";

        public UploadFileInteractor(IValidator<UploadFileInput> validator,
            IUploadFileOutputPorts uploadFileOutputPorts, 
            IDataAccessor dataAccessor, 
            IFileAccessor fileAccessor)
        {
            this.validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.uploadFileOutputPorts = uploadFileOutputPorts ?? throw new ArgumentNullException(nameof(uploadFileOutputPorts));
            this.dataAccessor = dataAccessor ?? throw new ArgumentNullException(nameof(dataAccessor));
            this.fileAccessor = fileAccessor ?? throw new ArgumentNullException(nameof(fileAccessor)); 
        }

        public async Task ExecuteAsync(UploadFileInput input)
        {
            var validationResult = await validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                await uploadFileOutputPorts.PublishValidationErrorsAsync(validationResult.Errors.Select(e => e.ErrorMessage));
                return;
            }

            var identificator = await this.GenerateIdentificator();

            var storedFile = new StoredFile(input.File.FileName, identificator, input.File, DateTime.Now);

            if(await fileAccessor.WriteFileToDiskAsync(storedFile))
            {
                await dataAccessor.StoreFile(storedFile);
                var output = new UploadFileOutput(true, storedFile.UploadDate, identificator);
                await uploadFileOutputPorts.PublishSuccessResultAsync(output);
            }
            else
            {
                await uploadFileOutputPorts.PublishApplicationErrorAsync(new UploadFileError(false, _applicationErrorMessage));
            }
        }

        private async Task<string> GenerateIdentificator()
        {
            string identificator;
            do
            {
                identificator = Guid.NewGuid().ToString().Split('-')[4].ToUpper();
            }
            while (await dataAccessor.CheckIfIdentificatorExists(identificator)); 
            
            return identificator;
        }
    }
}
