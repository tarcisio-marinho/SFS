using System;
using System.Collections.Generic;
using System.Text;

namespace SFS.Application.Boundaries.DownloadFile
{
    public class DownloadFileError
    {
        public string Error { get; }
        public DownloadFileError(string error)
        {
            Error = error;
        }
    }
}
