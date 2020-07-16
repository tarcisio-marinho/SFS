using Application.Boundaries.UploadFile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Application.Boundaries
{
    public interface IApplicationErrorOutputPort<TInput> where TInput : class
    {
        Task PublishApplicationErrorAsync(UploadFileOutput output);
    }
}
