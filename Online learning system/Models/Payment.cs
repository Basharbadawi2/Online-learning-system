using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Payment")]
public partial class Payment
{
    [Key]
    public int PaymentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [StringLength(50)]
    public string PaymentStatus { get; set; } = null!;

    public DateTime? PaidAt { get; set; }

    [StringLength(255)]
    public string? TransactionReference { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Payments")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Payments")]
    public virtual User Student { get; set; } = null!;
}
