using Project.DataAccess.Data;
using Project.DataAccess.Repostry.IRepostry;
using Projects.Models;


namespace Project.DataAccess.Repostry
{
    public class Professor_CoursesRepostry : Repostry<Professors_Courses>,IProessor_Courses
    {
        private readonly AcedmixDb2Context _db;

        public Professor_CoursesRepostry(AcedmixDb2Context db) : base(db)
        {
            _db = db;
        }

        public void Update(Professors_Courses obj)
        {
            _db.Professors_Courses.Update(obj);
        }
    }
}
