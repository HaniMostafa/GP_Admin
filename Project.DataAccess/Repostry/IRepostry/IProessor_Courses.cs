using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Repostry.IRepostry
{
    public interface IProessor_Courses:IRepostry<Professors_Courses>
    {
        void Update(Professors_Courses obj);
    }
}
