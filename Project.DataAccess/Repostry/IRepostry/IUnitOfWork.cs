using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Repostry.IRepostry
{
    public interface IUnitOfWork
    {
        CourseRepostry Course { get; }
        Professor_CoursesRepostry Professor_Courses { get; }
        MaterialRepostry MaterialRepo { get; }

        void Save();
    }
}
