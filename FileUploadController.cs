using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Host_ImageUpload.Controllers
{
    [Route("[api/controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        //private readonly IWebHostEnvironment _webHostEnviroment;
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public FileUploadController(IWebHostEnvironment webHostEnvironment)
        //{
        //    _webHostEnviroment = webHostEnvironment;
        //}       

        [HttpPost("[action]")]
        [Route("HollyHuber")]
        [RequestFormLimits(MultipartBodyLengthLimit =409715200)]
        [RequestSizeLimit(409715200)]

        public IActionResult UploadFiles(List<IFormFile> files, [FromServices] IHostingEnvironment oHostingEnviroment)
        {
            if (files.Count == 0)
                return BadRequest();
            string fileName = $"{oHostingEnviroment.WebRootPath}\\UploadedFiles\\{files[0].FileName}";
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                files[0].CopyTo(fs);
                fs.Flush();
            }
            //string directorypath = Path.Combine(_webHostEnviroment.ContentRootPath, "UploadedFiles");

            //foreach (var file in files)
            //{
            //    string filepath = Path.Combine(directorypath, file.FileName);
            //    using (var stram = new FileStream(filepath, FileMode.Create))
            //    {
            //        file.CopyTo(stram);
            //    }
            //}
            return Ok("Uploaded Successful");
        }
    }
}
