using Domain;
using SFS.Application.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Infrastructure.Data
{
    class FileAccessorMock : IFileAccessor
    {
        private string pathFromConfig = "C:\\Users\\tarcisio\\Desktop\\store";
        public async Task<bool> WriteFileToDiskAsync(StoredFile file)
        {
            try
            {
                // TODO: get path from config
                using (var stream = new FileStream(Path.Combine(new[] { pathFromConfig , file.FileName  + "-"+ file.Identifier}), FileMode.Create))
                {
                    await file.File.CopyToAsync(stream);
                }
            }catch(Exception ex)
            {
                // TODO: logg ex
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteFileFromDisk(string fileName)
        {
            // TODO: esperar retorno? 
            // TODO: lidar com exception ? hangfire 
            try
            {
                await Task.Run(() =>
                {
                    File.Delete(Path.Combine(pathFromConfig, fileName));
                });
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
