using Dapper.Contrib.Extensions;
using Domain;
using Npgsql;
using SFS.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Infrastructure.StoreFiles
{
    class DataAccessorMock : IDataAccessor
    {
        private IList<StoredFile> mock;

        public DataAccessorMock()
        {
            mock = new List<StoredFile>();
        }
        public async Task<bool> CheckIfIdentificatorExists(string identifier)
        {
            var contains = false;
            mock.ToList().ForEach(f =>
            {
                if(f.Identifier == identifier)
                {
                    contains = true;
                }
            });
            return contains;
        }

        public async Task<StoredFile> GetFileIfExists(string identifier)
        {
            return mock.ToList().Select(f => f).Where(f => f.Identifier == identifier).FirstOrDefault();
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

        public async Task RemoveFile(string identifier)
        {
            mock.ToList().RemoveAll(f => f.Identifier == identifier);
        }

        public async Task<StoredFile> GetFileIfExists(string identifier, string hashPassword)
        {
            return mock.ToList().Select(file => file).Where(file => file.Identifier == identifier && file.HashPassword == hashPassword).FirstOrDefault();
        }
    }
}
