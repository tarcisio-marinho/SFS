using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFS.Api.UseCases.DownloadFile
{
    public class DownloadFileRequest
    {
        public string Identificator { get; set; }
        public string Password { get; set; }
    }
}
