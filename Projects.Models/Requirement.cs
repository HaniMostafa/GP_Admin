using System;
using System.Collections.Generic;

namespace Projects.Models;

public partial class Requirement
{
    public string CourseId { get; set; } = null!;

    public string Requirement1 { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Course Requirement1Navigation { get; set; } = null!;
}
