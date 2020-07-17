using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class StoredFile
    {
        public StoredFile(string fileName, string identifier, IFormFile file, DateTime uploadDate)
        {
            FileName = fileName;
            Identifier = identifier;
            File = file;
            UploadDate = uploadDate;
        }
        public string FileName { get; }
        public string Identifier { get; }
        public IFormFile File { get; }
        public DateTime UploadDate { get; }
    }
}
