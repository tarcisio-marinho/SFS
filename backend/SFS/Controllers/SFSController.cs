using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFS.Services;

namespace SFS.Controllers
{
    [Route("api/")]
    public class SFSController : ControllerBase
    {
        private readonly FileService _fileService;

        public SFSController()
        {
            _fileService = new FileService();
        }

        // download file(s) to client according path: rootDirectory/subDirectory with single zip file
        [HttpGet("Download/{subDirectory}")]
        public async Task<IActionResult> DownloadFiles(string subDirectory)
        {
            try
            {
                var (fileType, archiveData, archiveName) = await _fileService.FetchFiles(subDirectory);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }

        // upload file(s) to server that palce under path: rootDirectory/subDirectory
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile([FromForm(Name = "file")] IFormFile file, string subDirectory)
        {
            try
            {
                await _fileService.SaveFile(file, subDirectory);

                return Ok(new { Count = 1, Size = FileService.SizeConverter(file.Length) });
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }

    }
}
