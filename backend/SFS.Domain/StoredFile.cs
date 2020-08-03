using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class StoredFile
    {
        public StoredFile(string fileName, string identifier, IFormFile file, DateTime uploadDate, string hashPassword)
        {
            FileName = fileName;
            Identifier = identifier;
            File = file;
            UploadDate = uploadDate;
            HashPassword = hashPassword;
        }
        public int Id { get; set; }
        public string FileName { get; }
        public string HashPassword { get; }
        public string Identifier { get; }
        public IFormFile File { get; }
        public DateTime UploadDate { get; }
    }
}
