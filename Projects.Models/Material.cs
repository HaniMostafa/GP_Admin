using System;
using System.Collections.Generic;

namespace Projects.Models;

public partial class Material
{
    public ulong MyRowId { get; set; }

    public int MaterialId { get; set; }

    public string CourseId { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;
}
