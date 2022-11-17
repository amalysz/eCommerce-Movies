using eMovies.Models;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace UploadFile.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            FileModel model = new FileModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult Upload(FileModel model)
        {
            if (ModelState.IsValid)
            {
                model.IsResponse = true;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(model.File.FileName);
                string fileName = model.FileName + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.File.CopyTo(stream);
                }
                model.IsSuccess = true;
                model.Message = "File upload successfully";
 
            }
            return View("Index", model);
        }
    }
}
