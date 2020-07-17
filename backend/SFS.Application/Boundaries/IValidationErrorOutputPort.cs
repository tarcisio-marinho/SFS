using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Boundaries
{
    public interface IValidationErrorOutputPort
    {
        Task PublishValidationErrorsAsync(IEnumerable<string> errors);
    }
}
