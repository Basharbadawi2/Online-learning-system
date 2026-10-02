using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Online_learning_system.Models;

[Table("Certificate")]
[Index("EnrollmentId", Name = "UQ__Certific__7F68771AE43BEA71", IsUnique = true)]
[Index("CertificateNumber", Name = "UQ__Certific__E384CE0FF1658214", IsUnique = true)]
public partial class Certificate
{
    [Key]
    public int CertificateId { get; set; }

    public int EnrollmentId { get; set; }

    [StringLength(100)]
    public string CertificateNumber { get; set; } = null!;

    public DateTime? IssuedAt { get; set; }

    [ForeignKey("EnrollmentId")]
    [InverseProperty("Certificate")]
    public virtual Enrollment Enrollment { get; set; } = null!;
}
