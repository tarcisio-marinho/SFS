using Api.Dtos.Errors;
using Api.Dtos.Mvc;
using Application.Boundaries.UploadFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UseCases.UploadFile
{
    public class UploadFilePresenter
    {

        private readonly ILogger _logger;
        public IActionResult ViewModel { get; set; }

        public UploadFilePresenter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<UploadFilePresenter>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }


        public Task PublishSuccessResultAsync(UploadFileOutput output)
        {
            _logger.LogInformation($"UploadFile Success: {output}");

            ViewModel = new OkObjectResult(output);

            return Task.CompletedTask;
        }

        public Task PublishValidationErrorsAsync(IEnumerable<string> errors)
        {
            _logger.LogWarning($"Failed to execute UseCase UploadFile | Errors: {string.Join("|", errors)}");

            ViewModel = new PreconditionFailedObjectResult(new ValidationError(errors));

            return Task.CompletedTask;
        }
    }
}
