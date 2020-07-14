using Api.Dtos.Errors;
using Application.Boundaries.UploadFile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UseCases.UploadFile
{
    [ProducesResponseType(typeof(UploadFileInput), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationError), StatusCodes.Status412PreconditionFailed)]
    [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
    public class UploadFileController
    {
        private readonly ILogger _logger;
        private readonly IUploadFileUseCase uploadFileUseCase;
        private readonly UploadFilePresenter uploadFilePresenter;

        public UploadFileController(ILoggerFactory loggerFactory,
            IUploadFileUseCase uploadFileUseCase,
            UploadFilePresenter uploadFilePresenter)
        {
            _logger = loggerFactory?.CreateLogger<UploadFileController>() ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.uploadFileUseCase = uploadFileUseCase ?? throw new ArgumentNullException(nameof(uploadFileUseCase));
            this.uploadFilePresenter = uploadFilePresenter ?? throw new ArgumentNullException(nameof(uploadFilePresenter));
        }

        [HttpPost("upload")]
        [ProducesResponseType(typeof(UploadFileInput), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationError), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadFileAsync([FromForm(Name = "file")] UploadFileResultRequest uploadFileResultRequest)
        {
            _logger.LogInformation("Initializing UseCase UploadFileInput with payload:", uploadFileResultRequest);

            var input = new UploadFileInput(uploadFileResultRequest.File, uploadFileResultRequest.HashPassword);

            await uploadFileUseCase.ExecuteAsync(input);

            return uploadFilePresenter.ViewModel;
        }
    }
}
