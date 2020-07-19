using Dapper.Contrib.Extensions;
using Domain;
using Npgsql;
using SFS.Application.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Infrastructure.StoreFiles
{
    class DataAccessor : IDataAccessor
    {
        private IList<StoredFile> mock;

        public DataAccessor()
        {
            mock = new List<StoredFile>();
        }
        public async Task<bool> CheckIfIdentificatorExists(string identifier)
        {
            bool contains = false;
            mock.ToList().ForEach(e =>
            {
                if(e.Identifier == identifier)
                {
                    contains = true;
                }
            });
            return contains;
        }
        public async Task StoreFile(StoredFile file)
        {
            mock.Add(file);
        }

        public async Task<IList<StoredFile>> GetAllFiles()
        {
            return mock;
        }

        public async Task<DateTime> GetDateTime(string identifier)
        {
            return mock.ToList().Where(f => f.Identifier == identifier).Select(e => e.UploadDate).FirstOrDefault();
        }

        public async Task<string> GetFileName(string identifier)
        {
            return mock.ToList().Where(f => f.Identifier == identifier).Select(e => e.FileName).FirstOrDefault();
        }
    }
}
