using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("AnswerOption")]
public partial class AnswerOption
{
    [Key]
    public int AnswerOptionId { get; set; }

    public int QuestionId { get; set; }

    public string OptionText { get; set; } = null!;

    public bool IsCorrect { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("AnswerOptions")]
    public virtual Question Question { get; set; } = null!;
}
