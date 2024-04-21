using System;
using System.Collections.Generic;

namespace Projects.Models;

public partial class Grade
{
    public int StudentId { get; set; }

    public string CourseId { get; set; } = null!;

    public decimal Grade1 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User Student { get; set; } = null!;
}
