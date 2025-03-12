using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UberApi.Models.EntityFramework;

[Table("otp")]
public partial class Otp
{
    [Key]
    [Column("idotp")]
    public int Idotp { get; set; }

    [Column("idclient")]
    public int Idclient { get; set; }

    [Column("codeotp")]
    [StringLength(6)]
    public string Codeotp { get; set; } = null!;

    [Column("dategeneration", TypeName = "timestamp without time zone")]
    public DateTime Dategeneration { get; set; }

    [Column("dateexpiration", TypeName = "timestamp without time zone")]
    public DateTime Dateexpiration { get; set; }

    [Column("utilise")]
    public bool? Utilise { get; set; }

    [ForeignKey("Idclient")]
    [InverseProperty("Otps")]
    public virtual Client IdclientNavigation { get; set; } = null!;
}
