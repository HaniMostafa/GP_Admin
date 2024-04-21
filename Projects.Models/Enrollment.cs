using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projects.Models;

public partial class Enrollment
{
    public int StudentId { get; set; }

    public string CourseId { get; set; } = null!;

    public decimal Progress { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User Student { get; set; } = null!;


}
