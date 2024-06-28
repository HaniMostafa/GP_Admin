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
    public class MaterialRepostry : Repostry<Material>, IMatriel
    {
        private readonly AcedmixDb2Context _db;

        public MaterialRepostry(AcedmixDb2Context db) : base(db)
        {
            _db = db;

        }

        public void Update(Material obj)
        {
            _db.Materials.Update(obj);

        }
    }
}
