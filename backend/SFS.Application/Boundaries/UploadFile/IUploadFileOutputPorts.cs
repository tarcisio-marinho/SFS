using SFS.Application.Boundaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Boundaries.UploadFile
{
    public interface IUploadFileOutputPorts : ISuccessOutputPort<UploadFileOutput>, IValidationErrorOutputPort, IApplicationErrorOutputPort<UploadFileError>
    {
    }
}
