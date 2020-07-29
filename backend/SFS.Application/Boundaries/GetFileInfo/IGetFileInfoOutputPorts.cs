using Application.Boundaries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Application.Boundaries.GetFileInfo
{
    public interface IGetFileInfoOutputPorts : ISuccessOutputPort<GetFileInfoOutput>, IValidationErrorOutputPort, IApplicationErrorOutputPort<string>
    {
    }
}
