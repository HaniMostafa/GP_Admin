using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Models.ViewModel
{
    public class CourseViewModel
    {
        public List<string> SelectedCourses { get; set; }=new List<string>();
        public IEnumerable<SelectListItem>LstCourses { get; set; }=Enumerable.Empty<SelectListItem>();


    }
}
