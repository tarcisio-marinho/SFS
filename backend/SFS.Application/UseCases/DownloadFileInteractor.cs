using SFS.Application.Boundaries.DownloadFile;
using SFS.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Application.UseCases
{
    class DownloadFileInteractor : IDownloadFileUseCase
    {
        public readonly DownloadFileValidator _validator;
        public readonly IDowloadFileOutputPorts _ports;
        public readonly IDataAccessor _dataAccessor;
        public readonly IFileAccessor _fileAccessor;
        public DownloadFileInteractor(DownloadFileValidator validator, IDowloadFileOutputPorts ports, IFileAccessor fileAccessor, IDataAccessor dataAccessor)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _ports = ports ?? throw new ArgumentNullException(nameof(ports));
            _fileAccessor = fileAccessor ?? throw new ArgumentNullException(nameof(fileAccessor));
            _dataAccessor = dataAccessor ?? throw new ArgumentNullException(nameof(dataAccessor));
        }

        public async Task ExecuteAsync(DownloadFileInput input)
        {
            var validationResult = await _validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                await _ports.PublishValidationErrorsAsync(validationResult.Errors
                    .Select(e => e.ErrorMessage));
                return;
            }

            if (! await _dataAccessor.CheckIfIdentificatorExists(input.Identificator))
            {
                await _ports.PublishApplicationErrorAsync(new DownloadFileError("File doesnt exists or wrong password or it may be already deleted."));
            }

            var file = _dataAccessor.GetFileIfExists(input.Identificator, input.HashPassword);
        }
    }
}
