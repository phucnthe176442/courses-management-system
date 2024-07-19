using System;
using System.Collections.Generic;

namespace CourseManagement.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string? Name { get; set; }

    public string? Bio { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
