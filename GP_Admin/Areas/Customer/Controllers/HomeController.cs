using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Project.DataAccess.Repostry.IRepostry;
using Projects.Models;
using Projects.Models.ViewModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using Utalites;
namespace GP_Admin.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var ClaimIdentity = (ClaimsIdentity)User.Identity;
            
            if (ClaimIdentity.IsAuthenticated==false)
            {
              ProfCoursesVm  vmf = new()
                {
                    LstProfCourses = new List<Professors_Courses>()

                };
                return View(vmf);
            }
            var userId = ClaimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ProfCoursesVm vm = new()
            {
                LstProfCourses = _unitOfWork.Professor_Courses.GetAll(a => a.ApplicationUserId == userId, includeProperties: "Course"),

            };
            if (vm==null)
            {
                vm = new()
                {
                    LstProfCourses = new List<Professors_Courses>()

                };
            return View(vm);
            }
            return View(vm);
        }
        [HttpGet]
        [Authorize(Roles = "Doctor,AssistantTeacher")]
        public IActionResult Add()
        {
            CourseViewModel model = new()
            {
                LstCourses=_unitOfWork.Course.GetAll().Select(c=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value=c.CourseId,
                    Text=c.CourseName


                })

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(CourseViewModel model)
        {
            var ClaimIdentity = (ClaimsIdentity)User.Identity;
            var userid = ClaimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int Index = 0;
            foreach (var item in model.SelectedCourses)
            {
                Professors_Courses prof = new()
                {
                    CourseId = model.SelectedCourses[Index],
                    ApplicationUserId = userid
                };
                _unitOfWork.Professor_Courses.Add(prof);
                _unitOfWork.Save();
                Index++;
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(string courseid)
        {

            var CartFromDb = _unitOfWork.Professor_Courses.Get(a => a.CourseId == courseid);
            _unitOfWork.Professor_Courses.Remove(CartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
