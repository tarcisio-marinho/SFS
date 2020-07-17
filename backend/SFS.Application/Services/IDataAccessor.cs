using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Application.Services
{
    public interface IDataAccessor
    {
        Task<bool> CheckIfIdentificatorExists(string identificator);
        Task StoreFile(StoredFile file);
    }
}
