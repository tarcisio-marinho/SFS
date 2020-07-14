using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Boundaries
{
    public interface IValidationErrorOutputPort<TInput> where TInput : class
    {
        Task PublishValidationErrorsAsync(TInput input, IEnumerable<string> errors);
    }
}
