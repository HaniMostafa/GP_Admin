namespace Projects.Models;

public partial class Professor
{
    public int ProfessorId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ProfessorCourse? ProfessorCourse { get; set; }
}
