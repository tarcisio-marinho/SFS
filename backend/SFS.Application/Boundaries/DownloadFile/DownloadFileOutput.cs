using System;
using System.Collections.Generic;
using System.Text;

namespace SFS.Application.Boundaries.DownloadFile
{
    public class DownloadFileOutput
    {
        public byte [] File { get; set; }
        public string FileName { get; set; }
        public string Format { get; set; }
    }
}
