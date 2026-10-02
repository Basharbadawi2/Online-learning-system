using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Lesson")]
public partial class Lesson
{
    [Key]
    public int LessonId { get; set; }

    public int ModuleId { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [StringLength(50)]
    public string LessonType { get; set; } = null!;

    public string? ContentUrl { get; set; }

    public int OrderNo { get; set; }

    [ForeignKey("ModuleId")]
    [InverseProperty("Lessons")]
    public virtual Module Module { get; set; } = null!;
}
