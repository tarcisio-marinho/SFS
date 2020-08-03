using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Application.Services
{
    public interface IDataAccessor
    {
        Task<bool> CheckIfIdentificatorExists(string identifier);
        Task StoreFile(StoredFile file);
        Task<IList<StoredFile>> GetAllFiles();
        Task<string> GetFileName(string identifier);
        Task<StoredFile> GetFileIfExists(string identifier);
        Task<DateTime> GetDateTime(string identifier);
        Task RemoveFile(string identifier);
        Task<StoredFile> GetFileIfExists(string identifier, string hashPassword);
    }
}
