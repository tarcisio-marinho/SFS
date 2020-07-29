using Application.Boundaries;
using SFS.Application.Boundaries.GetFileInfo;
using SFS.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Application.UseCases
{
    class GetFileInfoInteractor : IGetFileInfoUseCase
    {
        private readonly IDataAccessor _dataAccessor;
        private readonly GetFileInfoValidator _validator;
        private readonly IGetFileInfoOutputPorts getFileInfoOutputPorts;

        public GetFileInfoInteractor(IDataAccessor dataAccessor, GetFileInfoValidator validator,
            IGetFileInfoOutputPorts getFileInfoOutputPorts)
        {
            _dataAccessor = dataAccessor ?? throw new ArgumentNullException(nameof(dataAccessor));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            this.getFileInfoOutputPorts = getFileInfoOutputPorts ?? throw new ArgumentNullException(nameof(getFileInfoOutputPorts));
        }

        public async Task ExecuteAsync(string input)
        {
            var validationResult = await _validator.ValidateAsync(input);
            if (!validationResult.IsValid)
            {
                await getFileInfoOutputPorts.PublishValidationErrorsAsync(validationResult.Errors
                    .Select(e => e.ErrorMessage));
                return;
            }

            var exists = await _dataAccessor.GetFileIfExists(input);
            if (exists != null)
            {
                // TODO: tempo restante = uploaded date - now 
                var output = new GetFileInfoOutput(exists.UploadDate, true);
                await getFileInfoOutputPorts.PublishSuccessResultAsync(output);
            }

            getFileInfoOutputPorts.PublishApplicationErrorAsync("The server does not contains the file. It may be deleted !");
        }
    }
}
