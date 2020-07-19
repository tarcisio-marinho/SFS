using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace SFS.Application.Services
{
    public interface IFileAccessor
    {
        Task<bool> WriteFileToDiskAsync(StoredFile file);
        Task<bool> DeleteFileFromDisk(string fileName);
    }
}
