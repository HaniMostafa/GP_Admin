using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projects.Models;

public partial class Material
{
    
    public int MaterialId { get; set; }
    [ForeignKey("CourseId")]
    public string CourseId { get; set; } = null!;
    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public Course Course { get; set; } 
   
}
