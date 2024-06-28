using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Repostry.IRepostry
{
    public interface ICourseRepostry : IRepostry<Course>
    {
        void Update(Course obj);
    }
}
