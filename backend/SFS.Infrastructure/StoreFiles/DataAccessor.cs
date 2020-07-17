using Domain;
using SFS.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Infrastructure.StoreFiles
{
    class DataAccessor : IDataAccessor
    {
        public async Task<bool> CheckIfIdentificatorExists(string identificator)
        {
            throw new NotImplementedException();
        }

        public async Task StoreFile(StoredFile file)
        {
            throw new NotImplementedException();
        }
    }
}
