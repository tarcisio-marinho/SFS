using SFS.Application.Boundaries.DeleteFile;
using SFS.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Application.UseCases
{
    public class DeleteFileInteractor : IDeleteFileUseCase
    {
        private readonly IDeleteFileOutputPorts deleteFileOutputPorts;
        private readonly IDataAccessor dataAccessor;
        private readonly IFileAccessor fileAccessor;
        private readonly int maximumDays = 1;

        public DeleteFileInteractor(IDeleteFileOutputPorts deleteFileOutputPorts,
            IDataAccessor dataAccessor,
            IFileAccessor fileAccessor)
        {
            this.deleteFileOutputPorts = deleteFileOutputPorts ?? throw new ArgumentNullException(nameof(deleteFileOutputPorts));
            this.dataAccessor = dataAccessor ?? throw new ArgumentNullException(nameof(dataAccessor));
            this.fileAccessor = fileAccessor ?? throw new ArgumentNullException(nameof(fileAccessor));
        }

        public async Task ExecuteAsync(string input)
        {
            var files = await dataAccessor.GetAllFiles();
            files.ToList().ForEach(f =>
            {
                if (MaximumDaysExceeded(f.UploadDate))
                {
                    fileAccessor.DeleteFileFromDisk(f.FileName);
                }
            });
        }

        private bool MaximumDaysExceeded(DateTime uploadDate)
        {
            return uploadDate.AddDays(maximumDays) < DateTime.Now;
        }
    }
}
