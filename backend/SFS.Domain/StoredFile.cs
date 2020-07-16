using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class StoredFile
    {
        public StoredFile(string fileName, string identifier, IFormFile file)
        {
            FileName = fileName;
            Identifier = identifier;
            File = file;
        }
        public string FileName { get; }
        public string Identifier { get; }
        public IFormFile File { get; }
    }
}
