using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Models;


namespace Project.DataAccess.Repostry.IRepostry
{
    public interface IMatriel:IRepostry<Material>
    {
        void Update(Material obj);

    }
}
