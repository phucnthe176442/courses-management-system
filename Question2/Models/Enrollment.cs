using System;
using System.Collections.Generic;

namespace CourseManagement.Models;

public partial class Enrollment
{
    public int UserId { get; set; }

    public int CourseId { get; set; }

    public DateOnly? EnrolledDate { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
