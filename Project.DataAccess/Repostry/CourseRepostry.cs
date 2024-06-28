using Project.DataAccess.Data;
using Project.DataAccess.Repostry.IRepostry;
using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Repostry
{
    public class CourseRepostry : Repostry<Course>,ICourseRepostry
    {
        private readonly AcedmixDb2Context _db;
        public CourseRepostry(AcedmixDb2Context db) : base(db)
        {
            _db = db;
        }

        public void Update(Course obj)
        {
            _db.Courses.Update(obj);
        }
    }
}
