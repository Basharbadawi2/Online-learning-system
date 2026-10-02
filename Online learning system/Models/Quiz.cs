using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Quiz")]
[Index("ModuleId", Name = "UQ__Quiz__2B7477A609E39587", IsUnique = true)]
public partial class Quiz
{
    [Key]
    public int QuizId { get; set; }

    public int ModuleId { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal PassingScore { get; set; }

    [ForeignKey("ModuleId")]
    [InverseProperty("Quiz")]
    public virtual Module Module { get; set; } = null!;

    [InverseProperty("Quiz")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [InverseProperty("Quiz")]
    public virtual ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
}
