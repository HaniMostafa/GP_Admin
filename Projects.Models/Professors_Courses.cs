using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Models
{
    public class Professors_Courses
    {
        [Key]
        public int Id { get; set; }
        public string CourseId { get; set; } = null!;
        public string? ApplicationUserId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
