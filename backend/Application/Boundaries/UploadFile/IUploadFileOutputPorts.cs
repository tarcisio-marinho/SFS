using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Boundaries.UploadFile
{
    public interface IUploadFileOutputPorts : ISuccessOutputPort<ProcessOrderInvestigationResultInput>, IValidationErrorOutputPort<ProcessOrderInvestigationResultInput>
    {
    }
}
