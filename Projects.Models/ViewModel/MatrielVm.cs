using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Models;
namespace Projects.Models.ViewModel
{
    public class MatrielVm
    {
        [ValidateNever]
        public Material material { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LstCourse { get; set; }
    }
}
