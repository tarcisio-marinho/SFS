using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFS.Api.Dtos.Errors
{
    public class ApplicationError
    {
        public string Error { get; }

        public ApplicationError(string error)
        {
            Error = error;
        }
    }
}
