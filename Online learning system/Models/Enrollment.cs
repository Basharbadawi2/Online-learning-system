using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Enrollment")]
[Index("StudentId", "CourseId", Name = "UQ_Enrollment", IsUnique = true)]
public partial class Enrollment
{
    [Key]
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateTime? EnrolledAt { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? ProgressPercent { get; set; }

    public DateTime? CompletedAt { get; set; }

    [InverseProperty("Enrollment")]
    public virtual Certificate? Certificate { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Enrollments")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Enrollments")]
    public virtual User Student { get; set; } = null!;
}
