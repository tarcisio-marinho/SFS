using Application.Boundaries.UploadFile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Application.Boundaries
{
    public interface IApplicationErrorOutputPort<TOutuput> where TOutuput : class
    {
        Task PublishApplicationErrorAsync(TOutuput output);
    }
}
