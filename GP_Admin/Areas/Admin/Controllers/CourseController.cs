using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Repostry.IRepostry;
using Projects.Models;
using System.Security.Claims;
using Utalites;

namespace GP_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CourseController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Index()
        {
            var courses = _unitOfWork.Course.GetAll().ToList();

            return View(courses);
        }
        [HttpGet]
        public IActionResult Upsert(string? id)
        {
            if (id == null)
            {

                return View(new Course());
            }
            else
            {
                var Course = _unitOfWork.Course.Get(u => u.CourseId == id);
                return View(Course);

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Course model, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string WwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string ProductPath = Path.Combine(WwwRootPath, @"Images\Courses");
                    if (!string.IsNullOrEmpty(model.CourseImg))
                    {
                        //delete old image 
                        var OldImagePath = Path.Combine(WwwRootPath, model.CourseImg.TrimStart('\\'));
                        if (System.IO.File.Exists(OldImagePath))
                        {
                            System.IO.File.Delete(OldImagePath);
                        }

                    }
                    using (var FileStream = new FileStream(Path.Combine(ProductPath, FileName), FileMode.Create))
                    {
                        file.CopyTo(FileStream);
                    }
                    model.CourseImg = @"\Images\Courses\" + FileName;
                }
             
                if (model.CourseId == null)
                {
                    model.CourseId = Guid.NewGuid().ToString();
                    _unitOfWork.Course.Add(model);
                    _unitOfWork.Save();
                }
              
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
        public IActionResult Delete(string? courseid)
        {
            Course? obj = _unitOfWork.Course.Get(u => u.CourseId == courseid);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Course.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
