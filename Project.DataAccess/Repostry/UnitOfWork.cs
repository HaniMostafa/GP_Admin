using Project.DataAccess.Data;
using Project.DataAccess.Repostry.IRepostry;

namespace Project.DataAccess.Repostry
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcedmixDb2Context _db;
        public CourseRepostry Course { get; private set; }

        public Professor_CoursesRepostry Professor_Courses { get; private set; }

        public MaterialRepostry MaterialRepo { get; private set; }


        public UnitOfWork(AcedmixDb2Context db)
        {
            _db = db;
            Course = new CourseRepostry(_db);
            Professor_Courses=new Professor_CoursesRepostry(_db);
            MaterialRepo = new MaterialRepostry(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
