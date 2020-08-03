using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFS.Api.Dtos.Mvc
{
    [DefaultStatusCode(DefaultStatusCode)]
    public class GoneFailedObjectResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status410Gone;

        public GoneFailedObjectResult([ActionResultObjectValue] object value)
            : base(value)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
