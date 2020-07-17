using System;
using System.Collections.Generic;
using System.Text;

namespace SFS.Application.Boundaries
{
    public class UploadFileError
    {
        public bool Success { get; }        
        public string Message { get; }
        public UploadFileError(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}
