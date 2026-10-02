using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("QuizAttempt")]
public partial class QuizAttempt
{
    [Key]
    public int AttemptId { get; set; }

    public int QuizId { get; set; }

    public int StudentId { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Score { get; set; }

    public bool? Passed { get; set; }

    public DateTime? AttemptedAt { get; set; }

    [ForeignKey("QuizId")]
    [InverseProperty("QuizAttempts")]
    public virtual Quiz Quiz { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("QuizAttempts")]
    public virtual User Student { get; set; } = null!;
}
