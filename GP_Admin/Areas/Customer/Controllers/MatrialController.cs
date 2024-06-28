using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.DataAccess.Repostry.IRepostry;
using Projects.Models;
using Projects.Models.ViewModel;
using System.Security.Claims;

namespace GP_Admin.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class MatrialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MatrialController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

       
        public IActionResult Index()
        {
            List<Material> products = _unitOfWork.MaterialRepo.GetAll(includeProperties: "Course").ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            MatrielVm productViewModel = new()
            {
                LstCourse = _unitOfWork.Course.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CourseName,
                    Value = u.CourseId
                }),
                material = new Material()

            };
            if (id == 0 || id == null)
            {

                return View(productViewModel);
            }
            else
            {
                productViewModel.material = _unitOfWork.MaterialRepo.Get(u => u.MaterialId == id);
                return View(productViewModel);

            }


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MatrielVm obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string WwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string ProductPath = Path.Combine(WwwRootPath, @"Images\Matrials");



                    if (!string.IsNullOrEmpty(obj.material.Content))
                    {
                        //delete old image 
                        var OldImagePath = Path.Combine(WwwRootPath, obj.material.Content.TrimStart('\\'));
                        if (System.IO.File.Exists(OldImagePath))
                        {
                            System.IO.File.Delete(OldImagePath);


                        }

                    }
                    using (var FileStream = new FileStream(Path.Combine(ProductPath, FileName), FileMode.Create))
                    {
                        file.CopyTo(FileStream);
                    }
                    obj.material.Content = @"\Images\Matrials\" + FileName;
                }
                if (obj.material.MaterialId == 0)
                {
                    var cour = _unitOfWork.Course.Get(a => a.CourseId == obj.material.CourseId);
                    Material ma = new()
                    {
                        CourseId = obj.material.CourseId,
                        Content = obj.material.Content,
                        UpdatedAt = DateTime.Now,
                        CreatedAt = DateTime.Now,

                    };

                    _unitOfWork.MaterialRepo.Add(ma);
                    ma.MaterialId = obj.material.MaterialId;
                    _unitOfWork.Save();

                    TempData["sucess"] = "Category is Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    _unitOfWork.MaterialRepo.Update(obj.material);
                    _unitOfWork.Save();
                    TempData["sucess"] = "Category is Updated Successfully";
                    return RedirectToAction("Index");
                }

            }



            else
            {
                obj.LstCourse = _unitOfWork.Course.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CourseName,
                    Value = u.CourseId
                });
                return View(obj);
            }
        }




    }
}
