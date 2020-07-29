using Api.Dtos.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFS.Application.Boundaries.GetFileInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFS.Api.UseCases.GetFileInfo
{
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]// TODO: refactor output
    [ProducesResponseType(typeof(ValidationError), StatusCodes.Status412PreconditionFailed)]
    [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
    public class GetFileInfoController
    {
        private readonly ILogger _logger;
        private readonly GetFileInfoPresenter getFileInfoPresenter;
        private readonly IGetFileInfoUseCase getFileInfoUseCase;

        public GetFileInfoController(ILoggerFactory loggerFactory,
            IGetFileInfoUseCase getFileInfoUseCase,
            GetFileInfoPresenter getFileInfoPresenter)
        {
            _logger = loggerFactory?.CreateLogger<GetFileInfoController>() ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.getFileInfoUseCase = getFileInfoUseCase ?? throw new ArgumentNullException(nameof(getFileInfoUseCase));
            this.getFileInfoPresenter = getFileInfoPresenter ?? throw new ArgumentNullException(nameof(getFileInfoPresenter));
        }

        [HttpPost("upload")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)] // TODO: refactor output
        [ProducesResponseType(typeof(ValidationError), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(InternalServerError), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadFileAsync(string identifier)
        {
            _logger.LogInformation($"Initializing UseCase UploadFileInput with identifier: {identifier}");


            await getFileInfoUseCase.ExecuteAsync(identifier);

            return getFileInfoPresenter.ViewModel;
        }
    }
}
