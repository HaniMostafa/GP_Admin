using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Projects.Models;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public int Credits { get; set; }

    public int Grade { get; set; }

    public string CourseDescription { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? CourseImg { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    [ValidateNever]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    [ValidateNever]

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
    [ValidateNever]

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
    [ValidateNever]

    public virtual ICollection<ProfessorCourse> ProfessorCourses { get; set; } = new List<ProfessorCourse>();
    [ValidateNever]

    public virtual ICollection<Requirement> RequirementCourses { get; set; } = new List<Requirement>();
    [ValidateNever]

    public virtual ICollection<Requirement> RequirementRequirement1Navigations { get; set; } = new List<Requirement>();
}
