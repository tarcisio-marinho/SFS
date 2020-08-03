using Api.Dtos.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFS.Application.Boundaries.DownloadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFS.Api.UseCases.DownloadFile
{

    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]// TODO: refactor output
    [ProducesResponseType(typeof(ValidationError), StatusCodes.Status412PreconditionFailed)]
    [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
    public class DownloadFileController
    {
        private readonly ILogger _logger;
        private readonly DownloadFilePresenter downloadFilePresenter;
        private readonly IDownloadFileUseCase downloadFileUseCase;

        public DownloadFileController(ILoggerFactory loggerFactory,
            IDownloadFileUseCase downloadFileUseCase,
            DownloadFilePresenter downloadFilePresenter)
        {
            _logger = loggerFactory?.CreateLogger<DownloadFileController>() ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.downloadFileUseCase = downloadFileUseCase ?? throw new ArgumentNullException(nameof(downloadFileUseCase));
            this.downloadFilePresenter = downloadFilePresenter ?? throw new ArgumentNullException(nameof(downloadFilePresenter));
        }

        [HttpPost("upload")]
        [ProducesResponseType(typeof(DownloadFileOutput), StatusCodes.Status200OK)] // TODO: refactor output
        [ProducesResponseType(typeof(ValidationError), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(DownloadFileError), StatusCodes.Status410Gone)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadFileAsync(DownloadFileRequest input)
        {
            _logger.LogInformation($"Initializing UseCase UploadFileInput with identifier: {input.Identificator}");

            await downloadFileUseCase.ExecuteAsync(new DownloadFileInput { Identificator = input.Identificator, HashPassword = input.Password });

            return downloadFilePresenter.ViewModel;
        }
    }
}
