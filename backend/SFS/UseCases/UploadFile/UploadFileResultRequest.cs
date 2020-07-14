using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.UseCases.UploadFile
{
    public class UploadFileResultRequest
    {
        public bool Success { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
