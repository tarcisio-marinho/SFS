using Dapper.Contrib.Extensions;
using Domain;
using Npgsql;
using SFS.Application.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Infrastructure.StoreFiles
{
    class DataAccessor : IDataAccessor
    {
        public IList<string> mock;

        public DataAccessor()
        {
            mock = new List<string> { "SADFASFASDF", "ASDFFASDSASDF", "ASDFASDFSDFA" };
        }
        public async Task<bool> CheckIfIdentificatorExists(string identificator)
        {
            return mock.Contains(identificator);
        }

        public async Task StoreFile(StoredFile file)
        {
            mock.Add(file.Identifier);
        }
    }
}
