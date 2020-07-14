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


        public Task PublishSuccessResultAsync(ProcessOrderInvestigationResultInput output)
        {
            //TODO: gerar um objeto de retorno específico pra essa chamada... ou simples 204 resolve? Validar com o Marcelo Jr do VI se 204 pode.

            _logger.LogInformation("Investigation sent to peer successfully: {@0}", output);

            ViewModel = new OkObjectResult(output);

            return Task.CompletedTask;
        }

        public Task PublishValidationErrorsAsync(ProcessOrderInvestigationResultInput input, IEnumerable<string> errors)
        {
            _logger.LogWarning("Failed to execute UseCase ProcessOrderInvestigationResult: CorrelationId: {0} Errors: {1}", input.CorrelationId, string.Join("|", errors));

            ViewModel = new PreconditionFailedObjectResult(new ValidationError(errors));

            return Task.CompletedTask;
        }
    }
}
