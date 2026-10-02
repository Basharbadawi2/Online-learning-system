using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Question")]
public partial class Question
{
    [Key]
    public int QuestionId { get; set; }

    public int QuizId { get; set; }

    public string QuestionText { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();

    [ForeignKey("QuizId")]
    [InverseProperty("Questions")]
    public virtual Quiz Quiz { get; set; } = null!;
}
