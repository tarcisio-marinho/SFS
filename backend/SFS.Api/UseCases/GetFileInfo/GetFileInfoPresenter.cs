using Api.Dtos.Errors;
using Api.Dtos.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFS.Api.Dtos.Errors;
using SFS.Application.Boundaries.GetFileInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFS.Api.UseCases.GetFileInfo
{
    public class GetFileInfoPresenter : IGetFileInfoOutputPorts
    {

        private readonly ILogger _logger;
        public IActionResult ViewModel { get; set; }

        public GetFileInfoPresenter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<GetFileInfoPresenter>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }


        public Task PublishSuccessResultAsync(GetFileInfoOutput output)
        {
            _logger.LogInformation($"GetFileInfo Success: {output}");

            ViewModel = new OkObjectResult(output);

            return Task.CompletedTask;
        }

        public Task PublishValidationErrorsAsync(IEnumerable<string> errors)
        {
            _logger.LogWarning($"Failed to execute UseCase GetFileInfo | Errors: {string.Join("|", errors)}");

            ViewModel = new PreconditionFailedObjectResult(new ValidationError(errors));

            return Task.CompletedTask;
        }

        public Task PublishApplicationErrorAsync(string error)
        {
            _logger.LogWarning($"Failed to execute UseCase GetFileInfo");

            ViewModel = new PreconditionFailedObjectResult(new ApplicationError(error));

            return Task.CompletedTask;
        }
    }
}
