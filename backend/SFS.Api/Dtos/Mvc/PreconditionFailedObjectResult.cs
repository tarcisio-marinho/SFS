using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class PreconditionFailedObjectResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status412PreconditionFailed;

        public PreconditionFailedObjectResult([ActionResultObjectValue] object value)
            : base(value)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
