using System;
using System.Collections.Generic;
using System.Text;

namespace SFS.Application.Boundaries.GetFileInfo
{
    public class GetFileInfoOutput
    {
        public bool Exists { get; }
        public DateTime ElapsedTime { get; }

        public GetFileInfoOutput(DateTime elapsedTime, bool exists)
        {
            ElapsedTime = elapsedTime;
            Exists = exists;
        }
    }
}
