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

        [HttpGet("Download/")]
        public async Task<IActionResult> DownloadFiles(string identifier)
        {
            try
            {
                var (fileType, archiveData, archiveName) = await _fileService.FetchFiles(identifier);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile([FromForm(Name = "file")] IFormFile file, string hashPassword)
        {
            try
            {
                await _fileService.SaveFile(file, hashPassword);

                return Ok(new { Count = 1, Size = FileService.SizeConverter(file.Length) });
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }

    }
}
