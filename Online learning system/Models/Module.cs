using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Module")]
public partial class Module
{
    [Key]
    public int ModuleId { get; set; }

    public int CourseId { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public int OrderNo { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Modules")]
    public virtual Course Course { get; set; } = null!;

    [InverseProperty("Module")]
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    [InverseProperty("Module")]
    public virtual Quiz? Quiz { get; set; }
}
