using Api.Dtos.Errors;
using Application.Boundaries.UploadFile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        public async Task<IActionResult> UploadFileAsync([FromForm(Name = "file")] IFormFile file, string hashPassword)
        {
            _logger.LogInformation($"Initializing UseCase UploadFileInput with filename: {file.FileName} and password: {hashPassword}");

            var input = new UploadFileInput(file, hashPassword);

            await uploadFileUseCase.ExecuteAsync(input);

            return uploadFilePresenter.ViewModel;
        }
    }
}
