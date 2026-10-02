using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Course")]
public partial class Course
{
    [Key]
    public int CourseId { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public bool IsPublished { get; set; }

    public int InstructorId { get; set; }

    public int CategoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Courses")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Course")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [ForeignKey("InstructorId")]
    [InverseProperty("Courses")]
    public virtual Instructor Instructor { get; set; } = null!;

    [InverseProperty("Course")]
    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    [InverseProperty("Course")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
