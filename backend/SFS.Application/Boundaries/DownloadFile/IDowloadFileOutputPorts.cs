using Application.Boundaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFS.Application.Boundaries.DownloadFile
{
    public interface IDowloadFileOutputPorts : ISuccessOutputPort<DownloadFileOutput>, IValidationErrorOutputPort, IApplicationErrorOutputPort<DownloadFileError>
    {
    }
}
