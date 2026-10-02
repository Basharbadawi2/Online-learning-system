using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Instructor")]
[Index("UserId", Name = "UQ__Instruct__1788CC4D336C8A71", IsUnique = true)]
public partial class Instructor
{
    [Key]
    public int InstructorId { get; set; }

    public int UserId { get; set; }

    public string? Bio { get; set; }

    [StringLength(200)]
    public string? Specialization { get; set; }

    [InverseProperty("Instructor")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [ForeignKey("UserId")]
    [InverseProperty("Instructor")]
    public virtual User User { get; set; } = null!;
}
