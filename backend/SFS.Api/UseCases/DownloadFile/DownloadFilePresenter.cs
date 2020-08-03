using Api.Dtos.Errors;
using Api.Dtos.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFS.Api.Dtos.Errors;
using SFS.Api.Dtos.Mvc;
using SFS.Application.Boundaries.DownloadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFS.Api.UseCases.DownloadFile
{
    public class DownloadFilePresenter : IDowloadFileOutputPorts
    {

        private readonly ILogger _logger;
        public IActionResult ViewModel { get; set; }

        public DownloadFilePresenter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<DownloadFilePresenter>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }


        public Task PublishSuccessResultAsync(DownloadFileOutput output)
        {
            _logger.LogInformation($"DownloadFile Success: {output}");

            ViewModel = new OkObjectResult(output);

            return Task.CompletedTask;
        }

        public Task PublishValidationErrorsAsync(IEnumerable<string> errors)
        {
            _logger.LogWarning($"Failed to execute UseCase DownloadFile | Errors: {string.Join("|", errors)}");

            ViewModel = new PreconditionFailedObjectResult(new ValidationError(errors));

            return Task.CompletedTask;
        }

        public Task PublishApplicationErrorAsync(DownloadFileError error)
        {
            _logger.LogWarning($"Failed to execute UseCase DownloadFile");

            ViewModel = new GoneFailedObjectResult(error);

            return Task.CompletedTask;
        }
    }
}
