using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Application.Boundaries.UploadFile
{
    class UploadFileInput
    {
        public UploadFileInput (IFormFile file, string hashpassword)
        {
            File = file;
            HashPassword = hashpassword;
        }
        public IFormFile File { get; }
        public string HashPassword { get; }
    }
}
