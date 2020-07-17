using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Errors
{
    public class ValidationError 
    {
        public IEnumerable<string> Errors { get; set; }


        public ValidationError(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
