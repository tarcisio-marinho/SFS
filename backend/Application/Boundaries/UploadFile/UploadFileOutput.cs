using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Boundaries.UploadFile
{
    public class UploadFileOutput
    {
        public UploadFileOutput(bool success, DateTime expirationDate)
        {
            Success = success;
            ExpirationDate = expirationDate;
        }
        public bool Success { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
