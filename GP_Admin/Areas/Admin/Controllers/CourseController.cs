using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Data;
using Utalites;

namespace GP_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly AcedmixDb2Context _db;

        public CourseController(AcedmixDb2Context db)
        {
            _db = db;
        }
        [Authorize(Roles =SD.Role_Admin)]
        public IActionResult Index()
        {
            var courses=_db.Courses.ToList();

            return View(courses);
        }
    }
}
