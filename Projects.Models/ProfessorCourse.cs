using System;
using System.Collections.Generic;

namespace Projects.Models;

public partial class ProfessorCourse
{
    public int ProfessorId { get; set; }

    public string CourseId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public virtual Course Course { get; set; } = null!;

    public virtual Professor Professor { get; set; } = null!;
}
