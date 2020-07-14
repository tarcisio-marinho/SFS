﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Boundaries.UploadFile
{
    public class UploadFileOutput
    {
        public UploadFileOutput(bool success, DateTime expirationDate, string identificator)
        {
            Success = success;
            Identificator = identificator;
            ExpirationDate = expirationDate;
        }
        public bool Success { get; }
        public string Identificator { get; }
        public DateTime ExpirationDate { get; }
    }
}
