// Controllers/FileUploadController.cs
using FileUpload.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        // GET: FileUpload
        public ActionResult Index()
        {
            // Retrieve all uploaded files to display
            var files = _dbContext.UploadedFiles.ToList();
            return View(files);
        }

        // POST: FileUpload/UploadFile
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                // Read file into byte array
                byte[] fileData;
                using (var binaryReader = new BinaryReader(uploadedFile.InputStream))
                {
                    fileData = binaryReader.ReadBytes(uploadedFile.ContentLength);
                }

                // Create new UploadedFile object
                var file = new UploadedFile
                {
                    FileName = Path.GetFileName(uploadedFile.FileName),
                    ContentType = uploadedFile.ContentType,
                    Content = fileData
                };

                // Save file to database
                _dbContext.UploadedFiles.Add(file);
                _dbContext.SaveChanges();

                ViewBag.Message = "File uploaded and saved to database successfully!";
            }
            else
            {
                ViewBag.Message = "Please select a file to upload!";
            }

            return RedirectToAction("Index");
        }

        // GET: FileUpload/DownloadFile/{id}
        public FileResult DownloadFile(int id)
        {
            var file = _dbContext.UploadedFiles.Find(id);
            if (file != null)
            {
                return File(file.Content, file.ContentType, file.FileName);
            }

            throw new HttpException(404, "File not found");
        }
    }
}
